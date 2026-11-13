using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }

    public class KetQuaTinhTien
    {
        public LuotO Luot { get; set; } = new();
        public DateTime ThoiDiemTra { get; set; }
        public decimal GiaPhong { get; set; }
        public int SoDem { get; set; }
        public decimal TienPhong => SoDem * GiaPhong;
        public List<ChiTietDichVu> DichVu { get; set; } = new();
        public decimal TienDV => DichVu.Sum(x => x.ThanhTien);
        public decimal PhuThu { get; set; }
        public decimal Tong => TienPhong + TienDV + PhuThu;
    }

    public class ThongKeThang
    {
        public decimal DoanhThu { get; set; }
        public double CongSuat { get; set; }   // phần trăm
        public List<HoaDon> HoaDon { get; set; } = new();
    }

    public class HoaDonService
    {
        // Các giá trị TrangThai nghĩa là "đang lưu trú" (khớp với DichVuForm)
        public static readonly string[] TrangThaiDangO = { "DangO", "DaNhan", "DangLuuTru" };
        private const string TrangThaiDaTra = "DaTra";
        private const string PhongDangDon = "Đang dọn";

        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;
        private readonly ChiTietDichVuRepository _ctRepo = new();

        // ---------- Cấu hình App.config ----------
        public static int GioTraPhong =>
            int.TryParse(ConfigurationManager.AppSettings["GioTraPhong"], out int g) ? g : 12;

        public static decimal PhuThuTraTre =>
            decimal.TryParse(ConfigurationManager.AppSettings["PhuThuTraTre"], out decimal v) ? v : 200000;

        // ---------- Đọc/ghi file ----------
        private static string Path_(string file)
        {
            var dir = Path.Combine(AppContext.BaseDirectory, "Data");
            Directory.CreateDirectory(dir);
            return Path.Combine(dir, file);
        }

        private static List<string> DocDong(string file)
        {
            var path = Path_(file);
            if (!File.Exists(path)) return new List<string>();
            return File.ReadAllLines(path, Encoding.UTF8)
                       .Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
        }

        private static void GhiDong(string file, IEnumerable<string> lines) =>
            File.WriteAllLines(Path_(file), lines, Encoding.UTF8);

        private static DateTime ParseNgay(string s) =>
            DateTime.TryParse(s.Trim(), Inv, DateTimeStyles.None, out var d) ? d : DateTime.Today;

        // ---------- Tra cứu ----------
        private string TimTenKhach(string cccd)
        {
            foreach (var line in DocDong("Khach.txt"))
            {
                var p = line.Split('|');
                // GIẢ ĐỊNH: cột 0 = CCCD, cột 1 = họ tên (chỉnh nếu Khach.txt khác)
                if (p.Length >= 2 && p[0].Trim() == cccd) return p[1].Trim();
            }
            return cccd;
        }

        // MaPhong -> Phong.txt (tên loại) -> LoaiPhong.txt (giá), nối bằng TÊN loại
        public decimal LayGiaPhong(string maPhong)
        {
            string tenLoai = "";
            foreach (var line in DocDong("Phong.txt"))
            {
                var p = line.Split('|');
                if (p.Length >= 2 && p[0].Trim() == maPhong) { tenLoai = p[1].Trim(); break; }
            }
            foreach (var line in DocDong("LoaiPhong.txt"))
            {
                var p = line.Split('|');
                if (p.Length >= 3 && p[1].Trim().Equals(tenLoai, StringComparison.OrdinalIgnoreCase))
                    return decimal.TryParse(p[2].Trim(), out var g) ? g : 0;
            }
            return 0;
        }

        public List<LuotO> LayLuotDangO()
        {
            var ds = new List<LuotO>();
            foreach (var line in DocDong("DatPhong.txt"))
            {
                var p = line.Split('|');
                if (p.Length < 6) continue;
                if (!TrangThaiDangO.Contains(p[5].Trim(), StringComparer.OrdinalIgnoreCase)) continue;
                ds.Add(new LuotO
                {
                    MaDatPhong = p[0].Trim(),
                    CCCD = p[1].Trim(),
                    TenKhach = TimTenKhach(p[1].Trim()),
                    MaPhong = p[2].Trim(),
                    NgayDen = ParseNgay(p[3]),
                    NgayDiDuKien = ParseNgay(p[4])
                });
            }
            return ds;
        }

        // ---------- Tính tiền ----------
        public KetQuaTinhTien TinhTien(LuotO luot, DateTime thoiDiemTra)
        {
            var kq = new KetQuaTinhTien
            {
                Luot = luot,
                ThoiDiemTra = thoiDiemTra,
                GiaPhong = LayGiaPhong(luot.MaPhong),
                SoDem = Math.Max(1, (thoiDiemTra.Date - luot.NgayDen.Date).Days),
                DichVu = _ctRepo.LayTheoDatPhong(luot.MaDatPhong).OrderBy(x => x.NgayDung).ToList()
            };
            if (thoiDiemTra.TimeOfDay > TimeSpan.FromHours(GioTraPhong))
                kq.PhuThu = PhuThuTraTre;
            return kq;
        }

        public string TaoNoiDung(KetQuaTinhTien kq, string maHD = "(chưa lập)")
        {
            var sb = new StringBuilder();
            string line = new string('-', 46);
            sb.AppendLine("HOTEL MINI - HÓA ĐƠN THANH TOÁN");
            sb.AppendLine(line);
            sb.AppendLine($"Mã hóa đơn : {maHD}");
            sb.AppendLine($"Mã đặt phòng: {kq.Luot.MaDatPhong}");
            sb.AppendLine($"Khách hàng : {kq.Luot.TenKhach}");
            sb.AppendLine($"Phòng      : {kq.Luot.MaPhong}");
            sb.AppendLine($"Ngày đến   : {kq.Luot.NgayDen:dd/MM/yyyy}");
            sb.AppendLine($"Thời điểm trả: {kq.ThoiDiemTra:dd/MM/yyyy HH:mm}");
            sb.AppendLine(line);
            sb.AppendLine($"Tiền phòng : {kq.SoDem} đêm x {kq.GiaPhong:N0} = {kq.TienPhong:N0} đ");
            sb.AppendLine("Dịch vụ:");
            if (kq.DichVu.Count == 0) sb.AppendLine("  (không có)");
            foreach (var d in kq.DichVu)
                sb.AppendLine($"  {d.TenDV} x{d.SoLuong} @ {d.DonGiaLucDung:N0} = {d.ThanhTien:N0} đ");
            sb.AppendLine($"Tiền dịch vụ: {kq.TienDV:N0} đ");
            sb.AppendLine($"Phụ thu trả trễ (sau {GioTraPhong}:00): {kq.PhuThu:N0} đ");
            sb.AppendLine(line);
            sb.AppendLine($"TỔNG CỘNG  : {kq.Tong:N0} đ");
            return sb.ToString();
        }

        // ---------- Trả phòng ----------
        private string SinhMaHD()
        {
            int max = 0;
            foreach (var l in DocDong("HoaDon.txt"))
            {
                var ma = l.Split('|')[0];
                if (ma.StartsWith("HD") && int.TryParse(ma.Substring(2), out int n) && n > max) max = n;
            }
            return "HD" + (max + 1).ToString("0000");
        }

        public HoaDon TraPhong(KetQuaTinhTien kq)
        {
            var hd = new HoaDon
            {
                MaHD = SinhMaHD(),
                MaDatPhong = kq.Luot.MaDatPhong,
                TenKhach = kq.Luot.TenKhach,
                MaPhong = kq.Luot.MaPhong,
                NgayDen = kq.Luot.NgayDen,
                NgayTra = kq.ThoiDiemTra,
                SoDem = kq.SoDem,
                TienPhong = kq.TienPhong,
                TienDV = kq.TienDV,
                PhuThu = kq.PhuThu,
                Tong = kq.Tong,
                NgayLap = DateTime.Now
            };

            var lines = DocDong("HoaDon.txt");
            lines.Add(hd.ToLine());
            GhiDong("HoaDon.txt", lines);

            CapNhatCot("DatPhong.txt", kq.Luot.MaDatPhong, 5, TrangThaiDaTra);
            CapNhatCot("Phong.txt", kq.Luot.MaPhong, 3, PhongDangDon);
            return hd;
        }

        // Sửa 1 cột của dòng có cột 0 = khóa, giữ nguyên các cột khác
        private void CapNhatCot(string file, string khoa, int cot, string giaTri)
        {
            var lines = DocDong(file);
            for (int i = 0; i < lines.Count; i++)
            {
                var p = lines[i].Split('|');
                if (p.Length > cot && p[0].Trim() == khoa)
                {
                    p[cot] = giaTri;
                    lines[i] = string.Join("|", p);
                }
            }
            GhiDong(file, lines);
        }

        // ---------- Thống kê ----------
        public List<HoaDon> LayHoaDon() =>
            DocDong("HoaDon.txt").Select(HoaDon.FromLine).Where(h => h != null).Select(h => h!).ToList();

        public int TongSoPhong() => DocDong("Phong.txt").Count;

        public ThongKeThang ThongKe(int thang, int nam)
        {
            // Doanh thu: hóa đơn lập trong tháng
            var hdThang = LayHoaDon()
                .Where(h => h.NgayLap.Month == thang && h.NgayLap.Year == nam)
                .OrderBy(h => h.NgayLap).ToList();

            // Công suất: đêm phòng đã bán rơi vào tháng / (số phòng x số ngày trong tháng)
            int dem = 0;
            foreach (var h in LayHoaDon())
                for (int i = 0; i < h.SoDem; i++)
                {
                    var ngay = h.NgayDen.Date.AddDays(i);
                    if (ngay.Month == thang && ngay.Year == nam) dem++;
                }
            int tongPhong = TongSoPhong();
            int ngayTrongThang = DateTime.DaysInMonth(nam, thang);
            double congSuat = tongPhong == 0 ? 0 : dem * 100.0 / (tongPhong * ngayTrongThang);

            return new ThongKeThang
            {
                DoanhThu = hdThang.Sum(h => h.Tong),
                CongSuat = congSuat,
                HoaDon = hdThang
            };
        }

        // ---------- Dùng cho Dashboard ----------
        public int DemPhongCoKhach() =>
            DocDong("Phong.txt").Count(l =>
            {
                var p = l.Split('|');
                return p.Length >= 4 && p[3].Trim().Equals("Có khách", StringComparison.OrdinalIgnoreCase);
            });
    }
}
