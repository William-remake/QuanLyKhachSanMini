using System.Globalization;

namespace QuanLyKhachSanMini.Models
{
    public class HoaDon
    {
        public string MaHD { get; set; } = "";
        public string MaDatPhong { get; set; } = "";
        public string TenKhach { get; set; } = "";
        public string CCCD { get; set; } = "";
        public string MaPhong { get; set; } = "";
        public DateTime NgayDen { get; set; }
        public DateTime NgayTra { get; set; }
        public int SoDem { get; set; }
        public decimal TienPhong { get; set; }
        public decimal TienDV { get; set; }
        public decimal PhuThu { get; set; }
        public decimal Tong { get; set; }
        public DateTime NgayLap { get; set; }

        private const string Fmt = "yyyy-MM-dd HH:mm";
        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

        // 12 cột cũ vẫn đọc được; cột CCCD thứ 13 được bổ sung cho hóa đơn mới.
        public string ToLine() => string.Join("|", LamSach(MaHD), LamSach(MaDatPhong), LamSach(TenKhach), LamSach(MaPhong),
            NgayDen.ToString(Fmt, Inv), NgayTra.ToString(Fmt, Inv),
            SoDem.ToString(Inv), TienPhong.ToString(Inv), TienDV.ToString(Inv),
            PhuThu.ToString(Inv), Tong.ToString(Inv), NgayLap.ToString(Fmt, Inv), LamSach(CCCD));

        private static string LamSach(string? value) => (value ?? "").Trim()
            .Replace("|", "/").Replace("\r", " ").Replace("\n", " ");

        public static HoaDon? FromLine(string line)
        {
            var p = line.Split('|');
            if (p.Length < 12
                || !DateTime.TryParseExact(p[4], Fmt, Inv, DateTimeStyles.None, out var den)
                || !DateTime.TryParseExact(p[5], Fmt, Inv, DateTimeStyles.None, out var tra)
                || !int.TryParse(p[6], NumberStyles.Integer, Inv, out var dem)
                || !decimal.TryParse(p[7], NumberStyles.Number, Inv, out var tienPhong)
                || !decimal.TryParse(p[8], NumberStyles.Number, Inv, out var tienDV)
                || !decimal.TryParse(p[9], NumberStyles.Number, Inv, out var phuThu)
                || !decimal.TryParse(p[10], NumberStyles.Number, Inv, out var tong)
                || !DateTime.TryParseExact(p[11], Fmt, Inv, DateTimeStyles.None, out var ngayLap))
                return null;

            return new HoaDon
            {
                MaHD = p[0].Trim(), MaDatPhong = p[1].Trim(), TenKhach = p[2].Trim(),
                MaPhong = p[3].Trim(), CCCD = p.Length >= 13 ? p[12].Trim() : "",
                NgayDen = den, NgayTra = tra, SoDem = dem,
                TienPhong = tienPhong, TienDV = tienDV, PhuThu = phuThu,
                Tong = tong, NgayLap = ngayLap
            };
        }
    }
}
