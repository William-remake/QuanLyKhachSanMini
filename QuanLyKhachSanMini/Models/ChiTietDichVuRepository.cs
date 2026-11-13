using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSanMini.Models
{
    public class ChiTietDichVuRepository
    {
        private readonly string _path;

        public ChiTietDichVuRepository()
        {
            var dir = Path.Combine(AppContext.BaseDirectory, "Data");
            Directory.CreateDirectory(dir);
            _path = Path.Combine(dir, "ChiTietDichVu.txt");
            if (!File.Exists(_path)) File.WriteAllText(_path, "", Encoding.UTF8);
        }

        public List<ChiTietDichVu> LayTatCa() =>
            File.ReadAllLines(_path, Encoding.UTF8)
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(ChiTietDichVu.FromLine)
                .Where(x => x != null).Select(x => x!).ToList();

        public List<ChiTietDichVu> LayTheoDatPhong(string maDatPhong) =>
            LayTatCa().Where(x => x.MaDatPhong == maDatPhong).ToList();

        public void LuuTatCa(List<ChiTietDichVu> ds) =>
            File.WriteAllLines(_path, ds.Select(x => x.ToLine()), Encoding.UTF8);

        public string SinhMaMoi()
        {
            int max = 0;
            foreach (var x in LayTatCa())
                if (x.MaCT.StartsWith("CT") && int.TryParse(x.MaCT.Substring(2), out int n) && n > max)
                    max = n;
            return "CT" + (max + 1).ToString("0000");
        }
    }
}
