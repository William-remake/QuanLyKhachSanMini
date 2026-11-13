namespace QuanLyKhachSanMini.Forms
{
    partial class DichVuForm
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
            tabMain = new TabControl();
            tabDanhMuc = new TabPage();
            btnLamMoi = new Button();
            btnNgungKich = new Button();
            btnCapNhat = new Button();
            btnThem = new Button();
            chkApDung = new CheckBox();
            dgvDichVu = new DataGridView();
            numDonGia = new NumericUpDown();
            txtDonVi = new TextBox();
            txtTenDV = new TextBox();
            txtMaDV = new TextBox();
            lblDonGia = new Label();
            lblDonVi = new Label();
            lblTenDV = new Label();
            lblMaDV = new Label();
            tabGhiNhan = new TabPage();
            btnXoaDong = new Button();
            btnGhiNhan = new Button();
            label7 = new Label();
            lblThanhTien = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            dgvDichVuDaDung = new DataGridView();
            dtpNgayDung = new DateTimePicker();
            numSoLuong = new NumericUpDown();
            cboDichVu = new ComboBox();
            cboLuotLuuTru = new ComboBox();
            tabMain.SuspendLayout();
            tabDanhMuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDichVu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
            tabGhiNhan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDichVuDaDung).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(20, 0, 0, 0);
            label1.Size = new Size(982, 51);
            label1.TabIndex = 0;
            label1.Text = "DỊCH VỤ KHÁCH SẠN";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.UseMnemonic = false;
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabDanhMuc);
            tabMain.Controls.Add(tabGhiNhan);
            tabMain.Location = new Point(12, 54);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(958, 384);
            tabMain.TabIndex = 1;
            tabMain.SelectedIndexChanged += tabMain_SelectedIndexChanged;
            // 
            // tabDanhMuc
            // 
            tabDanhMuc.Controls.Add(btnLamMoi);
            tabDanhMuc.Controls.Add(btnNgungKich);
            tabDanhMuc.Controls.Add(btnCapNhat);
            tabDanhMuc.Controls.Add(btnThem);
            tabDanhMuc.Controls.Add(chkApDung);
            tabDanhMuc.Controls.Add(dgvDichVu);
            tabDanhMuc.Controls.Add(numDonGia);
            tabDanhMuc.Controls.Add(txtDonVi);
            tabDanhMuc.Controls.Add(txtTenDV);
            tabDanhMuc.Controls.Add(txtMaDV);
            tabDanhMuc.Controls.Add(lblDonGia);
            tabDanhMuc.Controls.Add(lblDonVi);
            tabDanhMuc.Controls.Add(lblTenDV);
            tabDanhMuc.Controls.Add(lblMaDV);
            tabDanhMuc.Location = new Point(4, 29);
            tabDanhMuc.Name = "tabDanhMuc";
            tabDanhMuc.Padding = new Padding(3);
            tabDanhMuc.Size = new Size(950, 351);
            tabDanhMuc.TabIndex = 0;
            tabDanhMuc.Text = "Danh mục dịch vụ";
            tabDanhMuc.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.LightSlateGray;
            btnLamMoi.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLamMoi.ForeColor = SystemColors.ButtonHighlight;
            btnLamMoi.Location = new Point(738, 290);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(185, 52);
            btnLamMoi.TabIndex = 13;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnNgungKich
            // 
            btnNgungKich.BackColor = Color.OrangeRed;
            btnNgungKich.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNgungKich.ForeColor = SystemColors.ButtonHighlight;
            btnNgungKich.Location = new Point(547, 290);
            btnNgungKich.Name = "btnNgungKich";
            btnNgungKich.Size = new Size(185, 52);
            btnNgungKich.TabIndex = 12;
            btnNgungKich.Text = "Ngừng/Kích hoạt";
            btnNgungKich.UseVisualStyleBackColor = false;
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = Color.DarkBlue;
            btnCapNhat.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCapNhat.ForeColor = SystemColors.ButtonHighlight;
            btnCapNhat.Location = new Point(356, 290);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(185, 52);
            btnCapNhat.TabIndex = 11;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.ForestGreen;
            btnThem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = SystemColors.ButtonHighlight;
            btnThem.Location = new Point(165, 290);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(185, 52);
            btnThem.TabIndex = 10;
            btnThem.Text = "Thêm dịch vụ";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // chkApDung
            // 
            chkApDung.AutoSize = true;
            chkApDung.Checked = true;
            chkApDung.CheckState = CheckState.Checked;
            chkApDung.Location = new Point(33, 304);
            chkApDung.Name = "chkApDung";
            chkApDung.Size = new Size(126, 24);
            chkApDung.TabIndex = 9;
            chkApDung.Text = "Đang áp dụng";
            chkApDung.UseVisualStyleBackColor = true;
            // 
            // dgvDichVu
            // 
            dgvDichVu.AllowUserToAddRows = false;
            dgvDichVu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDichVu.Location = new Point(25, 96);
            dgvDichVu.Name = "dgvDichVu";
            dgvDichVu.ReadOnly = true;
            dgvDichVu.RowHeadersVisible = false;
            dgvDichVu.RowHeadersWidth = 51;
            dgvDichVu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDichVu.Size = new Size(898, 188);
            dgvDichVu.TabIndex = 8;
            // 
            // numDonGia
            // 
            numDonGia.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            numDonGia.Location = new Point(679, 48);
            numDonGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numDonGia.Name = "numDonGia";
            numDonGia.Size = new Size(133, 27);
            numDonGia.TabIndex = 7;
            numDonGia.ThousandsSeparator = true;
            // 
            // txtDonVi
            // 
            txtDonVi.Location = new Point(466, 48);
            txtDonVi.Name = "txtDonVi";
            txtDonVi.Size = new Size(105, 27);
            txtDonVi.TabIndex = 6;
            // 
            // txtTenDV
            // 
            txtTenDV.Location = new Point(239, 48);
            txtTenDV.Name = "txtTenDV";
            txtTenDV.Size = new Size(105, 27);
            txtTenDV.TabIndex = 5;
            // 
            // txtMaDV
            // 
            txtMaDV.Location = new Point(33, 48);
            txtMaDV.Name = "txtMaDV";
            txtMaDV.ReadOnly = true;
            txtMaDV.Size = new Size(102, 27);
            txtMaDV.TabIndex = 4;
            // 
            // lblDonGia
            // 
            lblDonGia.AutoSize = true;
            lblDonGia.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDonGia.Location = new Point(679, 20);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Size = new Size(133, 25);
            lblDonGia.TabIndex = 3;
            lblDonGia.Text = "Đơn giá (VNĐ)";
            // 
            // lblDonVi
            // 
            lblDonVi.AutoSize = true;
            lblDonVi.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDonVi.Location = new Point(466, 20);
            lblDonVi.Name = "lblDonVi";
            lblDonVi.Size = new Size(104, 25);
            lblDonVi.TabIndex = 2;
            lblDonVi.Text = "Đơn vị tính";
            // 
            // lblTenDV
            // 
            lblTenDV.AutoSize = true;
            lblTenDV.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenDV.Location = new Point(239, 20);
            lblTenDV.Name = "lblTenDV";
            lblTenDV.Size = new Size(105, 25);
            lblTenDV.TabIndex = 1;
            lblTenDV.Text = "Tên dịch vụ";
            // 
            // lblMaDV
            // 
            lblMaDV.AutoSize = true;
            lblMaDV.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMaDV.Location = new Point(33, 20);
            lblMaDV.Name = "lblMaDV";
            lblMaDV.Size = new Size(102, 25);
            lblMaDV.TabIndex = 0;
            lblMaDV.Text = "Mã dịch vụ";
            // 
            // tabGhiNhan
            // 
            tabGhiNhan.Controls.Add(btnXoaDong);
            tabGhiNhan.Controls.Add(btnGhiNhan);
            tabGhiNhan.Controls.Add(label7);
            tabGhiNhan.Controls.Add(lblThanhTien);
            tabGhiNhan.Controls.Add(label5);
            tabGhiNhan.Controls.Add(label4);
            tabGhiNhan.Controls.Add(label3);
            tabGhiNhan.Controls.Add(label2);
            tabGhiNhan.Controls.Add(dgvDichVuDaDung);
            tabGhiNhan.Controls.Add(dtpNgayDung);
            tabGhiNhan.Controls.Add(numSoLuong);
            tabGhiNhan.Controls.Add(cboDichVu);
            tabGhiNhan.Controls.Add(cboLuotLuuTru);
            tabGhiNhan.Location = new Point(4, 29);
            tabGhiNhan.Name = "tabGhiNhan";
            tabGhiNhan.Padding = new Padding(3);
            tabGhiNhan.Size = new Size(950, 351);
            tabGhiNhan.TabIndex = 1;
            tabGhiNhan.Text = "Ghi nhận dịch vụ khách dùng";
            tabGhiNhan.UseVisualStyleBackColor = true;
            // 
            // btnXoaDong
            // 
            btnXoaDong.BackColor = Color.FromArgb(192, 0, 0);
            btnXoaDong.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoaDong.ForeColor = SystemColors.ButtonHighlight;
            btnXoaDong.Location = new Point(693, 102);
            btnXoaDong.Name = "btnXoaDong";
            btnXoaDong.Size = new Size(185, 46);
            btnXoaDong.TabIndex = 12;
            btnXoaDong.Text = "Xóa dòng";
            btnXoaDong.UseVisualStyleBackColor = false;
            btnXoaDong.Click += btnXoaDong_Click;
            // 
            // btnGhiNhan
            // 
            btnGhiNhan.BackColor = Color.FromArgb(0, 192, 0);
            btnGhiNhan.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGhiNhan.ForeColor = SystemColors.ButtonHighlight;
            btnGhiNhan.Location = new Point(496, 102);
            btnGhiNhan.Name = "btnGhiNhan";
            btnGhiNhan.Size = new Size(185, 46);
            btnGhiNhan.TabIndex = 11;
            btnGhiNhan.Text = "Ghi nhận";
            btnGhiNhan.UseVisualStyleBackColor = false;
            btnGhiNhan.Click += btnGhiNhan_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(96, 112);
            label7.Name = "label7";
            label7.Size = new Size(100, 25);
            label7.TabIndex = 10;
            label7.Text = "Thành tiền";
            // 
            // lblThanhTien
            // 
            lblThanhTien.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblThanhTien.ForeColor = Color.Red;
            lblThanhTien.Location = new Point(214, 105);
            lblThanhTien.Name = "lblThanhTien";
            lblThanhTien.Padding = new Padding(20, 0, 0, 0);
            lblThanhTien.Size = new Size(255, 34);
            lblThanhTien.TabIndex = 9;
            lblThanhTien.Text = "0 đ";
            lblThanhTien.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(496, 58);
            label5.Name = "label5";
            label5.Size = new Size(104, 25);
            label5.TabIndex = 8;
            label5.Text = "Ngày dùng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(496, 22);
            label4.Name = "label4";
            label4.Size = new Size(87, 25);
            label4.TabIndex = 7;
            label4.Text = "Số lượng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(96, 57);
            label3.Name = "label3";
            label3.Size = new Size(73, 25);
            label3.TabIndex = 6;
            label3.Text = "Dịch vụ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(96, 23);
            label2.Name = "label2";
            label2.Size = new Size(112, 25);
            label2.TabIndex = 5;
            label2.Text = "Lượt lưu trú";
            // 
            // dgvDichVuDaDung
            // 
            dgvDichVuDaDung.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDichVuDaDung.Location = new Point(29, 157);
            dgvDichVuDaDung.Name = "dgvDichVuDaDung";
            dgvDichVuDaDung.RowHeadersWidth = 51;
            dgvDichVuDaDung.Size = new Size(889, 188);
            dgvDichVuDaDung.TabIndex = 4;
            // 
            // dtpNgayDung
            // 
            dtpNgayDung.CustomFormat = "dd/MM/yyyy";
            dtpNgayDung.Format = DateTimePickerFormat.Custom;
            dtpNgayDung.Location = new Point(614, 56);
            dtpNgayDung.Name = "dtpNgayDung";
            dtpNgayDung.Size = new Size(134, 27);
            dtpNgayDung.TabIndex = 3;
            // 
            // numSoLuong
            // 
            numSoLuong.Location = new Point(614, 22);
            numSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(134, 27);
            numSoLuong.TabIndex = 2;
            numSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numSoLuong.ValueChanged += numSoLuong_ValueChanged;
            // 
            // cboDichVu
            // 
            cboDichVu.FormattingEnabled = true;
            cboDichVu.Location = new Point(214, 58);
            cboDichVu.Name = "cboDichVu";
            cboDichVu.Size = new Size(199, 28);
            cboDichVu.TabIndex = 1;
            cboDichVu.SelectedIndexChanged += cboDichVu_SelectedIndexChanged;
            // 
            // cboLuotLuuTru
            // 
            cboLuotLuuTru.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLuotLuuTru.FormattingEnabled = true;
            cboLuotLuuTru.Location = new Point(214, 24);
            cboLuotLuuTru.Name = "cboLuotLuuTru";
            cboLuotLuuTru.Size = new Size(199, 28);
            cboLuotLuuTru.TabIndex = 0;
            cboLuotLuuTru.SelectedIndexChanged += cboLuotLuuTru_SelectedIndexChanged;
            // 
            // DichVuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 453);
            Controls.Add(tabMain);
            Controls.Add(label1);
            Name = "DichVuForm";
            Text = "DichVuForm";
            Load += DichVuForm_Load_1;
            tabMain.ResumeLayout(false);
            tabDanhMuc.ResumeLayout(false);
            tabDanhMuc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDichVu).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
            tabGhiNhan.ResumeLayout(false);
            tabGhiNhan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDichVuDaDung).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TabControl tabMain;
        private TabPage tabDanhMuc;
        private TabPage tabGhiNhan;
        private Label lblDonGia;
        private Label lblDonVi;
        private Label lblTenDV;
        private Label lblMaDV;
        private NumericUpDown numDonGia;
        private TextBox txtDonVi;
        private TextBox txtTenDV;
        private TextBox txtMaDV;
        private Button btnThem;
        private CheckBox chkApDung;
        private DataGridView dgvDichVu;
        private Button btnLamMoi;
        private Button btnNgungKich;
        private Button btnCapNhat;
        private ComboBox cboLuotLuuTru;
        private Label label2;
        private DataGridView dgvDichVuDaDung;
        private DateTimePicker dtpNgayDung;
        private NumericUpDown numSoLuong;
        private ComboBox cboDichVu;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label label7;
        private Label lblThanhTien;
        private Button btnGhiNhan;
        private Button btnXoaDong;
    }
}