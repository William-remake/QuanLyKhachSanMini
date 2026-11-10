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
                if (selected.Contains("-"))
                {
                    // Cắt chuỗi lấy phần sau dấu gạch ngang (VD: "STD - Phòng Standard" -> "Phòng Standard")
                    return selected.Split('-')[1].Trim();
                }
                return selected.Trim();
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
            // 1. Đưa dữ liệu mẫu vào ComboBox Loại phòng
            cboLoaiPhong.Items.Add("STD - Phòng Standard");
            cboLoaiPhong.Items.Add("SUP - Phòng Superior");
            cboLoaiPhong.Items.Add("VIP - Phòng VIP");
            cboLoaiPhong.Items.Add("DLX - Phòng Deluxe");
            cboLoaiPhong.SelectedIndex = 0; // Chọn mặc định mục đầu tiên

            // 2. Đưa dữ liệu mẫu vào ComboBox Trạng thái
            cboTrangThai.Items.Add("Trống");
            cboTrangThai.Items.Add("Có Khách");
            cboTrangThai.Items.Add("Đang Dọn");
            cboTrangThai.SelectedIndex = 0;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu chưa nhập số phòng
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập số phòng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoPhong.Focus();
                return;
            }

            //Phải có dòng này để form chính biết là đã bấm Lưu thành công
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
