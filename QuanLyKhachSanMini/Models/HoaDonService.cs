using System.Configuration;
using System.Globalization;
using System.Text;

namespace QuanLyKhachSanMini.Models
{
    public class LuotO
    {
        public string MaDatPhong { get; set; } = "";
        public string CCCD { get; set; } = "";
        public string TenKhach { get; set; } = "";
        public string MaPhong { get; set; } = "";
        public DateTime NgayDen { get; set; }
        public DateTime NgayDiDuKien { get; set; }
        public decimal GiaPhong { get; set; }
    }

    public class KetQuaTinhTien
    {
        public LuotO Luot { get; set; } = new();
        public DateTime ThoiDiemTra { get; set; }
        public decimal GiaPhong { get; set; }
        public int SoDem { get; set; }
        public decimal? TienPhongDaLuu { get; set; }
        public decimal TienPhong => TienPhongDaLuu ?? (SoDem * GiaPhong);
        public List<ChiTietDichVu> DichVu { get; set; } = new();
        public decimal TienDV => DichVu.Sum(x => x.ThanhTien);
        public decimal PhuThu { get; set; }
        public decimal Tong => TienPhong + TienDV + PhuThu;
    }

    public class ThongKeThang
    {
        public decimal DoanhThu { get; set; }
        public double CongSuat { get; set; }
        public List<HoaDon> HoaDon { get; set; } = new();
    }

    public class HoaDonService
    {
        public static readonly string[] TrangThaiDangO = { "DangO", "DaNhan", "DangLuuTru" };
        private const string TrangThaiDaTra = "DaTra";
        private const string PhongDangDon = "Đang dọn";

        private readonly ChiTietDichVuRepository _ctRepo = new();
        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

        // Đọc giá trị từ App.config, hỗ trợ cả key cũ và key tên tiếng Anh.
        public static int GioTraPhong
        {
            get
            {
                string? text = ConfigurationManager.AppSettings["GioTraPhong"]
                    ?? ConfigurationManager.AppSettings["LateCheckoutTime"];
                if (int.TryParse(text, out int gio)) return Math.Clamp(gio, 0, 23);
                if (TimeSpan.TryParse(text, CultureInfo.InvariantCulture, out var time))
                    return Math.Clamp(time.Hours, 0, 23);
                return 12;
            }
        }

        public static decimal PhuThuTraTre
        {
            get
            {
                string? text = ConfigurationManager.AppSettings["PhuThuTraTre"]
                    ?? ConfigurationManager.AppSettings["LateCheckoutFee"];
                if (decimal.TryParse(text, NumberStyles.Number, Inv, out var fee)) return Math.Max(0, fee);
                if (decimal.TryParse(text, NumberStyles.Number, CultureInfo.CurrentCulture, out fee)) return Math.Max(0, fee);
                return 200000m;
            }
        }

        private static string TimTenKhach(string cccd) =>
            DuLieu.DocKhach().FirstOrDefault(k => k.CCCD.Equals(cccd, StringComparison.OrdinalIgnoreCase))?.HoTen ?? cccd;

        public decimal LayGiaPhong(string maPhong) => DuLieu.LayGiaPhongTheoPhong(maPhong);

        public List<LuotO> LayLuotDangO()
        {
            var ds = new List<LuotO>();
            foreach (var d in DuLieu.DocDatPhong().Where(x => DuLieu.LaTrangThaiDangLuuTru(x.TrangThai)))
            {
                ds.Add(new LuotO
                {
                    MaDatPhong = d.Ma,
                    CCCD = d.CCCD,
                    TenKhach = TimTenKhach(d.CCCD),
                    MaPhong = d.SoPhong,
                    NgayDen = d.NgayDen,
                    NgayDiDuKien = d.NgayDi,
                    GiaPhong = d.GiaPhong
                });
            }
            return ds;
        }

