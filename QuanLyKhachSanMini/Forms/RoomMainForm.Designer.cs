namespace QuanLyKhachSanMini
{
    partial class frmRoomMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            TreeNode treeNode1 = new TreeNode("Tầng 1");
            TreeNode treeNode2 = new TreeNode("Tầng 2");
            TreeNode treeNode3 = new TreeNode("Tầng 3");
            TreeNode treeNode4 = new TreeNode("TẤT CẢ CÁC PHÒNG", new TreeNode[] { treeNode1, treeNode2, treeNode3 });
            ListViewGroup listViewGroup1 = new ListViewGroup("Sơ Đồ", HorizontalAlignment.Left);
            ListViewGroup listViewGroup2 = new ListViewGroup("Tầng 1", HorizontalAlignment.Left);
            ListViewGroup listViewGroup3 = new ListViewGroup("Tầng 2", HorizontalAlignment.Left);
            ListViewGroup listViewGroup4 = new ListViewGroup("Tầng 3", HorizontalAlignment.Left);
            ListViewItem listViewItem1 = new ListViewItem("Trống", 0);
            ListViewItem listViewItem2 = new ListViewItem("Có Khách", 1);
            ListViewItem listViewItem3 = new ListViewItem("Đang Dọn ", 2);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoomMain));
            mnsRoom = new MenuStrip();
            phòngToolStripMenuItem = new ToolStripMenuItem();
            thêmPhòngToolStripMenuItem = new ToolStripMenuItem();
            sửaPhòngToolStripMenuItem = new ToolStripMenuItem();
            xóaPhòngToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            thoátToolStripMenuItem = new ToolStripMenuItem();
            cácLoạiPhòngToolStripMenuItem = new ToolStripMenuItem();
            pnlListView = new Panel();
            tvRoom = new TreeView();
            lbTieuDe = new Label();
            pnlRoomView = new Panel();
            lvSoDo = new ListView();
            imageList1 = new ImageList(components);
            ssTrangThai = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            mnsRoom.SuspendLayout();
            pnlListView.SuspendLayout();
            pnlRoomView.SuspendLayout();
            ssTrangThai.SuspendLayout();
            SuspendLayout();
            // 
            // mnsRoom
            // 
            mnsRoom.ImageScalingSize = new Size(24, 24);
            mnsRoom.Items.AddRange(new ToolStripItem[] { phòngToolStripMenuItem, cácLoạiPhòngToolStripMenuItem });
            mnsRoom.Location = new Point(0, 0);
            mnsRoom.Name = "mnsRoom";
            mnsRoom.Size = new Size(1258, 33);
            mnsRoom.TabIndex = 0;
            mnsRoom.Text = "menuStrip1";
            // 
            // phòngToolStripMenuItem
            // 
            phòngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thêmPhòngToolStripMenuItem, sửaPhòngToolStripMenuItem, xóaPhòngToolStripMenuItem, toolStripSeparator1, thoátToolStripMenuItem });
            phòngToolStripMenuItem.Name = "phòngToolStripMenuItem";
            phòngToolStripMenuItem.Size = new Size(116, 29);
            phòngToolStripMenuItem.Text = "Chức Năng";
            // 
            // thêmPhòngToolStripMenuItem
            // 
            thêmPhòngToolStripMenuItem.Name = "thêmPhòngToolStripMenuItem";
            thêmPhòngToolStripMenuItem.Size = new Size(270, 34);
            thêmPhòngToolStripMenuItem.Text = "Thêm Phòng";
            thêmPhòngToolStripMenuItem.Click += thêmPhòngToolStripMenuItem_Click;
            // 
            // sửaPhòngToolStripMenuItem
            // 
            sửaPhòngToolStripMenuItem.Name = "sửaPhòngToolStripMenuItem";
            sửaPhòngToolStripMenuItem.Size = new Size(270, 34);
            sửaPhòngToolStripMenuItem.Text = "Sửa Phòng";
            sửaPhòngToolStripMenuItem.Click += sửaPhòngToolStripMenuItem_Click;
            // 
            // xóaPhòngToolStripMenuItem
            // 
            xóaPhòngToolStripMenuItem.Name = "xóaPhòngToolStripMenuItem";
            xóaPhòngToolStripMenuItem.Size = new Size(270, 34);
            xóaPhòngToolStripMenuItem.Text = "Xóa Phòng";
            xóaPhòngToolStripMenuItem.Click += xóaPhòngToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(267, 6);
            // 
            // thoátToolStripMenuItem
            // 
            thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            thoátToolStripMenuItem.Size = new Size(270, 34);
            thoátToolStripMenuItem.Text = "Thoát";
            thoátToolStripMenuItem.Click += thoátToolStripMenuItem_Click;
            // 
            // cácLoạiPhòngToolStripMenuItem
            // 
            cácLoạiPhòngToolStripMenuItem.Name = "cácLoạiPhòngToolStripMenuItem";
            cácLoạiPhòngToolStripMenuItem.Size = new Size(150, 29);
            cácLoạiPhòngToolStripMenuItem.Text = "Các Loại Phòng";
            cácLoạiPhòngToolStripMenuItem.Click += cácLoạiPhòngToolStripMenuItem_Click;
            // 
            // pnlListView
            // 
            pnlListView.Controls.Add(tvRoom);
            pnlListView.Controls.Add(lbTieuDe);
            pnlListView.Location = new Point(12, 36);
            pnlListView.Name = "pnlListView";
            pnlListView.Size = new Size(377, 636);
            pnlListView.TabIndex = 1;
            // 
            // tvRoom
            // 
            tvRoom.Dock = DockStyle.Bottom;
            tvRoom.Location = new Point(0, 44);
            tvRoom.Name = "tvRoom";
            treeNode1.Name = "npTang1";
            treeNode1.Text = "Tầng 1";
            treeNode2.Name = "npTang2";
            treeNode2.Text = "Tầng 2";
            treeNode3.Name = "npTang3";
            treeNode3.Text = "Tầng 3";
            treeNode4.Name = "nRoomView";
            treeNode4.Text = "TẤT CẢ CÁC PHÒNG";
            tvRoom.Nodes.AddRange(new TreeNode[] { treeNode4 });
            tvRoom.Size = new Size(377, 592);
            tvRoom.TabIndex = 0;
            tvRoom.AfterSelect += tvRoom_AfterSelect;
            // 
            // lbTieuDe
            // 
            lbTieuDe.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbTieuDe.Location = new Point(3, 0);
            lbTieuDe.Name = "lbTieuDe";
            lbTieuDe.Size = new Size(371, 38);
            lbTieuDe.TabIndex = 0;
            lbTieuDe.Text = "DANH SÁCH TẦNG/PHÒNG";
            lbTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRoomView
            // 
            pnlRoomView.Controls.Add(lvSoDo);
            pnlRoomView.Location = new Point(395, 36);
            pnlRoomView.Name = "pnlRoomView";
            pnlRoomView.Size = new Size(851, 636);
            pnlRoomView.TabIndex = 2;
            // 
            // lvSoDo
            // 
            lvSoDo.GroupImageList = imageList1;
            listViewGroup1.Header = "Sơ Đồ";
            listViewGroup1.Name = "lswgSoDo";
            listViewGroup2.Header = "Tầng 1";
            listViewGroup2.Name = "lsvgTang1";
            listViewGroup3.Header = "Tầng 2";
            listViewGroup3.Name = "lsvgTang2";
            listViewGroup4.Header = "Tầng 3";
            listViewGroup4.Name = "lsvgTang3";
            lvSoDo.Groups.AddRange(new ListViewGroup[] { listViewGroup1, listViewGroup2, listViewGroup3, listViewGroup4 });
            lvSoDo.HeaderStyle = ColumnHeaderStyle.None;
            listViewItem1.Group = listViewGroup1;
            listViewItem2.Group = listViewGroup1;
            listViewItem3.Group = listViewGroup1;
            lvSoDo.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3 });
            lvSoDo.LargeImageList = imageList1;
            lvSoDo.Location = new Point(3, 3);
            lvSoDo.Name = "lvSoDo";
            lvSoDo.Size = new Size(845, 630);
            lvSoDo.SmallImageList = imageList1;
            lvSoDo.TabIndex = 0;
            lvSoDo.UseCompatibleStateImageBehavior = false;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "Index 0");
            imageList1.Images.SetKeyName(1, "Index 1");
            imageList1.Images.SetKeyName(2, "Index 2");
            // 
            // ssTrangThai
            // 
            ssTrangThai.ImageScalingSize = new Size(24, 24);
            ssTrangThai.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            ssTrangThai.Location = new Point(0, 697);
            ssTrangThai.Name = "ssTrangThai";
            ssTrangThai.Size = new Size(1258, 32);
            ssTrangThai.TabIndex = 3;
            ssTrangThai.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(179, 25);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // frmRoomMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 729);
            Controls.Add(ssTrangThai);
            Controls.Add(pnlRoomView);
            Controls.Add(pnlListView);
            Controls.Add(mnsRoom);
            MainMenuStrip = mnsRoom;
            Name = "frmRoomMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Phòng";
            FormClosing += RoomMainForm_FormClosing;
            Load += frmRoomMain_Load;
            mnsRoom.ResumeLayout(false);
            mnsRoom.PerformLayout();
            pnlListView.ResumeLayout(false);
            pnlRoomView.ResumeLayout(false);
            ssTrangThai.ResumeLayout(false);
            ssTrangThai.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnsRoom;
        private ToolStripMenuItem phòngToolStripMenuItem;
        private ToolStripMenuItem thêmPhòngToolStripMenuItem;
        private ToolStripMenuItem sửaPhòngToolStripMenuItem;
        private ToolStripMenuItem xóaPhòngToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem thoátToolStripMenuItem;
        private Panel pnlListView;
        private Panel pnlRoomView;
        private Label lbTieuDe;
        private TreeView tvRoom;
        private ListView lvSoDo;
        private ImageList imageList1;
        private ToolStripMenuItem cácLoạiPhòngToolStripMenuItem;
        private StatusStrip ssTrangThai;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}
