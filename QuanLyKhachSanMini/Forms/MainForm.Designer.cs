namespace QuanLyKhachSanMini.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            lblLogo = new Label();
            btnSoDoPhong = new Button();
            btnDatPhong = new Button();
            btnKhach = new Button();
            btnLoaiPhong = new Button();
            btnDichVu = new Button();
            btnHoaDon = new Button();
            pnlNoiDung = new Panel();
            lblTieuDe = new Label();
            lblPhuDe = new Label();
            pnlThongKe1 = new Panel();
            label1 = new Label();
            lblTongPhong = new Label();
            pnlThongKe2 = new Panel();
            lblPhongCoKhach = new Label();
            label3 = new Label();
            pnlThongKe3 = new Panel();
            lblLuotDangO = new Label();
            label5 = new Label();
            pnlThongKe4 = new Panel();
            lblDoanhThuThang = new Label();
            label7 = new Label();
            lblChucNang = new Label();
            pnlCard1 = new Panel();
            label2 = new Label();
            label4 = new Label();
            pnlCard2 = new Panel();
            label6 = new Label();
            label8 = new Label();
            pnlCard3 = new Panel();
            label9 = new Label();
            label10 = new Label();
            pnlCard4 = new Panel();
            label11 = new Label();
            label12 = new Label();
            pnlCard5 = new Panel();
            label13 = new Label();
            label14 = new Label();
            pnlCard6 = new Panel();
            label15 = new Label();
            label16 = new Label();
            pnlSidebar.SuspendLayout();
            pnlNoiDung.SuspendLayout();
            pnlThongKe1.SuspendLayout();
            pnlThongKe2.SuspendLayout();
            pnlThongKe3.SuspendLayout();
            pnlThongKe4.SuspendLayout();
            pnlCard1.SuspendLayout();
            pnlCard2.SuspendLayout();
            pnlCard3.SuspendLayout();
            pnlCard4.SuspendLayout();
            pnlCard5.SuspendLayout();
            pnlCard6.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.Navy;
            pnlSidebar.Controls.Add(btnHoaDon);
            pnlSidebar.Controls.Add(btnDichVu);
            pnlSidebar.Controls.Add(btnLoaiPhong);
            pnlSidebar.Controls.Add(btnKhach);
            pnlSidebar.Controls.Add(btnDatPhong);
            pnlSidebar.Controls.Add(btnSoDoPhong);
            pnlSidebar.Controls.Add(lblLogo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(250, 633);
            pnlSidebar.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogo.ForeColor = SystemColors.ControlLightLight;
            lblLogo.Location = new Point(21, 19);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(209, 63);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "HOTEL MINI QUẢN LÝ";
            // 
            // btnSoDoPhong
            // 
            btnSoDoPhong.BackColor = Color.FromArgb(0, 0, 192);
            btnSoDoPhong.Cursor = Cursors.Hand;
            btnSoDoPhong.FlatAppearance.BorderSize = 0;
            btnSoDoPhong.FlatStyle = FlatStyle.Flat;
            btnSoDoPhong.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSoDoPhong.ForeColor = SystemColors.ButtonHighlight;
            btnSoDoPhong.Location = new Point(21, 110);
            btnSoDoPhong.Name = "btnSoDoPhong";
            btnSoDoPhong.Size = new Size(209, 45);
            btnSoDoPhong.TabIndex = 1;
            btnSoDoPhong.Text = "Sơ đồ phòng";
            btnSoDoPhong.TextAlign = ContentAlignment.MiddleLeft;
            btnSoDoPhong.UseVisualStyleBackColor = false;
            // 
            // btnDatPhong
            // 
            btnDatPhong.BackColor = Color.FromArgb(0, 0, 192);
            btnDatPhong.Cursor = Cursors.Hand;
            btnDatPhong.FlatAppearance.BorderSize = 0;
            btnDatPhong.FlatStyle = FlatStyle.Flat;
            btnDatPhong.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDatPhong.ForeColor = SystemColors.ButtonHighlight;
            btnDatPhong.Location = new Point(21, 165);
            btnDatPhong.Name = "btnDatPhong";
            btnDatPhong.Size = new Size(209, 45);
            btnDatPhong.TabIndex = 2;
            btnDatPhong.Text = "Đặt phòng / nhận";
            btnDatPhong.TextAlign = ContentAlignment.MiddleLeft;
            btnDatPhong.UseVisualStyleBackColor = false;
            // 
            // btnKhach
            // 
            btnKhach.BackColor = Color.FromArgb(0, 0, 192);
            btnKhach.Cursor = Cursors.Hand;
            btnKhach.FlatAppearance.BorderSize = 0;
            btnKhach.FlatStyle = FlatStyle.Flat;
            btnKhach.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKhach.ForeColor = SystemColors.ButtonHighlight;
            btnKhach.Location = new Point(21, 220);
            btnKhach.Name = "btnKhach";
            btnKhach.Size = new Size(209, 45);
            btnKhach.TabIndex = 3;
            btnKhach.Text = "Quản lý khách";
            btnKhach.TextAlign = ContentAlignment.MiddleLeft;
            btnKhach.UseVisualStyleBackColor = false;
            // 
            // btnLoaiPhong
            // 
            btnLoaiPhong.BackColor = Color.FromArgb(0, 0, 192);
            btnLoaiPhong.Cursor = Cursors.Hand;
            btnLoaiPhong.FlatAppearance.BorderSize = 0;
            btnLoaiPhong.FlatStyle = FlatStyle.Flat;
            btnLoaiPhong.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoaiPhong.ForeColor = SystemColors.ButtonHighlight;
            btnLoaiPhong.Location = new Point(21, 275);
            btnLoaiPhong.Name = "btnLoaiPhong";
            btnLoaiPhong.Size = new Size(209, 45);
            btnLoaiPhong.TabIndex = 4;
            btnLoaiPhong.Text = "Loại phòng";
            btnLoaiPhong.TextAlign = ContentAlignment.MiddleLeft;
            btnLoaiPhong.UseVisualStyleBackColor = false;
            // 
            // btnDichVu
            // 
            btnDichVu.BackColor = Color.FromArgb(0, 0, 192);
            btnDichVu.Cursor = Cursors.Hand;
            btnDichVu.FlatAppearance.BorderSize = 0;
            btnDichVu.FlatStyle = FlatStyle.Flat;
            btnDichVu.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDichVu.ForeColor = SystemColors.ButtonHighlight;
            btnDichVu.Location = new Point(21, 330);
            btnDichVu.Name = "btnDichVu";
            btnDichVu.Size = new Size(209, 45);
            btnDichVu.TabIndex = 5;
            btnDichVu.Text = "Dịch vụ";
            btnDichVu.TextAlign = ContentAlignment.MiddleLeft;
            btnDichVu.UseVisualStyleBackColor = false;
            // 
            // btnHoaDon
            // 
            btnHoaDon.BackColor = Color.FromArgb(0, 0, 192);
            btnHoaDon.Cursor = Cursors.Hand;
            btnHoaDon.FlatAppearance.BorderSize = 0;
            btnHoaDon.FlatStyle = FlatStyle.Flat;
            btnHoaDon.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHoaDon.ForeColor = SystemColors.ButtonHighlight;
            btnHoaDon.Location = new Point(21, 385);
            btnHoaDon.Name = "btnHoaDon";
            btnHoaDon.Size = new Size(209, 45);
            btnHoaDon.TabIndex = 6;
            btnHoaDon.Text = "Hóa đơn / trả";
            btnHoaDon.TextAlign = ContentAlignment.MiddleLeft;
            btnHoaDon.UseVisualStyleBackColor = false;
            // 
            // pnlNoiDung
            // 
            pnlNoiDung.BackColor = Color.WhiteSmoke;
            pnlNoiDung.Controls.Add(pnlCard6);
            pnlNoiDung.Controls.Add(pnlCard5);
            pnlNoiDung.Controls.Add(pnlCard4);
            pnlNoiDung.Controls.Add(pnlCard3);
            pnlNoiDung.Controls.Add(pnlCard2);
            pnlNoiDung.Controls.Add(pnlCard1);
            pnlNoiDung.Controls.Add(lblChucNang);
            pnlNoiDung.Controls.Add(pnlThongKe4);
            pnlNoiDung.Controls.Add(pnlThongKe3);
            pnlNoiDung.Controls.Add(pnlThongKe2);
            pnlNoiDung.Controls.Add(pnlThongKe1);
            pnlNoiDung.Controls.Add(lblPhuDe);
            pnlNoiDung.Controls.Add(lblTieuDe);
            pnlNoiDung.Dock = DockStyle.Fill;
            pnlNoiDung.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlNoiDung.Location = new Point(250, 0);
            pnlNoiDung.Name = "pnlNoiDung";
            pnlNoiDung.Size = new Size(862, 633);
            pnlNoiDung.TabIndex = 1;
            // 
            // lblTieuDe
            // 
            lblTieuDe.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.ForeColor = Color.Navy;
            lblTieuDe.Location = new Point(20, 13);
            lblTieuDe.MaximumSize = new Size(0, 50);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(506, 50);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "BẢNG ĐIỀU KHIỂN";
            // 
            // lblPhuDe
            // 
            lblPhuDe.AutoSize = true;
            lblPhuDe.Location = new Point(20, 62);
            lblPhuDe.MaximumSize = new Size(0, 50);
            lblPhuDe.Name = "lblPhuDe";
            lblPhuDe.Padding = new Padding(5, 0, 0, 0);
            lblPhuDe.Size = new Size(603, 23);
            lblPhuDe.TabIndex = 1;
            lblPhuDe.Text = "Quản lý phòng, khách lưu trú, dịch vụ và doanh thu trên cùng một màn hình";
            // 
            // pnlThongKe1
            // 
            pnlThongKe1.BackColor = Color.White;
            pnlThongKe1.Controls.Add(lblTongPhong);
            pnlThongKe1.Controls.Add(label1);
            pnlThongKe1.Location = new Point(20, 110);
            pnlThongKe1.Name = "pnlThongKe1";
            pnlThongKe1.Size = new Size(200, 100);
            pnlThongKe1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(17, 13);
            label1.Name = "label1";
            label1.Size = new Size(126, 23);
            label1.TabIndex = 0;
            label1.Text = "Tổng số phòng";
            // 
            // lblTongPhong
            // 
            lblTongPhong.AutoSize = true;
            lblTongPhong.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongPhong.ForeColor = Color.Navy;
            lblTongPhong.Location = new Point(17, 39);
            lblTongPhong.Name = "lblTongPhong";
            lblTongPhong.Size = new Size(117, 46);
            lblTongPhong.TabIndex = 1;
            lblTongPhong.Text = "label2";
            // 
            // pnlThongKe2
            // 
            pnlThongKe2.BackColor = Color.White;
            pnlThongKe2.Controls.Add(lblPhongCoKhach);
            pnlThongKe2.Controls.Add(label3);
            pnlThongKe2.Location = new Point(226, 110);
            pnlThongKe2.Name = "pnlThongKe2";
            pnlThongKe2.Size = new Size(200, 100);
            pnlThongKe2.TabIndex = 3;
            // 
            // lblPhongCoKhach
            // 
            lblPhongCoKhach.AutoSize = true;
            lblPhongCoKhach.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhongCoKhach.ForeColor = Color.Navy;
            lblPhongCoKhach.Location = new Point(17, 39);
            lblPhongCoKhach.Name = "lblPhongCoKhach";
            lblPhongCoKhach.Size = new Size(117, 46);
            lblPhongCoKhach.TabIndex = 1;
            lblPhongCoKhach.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(17, 13);
            label3.Name = "label3";
            label3.Size = new Size(133, 23);
            label3.TabIndex = 0;
            label3.Text = "Phòng có khách";
            // 
            // pnlThongKe3
            // 
            pnlThongKe3.BackColor = Color.White;
            pnlThongKe3.Controls.Add(lblLuotDangO);
            pnlThongKe3.Controls.Add(label5);
            pnlThongKe3.Location = new Point(432, 110);
            pnlThongKe3.Name = "pnlThongKe3";
            pnlThongKe3.Size = new Size(200, 100);
            pnlThongKe3.TabIndex = 3;
            // 
            // lblLuotDangO
            // 
            lblLuotDangO.AutoSize = true;
            lblLuotDangO.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLuotDangO.ForeColor = Color.Navy;
            lblLuotDangO.Location = new Point(17, 39);
            lblLuotDangO.Name = "lblLuotDangO";
            lblLuotDangO.Size = new Size(117, 46);
            lblLuotDangO.TabIndex = 1;
            lblLuotDangO.Text = "label2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(17, 13);
            label5.Name = "label5";
            label5.Size = new Size(144, 23);
            label5.TabIndex = 0;
            label5.Text = "Lượt đang lưu trú";
            // 
            // pnlThongKe4
            // 
            pnlThongKe4.BackColor = Color.White;
            pnlThongKe4.Controls.Add(lblDoanhThuThang);
            pnlThongKe4.Controls.Add(label7);
            pnlThongKe4.Location = new Point(638, 110);
            pnlThongKe4.Name = "pnlThongKe4";
            pnlThongKe4.Size = new Size(200, 100);
            pnlThongKe4.TabIndex = 3;
            // 
            // lblDoanhThuThang
            // 
            lblDoanhThuThang.AutoSize = true;
            lblDoanhThuThang.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDoanhThuThang.ForeColor = Color.Navy;
            lblDoanhThuThang.Location = new Point(17, 39);
            lblDoanhThuThang.Name = "lblDoanhThuThang";
            lblDoanhThuThang.Size = new Size(117, 46);
            lblDoanhThuThang.TabIndex = 1;
            lblDoanhThuThang.Text = "label2";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.ControlDarkDark;
            label7.Location = new Point(17, 13);
            label7.Name = "label7";
            label7.Size = new Size(142, 23);
            label7.TabIndex = 0;
            label7.Text = "Doanh thu tháng";
            // 
            // lblChucNang
            // 
            lblChucNang.AutoSize = true;
            lblChucNang.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChucNang.ForeColor = Color.Navy;
            lblChucNang.Location = new Point(20, 245);
            lblChucNang.Name = "lblChucNang";
            lblChucNang.Size = new Size(257, 31);
            lblChucNang.TabIndex = 4;
            lblChucNang.Text = "CHỨC NĂNG QUẢN LÝ";
            // 
            // pnlCard1
            // 
            pnlCard1.BackColor = Color.White;
            pnlCard1.Controls.Add(label4);
            pnlCard1.Controls.Add(label2);
            pnlCard1.Location = new Point(20, 291);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.Size = new Size(406, 90);
            pnlCard1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(16, 15);
            label2.Name = "label2";
            label2.Size = new Size(183, 28);
            label2.TabIndex = 0;
            label2.Text = "01 SƠ ĐỒ PHÒNG";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(16, 50);
            label4.Name = "label4";
            label4.Size = new Size(359, 23);
            label4.TabIndex = 1;
            label4.Text = "Theo dõi phòng trống, có khách và đang dọn";
            // 
            // pnlCard2
            // 
            pnlCard2.BackColor = Color.White;
            pnlCard2.Controls.Add(label6);
            pnlCard2.Controls.Add(label8);
            pnlCard2.Location = new Point(432, 291);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.Size = new Size(406, 90);
            pnlCard2.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(16, 50);
            label6.Name = "label6";
            label6.Size = new Size(381, 23);
            label6.TabIndex = 1;
            label6.Text = "Tìm phòng trống, tạo đặt phòng và nhận phòng";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(16, 15);
            label8.Name = "label8";
            label8.Size = new Size(243, 28);
            label8.TabIndex = 0;
            label8.Text = "02 ĐẶT / NHẬN PHÒNG";
            // 
            // pnlCard3
            // 
            pnlCard3.BackColor = Color.White;
            pnlCard3.Controls.Add(label9);
            pnlCard3.Controls.Add(label10);
            pnlCard3.Location = new Point(20, 396);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.Size = new Size(406, 90);
            pnlCard3.TabIndex = 6;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(16, 50);
            label9.Name = "label9";
            label9.Size = new Size(254, 23);
            label9.TabIndex = 1;
            label9.Text = "Quản lý thông tin khách lưu trú";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(16, 15);
            label10.Name = "label10";
            label10.Size = new Size(176, 28);
            label10.TabIndex = 0;
            label10.Text = "03 KHÁCH HÀNG";
            // 
            // pnlCard4
            // 
            pnlCard4.BackColor = Color.White;
            pnlCard4.Controls.Add(label11);
            pnlCard4.Controls.Add(label12);
            pnlCard4.Location = new Point(432, 396);
            pnlCard4.Name = "pnlCard4";
            pnlCard4.Size = new Size(406, 90);
            pnlCard4.TabIndex = 6;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(16, 50);
            label11.Name = "label11";
            label11.Size = new Size(342, 23);
            label11.TabIndex = 1;
            label11.Text = "Danh mục dịch vụ và ghi nhận khách dùng";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(16, 15);
            label12.Name = "label12";
            label12.Size = new Size(123, 28);
            label12.TabIndex = 0;
            label12.Text = "04 DỊCH VỤ";
            // 
            // pnlCard5
            // 
            pnlCard5.BackColor = Color.White;
            pnlCard5.Controls.Add(label13);
            pnlCard5.Controls.Add(label14);
            pnlCard5.Location = new Point(20, 502);
            pnlCard5.Name = "pnlCard5";
            pnlCard5.Size = new Size(406, 90);
            pnlCard5.TabIndex = 6;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(16, 50);
            label13.Name = "label13";
            label13.Size = new Size(304, 23);
            label13.TabIndex = 1;
            label13.Text = "Tính tiền, phụ thu trễ và xuất hóa đơn";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(16, 15);
            label14.Name = "label14";
            label14.Size = new Size(277, 28);
            label14.TabIndex = 0;
            label14.Text = "05 TRẢ PHÒNG / HÓA ĐƠN";
            // 
            // pnlCard6
            // 
            pnlCard6.BackColor = Color.White;
            pnlCard6.Controls.Add(label15);
            pnlCard6.Controls.Add(label16);
            pnlCard6.Location = new Point(432, 502);
            pnlCard6.Name = "pnlCard6";
            pnlCard6.Size = new Size(406, 90);
            pnlCard6.TabIndex = 6;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(16, 50);
            label15.Name = "label15";
            label15.Size = new Size(316, 23);
            label15.TabIndex = 1;
            label15.Text = "Quản lý loại phòng và đơn giá mỗi đêm";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(16, 15);
            label16.Name = "label16";
            label16.Size = new Size(165, 28);
            label16.TabIndex = 0;
            label16.Text = "06 LOẠI PHÒNG";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1112, 633);
            Controls.Add(pnlNoiDung);
            Controls.Add(pnlSidebar);
            Name = "MainForm";
            Text = "Quản lý khách sạn mini";
            Load += MainForm_Load;
            pnlSidebar.ResumeLayout(false);
            pnlNoiDung.ResumeLayout(false);
            pnlNoiDung.PerformLayout();
            pnlThongKe1.ResumeLayout(false);
            pnlThongKe1.PerformLayout();
            pnlThongKe2.ResumeLayout(false);
            pnlThongKe2.PerformLayout();
            pnlThongKe3.ResumeLayout(false);
            pnlThongKe3.PerformLayout();
            pnlThongKe4.ResumeLayout(false);
            pnlThongKe4.PerformLayout();
            pnlCard1.ResumeLayout(false);
            pnlCard1.PerformLayout();
            pnlCard2.ResumeLayout(false);
            pnlCard2.PerformLayout();
            pnlCard3.ResumeLayout(false);
            pnlCard3.PerformLayout();
            pnlCard4.ResumeLayout(false);
            pnlCard4.PerformLayout();
            pnlCard5.ResumeLayout(false);
            pnlCard5.PerformLayout();
            pnlCard6.ResumeLayout(false);
            pnlCard6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Label lblLogo;
        private Button btnSoDoPhong;
        private Button btnHoaDon;
        private Button btnDichVu;
        private Button btnLoaiPhong;
        private Button btnKhach;
        private Button btnDatPhong;
        private Panel pnlNoiDung;
        private Label lblTieuDe;
        private Label lblPhuDe;
        private Panel pnlThongKe1;
        private Panel pnlThongKe4;
        private Label lblDoanhThuThang;
        private Label label7;
        private Panel pnlThongKe3;
        private Label lblLuotDangO;
        private Label label5;
        private Panel pnlThongKe2;
        private Label lblPhongCoKhach;
        private Label label3;
        private Label lblTongPhong;
        private Label label1;
        private Label lblChucNang;
        private Panel pnlCard1;
        private Label label4;
        private Label label2;
        private Panel pnlCard6;
        private Label label15;
        private Label label16;
        private Panel pnlCard5;
        private Label label13;
        private Label label14;
        private Panel pnlCard4;
        private Label label11;
        private Label label12;
        private Panel pnlCard3;
        private Label label9;
        private Label label10;
        private Panel pnlCard2;
        private Label label6;
        private Label label8;
    }
}