        public KetQuaTinhTien TinhTien(LuotO luot, DateTime thoiDiemTra)
        {
            if (thoiDiemTra < luot.NgayDen)
                throw new InvalidOperationException("Thời điểm trả phòng không được trước ngày nhận phòng.");
            if (thoiDiemTra > DateTime.Now)
                throw new InvalidOperationException("Không thể trả phòng ở thời điểm trong tương lai.");

            decimal giaPhong = luot.GiaPhong > 0 ? luot.GiaPhong : LayGiaPhong(luot.MaPhong);
            if (giaPhong <= 0)
                throw new InvalidOperationException($"Không tìm thấy giá của loại phòng đang gán cho phòng {luot.MaPhong}. Hãy kiểm tra LoaiPhong.txt và Phong.txt.");

            var kq = new KetQuaTinhTien
            {
                Luot = luot,
                ThoiDiemTra = thoiDiemTra,
                GiaPhong = giaPhong,
                SoDem = Math.Max(1, (thoiDiemTra.Date - luot.NgayDen.Date).Days),
                DichVu = _ctRepo.LayTheoDatPhong(luot.MaDatPhong)
                    .Where(x => x.NgayDung <= thoiDiemTra)
                    .OrderBy(x => x.NgayDung).ToList()
            };

            // Phụ thu chỉ áp dụng khi thời điểm trả sau mốc 12:00 (hoặc giờ cấu hình).
            if (thoiDiemTra.TimeOfDay > TimeSpan.FromHours(GioTraPhong))
                kq.PhuThu = PhuThuTraTre;
            return kq;
        }

        public string TaoNoiDung(KetQuaTinhTien kq, string maHD = "(chưa lập)")
        {
            var sb = new StringBuilder();
            string line = new string('-', 54);
            sb.AppendLine("HOTEL MINI - HÓA ĐƠN THANH TOÁN");
            sb.AppendLine(line);
            sb.AppendLine($"Mã hóa đơn : {maHD}");
            sb.AppendLine($"Mã đặt phòng: {kq.Luot.MaDatPhong}");
            sb.AppendLine($"Khách hàng : {kq.Luot.TenKhach}");
            sb.AppendLine($"CCCD       : {kq.Luot.CCCD}");
            sb.AppendLine($"Phòng      : {kq.Luot.MaPhong}");
            sb.AppendLine($"Ngày đến   : {kq.Luot.NgayDen:dd/MM/yyyy}");
            sb.AppendLine($"Thời điểm trả: {kq.ThoiDiemTra:dd/MM/yyyy HH:mm}");
            sb.AppendLine(line);
            sb.AppendLine($"Tiền phòng ({kq.SoDem} đêm x {kq.GiaPhong:N0}): {kq.TienPhong:N0} đ");
            sb.AppendLine("Dịch vụ:");
            if (kq.DichVu.Count == 0) sb.AppendLine("  (không có)");
            foreach (var d in kq.DichVu)
                sb.AppendLine($"  {d.TenDV} x{d.SoLuong} @ {d.DonGiaLucDung:N0} = {d.ThanhTien:N0} đ");
            sb.AppendLine($"Tiền dịch vụ: {kq.TienDV:N0} đ");
            sb.AppendLine($"Phụ thu trả sau {GioTraPhong:00}:00: {kq.PhuThu:N0} đ");
            sb.AppendLine(line);
            sb.AppendLine($"TỔNG CỘNG: {kq.Tong:N0} đ");
            return sb.ToString();
        }

        public string TaoNoiDung(HoaDon hoaDon)
        {
            var luot = new LuotO
            {
                MaDatPhong = hoaDon.MaDatPhong,
                TenKhach = hoaDon.TenKhach,
                CCCD = hoaDon.CCCD,
                MaPhong = hoaDon.MaPhong,
                NgayDen = hoaDon.NgayDen,
                NgayDiDuKien = hoaDon.NgayTra
            };
            var kq = new KetQuaTinhTien
            {
                Luot = luot,
                ThoiDiemTra = hoaDon.NgayTra,
                SoDem = hoaDon.SoDem,
                GiaPhong = hoaDon.SoDem > 0 ? hoaDon.TienPhong / hoaDon.SoDem : 0,
                TienPhongDaLuu = hoaDon.TienPhong,
                DichVu = _ctRepo.LayTheoDatPhong(hoaDon.MaDatPhong)
                    .Where(x => x.NgayDung <= hoaDon.NgayTra)
                    .OrderBy(x => x.NgayDung).ToList(),
                PhuThu = hoaDon.PhuThu
            };
            return TaoNoiDung(kq, hoaDon.MaHD);
        }

