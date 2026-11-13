using System.Globalization;

namespace QuanLyKhachSanMini.Models
{
    public class ChiTietDichVu
    {
        public string MaCT { get; set; } = "";
        public string MaDatPhong { get; set; } = "";
        public string MaDV { get; set; } = "";
        public string TenDV { get; set; } = "";
        public int SoLuong { get; set; }
        public decimal DonGiaLucDung { get; set; }
        public DateTime NgayDung { get; set; }
        public decimal ThanhTien => SoLuong * DonGiaLucDung;

        // MaCT|MaDatPhong|MaDV|TenDV|SoLuong|DonGiaLucDung|NgayDung
        public string ToLine() => string.Join("|", LamSach(MaCT), LamSach(MaDatPhong), LamSach(MaDV), LamSach(TenDV),
            SoLuong.ToString(CultureInfo.InvariantCulture),
            DonGiaLucDung.ToString(CultureInfo.InvariantCulture),
            NgayDung.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture));

        private static string LamSach(string? value) => (value ?? "").Trim()
            .Replace("|", "/").Replace("\r", " ").Replace("\n", " ");

        public static ChiTietDichVu? FromLine(string line)
        {
            var p = line.Split('|');
            if (p.Length < 7
                || !int.TryParse(p[4], NumberStyles.Integer, CultureInfo.InvariantCulture, out int sl)
                || !TryParseGia(p[5], out decimal gia)
                || !DateTime.TryParseExact(p[6], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime ngay)) return null;

            return new ChiTietDichVu
            {
                MaCT = p[0].Trim(), MaDatPhong = p[1].Trim(), MaDV = p[2].Trim(),
                TenDV = p[3].Trim(), SoLuong = sl, DonGiaLucDung = gia, NgayDung = ngay
            };
        }

        private static bool TryParseGia(string text, out decimal gia)
        {
            string value = text.Trim();
            if (value.Contains(',') && !value.Contains('.'))
                return decimal.TryParse(value, NumberStyles.Number, CultureInfo.CurrentCulture, out gia);
            return decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out gia)
                || decimal.TryParse(value, NumberStyles.Number, CultureInfo.CurrentCulture, out gia);
        }
    }
}
