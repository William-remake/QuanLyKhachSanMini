namespace QuanLyKhachSanMini.Forms
{
    partial class DatPhongForm
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
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            cboLoaiPhong = new ComboBox();
            dtpNgayDen = new DateTimePicker();
            dtpNgayDi = new DateTimePicker();
            btnTimPhong = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dgvPhongTrong = new DataGridView();
            cboKhach = new ComboBox();
            lblPhongChon = new Label();
            btnDatPhong = new Button();
            label4 = new Label();
            dgvDatPhong = new DataGridView();
            btnNhanPhong = new Button();
            btnHuyDat = new Button();
            btnLamMoi = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhongTrong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDatPhong).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvPhongTrong);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnTimPhong);
            groupBox1.Controls.Add(dtpNgayDi);
            groupBox1.Controls.Add(dtpNgayDen);
            groupBox1.Controls.Add(cboLoaiPhong);
            groupBox1.Location = new Point(6, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(420, 315);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm phòng trống";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(btnDatPhong);
            groupBox2.Controls.Add(lblPhongChon);
            groupBox2.Controls.Add(cboKhach);
            groupBox2.Location = new Point(446, 9);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(450, 305);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin đặt";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnLamMoi);
            groupBox3.Controls.Add(btnHuyDat);
            groupBox3.Controls.Add(btnNhanPhong);
            groupBox3.Controls.Add(dgvDatPhong);
            groupBox3.Location = new Point(7, 326);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(889, 315);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Danh sách đặt phòng";
            // 
            // cboLoaiPhong
            // 
            cboLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiPhong.FormattingEnabled = true;
            cboLoaiPhong.Location = new Point(164, 26);
            cboLoaiPhong.Name = "cboLoaiPhong";
            cboLoaiPhong.Size = new Size(151, 28);
            cboLoaiPhong.TabIndex = 0;
            // 
            // dtpNgayDen
            // 
            dtpNgayDen.Format = DateTimePickerFormat.Short;
            dtpNgayDen.Location = new Point(164, 60);
            dtpNgayDen.Name = "dtpNgayDen";
            dtpNgayDen.Size = new Size(228, 27);
            dtpNgayDen.TabIndex = 1;
            // 
            // dtpNgayDi
            // 
            dtpNgayDi.Format = DateTimePickerFormat.Short;
            dtpNgayDi.Location = new Point(164, 93);
            dtpNgayDi.Name = "dtpNgayDi";
            dtpNgayDi.Size = new Size(228, 27);
            dtpNgayDi.TabIndex = 2;
            // 
            // btnTimPhong
            // 
            btnTimPhong.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimPhong.ForeColor = Color.Blue;
            btnTimPhong.Location = new Point(99, 131);
            btnTimPhong.Name = "btnTimPhong";
            btnTimPhong.Size = new Size(216, 36);
            btnTimPhong.TabIndex = 3;
            btnTimPhong.Text = "Tìm phòng trống";
            btnTimPhong.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 29);
            label1.Name = "label1";
            label1.Size = new Size(142, 23);
            label1.TabIndex = 4;
            label1.Text = "Chọn loại phòng";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 65);
            label2.Name = "label2";
            label2.Size = new Size(87, 23);
            label2.TabIndex = 5;
            label2.Text = "Ngày đến";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(17, 96);
            label3.Name = "label3";
            label3.Size = new Size(73, 23);
            label3.TabIndex = 6;
            label3.Text = "Ngày đi";
            // 
            // dgvPhongTrong
            // 
            dgvPhongTrong.AllowUserToAddRows = false;
            dgvPhongTrong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhongTrong.Location = new Point(1, 173);
            dgvPhongTrong.Name = "dgvPhongTrong";
            dgvPhongTrong.ReadOnly = true;
            dgvPhongTrong.RowHeadersWidth = 51;
            dgvPhongTrong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhongTrong.Size = new Size(419, 136);
            dgvPhongTrong.TabIndex = 7;
            dgvPhongTrong.CellContentClick += dataGridView1_CellContentClick;
            // 
            // cboKhach
            // 
            cboKhach.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhach.FormattingEnabled = true;
            cboKhach.Location = new Point(194, 55);
            cboKhach.Name = "cboKhach";
            cboKhach.Size = new Size(219, 28);
            cboKhach.TabIndex = 0;
            // 
            // lblPhongChon
            // 
            lblPhongChon.AutoSize = true;
            lblPhongChon.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPhongChon.Location = new Point(88, 127);
            lblPhongChon.Name = "lblPhongChon";
            lblPhongChon.Size = new Size(270, 28);
            lblPhongChon.TabIndex = 1;
            lblPhongChon.Text = "Hiển thị số phòng đang chọn";
            // 
            // btnDatPhong
            // 
            btnDatPhong.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDatPhong.ForeColor = Color.Blue;
            btnDatPhong.Location = new Point(117, 211);
            btnDatPhong.Name = "btnDatPhong";
            btnDatPhong.Size = new Size(220, 46);
            btnDatPhong.TabIndex = 2;
            btnDatPhong.Text = "Đặt phòng";
            btnDatPhong.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(25, 56);
            label4.Name = "label4";
            label4.Size = new Size(140, 23);
            label4.TabIndex = 8;
            label4.Text = "Thông tin khách";
            // 
            // dgvDatPhong
            // 
            dgvDatPhong.AllowUserToAddRows = false;
            dgvDatPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatPhong.Location = new Point(0, 26);
            dgvDatPhong.Name = "dgvDatPhong";
            dgvDatPhong.ReadOnly = true;
            dgvDatPhong.RowHeadersWidth = 51;
            dgvDatPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatPhong.Size = new Size(889, 235);
            dgvDatPhong.TabIndex = 0;
            // 
            // btnNhanPhong
            // 
            btnNhanPhong.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNhanPhong.Location = new Point(64, 267);
            btnNhanPhong.Name = "btnNhanPhong";
            btnNhanPhong.Size = new Size(227, 42);
            btnNhanPhong.TabIndex = 1;
            btnNhanPhong.Text = "Nhận phòng";
            btnNhanPhong.UseVisualStyleBackColor = true;
            // 
            // btnHuyDat
            // 
            btnHuyDat.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuyDat.Location = new Point(328, 267);
            btnHuyDat.Name = "btnHuyDat";
            btnHuyDat.Size = new Size(227, 42);
            btnHuyDat.TabIndex = 2;
            btnHuyDat.Text = "Hủy đặt phòng";
            btnHuyDat.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLamMoi.Location = new Point(592, 267);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(227, 42);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // DatPhongForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(906, 649);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "DatPhongForm";
            Text = "DatPhongForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPhongTrong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDatPhong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private DateTimePicker dtpNgayDen;
        private ComboBox cboLoaiPhong;
        private Label label1;
        private Button btnTimPhong;
        private DateTimePicker dtpNgayDi;
        private Label label3;
        private Label label2;
        private DataGridView dgvPhongTrong;
        private Label lblPhongChon;
        private ComboBox cboKhach;
        private Button btnDatPhong;
        private Label label4;
        private Button btnLamMoi;
        private Button btnHuyDat;
        private Button btnNhanPhong;
        private DataGridView dgvDatPhong;
    }
}