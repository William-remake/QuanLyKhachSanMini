using System.Globalization;
using System.Text;

namespace QuanLyKhachSanMini.Models
{
    /// <summary>
    /// Lớp truy cập dữ liệu dùng chung. Tất cả form/repository đều đọc ghi cùng thư mục
    /// Data cạnh file chạy, tránh trường hợp mỗi form dùng một đường dẫn tương đối khác nhau.
    /// </summary>
    public static class DuLieu
    {
        private static readonly Encoding Utf8 = new UTF8Encoding(false);
        private static readonly object SyncRoot = new();

        public static string ThuMucData
        {
            get
            {
                string dir = Path.Combine(AppContext.BaseDirectory, "Data");
                Directory.CreateDirectory(dir);
                return dir;
            }
        }

        public static string LayDuongDanData(string tenFile) => Path.Combine(ThuMucData, tenFile);

        public static List<string> DocDong(string tenFile)
        {
            string path = LayDuongDanData(tenFile);
            if (!File.Exists(path)) return new List<string>();
            return File.ReadAllLines(path, Encoding.UTF8)
                .Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        }

        public static void GhiDong(string tenFile, IEnumerable<string> dong)
        {
            lock (SyncRoot)
            {
                File.WriteAllLines(LayDuongDanData(tenFile), dong, Utf8);
            }
        }

        /// <summary>
        /// Chạy một thao tác cập nhật nhiều file như một giao dịch: nếu một bước lỗi,
        /// các file đã thay đổi sẽ được khôi phục về nội dung trước khi chạy.
        /// tenFile nhận đường dẫn tương đối bên trong thư mục Data.
        /// </summary>
        public static void ThucHienGiaoDich(Action thaoTac, params string[] tenFileLienQuan)
        {
            ArgumentNullException.ThrowIfNull(thaoTac);
            lock (SyncRoot)
            {
                string thuMucGoc = Path.GetFullPath(ThuMucData) + Path.DirectorySeparatorChar;
                var saoLuu = new Dictionary<string, (bool TonTai, byte[] NoiDung)>(StringComparer.OrdinalIgnoreCase);

                foreach (string tenFile in tenFileLienQuan.Distinct(StringComparer.OrdinalIgnoreCase))
                {
                    string path = Path.GetFullPath(Path.Combine(ThuMucData, tenFile));
                    if (!path.StartsWith(thuMucGoc, StringComparison.OrdinalIgnoreCase))
                        throw new InvalidOperationException("Đường dẫn dữ liệu giao dịch không hợp lệ.");

                    bool tonTai = File.Exists(path);
                    saoLuu[path] = (tonTai, tonTai ? File.ReadAllBytes(path) : Array.Empty<byte>());
                }

                try
                {
                    thaoTac();
                }
                catch (Exception loiGoc)
                {
                    var loiKhoiPhuc = new List<Exception>();
                    foreach (var muc in saoLuu)
                    {
                        try
                        {
                            if (muc.Value.TonTai)
                            {
                                Directory.CreateDirectory(Path.GetDirectoryName(muc.Key)!);
                                File.WriteAllBytes(muc.Key, muc.Value.NoiDung);
                            }
                            else if (File.Exists(muc.Key))
                            {
                                File.Delete(muc.Key);
                            }
                        }
                        catch (Exception ex)
                        {
                            loiKhoiPhuc.Add(ex);
                        }
                    }

                    if (loiKhoiPhuc.Count > 0)
                        throw new AggregateException("Giao dịch thất bại và có lỗi khi khôi phục dữ liệu.",
                            new[] { loiGoc }.Concat(loiKhoiPhuc));
                    throw;
                }
            }
        }

        private static bool TryParseMoney(string value, out decimal money)
        {
            string text = value.Trim();
            // Dữ liệu cũ trên Windows tiếng Việt có thể dùng dấu phẩy thập phân;
            // dữ liệu mới luôn ghi theo InvariantCulture.
            if (text.Contains(',') && !text.Contains('.'))
            {
                if (decimal.TryParse(text, NumberStyles.Number, CultureInfo.CurrentCulture, out money)) return true;
            }
            return decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out money)
                || decimal.TryParse(text, NumberStyles.Number, CultureInfo.CurrentCulture, out money);
        }

