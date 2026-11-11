using System.Globalization;
using System.Text;

namespace QuanLyKhachSanMini.Models
{
    public static class DuLieu
    {
        static string Dir = Path.Combine(AppContext.BaseDirectory, "Data");
        static string KhachPath = Path.Combine(Dir, "Khach.txt");
        static string DatPhongPath = Path.Combine(Dir, "DatPhong.txt");
        static string PhongPath = Path.Combine(Dir, "Phong.txt");

        public static List<KhachHang> DocKhach()
        {
            var ds = new List<KhachHang>();
            if (!File.Exists(KhachPath)) return ds;

            foreach (var line in File.ReadAllLines(KhachPath, Encoding.UTF8))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var p = line.Split('|');
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
            var lines = ds.Select(k => $"{k.CCCD}|{k.HoTen}|{k.SDT}");
            File.WriteAllLines(KhachPath, lines, Encoding.UTF8);
        }

        public static List<DatPhong> DocDatPhong()
        {
            var ds = new List<DatPhong>();
            if (!File.Exists(DatPhongPath)) return ds;

            foreach (var line in File.ReadAllLines(DatPhongPath, Encoding.UTF8))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var p = line.Split('|');
                if (p.Length < 6) continue;

                if (!DateTime.TryParseExact(p[3].Trim(), "yyyy-MM-dd", null,
                        DateTimeStyles.None, out var den)) continue;
                if (!DateTime.TryParseExact(p[4].Trim(), "yyyy-MM-dd", null,
                        DateTimeStyles.None, out var di)) continue;

                ds.Add(new DatPhong
                {
                    Ma = p[0].Trim(),
                    CCCD = p[1].Trim(),
                    SoPhong = p[2].Trim(),
                    NgayDen = den,
                    NgayDi = di,
                    TrangThai = p[5].Trim()
                });
            }
            return ds;
        }

        public static void GhiDatPhong(List<DatPhong> ds)
        {
            var lines = ds.Select(d =>
                $"{d.Ma}|{d.CCCD}|{d.SoPhong}|{d.NgayDen:yyyy-MM-dd}|{d.NgayDi:yyyy-MM-dd}|{d.TrangThai}");
            File.WriteAllLines(DatPhongPath, lines, Encoding.UTF8);
        }

        // Đọc phòng của SV1 (chỉ đọc, không ghi)
        public static List<(string SoPhong, string Loai, string Tang, string TrangThai)> DocPhong()
        {
            var ds = new List<(string SoPhong, string Loai, string Tang, string TrangThai)>();
            if (!File.Exists(PhongPath)) return ds;

            foreach (var line in File.ReadAllLines(PhongPath, Encoding.UTF8))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var p = line.Split('|');
                if (p.Length < 4) continue;
                ds.Add((p[0].Trim(), p[1].Trim(), p[2].Trim(), p[3].Trim()));
            }
            return ds;
        }
    }
}