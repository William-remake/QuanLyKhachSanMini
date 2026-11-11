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
            dgvPhongTrong = new DataGridView();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnTimPhong = new Button();
            dtpNgayDi = new DateTimePicker();
            dtpNgayDen = new DateTimePicker();
            cboLoaiPhong = new ComboBox();
            groupBox2 = new GroupBox();
            label4 = new Label();
            btnDatPhong = new Button();
            lblPhongChon = new Label();
            cboKhach = new ComboBox();
            groupBox3 = new GroupBox();
            btnLamMoi = new Button();
            btnHuyDat = new Button();
            btnNhanPhong = new Button();
            dgvDatPhong = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhongTrong).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
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
            groupBox1.Location = new Point(8, 6);
            groupBox1.Margin = new Padding(4, 4, 4, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 4, 4, 4);
            groupBox1.Size = new Size(525, 394);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm phòng trống";
            // 
            // dgvPhongTrong
            // 
            dgvPhongTrong.AllowUserToAddRows = false;
            dgvPhongTrong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhongTrong.Location = new Point(1, 216);
            dgvPhongTrong.Margin = new Padding(4, 4, 4, 4);
            dgvPhongTrong.Name = "dgvPhongTrong";
            dgvPhongTrong.ReadOnly = true;
            dgvPhongTrong.RowHeadersWidth = 51;
            dgvPhongTrong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhongTrong.Size = new Size(524, 170);
            dgvPhongTrong.TabIndex = 7;
            dgvPhongTrong.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(21, 120);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(90, 30);
            label3.TabIndex = 6;
            label3.Text = "Ngày đi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 81);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(108, 30);
            label2.TabIndex = 5;
            label2.Text = "Ngày đến";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 36);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(178, 30);
            label1.TabIndex = 4;
            label1.Text = "Chọn loại phòng";
            label1.Click += label1_Click;
            // 
            // btnTimPhong
            // 
            btnTimPhong.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimPhong.ForeColor = Color.Blue;
            btnTimPhong.Location = new Point(124, 164);
            btnTimPhong.Margin = new Padding(4, 4, 4, 4);
            btnTimPhong.Name = "btnTimPhong";
            btnTimPhong.Size = new Size(270, 45);
            btnTimPhong.TabIndex = 3;
            btnTimPhong.Text = "Tìm phòng trống";
            btnTimPhong.UseVisualStyleBackColor = true;
            // 
            // dtpNgayDi
            // 
            dtpNgayDi.Format = DateTimePickerFormat.Short;
            dtpNgayDi.Location = new Point(205, 116);
            dtpNgayDi.Margin = new Padding(4, 4, 4, 4);
            dtpNgayDi.Name = "dtpNgayDi";
            dtpNgayDi.Size = new Size(284, 31);
            dtpNgayDi.TabIndex = 2;
            // 
            // dtpNgayDen
            // 
            dtpNgayDen.Format = DateTimePickerFormat.Short;
            dtpNgayDen.Location = new Point(205, 75);
            dtpNgayDen.Margin = new Padding(4, 4, 4, 4);
            dtpNgayDen.Name = "dtpNgayDen";
            dtpNgayDen.Size = new Size(284, 31);
            dtpNgayDen.TabIndex = 1;
            // 
            // cboLoaiPhong
            // 
            cboLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiPhong.FormattingEnabled = true;
            cboLoaiPhong.Location = new Point(205, 32);
            cboLoaiPhong.Margin = new Padding(4, 4, 4, 4);
            cboLoaiPhong.Name = "cboLoaiPhong";
            cboLoaiPhong.Size = new Size(188, 33);
            cboLoaiPhong.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(btnDatPhong);
            groupBox2.Controls.Add(lblPhongChon);
            groupBox2.Controls.Add(cboKhach);
            groupBox2.Location = new Point(558, 11);
            groupBox2.Margin = new Padding(4, 4, 4, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 4, 4, 4);
            groupBox2.Size = new Size(562, 381);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin đặt";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(31, 70);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(175, 30);
            label4.TabIndex = 8;
            label4.Text = "Thông tin khách";
            // 
            // btnDatPhong
            // 
            btnDatPhong.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDatPhong.ForeColor = Color.Blue;
            btnDatPhong.Location = new Point(146, 264);
            btnDatPhong.Margin = new Padding(4, 4, 4, 4);
            btnDatPhong.Name = "btnDatPhong";
            btnDatPhong.Size = new Size(275, 58);
            btnDatPhong.TabIndex = 2;
            btnDatPhong.Text = "Đặt phòng";
            btnDatPhong.UseVisualStyleBackColor = true;
            // 
            // lblPhongChon
            // 
            lblPhongChon.AutoSize = true;
            lblPhongChon.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPhongChon.Location = new Point(110, 159);
            lblPhongChon.Margin = new Padding(4, 0, 4, 0);
            lblPhongChon.Name = "lblPhongChon";
            lblPhongChon.Size = new Size(329, 32);
            lblPhongChon.TabIndex = 1;
            lblPhongChon.Text = "Hiển thị số phòng đang chọn";
            // 
            // cboKhach
            // 
            cboKhach.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhach.FormattingEnabled = true;
            cboKhach.Location = new Point(242, 69);
            cboKhach.Margin = new Padding(4, 4, 4, 4);
            cboKhach.Name = "cboKhach";
            cboKhach.Size = new Size(273, 33);
            cboKhach.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnLamMoi);
            groupBox3.Controls.Add(btnHuyDat);
            groupBox3.Controls.Add(btnNhanPhong);
            groupBox3.Controls.Add(dgvDatPhong);
            groupBox3.Location = new Point(9, 408);
            groupBox3.Margin = new Padding(4, 4, 4, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 4, 4, 4);
            groupBox3.Size = new Size(1111, 394);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Danh sách đặt phòng";
            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLamMoi.Location = new Point(740, 334);
            btnLamMoi.Margin = new Padding(4, 4, 4, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(284, 52);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnHuyDat
            // 
            btnHuyDat.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuyDat.Location = new Point(410, 334);
            btnHuyDat.Margin = new Padding(4, 4, 4, 4);
            btnHuyDat.Name = "btnHuyDat";
            btnHuyDat.Size = new Size(284, 52);
            btnHuyDat.TabIndex = 2;
            btnHuyDat.Text = "Hủy đặt phòng";
            btnHuyDat.UseVisualStyleBackColor = true;
            // 
            // btnNhanPhong
            // 
            btnNhanPhong.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNhanPhong.Location = new Point(80, 334);
            btnNhanPhong.Margin = new Padding(4, 4, 4, 4);
            btnNhanPhong.Name = "btnNhanPhong";
            btnNhanPhong.Size = new Size(284, 52);
            btnNhanPhong.TabIndex = 1;
            btnNhanPhong.Text = "Nhận phòng";
            btnNhanPhong.UseVisualStyleBackColor = true;
            btnNhanPhong.Click += btnNhanPhong_Click_1;
            // 
            // dgvDatPhong
            // 
            dgvDatPhong.AllowUserToAddRows = false;
            dgvDatPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatPhong.Location = new Point(0, 32);
            dgvDatPhong.Margin = new Padding(4, 4, 4, 4);
            dgvDatPhong.Name = "dgvDatPhong";
            dgvDatPhong.ReadOnly = true;
            dgvDatPhong.RowHeadersWidth = 51;
            dgvDatPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatPhong.Size = new Size(1111, 294);
            dgvDatPhong.TabIndex = 0;
            // 
            // DatPhongForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 811);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "DatPhongForm";
            Text = "DatPhongForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhongTrong).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
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