        // -------------------- KHÁCH HÀNG --------------------
        public static List<KhachHang> DocKhach()
        {
            var ds = new List<KhachHang>();
            foreach (string line in DocDong("Khach.txt"))
            {
                string[] p = line.Split('|');
                if (p.Length < 3) continue;
                ds.Add(new KhachHang
                {
                    CCCD = p[0].Trim(),
                    HoTen = p[1].Trim(),
                    SDT = p[2].Trim()
                });
            }
            return ds;
        }

        public static void GhiKhach(List<KhachHang> ds)
        {
            GhiDong("Khach.txt", ds.Select(k =>
                $"{LamSach(k.CCCD)}|{LamSach(k.HoTen)}|{LamSach(k.SDT)}"));
        }

        // -------------------- ĐẶT PHÒNG --------------------
        public static List<DatPhong> DocDatPhong()
        {
            var ds = new List<DatPhong>();
            foreach (string line in DocDong("DatPhong.txt"))
            {
                string[] p = line.Split('|');
                if (p.Length < 6) continue;

                if (!DateTime.TryParseExact(p[3].Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime den)
                    || !DateTime.TryParseExact(p[4].Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime di))
                    continue;

                decimal giaPhong = p.Length >= 7 && TryParseMoney(p[6], out decimal giaDaLuu)
                    ? giaDaLuu : LayGiaPhongTheoPhong(p[2].Trim());
                ds.Add(new DatPhong
                {
                    Ma = p[0].Trim(),
                    CCCD = p[1].Trim(),
                    SoPhong = p[2].Trim(),
                    NgayDen = den,
                    NgayDi = di,
                    TrangThai = ChuanHoaTrangThaiDatPhong(p[5]),
                    GiaPhong = giaPhong
                });
            }
            return ds;
        }

        public static void GhiDatPhong(List<DatPhong> ds)
        {
            GhiDong("DatPhong.txt", ds.Select(d =>
                $"{LamSach(d.Ma)}|{LamSach(d.CCCD)}|{LamSach(d.SoPhong)}|{d.NgayDen:yyyy-MM-dd}|{d.NgayDi:yyyy-MM-dd}|{LamSach(ChuanHoaTrangThaiDatPhong(d.TrangThai))}|{d.GiaPhong.ToString(CultureInfo.InvariantCulture)}"));
        }

        public static decimal LayGiaPhongTheoPhong(string soPhong)
        {
            var phong = DocPhong().FirstOrDefault(p =>
                p.SoPhong.Equals(soPhong, StringComparison.OrdinalIgnoreCase));
            if (string.IsNullOrWhiteSpace(phong.SoPhong)) return 0;
            return DocLoaiPhong().FirstOrDefault(lp =>
                lp.TenLoai.Equals(phong.Loai, StringComparison.OrdinalIgnoreCase))?.Gia ?? 0;
        }

        public static string SinhMaDatPhong()
        {
            int max = DocDatPhong()
                .Select(d => d.Ma.StartsWith("DP", StringComparison.OrdinalIgnoreCase)
                    && int.TryParse(d.Ma[2..], out int n) ? n : 0)
                .DefaultIfEmpty(0).Max();
            return $"DP{max + 1:000}";
        }

        // -------------------- PHÒNG --------------------
        public static List<(string SoPhong, string Loai, string Tang, string TrangThai)> DocPhong()
        {
            var ds = new List<(string SoPhong, string Loai, string Tang, string TrangThai)>();
            foreach (string line in DocDong("Phong.txt"))
            {
                string[] p = line.Split('|');
                if (p.Length < 4) continue;
                ds.Add((p[0].Trim(), p[1].Trim(), p[2].Trim(), ChuanHoaTrangThaiPhong(p[3])));
            }
            return ds;
        }

        public static void GhiPhong(IEnumerable<(string SoPhong, string Loai, string Tang, string TrangThai)> ds)
        {
            GhiDong("Phong.txt", ds.Select(p =>
                $"{LamSach(p.SoPhong)}|{LamSach(p.Loai)}|{LamSach(p.Tang)}|{LamSach(ChuanHoaTrangThaiPhong(p.TrangThai))}"));
        }

        public static bool CapNhatTrangThaiPhong(string soPhong, string trangThaiMoi)
        {
            var ds = DocPhong();
            int index = ds.FindIndex(p => p.SoPhong.Equals(soPhong, StringComparison.OrdinalIgnoreCase));
            if (index < 0) return false;
            ds[index] = (ds[index].SoPhong, ds[index].Loai, ds[index].Tang, ChuanHoaTrangThaiPhong(trangThaiMoi));
            GhiPhong(ds);
            return true;
        }

