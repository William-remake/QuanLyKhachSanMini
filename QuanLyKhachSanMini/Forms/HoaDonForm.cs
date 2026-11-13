using QuanLyKhachSanMini.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSanMini.Forms
{
    public partial class HoaDonForm : Form
    {
        private readonly HoaDonService _sv = new();
        private KetQuaTinhTien? _ketQua;

        public HoaDonForm()
        {
            InitializeComponent();
        }

        private void lblGhiChuPhuThu_Click(object sender, EventArgs e)
        {

        }

        private void HoaDonForm_Load(object sender, EventArgs e)
        {
            // Lưới đang ở
            dgvDangO.AutoGenerateColumns = false;
            if (dgvDangO.Columns.Count == 0)
            {
                dgvDangO.RowHeadersVisible = false;
                dgvDangO.Columns.Add("colMa", "Mã đặt phòng");
                dgvDangO.Columns.Add("colKhach", "Khách hàng");
                dgvDangO.Columns.Add("colPhong", "Phòng");
                dgvDangO.Columns.Add("colDen", "Ngày đến");
                dgvDangO.Columns.Add("colTra", "Ngày dự kiến trả");
                foreach (DataGridViewColumn c in dgvDangO.Columns)
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Lưới hóa đơn
            if (dgvHoaDon.Columns.Count == 0)
            {
                dgvHoaDon.RowHeadersVisible = false;
                dgvHoaDon.Columns.Add("colHD", "Mã hóa");
                dgvHoaDon.Columns.Add("colKhachHD", "Khách");
                dgvHoaDon.Columns.Add("colPhongHD", "Phòng");
                dgvHoaDon.Columns.Add("colNgayLap", "Ngày lập");
                dgvHoaDon.Columns.Add("colTong", "Tổng tiền");
                foreach (DataGridViewColumn c in dgvHoaDon.Columns)
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dtpThoiDiemTra.Format = DateTimePickerFormat.Custom;
            dtpThoiDiemTra.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpThoiDiemTra.Value = DateTime.Now;

            dtpThang.Format = DateTimePickerFormat.Custom;
            dtpThang.CustomFormat = "MM/yyyy";
            dtpThang.ShowUpDown = true;
            dtpThang.Value = DateTime.Now;

            lblGhiChuPhuThu.Text =
                $"Trả sau {HoaDonService.GioTraPhong}:00 phụ thu {HoaDonService.PhuThuTraTre:N0} VNĐ.";

            TaiDanhSachDangO();
            XemThongKe();
        }

        private void TaiDanhSachDangO()
        {
            dgvDangO.Rows.Clear();
            foreach (var l in _sv.LayLuotDangO())
            {
                int i = dgvDangO.Rows.Add(l.MaDatPhong, l.TenKhach, l.MaPhong,
                    l.NgayDen.ToString("dd/MM/yyyy"), l.NgayDiDuKien.ToString("dd/MM/yyyy"));
                dgvDangO.Rows[i].Tag = l;
            }
            dgvDangO.ClearSelection();
            _ketQua = null;
        }

        private LuotO? LuotDangChon() => dgvDangO.CurrentRow?.Tag as LuotO;

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            var luot = LuotDangChon();
            if (luot == null)
            {
                MessageBox.Show("Hãy chọn một khách đang lưu trú ở bảng phía trên.", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _ketQua = _sv.TinhTien(luot, dtpThoiDiemTra.Value);
            txtChiTiet.Text = _sv.TaoNoiDung(_ketQua);
        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            var luot = LuotDangChon();
            if (luot == null)
            {
                MessageBox.Show("Hãy chọn một khách đang lưu trú.", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // luôn tính lại để khớp lựa chọn + thời điểm trả hiện tại
            _ketQua = _sv.TinhTien(luot, dtpThoiDiemTra.Value);
            txtChiTiet.Text = _sv.TaoNoiDung(_ketQua);

            var xacNhan = MessageBox.Show(
                $"Trả phòng {luot.MaPhong} cho {luot.TenKhach}?\nTổng thanh toán: {_ketQua.Tong:N0} đ",
                "Xác nhận trả phòng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xacNhan != DialogResult.Yes) return;

            var hd = _sv.TraPhong(_ketQua);
            string noiDung = _sv.TaoNoiDung(_ketQua, hd.MaHD);
            txtChiTiet.Text = noiDung;

            using var dlg = new SaveFileDialog
            {
                Filter = "Text file (*.txt)|*.txt",
                FileName = $"{hd.MaHD}.txt",
                Title = "Xuất hóa đơn TXT"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dlg.FileName, noiDung, System.Text.Encoding.UTF8);
                MessageBox.Show("Đã trả phòng và xuất hóa đơn.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Đã trả phòng. Hóa đơn {hd.MaHD} đã được lưu (chưa xuất file TXT).",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            TaiDanhSachDangO();
            XemThongKe();
        }

        private void btnXemThongKe_Click(object sender, EventArgs e) => XemThongKe();
        private void XemThongKe()
        {
            var tk = _sv.ThongKe(dtpThang.Value.Month, dtpThang.Value.Year);
            lblDoanhThu.Text = $"Doanh thu\n{tk.DoanhThu:N0} VNĐ";
            lblCongSuat.Text = $"Công suất\n{tk.CongSuat:0.0}%";
            lblSoHoaDon.Text = $"Hóa đơn\n{tk.HoaDon.Count}";

            dgvHoaDon.Rows.Clear();
            foreach (var h in tk.HoaDon)
                dgvHoaDon.Rows.Add(h.MaHD, h.TenKhach, h.MaPhong,
                    h.NgayLap.ToString("dd/MM/yyyy"), h.Tong.ToString("N0"));
        }
    }
}
