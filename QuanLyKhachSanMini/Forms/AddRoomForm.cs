using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachSanMini.Models;

namespace QuanLyKhachSanMini.Forms
{
    public partial class frmThemPhong : Form
    {
        // Tạo các Property công khai để Form chính có thể đọc được
        public string SoPhong => txtSoPhong.Text.Trim(); // Hoặc tên TextBox số phòng của bạn
        public string Tang => numTang.Value.ToString();    // Hoặc giá trị từ NumericUpDown tầng
        public string TrangThai => cboTrangThai.SelectedItem?.ToString() ?? "Trống";

        // Lọc lại chỉ lấy phần tên phòng (bỏ đoạn mã "STD - " nếu có)
        public string LoaiPhong
        {
            get
            {
                string selected = cboLoaiPhong.SelectedItem?.ToString() ?? "";
                int separator = selected.IndexOf(" - ", StringComparison.Ordinal);
                return separator >= 0 ? selected[(separator + 3)..].Trim() : selected.Trim();
            }
        }

        public frmThemPhong()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThemPhong_Load(object sender, EventArgs e)
        {
            cboLoaiPhong.Items.Clear();
            foreach (var loai in DuLieu.DocLoaiPhong())
                cboLoaiPhong.Items.Add($"{loai.MaLoai} - {loai.TenLoai}");
            if (cboLoaiPhong.Items.Count > 0) cboLoaiPhong.SelectedIndex = 0;

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Trống");
            cboTrangThai.Items.Add("Có khách");
            cboTrangThai.Items.Add("Đang dọn");
            cboTrangThai.SelectedItem = "Trống";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu chưa nhập số phòng
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text)
                || txtSoPhong.Text.Contains('|') || txtSoPhong.Text.Contains('\r') || txtSoPhong.Text.Contains('\n'))
            {
                MessageBox.Show("Vui lòng nhập số phòng hợp lệ, không chứa ký tự | hoặc xuống dòng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoPhong.Focus();
                return;
            }

            if (cboLoaiPhong.SelectedItem == null)
            {
                MessageBox.Show("Chưa có loại phòng. Vui lòng tạo loại phòng trước.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Phải có dòng này để form chính biết là đã bấm Lưu thành công.
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