        /// <summary>Nhận phòng và cập nhật hồ sơ đặt phòng + trạng thái phòng trong cùng giao dịch.</summary>
        public static DatPhong NhanPhong(string maDatPhong)
        {
            DatPhong? ketQua = null;
            ThucHienGiaoDich(() =>
            {
                var dsDat = DocDatPhong();
                var booking = dsDat.FirstOrDefault(d =>
                    d.Ma.Equals(maDatPhong, StringComparison.OrdinalIgnoreCase));
                if (booking == null || !booking.TrangThai.Equals("DaDat", StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException("Chỉ nhận phòng được với đặt phòng ở trạng thái Đã đặt.");
                if (DateTime.Today < booking.NgayDen.Date)
                    throw new InvalidOperationException($"Chưa đến ngày nhận phòng ({booking.NgayDen:dd/MM/yyyy}).");
                if (DateTime.Today >= booking.NgayDi.Date)
                    throw new InvalidOperationException("Đặt phòng này đã quá hạn.");

                var dsPhong = DocPhong();
                var phong = dsPhong.FirstOrDefault(p =>
                    p.SoPhong.Equals(booking.SoPhong, StringComparison.OrdinalIgnoreCase));
                if (string.IsNullOrWhiteSpace(phong.SoPhong))
                    throw new InvalidOperationException($"Không tìm thấy phòng {booking.SoPhong} trong Phong.txt.");
                if (phong.TrangThai.Equals("Đang dọn", StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException("Phòng đang dọn. Hãy chuyển phòng về Trống trước khi nhận khách.");

                bool trungLich = dsDat.Any(d => !d.Ma.Equals(booking.Ma, StringComparison.OrdinalIgnoreCase)
                    && d.SoPhong.Equals(booking.SoPhong, StringComparison.OrdinalIgnoreCase)
                    && (d.TrangThai.Equals("DaDat", StringComparison.OrdinalIgnoreCase) || LaTrangThaiDangLuuTru(d.TrangThai))
                    && booking.NgayDen < d.NgayDi && d.NgayDen < booking.NgayDi);
                if (trungLich)
                    throw new InvalidOperationException("Phòng có một lượt đặt/lưu trú khác trùng thời gian. Vui lòng kiểm tra lịch phòng.");

                booking.TrangThai = "DaNhan";
                GhiDatPhong(dsDat);
                if (!CapNhatTrangThaiPhong(booking.SoPhong, "Có khách"))
                    throw new InvalidOperationException($"Không cập nhật được trạng thái phòng {booking.SoPhong}.");
                ketQua = booking;
            }, "DatPhong.txt", "Phong.txt");

            return ketQua ?? throw new InvalidOperationException("Không nhận được phòng.");
        }

        public static bool PhongDangDuocSuDung(string soPhong)
        {
            return DocDatPhong().Any(d => d.SoPhong.Equals(soPhong, StringComparison.OrdinalIgnoreCase)
                && (d.TrangThai == "DaDat" || LaTrangThaiDangLuuTru(d.TrangThai)));
        }

        /// <summary>
        /// Đồng bộ trạng thái vật lý phòng theo lượt nhận phòng.
        /// Đặt trước không làm phòng thành Có khách; lượt DaNhan/DangO thì bắt buộc là Có khách.
        /// Trạng thái Đang dọn được giữ nguyên cho đến khi nhân viên chủ động chuyển về Trống.
        /// </summary>
        public static void DongBoTrangThaiPhong()
        {
            var bookings = DocDatPhong();
            var rooms = DocPhong();
            var phongDangO = bookings
                .Where(d => LaTrangThaiDangLuuTru(d.TrangThai))
                .Select(d => d.SoPhong)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            bool changed = false;
            for (int i = 0; i < rooms.Count; i++)
            {
                var p = rooms[i];
                string trangThaiMoi = p.TrangThai;
                if (phongDangO.Contains(p.SoPhong))
                    trangThaiMoi = "Có khách";
                else if (p.TrangThai.Equals("Có khách", StringComparison.OrdinalIgnoreCase))
                    trangThaiMoi = "Trống"; // dọn các trạng thái Có khách không có lượt nhận phòng tương ứng.

                if (!p.TrangThai.Equals(trangThaiMoi, StringComparison.OrdinalIgnoreCase))
                {
                    rooms[i] = (p.SoPhong, p.Loai, p.Tang, trangThaiMoi);
                    changed = true;
                }
            }
            if (changed) GhiPhong(rooms);
        }

        // -------------------- LOẠI PHÒNG --------------------
        public static List<LoaiPhong> DocLoaiPhong()
        {
            var ds = new List<LoaiPhong>();
            foreach (string line in DocDong("LoaiPhong.txt"))
            {
                string[] p = line.Split('|');
                if (p.Length < 3 || !TryParseMoney(p[2], out decimal gia)) continue;
                ds.Add(new LoaiPhong
                {
                    MaLoai = p[0].Trim(),
                    TenLoai = p[1].Trim(),
                    Gia = gia
                });
            }
            return ds;
        }

        public static void GhiLoaiPhong(List<LoaiPhong> ds)
        {
            GhiDong("LoaiPhong.txt", ds.Select(x =>
                $"{LamSach(x.MaLoai)}|{LamSach(x.TenLoai)}|{x.Gia.ToString(CultureInfo.InvariantCulture)}"));
        }

        /// <summary>Đổi tên loại phòng đồng thời cập nhật các phòng đang tham chiếu tới tên cũ.</summary>
        public static void CapNhatTenLoaiPhongThamChieu(string tenCu, string tenMoi)
        {
            if (string.Equals(tenCu, tenMoi, StringComparison.OrdinalIgnoreCase)) return;
            var rooms = DocPhong();
            bool changed = false;
            for (int i = 0; i < rooms.Count; i++)
            {
                var p = rooms[i];
                if (p.Loai.Equals(tenCu, StringComparison.OrdinalIgnoreCase))
                {
                    rooms[i] = (p.SoPhong, tenMoi, p.Tang, p.TrangThai);
                    changed = true;
                }
            }
            if (changed) GhiPhong(rooms);
        }

        // -------------------- TRẠNG THÁI / TIỆN ÍCH --------------------
        public static string ChuanHoaTrangThaiDatPhong(string? trangThai)
        {
            string value = (trangThai ?? "").Trim();
            if (value.Equals("DaDat", StringComparison.OrdinalIgnoreCase)
                || value.Equals("Đã đặt", StringComparison.OrdinalIgnoreCase)) return "DaDat";
            if (value.Equals("DaNhan", StringComparison.OrdinalIgnoreCase)
                || value.Equals("DangO", StringComparison.OrdinalIgnoreCase)
                || value.Equals("DangLuuTru", StringComparison.OrdinalIgnoreCase)
                || value.Equals("Đang ở", StringComparison.OrdinalIgnoreCase)
                || value.Equals("Đang lưu trú", StringComparison.OrdinalIgnoreCase)) return "DaNhan";
            if (value.Equals("DaTra", StringComparison.OrdinalIgnoreCase)
                || value.Equals("Đã trả", StringComparison.OrdinalIgnoreCase)) return "DaTra";
            if (value.Equals("DaHuy", StringComparison.OrdinalIgnoreCase)
                || value.Equals("Đã hủy", StringComparison.OrdinalIgnoreCase)
                || value.Equals("Đã huỷ", StringComparison.OrdinalIgnoreCase)) return "DaHuy";
            return value;
        }

        public static bool LaTrangThaiDangLuuTru(string? trangThai) =>
            ChuanHoaTrangThaiDatPhong(trangThai) == "DaNhan";

        public static string ChuanHoaTrangThaiPhong(string? trangThai)
        {
            string value = (trangThai ?? "").Trim();
            if (value.Equals("Trong", StringComparison.OrdinalIgnoreCase)
                || value.Equals("Trống", StringComparison.OrdinalIgnoreCase)) return "Trống";
            if (value.Equals("Co khach", StringComparison.OrdinalIgnoreCase)
                || value.Equals("Có khách", StringComparison.OrdinalIgnoreCase)
                || value.Equals("DangO", StringComparison.OrdinalIgnoreCase)
                || value.Equals("DaNhan", StringComparison.OrdinalIgnoreCase)) return "Có khách";
            if (value.Equals("Dang don", StringComparison.OrdinalIgnoreCase)
                || value.Equals("Đang dọn", StringComparison.OrdinalIgnoreCase)) return "Đang dọn";
            return value;
        }

        private static string LamSach(string? value)
        {
            string s = (value ?? "").Trim();
            return s.Replace("|", "/").Replace("\r", " ").Replace("\n", " ");
        }
    }
}
