namespace QuanLyKhachSanMini.Forms
{
    partial class frmThemLoaiPhong
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
            lblTitle = new Label();
            lblMaLoai = new Label();
            lblTenLoai = new Label();
            lblGia = new Label();
            txtMaLoai = new TextBox();
            txtTenLoai = new TextBox();
            numGia = new NumericUpDown();
            btnHuy = new Button();
            btnLuu = new Button();
            ((System.ComponentModel.ISupportInitialize)numGia).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = SystemColors.MenuHighlight;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(516, 38);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "THÊM LOẠI PHÒNG";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMaLoai
            // 
            lblMaLoai.AutoSize = true;
            lblMaLoai.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMaLoai.Location = new Point(12, 47);
            lblMaLoai.Name = "lblMaLoai";
            lblMaLoai.Size = new Size(90, 29);
            lblMaLoai.TabIndex = 2;
            lblMaLoai.Text = "Mã Loại:";
            // 
            // lblTenLoai
            // 
            lblTenLoai.AutoSize = true;
            lblTenLoai.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTenLoai.Location = new Point(12, 109);
            lblTenLoai.Name = "lblTenLoai";
            lblTenLoai.Size = new Size(96, 29);
            lblTenLoai.TabIndex = 3;
            lblTenLoai.Text = "Tên Loại:";
            // 
            // lblGia
            // 
            lblGia.AutoSize = true;
            lblGia.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGia.Location = new Point(12, 182);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(48, 29);
            lblGia.TabIndex = 4;
            lblGia.Text = "Giá:";
            // 
            // txtMaLoai
            // 
            txtMaLoai.Location = new Point(124, 50);
            txtMaLoai.Name = "txtMaLoai";
            txtMaLoai.Size = new Size(376, 31);
            txtMaLoai.TabIndex = 0;
            // 
            // txtTenLoai
            // 
            txtTenLoai.Location = new Point(124, 109);
            txtTenLoai.Name = "txtTenLoai";
            txtTenLoai.Size = new Size(376, 31);
            txtTenLoai.TabIndex = 1;
            // 
            // numGia
            // 
            numGia.Increment = new decimal(new int[] { 50000, 0, 0, 0 });
            numGia.Location = new Point(124, 180);
            numGia.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numGia.Name = "numGia";
            numGia.Size = new Size(175, 31);
            numGia.TabIndex = 2;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = SystemColors.ButtonShadow;
            btnHuy.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHuy.ForeColor = SystemColors.ButtonHighlight;
            btnHuy.Location = new Point(242, 236);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(119, 52);
            btnHuy.TabIndex = 3;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = SystemColors.ActiveCaption;
            btnLuu.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLuu.ForeColor = SystemColors.ButtonHighlight;
            btnLuu.Location = new Point(381, 236);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(119, 52);
            btnLuu.TabIndex = 5;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // frmThemLoaiPhong
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 300);
            Controls.Add(btnLuu);
            Controls.Add(btnHuy);
            Controls.Add(numGia);
            Controls.Add(txtTenLoai);
            Controls.Add(txtMaLoai);
            Controls.Add(lblGia);
            Controls.Add(lblTenLoai);
            Controls.Add(lblMaLoai);
            Controls.Add(lblTitle);
            Name = "frmThemLoaiPhong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm Loại Phòng";
            ((System.ComponentModel.ISupportInitialize)numGia).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblMaLoai;
        private Label lblTenLoai;
        private Label lblGia;
        private TextBox txtMaLoai;
        private TextBox txtTenLoai;
        private NumericUpDown numGia;
        private Button btnHuy;
        private Button btnLuu;
    }
}