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

        // Giữ lại vì Designer có thể đang gán event này.
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
                dgvHoaDon.Columns.Add("colHD", "Mã hóa đơn");
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

        // ===================== TÍNH TIỀN (chỉ xem trước) =====================
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            var luot = LuotDangChon();
            if (luot == null)
            {
                MessageBox.Show("Hãy chọn một khách đang lưu trú ở bảng phía trên.", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                _ketQua = _sv.TinhTien(luot, dtpThoiDiemTra.Value);
                txtChiTiet.Text = _sv.TaoNoiDung(_ketQua);
            }
            catch (Exception ex)
            {
                _ketQua = null;
                MessageBox.Show(ex.Message, "Không thể tính tiền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ===================== XUẤT HÓA ĐƠN (tính vào doanh thu, KHÔNG trả phòng) =====================
        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            var luot = LuotDangChon();
            if (luot == null)
            {
                MessageBox.Show("Hãy chọn một khách đang lưu trú.", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (_sv.DaCoHoaDon(luot.MaDatPhong))
                {
                    MessageBox.Show("Lượt ở này đã được xuất hóa đơn rồi.", "Đã có hóa đơn",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Luôn tính lại ngay trước khi lưu để lấy giá phòng và dịch vụ mới nhất.
                _ketQua = _sv.TinhTien(luot, dtpThoiDiemTra.Value);
                txtChiTiet.Text = _sv.TaoNoiDung(_ketQua);

                var xacNhan = MessageBox.Show(
                    $"Xuất hóa đơn cho {luot.TenKhach} - phòng {luot.MaPhong}?\nTổng thanh toán: {_ketQua.Tong:N0} đ",
                    "Xác nhận xuất hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (xacNhan != DialogResult.Yes) return;

                var hd = _sv.LapHoaDon(_ketQua);   // lưu hóa đơn -> tính vào doanh thu
                string noiDung = _sv.TaoNoiDung(hd);
                txtChiTiet.Text = noiDung;

                string fileMacDinh = Path.Combine(DuLieu.ThuMucData, "HoaDon", hd.MaHD + ".txt");
                using var dlg = new SaveFileDialog
                {
                    Filter = "Text file (*.txt)|*.txt",
                    FileName = $"{hd.MaHD}.txt",
                    Title = "Xuất hóa đơn TXT",
                    InitialDirectory = Path.GetDirectoryName(fileMacDinh)
                };

                string thongBao = $"Đã xuất hóa đơn. File được lưu tại: {fileMacDinh}";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fileChon = Path.GetFullPath(dlg.FileName);
                        if (!fileChon.Equals(Path.GetFullPath(fileMacDinh), StringComparison.OrdinalIgnoreCase))
                            File.WriteAllText(fileChon, noiDung, new UTF8Encoding(false));
                        thongBao = $"Đã xuất hóa đơn: {fileChon}";
                    }
                    catch (Exception exXuat)
                    {
                        // Hóa đơn gốc đã được lưu; lỗi bản sao không được báo nhầm là lỗi lập hóa đơn.
                        MessageBox.Show($"Hóa đơn gốc đã lưu tại {fileMacDinh}, nhưng không thể xuất bản sao.\n{exXuat.Message}",
                            "Không thể xuất bản sao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                MessageBox.Show(thongBao, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                XemThongKe();   // cập nhật doanh thu ngay; khách vẫn còn trong danh sách đang ở
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Không thể xuất hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XemThongKe();
            }
        }

        // ===================== TRẢ PHÒNG (chỉ đổi trạng thái, KHÔNG lập hóa đơn) =====================
        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            var luot = LuotDangChon();
            if (luot == null)
            {
                MessageBox.Show("Hãy chọn một khách đang lưu trú.", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!_sv.DaCoHoaDon(luot.MaDatPhong))
            {
                MessageBox.Show("Khách này chưa được xuất hóa đơn. Hãy bấm \"Xuất hóa đơn\" trước khi trả phòng.",
                    "Chưa xuất hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Trả phòng {luot.MaPhong} cho {luot.TenKhach}?", "Xác nhận trả phòng",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                _sv.TraPhong(luot, dtpThoiDiemTra.Value);
                MessageBox.Show("Đã trả phòng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChiTiet.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Không thể trả phòng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                TaiDanhSachDangO();
                XemThongKe();
            }
        }

        // ===================== THỐNG KÊ =====================
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