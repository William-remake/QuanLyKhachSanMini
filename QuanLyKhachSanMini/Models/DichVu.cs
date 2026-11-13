using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSanMini.Models
{
    public class DichVu
    {
        public string MaDV { get; set; } = "";
        public string TenDV { get; set; } = "";
        public string DonVi { get; set; } = "";
        public decimal DonGia { get; set; }
        public bool DangApDung { get; set; } = true;

        // Định dạng 1 dòng trong file: MaDV|TenDV|DonVi|DonGia|DangApDung
        public string ToLine() => $"{MaDV}|{TenDV}|{DonVi}|{DonGia}|{(DangApDung ? 1 : 0)}";

        public static DichVu? FromLine(string line)
        {
            var p = line.Split('|');
            if (p.Length < 5) return null;
            return new DichVu
            {
                MaDV = p[0],
                TenDV = p[1],
                DonVi = p[2],
                DonGia = decimal.TryParse(p[3], out var g) ? g : 0,
                DangApDung = p[4] == "1"
            };
        }
    }
}