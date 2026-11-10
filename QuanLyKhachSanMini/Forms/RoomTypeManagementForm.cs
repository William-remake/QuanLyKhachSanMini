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
    public partial class frmQuanLyLoaiPhong : Form
    {
        public frmQuanLyLoaiPhong()
        {
            InitializeComponent();
        }

        private void frmQuanLyLoaiPhong_Load(object sender, EventArgs e)
        {
            // Căn lề phải cho cột giá tiền để hiển thị đẹp mắt giống mẫu
            colGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Đưa dữ liệu mẫu vào DataGridView
            dgvLoaiPhong.Rows.Add("STD", "Phòng Standard", "450.000");
            dgvLoaiPhong.Rows.Add("SUP", "Phòng Superior", "500.000");
            dgvLoaiPhong.Rows.Add("DLX", "Phòng Deluxe", "650.000");
            dgvLoaiPhong.Rows.Add("VIP", "Phòng VIP", "950.000");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Mở form Thêm loại phòng dưới dạng Hộp thoại Modal
            using (frmThemLoaiPhong frm = new frmThemLoaiPhong())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Định dạng tiền tệ hiển thị (ví dụ: 450.000)[cite: 2]
                    string giaFormatted = frm.Gia.ToString("#,##0");

                    // Thêm trực tiếp dòng mới vào DataGridView[cite: 2]
                    dgvLoaiPhong.Rows.Add(frm.MaLoai, frm.TenLoai, giaFormatted);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn dòng nào chưa để sửa
            if (dgvLoaiPhong.SelectedRows.Count > 0)
            {
                MessageBox.Show("Sửa thông tin loại phòng đang chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Xóa dòng đang được chọn
            if (dgvLoaiPhong.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa loại phòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    dgvLoaiPhong.Rows.RemoveAt(dgvLoaiPhong.SelectedRows[0].Index);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            // TODO: Viết code lưu các thay đổi vào Cơ sở dữ liệu (SQL Server)
            MessageBox.Show("Lưu thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
