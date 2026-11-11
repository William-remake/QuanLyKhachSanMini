namespace QuanLyKhachSanMini.Forms
{
    partial class KhachForm
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
            dgvKhach = new DataGridView();
            grbKhach = new GroupBox();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtCCCD = new TextBox();
            txtHoTen = new TextBox();
            txtSDT = new TextBox();
            btnTim = new Button();
            txtTim = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvKhach).BeginInit();
            grbKhach.SuspendLayout();
            SuspendLayout();
            // 
            // dgvKhach
            // 
            dgvKhach.AllowUserToAddRows = false;
            dgvKhach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhach.Dock = DockStyle.Bottom;
            dgvKhach.Location = new Point(0, 248);
            dgvKhach.Name = "dgvKhach";
            dgvKhach.ReadOnly = true;
            dgvKhach.RowHeadersWidth = 51;
            dgvKhach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhach.Size = new Size(800, 306);
            dgvKhach.TabIndex = 0;
            // 
            // grbKhach
            // 
            grbKhach.Controls.Add(txtSDT);
            grbKhach.Controls.Add(txtHoTen);
            grbKhach.Controls.Add(txtCCCD);
            grbKhach.Controls.Add(label3);
            grbKhach.Controls.Add(label2);
            grbKhach.Controls.Add(label1);
            grbKhach.Controls.Add(btnLamMoi);
            grbKhach.Controls.Add(btnXoa);
            grbKhach.Controls.Add(btnSua);
            grbKhach.Controls.Add(btnThem);
            grbKhach.Location = new Point(0, 0);
            grbKhach.Name = "grbKhach";
            grbKhach.Size = new Size(800, 200);
            grbKhach.TabIndex = 1;
            grbKhach.TabStop = false;
            grbKhach.Text = "Khách hàng";
            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLamMoi.Location = new Point(602, 110);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(136, 42);
            btnLamMoi.TabIndex = 10;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(451, 110);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(136, 42);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(602, 52);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(136, 42);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(451, 52);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(136, 42);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 37);
            label1.Name = "label1";
            label1.Size = new Size(61, 28);
            label1.TabIndex = 11;
            label1.Text = "CCCD";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(26, 88);
            label2.Name = "label2";
            label2.Size = new Size(76, 28);
            label2.TabIndex = 12;
            label2.Text = "Họ tên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(26, 141);
            label3.Name = "label3";
            label3.Size = new Size(50, 28);
            label3.TabIndex = 13;
            label3.Text = "SĐT";
            // 
            // txtCCCD
            // 
            txtCCCD.Location = new Point(127, 41);
            txtCCCD.MaxLength = 12;
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(265, 27);
            txtCCCD.TabIndex = 14;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(127, 92);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(265, 27);
            txtHoTen.TabIndex = 15;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(127, 145);
            txtSDT.MaxLength = 11;
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(265, 27);
            txtSDT.TabIndex = 16;
            // 
            // btnTim
            // 
            btnTim.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTim.ForeColor = Color.Blue;
            btnTim.Location = new Point(514, 199);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(168, 43);
            btnTim.TabIndex = 7;
            btnTim.Text = "Tìm kiếm";
            btnTim.UseVisualStyleBackColor = true;
            // 
            // txtTim
            // 
            txtTim.Font = new Font("Segoe UI", 11F);
            txtTim.Location = new Point(40, 206);
            txtTim.Name = "txtTim";
            txtTim.PlaceholderText = "Tìm kiếm theo CCCD hoặc tên";
            txtTim.Size = new Size(443, 32);
            txtTim.TabIndex = 8;
            // 
            // KhachForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 554);
            Controls.Add(txtTim);
            Controls.Add(btnTim);
            Controls.Add(grbKhach);
            Controls.Add(dgvKhach);
            ForeColor = SystemColors.ControlText;
            Name = "KhachForm";
            Text = "KhachForm";
            ((System.ComponentModel.ISupportInitialize)dgvKhach).EndInit();
            grbKhach.ResumeLayout(false);
            grbKhach.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvKhach;
        private GroupBox grbKhach;
        private Label label1;
        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private TextBox txtSDT;
        private TextBox txtHoTen;
        private TextBox txtCCCD;
        private Label label3;
        private Label label2;
        private Button btnTim;
        private TextBox txtTim;
    }
}