        private static string SinhMaHD()
        {
            int max = DuLieu.DocDong("HoaDon.txt")
                .Select(line => line.Split('|').FirstOrDefault() ?? "")
                .Select(ma => ma.StartsWith("HD", StringComparison.OrdinalIgnoreCase)
                    && int.TryParse(ma[2..], out int n) ? n : 0)
                .DefaultIfEmpty(0).Max();
            return $"HD{max + 1:0000}";
        }

        public HoaDon TraPhong(KetQuaTinhTien kq)
        {
            ArgumentNullException.ThrowIfNull(kq);

            // Mã được sinh từ dữ liệu hiện tại; trong giao dịch sẽ kiểm tra lại để tránh trùng.
            string maHD = SinhMaHD();
            string fileTxtTuongDoi = Path.Combine("HoaDon", maHD + ".txt");
            string fileTxtDayDu = DuLieu.LayDuongDanData(fileTxtTuongDoi);
            HoaDon? hoaDonDaTao = null;

            DuLieu.ThucHienGiaoDich(() =>
            {
                var luotHienTai = LayLuotDangO().FirstOrDefault(x =>
                    x.MaDatPhong.Equals(kq.Luot.MaDatPhong, StringComparison.OrdinalIgnoreCase));
                if (luotHienTai == null)
                    throw new InvalidOperationException("Lượt đặt phòng không còn ở trạng thái đang lưu trú. Vui lòng tải lại danh sách.");

                var datPhong = DuLieu.DocDatPhong();
                var booking = datPhong.FirstOrDefault(d =>
                    d.Ma.Equals(luotHienTai.MaDatPhong, StringComparison.OrdinalIgnoreCase));
                if (booking == null || !DuLieu.LaTrangThaiDangLuuTru(booking.TrangThai))
                    throw new InvalidOperationException("Lượt đặt phòng đã thay đổi trạng thái. Vui lòng tải lại danh sách.");

                if (DuLieu.DocDong("HoaDon.txt").Select(HoaDon.FromLine).Any(h =>
                        h != null && h.MaDatPhong.Equals(booking.Ma, StringComparison.OrdinalIgnoreCase)))
                    throw new InvalidOperationException("Đặt phòng này đã có hóa đơn, không thể lập trùng.");

                if (DuLieu.DocDong("HoaDon.txt").Select(HoaDon.FromLine).Any(h =>
                        h != null && h.MaHD.Equals(maHD, StringComparison.OrdinalIgnoreCase)))
                    throw new InvalidOperationException("Mã hóa đơn vừa được sử dụng ở phiên khác. Vui lòng thao tác trả phòng lại.");

                if (!DuLieu.DocPhong().Any(p => p.SoPhong.Equals(booking.SoPhong, StringComparison.OrdinalIgnoreCase)))
                    throw new InvalidOperationException($"Phòng {booking.SoPhong} không còn tồn tại trong Phong.txt.");

                // Tính lại trong giao dịch để lấy đúng giá và dịch vụ mới nhất, không dùng bản xem trước cũ.
                var ketQuaMoi = TinhTien(luotHienTai, kq.ThoiDiemTra);
                var hd = new HoaDon
                {
                    MaHD = maHD,
                    MaDatPhong = booking.Ma,
                    TenKhach = luotHienTai.TenKhach,
                    CCCD = luotHienTai.CCCD,
                    MaPhong = booking.SoPhong,
                    NgayDen = booking.NgayDen,
                    NgayTra = ketQuaMoi.ThoiDiemTra,
                    SoDem = ketQuaMoi.SoDem,
                    TienPhong = ketQuaMoi.TienPhong,
                    TienDV = ketQuaMoi.TienDV,
                    PhuThu = ketQuaMoi.PhuThu,
                    Tong = ketQuaMoi.Tong,
                    NgayLap = DateTime.Now
                };

                var hoaDonLines = DuLieu.DocDong("HoaDon.txt");
                hoaDonLines.Add(hd.ToLine());
                DuLieu.GhiDong("HoaDon.txt", hoaDonLines);

                booking.TrangThai = TrangThaiDaTra;
                DuLieu.GhiDatPhong(datPhong);
                if (!DuLieu.CapNhatTrangThaiPhong(booking.SoPhong, PhongDangDon))
                    throw new InvalidOperationException($"Không cập nhật được trạng thái phòng {booking.SoPhong}.");

                Directory.CreateDirectory(Path.GetDirectoryName(fileTxtDayDu)!);
                File.WriteAllText(fileTxtDayDu, TaoNoiDung(ketQuaMoi, hd.MaHD), new UTF8Encoding(false));
                hoaDonDaTao = hd;
            }, "HoaDon.txt", "DatPhong.txt", "Phong.txt", fileTxtTuongDoi);

            return hoaDonDaTao ?? throw new InvalidOperationException("Không tạo được hóa đơn.");
        }

