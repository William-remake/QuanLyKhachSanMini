using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSanMini.Models
{
    public class ChiTietDichVu
    {
        public string MaCT { get; set; } = "";
        public string MaDatPhong { get; set; } = "";
        public string MaDV { get; set; } = "";
        public string TenDV { get; set; } = "";
        public int SoLuong { get; set; }
        public decimal DonGiaLucDung { get; set; }   // lưu giá tại thời điểm dùng
        public DateTime NgayDung { get; set; }

        public decimal ThanhTien => SoLuong * DonGiaLucDung;

        // MaCT|MaDatPhong|MaDV|TenDV|SoLuong|DonGiaLucDung|NgayDung
        public string ToLine() =>
            $"{MaCT}|{MaDatPhong}|{MaDV}|{TenDV}|{SoLuong}|{DonGiaLucDung}|{NgayDung:yyyy-MM-dd HH:mm}";

        public static ChiTietDichVu? FromLine(string line)
        {
            var p = line.Split('|');
            if (p.Length < 7) return null;
            return new ChiTietDichVu
            {
                MaCT = p[0],
                MaDatPhong = p[1],
                MaDV = p[2],
                TenDV = p[3],
                SoLuong = int.TryParse(p[4], out var sl) ? sl : 0,
                DonGiaLucDung = decimal.TryParse(p[5], out var g) ? g : 0,
                NgayDung = DateTime.TryParse(p[6], out var d) ? d : DateTime.Now
            };
        }
    }
}
