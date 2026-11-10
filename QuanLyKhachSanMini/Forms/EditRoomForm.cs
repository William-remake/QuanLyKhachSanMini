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
    public partial class frmThemLoaiPhong : Form
    {
        // Khai báo các thuộc tính để lấy dữ liệu ra ngoài
        public string MaLoai { get; private set; }
        public string TenLoai { get; private set; }
        public decimal Gia { get; private set; }

        public frmThemLoaiPhong()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtMaLoai.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã loại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoai.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên loại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoai.Focus();
                return;
            }

            // Gán giá trị vào thuộc tính
            MaLoai = txtMaLoai.Text.Trim();
            TenLoai = txtTenLoai.Text.Trim();
            Gia = numGia.Value;

            // Đánh dấu lưu thành công và đóng form
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
