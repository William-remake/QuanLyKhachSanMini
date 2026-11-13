using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSanMini.Models
{
    public class DichVuRepository
    {
        private readonly string _path;

        public DichVuRepository()
        {
            var dir = Path.Combine(AppContext.BaseDirectory, "Data");
            Directory.CreateDirectory(dir);
            _path = Path.Combine(dir, "DichVu.txt");
            if (!File.Exists(_path))
                File.WriteAllText(_path, "", Encoding.UTF8);
        }

        public List<DichVu> LayTatCa()
        {
            return File.ReadAllLines(_path, Encoding.UTF8)
                       .Where(l => !string.IsNullOrWhiteSpace(l))
                       .Select(DichVu.FromLine)
                       .Where(d => d != null)
                       .Select(d => d!)
                       .ToList();
        }

        public void LuuTatCa(List<DichVu> ds)
        {
            File.WriteAllLines(_path, ds.Select(d => d.ToLine()), Encoding.UTF8);
        }

        public string SinhMaMoi()
        {
            var ds = LayTatCa();
            int max = 0;
            foreach (var d in ds)
                if (d.MaDV.StartsWith("DV") && int.TryParse(d.MaDV.Substring(2), out int n) && n > max)
                    max = n;
            return "DV" + (max + 1).ToString("000");
        }
    }
}
