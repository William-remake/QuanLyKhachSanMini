using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSanMini.Models
{
    public class LuotItem
    {
        public string MaDatPhong { get; set; } = "";
        public string HienThi { get; set; } = "";
        public override string ToString() => HienThi;
    }
}
