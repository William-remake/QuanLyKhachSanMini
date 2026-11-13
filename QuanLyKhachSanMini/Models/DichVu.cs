using System.Globalization;

namespace QuanLyKhachSanMini.Models
{
    public class DichVu
    {
        public string MaDV { get; set; } = "";
        public string TenDV { get; set; } = "";
        public string DonVi { get; set; } = "";
        public decimal DonGia { get; set; }
        public bool DangApDung { get; set; } = true;

        // MaDV|TenDV|DonVi|DonGia|DangApDung
        public string ToLine() => string.Join("|", LamSach(MaDV), LamSach(TenDV), LamSach(DonVi),
            DonGia.ToString(CultureInfo.InvariantCulture), DangApDung ? "1" : "0");

        private static string LamSach(string? value) => (value ?? "").Trim()
            .Replace("|", "/").Replace("\r", " ").Replace("\n", " ");

        public static DichVu? FromLine(string line)
        {
            var p = line.Split('|');
            if (p.Length < 5) return null;
            string giaText = p[3].Trim();
            decimal gia;
            bool parsed;
            if (giaText.Contains(',') && !giaText.Contains('.'))
                parsed = decimal.TryParse(giaText, NumberStyles.Number, CultureInfo.CurrentCulture, out gia);
            else
                parsed = decimal.TryParse(giaText, NumberStyles.Number, CultureInfo.InvariantCulture, out gia);
            if (!parsed && !decimal.TryParse(giaText, NumberStyles.Number, CultureInfo.CurrentCulture, out gia)) return null;
            return new DichVu
            {
                MaDV = p[0].Trim(), TenDV = p[1].Trim(), DonVi = p[2].Trim(),
                DonGia = gia, DangApDung = p[4].Trim() == "1"
            };
        }
    }
}
