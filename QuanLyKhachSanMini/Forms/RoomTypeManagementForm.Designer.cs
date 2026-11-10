namespace QuanLyKhachSanMini.Forms
{
    partial class frmQuanLyLoaiPhong
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
            panel1 = new Panel();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            dgvLoaiPhong = new DataGridView();
            colMaLoai = new DataGridViewTextBoxColumn();
            colTenLoai = new DataGridViewTextBoxColumn();
            colGia = new DataGridViewTextBoxColumn();
            btnDong = new Button();
            btnLuuThayDoi = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoaiPhong).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnThem);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(823, 66);
            panel1.TabIndex = 0;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.IndianRed;
            btnXoa.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoa.ForeColor = SystemColors.ButtonHighlight;
            btnXoa.Location = new Point(317, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(130, 60);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = SystemColors.ButtonShadow;
            btnSua.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSua.ForeColor = SystemColors.ButtonHighlight;
            btnSua.Location = new Point(158, 3);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(130, 60);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.ActiveCaption;
            btnThem.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThem.ForeColor = SystemColors.ButtonHighlight;
            btnThem.Location = new Point(3, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(130, 60);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // dgvLoaiPhong
            // 
            dgvLoaiPhong.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvLoaiPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoaiPhong.Columns.AddRange(new DataGridViewColumn[] { colMaLoai, colTenLoai, colGia });
            dgvLoaiPhong.Location = new Point(12, 84);
            dgvLoaiPhong.Name = "dgvLoaiPhong";
            dgvLoaiPhong.RowHeadersWidth = 62;
            dgvLoaiPhong.Size = new Size(823, 348);
            dgvLoaiPhong.TabIndex = 3;
            // 
            // colMaLoai
            // 
            colMaLoai.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMaLoai.HeaderText = "Mã loại";
            colMaLoai.MinimumWidth = 8;
            colMaLoai.Name = "colMaLoai";
            // 
            // colTenLoai
            // 
            colTenLoai.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTenLoai.HeaderText = "Tên loại phòng";
            colTenLoai.MinimumWidth = 8;
            colTenLoai.Name = "colTenLoai";
            // 
            // colGia
            // 
            colGia.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colGia.HeaderText = "Giá / ngày (VNĐ)";
            colGia.MinimumWidth = 8;
            colGia.Name = "colGia";
            // 
            // btnDong
            // 
            btnDong.BackColor = SystemColors.ButtonShadow;
            btnDong.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDong.ForeColor = SystemColors.ButtonHighlight;
            btnDong.Location = new Point(513, 447);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(130, 60);
            btnDong.TabIndex = 4;
            btnDong.Text = "Dóng";
            btnDong.UseVisualStyleBackColor = false;
            btnDong.Click += btnDong_Click;
            // 
            // btnLuuThayDoi
            // 
            btnLuuThayDoi.BackColor = SystemColors.HotTrack;
            btnLuuThayDoi.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLuuThayDoi.ForeColor = SystemColors.ButtonHighlight;
            btnLuuThayDoi.Location = new Point(674, 447);
            btnLuuThayDoi.Name = "btnLuuThayDoi";
            btnLuuThayDoi.Size = new Size(161, 60);
            btnLuuThayDoi.TabIndex = 5;
            btnLuuThayDoi.Text = "Lưu Thay Đổi";
            btnLuuThayDoi.UseVisualStyleBackColor = false;
            btnLuuThayDoi.Click += btnLuuThayDoi_Click;
            // 
            // frmQuanLyLoaiPhong
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 520);
            Controls.Add(btnLuuThayDoi);
            Controls.Add(btnDong);
            Controls.Add(dgvLoaiPhong);
            Controls.Add(panel1);
            Name = "frmQuanLyLoaiPhong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Loại Phòng";
            Load += frmQuanLyLoaiPhong_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLoaiPhong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private DataGridView dgvLoaiPhong;
        private Button btnDong;
        private Button btnLuuThayDoi;
        private DataGridViewTextBoxColumn colMaLoai;
        private DataGridViewTextBoxColumn colTenLoai;
        private DataGridViewTextBoxColumn colGia;
    }
}