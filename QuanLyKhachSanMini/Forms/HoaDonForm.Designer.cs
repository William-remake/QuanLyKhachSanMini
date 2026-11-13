namespace QuanLyKhachSanMini.Forms
{
    partial class HoaDonForm
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            dgvDangO = new DataGridView();
            grpTinhTien = new GroupBox();
            btnTraPhong = new Button();
            btnTinhTien = new Button();
            txtChiTiet = new TextBox();
            lblGhiChuPhuThu = new Label();
            dtpThoiDiemTra = new DateTimePicker();
            lblThoiDiemTra = new Label();
            grpThongKe = new GroupBox();
            dgvHoaDon = new DataGridView();
            lblCongSuat = new Label();
            lblSoHoaDon = new Label();
            lblDoanhThu = new Label();
            btnXemThongKe = new Button();
            dtpThang = new DateTimePicker();
            label2 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDangO).BeginInit();
            grpTinhTien.SuspendLayout();
            grpThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(982, 54);
            label1.TabIndex = 0;
            label1.Text = "TRẢ PHÒNG & HÓA ĐƠN";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.UseMnemonic = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvDangO);
            groupBox1.Location = new Point(12, 57);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(958, 221);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách khách đang lưu trú (chọn một lượt để trả phòng)";
            // 
            // dgvDangO
            // 
            dgvDangO.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDangO.Location = new Point(6, 26);
            dgvDangO.Name = "dgvDangO";
            dgvDangO.RowHeadersWidth = 51;
            dgvDangO.Size = new Size(946, 188);
            dgvDangO.TabIndex = 0;
            // 
            // grpTinhTien
            // 
            grpTinhTien.Controls.Add(btnTraPhong);
            grpTinhTien.Controls.Add(btnTinhTien);
            grpTinhTien.Controls.Add(txtChiTiet);
            grpTinhTien.Controls.Add(lblGhiChuPhuThu);
            grpTinhTien.Controls.Add(dtpThoiDiemTra);
            grpTinhTien.Controls.Add(lblThoiDiemTra);
            grpTinhTien.Location = new Point(12, 284);
            grpTinhTien.Name = "grpTinhTien";
            grpTinhTien.Size = new Size(455, 319);
            grpTinhTien.TabIndex = 2;
            grpTinhTien.TabStop = false;
            grpTinhTien.Text = "Tính tiền và trả phòng";
            // 
            // btnTraPhong
            // 
            btnTraPhong.BackColor = Color.Green;
            btnTraPhong.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTraPhong.ForeColor = SystemColors.ControlLightLight;
            btnTraPhong.Location = new Point(172, 270);
            btnTraPhong.Name = "btnTraPhong";
            btnTraPhong.Size = new Size(200, 41);
            btnTraPhong.TabIndex = 5;
            btnTraPhong.Text = "Trả phòng && xuất TXT";
            btnTraPhong.UseMnemonic = false;
            btnTraPhong.UseVisualStyleBackColor = false;
            btnTraPhong.Click += btnTraPhong_Click;
            // 
            // btnTinhTien
            // 
            btnTinhTien.BackColor = Color.FromArgb(0, 0, 192);
            btnTinhTien.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTinhTien.ForeColor = SystemColors.ControlLightLight;
            btnTinhTien.Location = new Point(22, 270);
            btnTinhTien.Name = "btnTinhTien";
            btnTinhTien.Size = new Size(144, 41);
            btnTinhTien.TabIndex = 4;
            btnTinhTien.Text = "Tính tiền";
            btnTinhTien.UseVisualStyleBackColor = false;
            btnTinhTien.Click += btnTinhTien_Click;
            // 
            // txtChiTiet
            // 
            txtChiTiet.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtChiTiet.Location = new Point(18, 76);
            txtChiTiet.Multiline = true;
            txtChiTiet.Name = "txtChiTiet";
            txtChiTiet.ReadOnly = true;
            txtChiTiet.ScrollBars = ScrollBars.Vertical;
            txtChiTiet.Size = new Size(419, 188);
            txtChiTiet.TabIndex = 3;
            // 
            // lblGhiChuPhuThu
            // 
            lblGhiChuPhuThu.AutoSize = true;
            lblGhiChuPhuThu.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblGhiChuPhuThu.ForeColor = Color.IndianRed;
            lblGhiChuPhuThu.Location = new Point(18, 53);
            lblGhiChuPhuThu.Name = "lblGhiChuPhuThu";
            lblGhiChuPhuThu.Size = new Size(157, 20);
            lblGhiChuPhuThu.TabIndex = 2;
            lblGhiChuPhuThu.Text = "Trả sau 12:00 phụ thu...";
            lblGhiChuPhuThu.Click += lblGhiChuPhuThu_Click;
            // 
            // dtpThoiDiemTra
            // 
            dtpThoiDiemTra.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpThoiDiemTra.Format = DateTimePickerFormat.Custom;
            dtpThoiDiemTra.Location = new Point(143, 23);
            dtpThoiDiemTra.Name = "dtpThoiDiemTra";
            dtpThoiDiemTra.Size = new Size(162, 27);
            dtpThoiDiemTra.TabIndex = 1;
            // 
            // lblThoiDiemTra
            // 
            lblThoiDiemTra.AutoSize = true;
            lblThoiDiemTra.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblThoiDiemTra.Location = new Point(18, 26);
            lblThoiDiemTra.Name = "lblThoiDiemTra";
            lblThoiDiemTra.Size = new Size(116, 23);
            lblThoiDiemTra.TabIndex = 0;
            lblThoiDiemTra.Text = "Thời điểm trả:";
            // 
            // grpThongKe
            // 
            grpThongKe.Controls.Add(dgvHoaDon);
            grpThongKe.Controls.Add(lblCongSuat);
            grpThongKe.Controls.Add(lblSoHoaDon);
            grpThongKe.Controls.Add(lblDoanhThu);
            grpThongKe.Controls.Add(btnXemThongKe);
            grpThongKe.Controls.Add(dtpThang);
            grpThongKe.Controls.Add(label2);
            grpThongKe.Location = new Point(473, 284);
            grpThongKe.Name = "grpThongKe";
            grpThongKe.Size = new Size(497, 319);
            grpThongKe.TabIndex = 3;
            grpThongKe.TabStop = false;
            grpThongKe.Text = "Thống kê doanh thu và công suất phòng theo tháng";
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new Point(19, 132);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.RowHeadersVisible = false;
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.Size = new Size(461, 179);
            dgvHoaDon.TabIndex = 7;
            // 
            // lblCongSuat
            // 
            lblCongSuat.BackColor = SystemColors.GradientActiveCaption;
            lblCongSuat.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCongSuat.ForeColor = Color.Navy;
            lblCongSuat.Location = new Point(174, 60);
            lblCongSuat.Name = "lblCongSuat";
            lblCongSuat.Size = new Size(150, 58);
            lblCongSuat.TabIndex = 6;
            lblCongSuat.Text = "label3";
            lblCongSuat.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSoHoaDon
            // 
            lblSoHoaDon.BackColor = SystemColors.GradientActiveCaption;
            lblSoHoaDon.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSoHoaDon.ForeColor = Color.Navy;
            lblSoHoaDon.Location = new Point(330, 60);
            lblSoHoaDon.Name = "lblSoHoaDon";
            lblSoHoaDon.Size = new Size(150, 58);
            lblSoHoaDon.TabIndex = 5;
            lblSoHoaDon.Text = "label3";
            lblSoHoaDon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDoanhThu
            // 
            lblDoanhThu.BackColor = SystemColors.GradientActiveCaption;
            lblDoanhThu.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDoanhThu.ForeColor = Color.Navy;
            lblDoanhThu.Location = new Point(18, 60);
            lblDoanhThu.Name = "lblDoanhThu";
            lblDoanhThu.Size = new Size(150, 58);
            lblDoanhThu.TabIndex = 3;
            lblDoanhThu.Text = "label3";
            lblDoanhThu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnXemThongKe
            // 
            btnXemThongKe.BackColor = SystemColors.ControlDark;
            btnXemThongKe.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXemThongKe.ForeColor = SystemColors.ControlLightLight;
            btnXemThongKe.Location = new Point(192, 21);
            btnXemThongKe.Name = "btnXemThongKe";
            btnXemThongKe.Size = new Size(144, 33);
            btnXemThongKe.TabIndex = 2;
            btnXemThongKe.Text = "Xem thống kê";
            btnXemThongKe.UseVisualStyleBackColor = false;
            btnXemThongKe.Click += btnXemThongKe_Click;
            // 
            // dtpThang
            // 
            dtpThang.CustomFormat = "MM/yyyy";
            dtpThang.Format = DateTimePickerFormat.Custom;
            dtpThang.Location = new Point(87, 23);
            dtpThang.Name = "dtpThang";
            dtpThang.ShowUpDown = true;
            dtpThang.Size = new Size(100, 27);
            dtpThang.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(19, 26);
            label2.Name = "label2";
            label2.Size = new Size(62, 23);
            label2.TabIndex = 0;
            label2.Text = "Tháng:";
            // 
            // HoaDonForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 615);
            Controls.Add(grpThongKe);
            Controls.Add(grpTinhTien);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "HoaDonForm";
            Text = "HoaDonForm";
            Load += HoaDonForm_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDangO).EndInit();
            grpTinhTien.ResumeLayout(false);
            grpTinhTien.PerformLayout();
            grpThongKe.ResumeLayout(false);
            grpThongKe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private DataGridView dgvDangO;
        private GroupBox grpTinhTien;
        private GroupBox grpThongKe;
        private Label lblThoiDiemTra;
        private DateTimePicker dtpThoiDiemTra;
        private TextBox txtChiTiet;
        private Label lblGhiChuPhuThu;
        private Button btnTinhTien;
        private Button btnTraPhong;
        private Label label2;
        private DateTimePicker dtpThang;
        private Button btnXemThongKe;
        private Label lblSoHoaDon;
        private Label lblDoanhThu;
        private Label lblCongSuat;
        private DataGridView dgvHoaDon;
    }
}