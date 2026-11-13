using System.Globalization;

namespace QuanLyKhachSanMini.Models
{
    public class DichVuRepository
    {
        private const string TenFile = "DichVu.txt";

        public List<DichVu> LayTatCa() => DuLieu.DocDong(TenFile)
            .Select(DichVu.FromLine).Where(x => x != null).Select(x => x!).ToList();

        public void LuuTatCa(List<DichVu> ds) => DuLieu.GhiDong(TenFile, ds.Select(x => x.ToLine()));

        public string SinhMaMoi()
        {
            int max = LayTatCa()
                .Select(d => d.MaDV.StartsWith("DV", StringComparison.OrdinalIgnoreCase)
                    && int.TryParse(d.MaDV[2..], out int n) ? n : 0)
                .DefaultIfEmpty(0).Max();
            return $"DV{max + 1:000}";
        }
    }
}
