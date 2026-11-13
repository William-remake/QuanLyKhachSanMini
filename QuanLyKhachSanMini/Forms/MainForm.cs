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
    public partial class MainForm : Form
    {
        private readonly HoaDonService _hdService = new();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TaiThongKe();

            // 6 nút sidebar
            btnSoDoPhong.Click += SoDoPhong_Click;
            btnDatPhong.Click += DatPhong_Click;
            btnKhach.Click += Khach_Click;
            btnLoaiPhong.Click += LoaiPhong_Click;
            btnDichVu.Click += DichVu_Click;
            btnHoaDon.Click += HoaDon_Click;

            // 6 thẻ chức năng (bấm vào thẻ hoặc chữ trong thẻ đều mở được)
            GanClickThe(pnlCard1, SoDoPhong_Click);
            GanClickThe(pnlCard2, DatPhong_Click);
            GanClickThe(pnlCard3, Khach_Click);
            GanClickThe(pnlCard4, DichVu_Click);
            GanClickThe(pnlCard5, HoaDon_Click);
            GanClickThe(pnlCard6, LoaiPhong_Click);
        }

        private void TaiThongKe()
        {
            lblTongPhong.Text = _hdService.TongSoPhong().ToString();
            lblPhongCoKhach.Text = _hdService.DemPhongCoKhach().ToString();
            lblLuotDangO.Text = _hdService.LayLuotDangO().Count.ToString();
            var tk = _hdService.ThongKe(DateTime.Now.Month, DateTime.Now.Year);
            lblDoanhThuThang.Text = $"{tk.DoanhThu:N0} đ";
        }

        // Mở form con, đóng xong thì làm mới số liệu
        private void MoForm(Form f)
        {
            using (f)
            {
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog(this);
            }
            TaiThongKe();
        }

        // Gắn click cho thẻ và mọi control bên trong thẻ
        private void GanClickThe(Control the, EventHandler handler)
        {
            the.Cursor = Cursors.Hand;
            the.Click += handler;
            foreach (Control c in the.Controls)
            {
                c.Cursor = Cursors.Hand;
                c.Click += handler;
            }
        }

        // Đổi tên form nếu project bạn đặt khác
        private void SoDoPhong_Click(object? sender, EventArgs e) => MoForm(new frmRoomMain());
        private void DatPhong_Click(object? sender, EventArgs e) => MoForm(new DatPhongForm());
        private void Khach_Click(object? sender, EventArgs e) => MoForm(new KhachForm());
        private void LoaiPhong_Click(object? sender, EventArgs e) => MoForm(new frmQuanLyLoaiPhong());
        private void DichVu_Click(object? sender, EventArgs e) => MoForm(new DichVuForm());
        private void HoaDon_Click(object? sender, EventArgs e) => MoForm(new HoaDonForm());

    }
}
