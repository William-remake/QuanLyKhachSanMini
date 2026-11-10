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
                if (selected.Contains("-"))
                {
                    return selected.Split('-')[1].Trim();
                }
                return selected.Trim();
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

            // 2. Nạp dữ liệu mẫu cho ComboBox Loại phòng
            cboLoaiPhong.Items.Add("STD - Phòng Standard");
            cboLoaiPhong.Items.Add("DLX - Phòng Deluxe");
            cboLoaiPhong.Items.Add("VIP - Phòng VIP");

            // Chọn sẵn đúng loại phòng cũ
            foreach (var item in cboLoaiPhong.Items)
            {
                if (item.ToString().Contains(loaiPhongCu))
                {
                    cboLoaiPhong.SelectedItem = item;
                    break;
                }
            }
            if (cboLoaiPhong.SelectedIndex == -1 && cboLoaiPhong.Items.Count > 0)
                cboLoaiPhong.SelectedIndex = 0;

            // 3. Nạp dữ liệu cho ComboBox Trạng thái
            cboTrangThai.Items.Add("Trống");
            cboTrangThai.Items.Add("Có khách");
            cboTrangThai.Items.Add("Đang dọn");
            cboTrangThai.SelectedItem = trangThaiCu;
            if (cboTrangThai.SelectedIndex == -1)
                cboTrangThai.SelectedIndex = 0;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập số phòng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoPhong.Focus();
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
