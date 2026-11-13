using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSanMini.Models
{
    public class HoaDon
    {
        public string MaHD { get; set; } = "";
        public string MaDatPhong { get; set; } = "";
        public string TenKhach { get; set; } = "";
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

        // MaHD|MaDatPhong|TenKhach|MaPhong|NgayDen|NgayTra|SoDem|TienPhong|TienDV|PhuThu|Tong|NgayLap
        public string ToLine() => string.Join("|", MaHD, MaDatPhong, TenKhach, MaPhong,
            NgayDen.ToString(Fmt, Inv), NgayTra.ToString(Fmt, Inv), SoDem,
            TienPhong.ToString(Inv), TienDV.ToString(Inv), PhuThu.ToString(Inv),
            Tong.ToString(Inv), NgayLap.ToString(Fmt, Inv));

        public static HoaDon? FromLine(string line)
        {
            var p = line.Split('|');
            if (p.Length < 12) return null;
            return new HoaDon
            {
                MaHD = p[0],
                MaDatPhong = p[1],
                TenKhach = p[2],
                MaPhong = p[3],
                NgayDen = DateTime.Parse(p[4], Inv),
                NgayTra = DateTime.Parse(p[5], Inv),
                SoDem = int.Parse(p[6]),
                TienPhong = decimal.Parse(p[7], Inv),
                TienDV = decimal.Parse(p[8], Inv),
                PhuThu = decimal.Parse(p[9], Inv),
                Tong = decimal.Parse(p[10], Inv),
                NgayLap = DateTime.Parse(p[11], Inv)
            };
        }
    }
}
