namespace QuanLyKhachSanMini.Forms
{
    partial class frmThemPhong
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
            lblTieuDe = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnHuy = new Button();
            btnLuu = new Button();
            txtSoPhong = new TextBox();
            numTang = new NumericUpDown();
            cboLoaiPhong = new ComboBox();
            cboTrangThai = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numTang).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.ForeColor = SystemColors.MenuHighlight;
            lblTieuDe.Location = new Point(12, 9);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(501, 38);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "THÔNG TIN PHÒNG MỚI";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 69);
            label1.Name = "label1";
            label1.Size = new Size(107, 29);
            label1.TabIndex = 1;
            label1.Text = "Số Phòng:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 125);
            label2.Name = "label2";
            label2.Size = new Size(65, 29);
            label2.TabIndex = 2;
            label2.Text = "Tầng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 184);
            label3.Name = "label3";
            label3.Size = new Size(119, 29);
            label3.TabIndex = 3;
            label3.Text = "Loại Phòng:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 250);
            label4.Name = "label4";
            label4.Size = new Size(115, 29);
            label4.TabIndex = 4;
            label4.Text = "Trạng Thái:";
            // 
            // btnHuy
            // 
            btnHuy.BackColor = SystemColors.ActiveCaption;
            btnHuy.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuy.ForeColor = SystemColors.ButtonHighlight;
            btnHuy.Location = new Point(394, 302);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(119, 64);
            btnHuy.TabIndex = 5;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = SystemColors.ControlDark;
            btnLuu.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLuu.ForeColor = SystemColors.ButtonHighlight;
            btnLuu.Location = new Point(269, 302);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(119, 64);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // txtSoPhong
            // 
            txtSoPhong.Location = new Point(125, 67);
            txtSoPhong.Name = "txtSoPhong";
            txtSoPhong.Size = new Size(388, 31);
            txtSoPhong.TabIndex = 0;
            // 
            // numTang
            // 
            numTang.Location = new Point(125, 123);
            numTang.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numTang.Name = "numTang";
            numTang.Size = new Size(180, 31);
            numTang.TabIndex = 1;
            numTang.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cboLoaiPhong
            // 
            cboLoaiPhong.FormattingEnabled = true;
            cboLoaiPhong.Location = new Point(137, 184);
            cboLoaiPhong.Name = "cboLoaiPhong";
            cboLoaiPhong.Size = new Size(278, 33);
            cboLoaiPhong.TabIndex = 2;
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(137, 246);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(278, 33);
            cboTrangThai.TabIndex = 3;
            // 
            // frmThemPhong
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 378);
            Controls.Add(cboTrangThai);
            Controls.Add(cboLoaiPhong);
            Controls.Add(numTang);
            Controls.Add(txtSoPhong);
            Controls.Add(btnLuu);
            Controls.Add(btnHuy);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblTieuDe);
            Name = "frmThemPhong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddRoomForm";
            Load += frmThemPhong_Load;
            ((System.ComponentModel.ISupportInitialize)numTang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnHuy;
        private Button btnLuu;
        private TextBox txtSoPhong;
        private NumericUpDown numTang;
        private ComboBox cboLoaiPhong;
        private ComboBox cboTrangThai;
    }
}