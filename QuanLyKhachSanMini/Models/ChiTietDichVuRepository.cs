namespace QuanLyKhachSanMini.Models
{
    public class ChiTietDichVuRepository
    {
        private const string TenFile = "ChiTietDichVu.txt";

        public List<ChiTietDichVu> LayTatCa() => DuLieu.DocDong(TenFile)
            .Select(ChiTietDichVu.FromLine).Where(x => x != null).Select(x => x!).ToList();

        public List<ChiTietDichVu> LayTheoDatPhong(string maDatPhong) =>
            LayTatCa().Where(x => x.MaDatPhong.Equals(maDatPhong, StringComparison.OrdinalIgnoreCase)).ToList();

        public void LuuTatCa(List<ChiTietDichVu> ds) => DuLieu.GhiDong(TenFile, ds.Select(x => x.ToLine()));

        public string SinhMaMoi()
        {
            int max = LayTatCa()
                .Select(x => x.MaCT.StartsWith("CT", StringComparison.OrdinalIgnoreCase)
                    && int.TryParse(x.MaCT[2..], out int n) ? n : 0)
                .DefaultIfEmpty(0).Max();
            return $"CT{max + 1:0000}";
        }
    }
}
