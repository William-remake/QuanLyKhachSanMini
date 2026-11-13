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
    public partial class frmEditRoom : Form
    {
        // Các thuộc tính công khai để Form chính lấy dữ liệu sau khi sửa
        public string SoPhong => txtSoPhong.Text.Trim();
        public string Tang => numTang.Value.ToString();
        public string TrangThai => cboTrangThai.SelectedItem?.ToString() ?? "Trống";

        // Tự động cắt chuỗi loại phòng (chỉ lấy phần tên phòng, ví dụ: "Phòng Standard")
        public string LoaiPhong
        {
            get
            {
                string selected = cboLoaiPhong.SelectedItem?.ToString() ?? "";
                int separator = selected.IndexOf(" - ", StringComparison.Ordinal);
                return separator >= 0 ? selected[(separator + 3)..].Trim() : selected.Trim();
            }
        }

        public frmEditRoom(string soPhongCu, string tangCu, string loaiPhongCu, string trangThaiCu)
        {
            InitializeComponent();

            // 1. Đổ dữ liệu cũ vào các control
            txtSoPhong.Text = soPhongCu;

            if (decimal.TryParse(tangCu, out decimal t))
            {
                numTang.Value = t;
            }

            // Nạp loại phòng từ cùng file LoaiPhong.txt đang được màn hình quản lý loại phòng sử dụng.
            foreach (var loai in DuLieu.DocLoaiPhong())
            {
                string hienThi = $"{loai.MaLoai} - {loai.TenLoai}";
                cboLoaiPhong.Items.Add(hienThi);
                if (loai.TenLoai.Equals(loaiPhongCu.Trim(), StringComparison.OrdinalIgnoreCase))
                    cboLoaiPhong.SelectedItem = hienThi;
            }
            if (cboLoaiPhong.SelectedIndex == -1 && cboLoaiPhong.Items.Count > 0)
                cboLoaiPhong.SelectedIndex = 0;

            // Trạng thái phòng sử dụng thống nhất ba giá trị trong Phong.txt.
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Trống");
            cboTrangThai.Items.Add("Có khách");
            cboTrangThai.Items.Add("Đang dọn");
            cboTrangThai.SelectedItem = DuLieu.ChuanHoaTrangThaiPhong(trangThaiCu);
            if (cboTrangThai.SelectedIndex == -1)
                cboTrangThai.SelectedIndex = 0;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text)
                || txtSoPhong.Text.Contains('|') || txtSoPhong.Text.Contains('\r') || txtSoPhong.Text.Contains('\n'))
            {
                MessageBox.Show("Vui lòng nhập số phòng hợp lệ, không chứa ký tự | hoặc xuống dòng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoPhong.Focus();
                return;
            }

            if (cboLoaiPhong.SelectedItem == null)
            {
                MessageBox.Show("Chưa có loại phòng hợp lệ.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