        public List<HoaDon> LayHoaDon() => DuLieu.DocDong("HoaDon.txt")
            .Select(HoaDon.FromLine).Where(h => h != null).Select(h => h!).ToList();

        public int TongSoPhong() => DuLieu.DocPhong().Count;

        public ThongKeThang ThongKe(int thang, int nam)
        {
            var hoaDon = LayHoaDon();
            var hdThang = hoaDon
                .Where(h => h.NgayLap.Month == thang && h.NgayLap.Year == nam)
                .OrderBy(h => h.NgayLap).ToList();

            int demPhongDem = 0;
            // Đếm đêm đã thanh toán từ các hóa đơn.
            foreach (var h in hoaDon)
                demPhongDem += DemDemTrongThang(h.NgayDen.Date, h.NgayDen.Date.AddDays(h.SoDem), thang, nam);

            // Bổ sung số đêm đã sử dụng của khách hiện vẫn đang lưu trú trong tháng hiện tại.
            DateTime ngayKetThuc = DateTime.Today;
            foreach (var luot in LayLuotDangO())
            {
                DateTime ketThuc = luot.NgayDiDuKien.Date < ngayKetThuc
                    ? luot.NgayDiDuKien.Date : ngayKetThuc;
                if (ketThuc > luot.NgayDen.Date)
                    demPhongDem += DemDemTrongThang(luot.NgayDen.Date, ketThuc, thang, nam);
            }

            int tongPhong = TongSoPhong();
            int ngayTrongThang = DateTime.DaysInMonth(nam, thang);
            double congSuat = tongPhong == 0 ? 0
                : Math.Min(100.0, demPhongDem * 100.0 / (tongPhong * ngayTrongThang));

            return new ThongKeThang
            {
                DoanhThu = hdThang.Sum(h => h.Tong),
                CongSuat = congSuat,
                HoaDon = hdThang
            };
        }

        private static int DemDemTrongThang(DateTime tuNgay, DateTime denNgayExclusive, int thang, int nam)
        {
            int dem = 0;
            for (DateTime ngay = tuNgay.Date; ngay < denNgayExclusive.Date; ngay = ngay.AddDays(1))
                if (ngay.Month == thang && ngay.Year == nam) dem++;
            return dem;
        }

        public int DemPhongCoKhach() => DuLieu.DocPhong().Count(p =>
            p.TrangThai.Equals("Có khách", StringComparison.OrdinalIgnoreCase));
    }
}
