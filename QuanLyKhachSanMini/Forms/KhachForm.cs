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
    public partial class KhachForm : Form
    {
        private List<KhachHang> dsKhach = new List<KhachHang>();

        public KhachForm()
        {
            InitializeComponent();

            // Gắn sự kiện bằng code
            Load += KhachForm_Load;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            btnTim.Click += BtnTim_Click;
            txtTim.KeyDown += TxtTim_KeyDown;
            dgvKhach.CellClick += DgvKhach_CellClick;
        }

        private void KhachForm_Load(object? sender, EventArgs e)
        {
            dgvKhach.ReadOnly = true;
            dgvKhach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhach.MultiSelect = false;
            dgvKhach.AllowUserToAddRows = false;
            dgvKhach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txtCCCD.MaxLength = 12;
            txtSDT.MaxLength = 11;

            TaiDanhSach();
        }

        // ---------- Hiển thị ----------

        private void TaiDanhSach()
        {
            dsKhach = DuLieu.DocKhach();
            HienThi(dsKhach);
        }

        private void HienThi(List<KhachHang> ds)
        {
            dgvKhach.DataSource = null;
            dgvKhach.DataSource = ds;

            if (dgvKhach.Columns["CCCD"] != null) dgvKhach.Columns["CCCD"].HeaderText = "CCCD";
            if (dgvKhach.Columns["HoTen"] != null) dgvKhach.Columns["HoTen"].HeaderText = "Họ tên";
            if (dgvKhach.Columns["SDT"] != null) dgvKhach.Columns["SDT"].HeaderText = "SĐT";

            dgvKhach.ClearSelection();
        }

        private void LamTrongO()
        {
            txtCCCD.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtCCCD.ReadOnly = false;   // cho nhập CCCD khi thêm mới
            txtCCCD.Focus();
        }

        // ---------- Kiểm tra dữ liệu ----------

        private bool KiemTraDauVao()
        {
            string cccd = txtCCCD.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            if (cccd.Length != 12 || !cccd.All(char.IsDigit))
            {
                MessageBox.Show("CCCD phải gồm đúng 12 chữ số.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Họ tên không được để trống.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (!sdt.All(char.IsDigit) || sdt.Length < 9 || sdt.Length > 11)
            {
                MessageBox.Show("SĐT phải gồm 9 đến 11 chữ số.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            return true;
        }

        // ---------- Chức năng ----------

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            if (!KiemTraDauVao()) return;

            string cccd = txtCCCD.Text.Trim();

            if (dsKhach.Any(k => k.CCCD == cccd))
            {
                MessageBox.Show("CCCD này đã tồn tại.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }

            dsKhach.Add(new KhachHang
            {
                CCCD = cccd,
                HoTen = txtHoTen.Text.Trim(),
                SDT = txtSDT.Text.Trim()
            });

            DuLieu.GhiKhach(dsKhach);
            HienThi(dsKhach);
            LamTrongO();
            MessageBox.Show("Thêm khách thành công.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSua_Click(object? sender, EventArgs e)
        {
            string cccd = txtCCCD.Text.Trim();
            var kh = dsKhach.FirstOrDefault(k => k.CCCD == cccd);

            if (kh == null)
            {
                MessageBox.Show("Hãy chọn một khách trong danh sách để sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!KiemTraDauVao()) return;

            kh.HoTen = txtHoTen.Text.Trim();
            kh.SDT = txtSDT.Text.Trim();

            DuLieu.GhiKhach(dsKhach);
            HienThi(dsKhach);
            LamTrongO();
            MessageBox.Show("Cập nhật thành công.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnXoa_Click(object? sender, EventArgs e)
        {
            string cccd = txtCCCD.Text.Trim();
            var kh = dsKhach.FirstOrDefault(k => k.CCCD == cccd);

            if (kh == null)
            {
                MessageBox.Show("Hãy chọn một khách trong danh sách để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Giữ khách nếu còn bất kỳ lịch sử đặt phòng nào để không làm đứt liên kết dữ liệu.
            bool dangDat = DuLieu.DocDatPhong().Any(d => d.CCCD == cccd);

            if (dangDat)
            {
                MessageBox.Show("Khách hàng đã có lịch sử đặt phòng nên không thể xóa để bảo toàn dữ liệu.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var kq = MessageBox.Show($"Xóa khách {kh.HoTen} ({kh.CCCD})?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq != DialogResult.Yes) return;

            dsKhach.Remove(kh);
            DuLieu.GhiKhach(dsKhach);
            HienThi(dsKhach);
            LamTrongO();
        }

        private void BtnLamMoi_Click(object? sender, EventArgs e)
        {
            txtTim.Clear();
            LamTrongO();
            TaiDanhSach();
        }

        private void BtnTim_Click(object? sender, EventArgs e)
        {
            string tuKhoa = txtTim.Text.Trim();

            if (tuKhoa == "")
            {
                HienThi(dsKhach);
                return;
            }

            var kq = dsKhach.Where(k =>
                k.CCCD.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase) ||
                k.HoTen.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase)).ToList();

            HienThi(kq);

            if (kq.Count == 0)
                MessageBox.Show("Không tìm thấy khách phù hợp.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TxtTim_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BtnTim_Click(sender, EventArgs.Empty);
            }
        }

        private void DgvKhach_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvKhach.Rows[e.RowIndex].DataBoundItem is KhachHang kh)
            {
                txtCCCD.Text = kh.CCCD;
                txtHoTen.Text = kh.HoTen;
                txtSDT.Text = kh.SDT;
                txtCCCD.ReadOnly = true;   // không cho đổi CCCD khi sửa
            }
        }
    }
}

