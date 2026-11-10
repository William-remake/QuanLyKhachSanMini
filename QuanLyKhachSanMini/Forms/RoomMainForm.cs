using QuanLyKhachSanMini.Forms;

namespace QuanLyKhachSanMini
{
    public partial class frmRoomMain : Form
    {
        // Đường dẫn tới file chứa dữ liệu phòng
        private string filePath = "Data\\Phong.txt";

        // Danh sách lưu toàn bộ dữ liệu phòng để dùng cho việc lọc
        private List<RoomInfo> allRooms = new List<RoomInfo>();

        // Class đại diện cho thông tin một phòng
        public class RoomInfo
        {
            public string SoPhong { get; set; }
            public string LoaiPhong { get; set; }
            public string Tang { get; set; }
            public string TrangThai { get; set; }
        }

        public frmRoomMain()
        {
            InitializeComponent();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thêmPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmThemPhong frm = new frmThemPhong())
            {
                // Kiểm tra nếu người dùng bấm Lưu (DialogResult.OK)
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Lấy dữ liệu từ các control của form thêm phòng
                    string soPhong = frm.SoPhong;
                    string loaiPhong = frm.LoaiPhong;
                    string tang = frm.Tang;
                    string trangThai = frm.TrangThai;

                    // Tạo chuỗi đúng định dạng phân cách bằng dấu gạch đứng | giống trong Phong.txt
                    string newRoomLine = $"{soPhong}|{loaiPhong}|{tang}|{trangThai}";

                    // Đảm bảo thư mục "Data" tồn tại trước khi ghi file
                    string dir = Path.GetDirectoryName(filePath);
                    if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    // Ghi nối tiếp dòng mới vào file Phong.txt
                    File.AppendAllText(filePath, newRoomLine + Environment.NewLine);

                    //CẬP NHẬT GIAO DIỆN NGAY LẬP TỨC:
                    // 1. Đọc lại toàn bộ dữ liệu từ file vào bộ nhớ (allRooms)
                    LoadDataFromFile();
                    // 2. Vẽ lại cây TreeView (để hiện thêm phòng con dưới tầng tương ứng)
                    BuildTreeView();
                    // 3. Hiển thị lại danh sách lên ListView (Sơ đồ)
                    DisplayRoomsOnListView(allRooms);

                    MessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void RoomMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void cácLoạiPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyLoaiPhong f = new frmQuanLyLoaiPhong();
            f.ShowDialog();
            this.Show();
        }

        private void frmRoomMain_Load(object sender, EventArgs e)
        {
            // Kiểm tra và tạo thư mục/file mẫu nếu chưa có
            EnsureDataFileExists();

            // Load dữ liệu lên TreeView và Sơ đồ
            LoadDataFromFile();

            BuildTreeView();

            // Mặc định ban đầu hiển thị tất cả các phòng lên ListView
            DisplayRoomsOnListView(allRooms);
        }

        private void EnsureDataFileExists()
        {
            string dir = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (!File.Exists(filePath))
            {
                string sampleData =
                    "101|Phòng Standard|1|Trống\n" +
                    "102|Phòng Deluxe|1|Có khách\n" +
                    "103|Phòng Standard|1|Đang dọn\n" +
                    "201|Phòng Standard|2|Trống\n" +
                    "202|Phòng VIP|2|Có khách\n" +
                    "301|Phòng Standard|3|Đang dọn";
                File.WriteAllText(filePath, sampleData);
            }
        }

        private void LoadDataFromFile()
        {
            allRooms.Clear();
            if (!File.Exists(filePath)) return;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');
                if (parts.Length >= 4)
                {
                    allRooms.Add(new RoomInfo
                    {
                        SoPhong = parts[0].Trim(),
                        LoaiPhong = parts[1].Trim(),
                        Tang = parts[2].Trim(),
                        TrangThai = parts[3].Trim()
                    });
                }
            }
        }

        // Xây dựng cây TreeView (3 tầng cố định và các phòng con)
        private void BuildTreeView()
        {
            tvRoom.Nodes.Clear();
            TreeNode rootNode = tvRoom.Nodes.Add("Tất cả các phòng");

            TreeNode nodeTang1 = rootNode.Nodes.Add("Tầng 1");
            TreeNode nodeTang2 = rootNode.Nodes.Add("Tầng 2");
            TreeNode nodeTang3 = rootNode.Nodes.Add("Tầng 3");

            foreach (var room in allRooms)
            {
                TreeNode roomNode = new TreeNode($"Phòng {room.SoPhong} - {room.LoaiPhong}");
                // Gắn đối tượng room vào thuộc tính Tag để dễ nhận diện khi click
                roomNode.Tag = room.SoPhong;

                if (room.Tang == "1") nodeTang1.Nodes.Add(roomNode);
                else if (room.Tang == "2") nodeTang2.Nodes.Add(roomNode);
                else if (room.Tang == "3") nodeTang3.Nodes.Add(roomNode);
            }

            tvRoom.ExpandAll();
        }

        // Hàm hiển thị danh sách phòng lên ListView (lvSoDo) theo nhóm tầng
        private void DisplayRoomsOnListView(List<RoomInfo> roomsToDisplay)
        {
            lvSoDo.Items.Clear();
            lvSoDo.Groups.Clear();

            // Tạo các Group theo tầng cho ListView giống mẫu thiết kế
            ListViewGroup groupTang1 = new ListViewGroup("Tầng 1", HorizontalAlignment.Left);
            ListViewGroup groupTang2 = new ListViewGroup("Tầng 2", HorizontalAlignment.Left);
            ListViewGroup groupTang3 = new ListViewGroup("Tầng 3", HorizontalAlignment.Left);

            lvSoDo.Groups.Add(groupTang1);
            lvSoDo.Groups.Add(groupTang2);
            lvSoDo.Groups.Add(groupTang3);

            lvSoDo.View = View.LargeIcon; // Đảm bảo hiển thị dạng khối màu

            foreach (var room in roomsToDisplay)
            {
                ListViewItem item = new ListViewItem();

                // Thêm dấu "-" ở giữa số phòng và loại phòng theo ý bạn
                item.Text = $"Phòng {room.SoPhong} - {room.LoaiPhong}";

                item.ForeColor = Color.White;
                item.BackColor = GetStatusColor(room.TrangThai);
                item.Tag = room.SoPhong; // Lưu mã phòng vào Tag để phục vụ việc lọc

                // Đưa vào group tương ứng theo tầng
                if (room.Tang == "1") item.Group = groupTang1;
                else if (room.Tang == "2") item.Group = groupTang2;
                else if (room.Tang == "3") item.Group = groupTang3;

                lvSoDo.Items.Add(item);
            }
        }

        // Hàm tự động đổi màu sắc theo trạng thái yêu cầu
        private Color GetStatusColor(string trangThai)
        {
            // Chuyển về chữ thường để so sánh chính xác tránh lỗi viết hoa/thường
            string status = trangThai.Trim().ToLower();

            if (status.Contains("trống"))
            {
                return Color.SeaGreen;       // Xanh lá (Trống)
            }
            else if (status.Contains("khách"))
            {
                return Color.IndianRed;      // Đỏ (Có khách)
            }
            else if (status.Contains("dọn"))
            {
                return Color.Goldenrod;      // Vàng / Cam (Đang dọn)
            }

            return Color.Gray; // Mặc định nếu không khớp
        }

        private void tvRoom_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string nodeText = e.Node.Text;

            if (nodeText.Contains("Tất cả các phòng"))
            {
                // Bấm tất cả: Hiển thị đầy đủ toàn bộ phòng
                DisplayRoomsOnListView(allRooms);
            }
            else if (nodeText.Equals("Tầng 1"))
            {
                // Bấm Tầng 1: Lọc các phòng thuộc Tầng 1
                var filtered = allRooms.Where(r => r.Tang == "1").ToList();
                DisplayRoomsOnListView(filtered);
            }
            else if (nodeText.Equals("Tầng 2"))
            {
                // Bấm Tầng 2: Lọc các phòng thuộc Tầng 2
                var filtered = allRooms.Where(r => r.Tang == "2").ToList();
                DisplayRoomsOnListView(filtered);
            }
            else if (nodeText.Equals("Tầng 3"))
            {
                // Bấm Tầng 3: Lọc các phòng thuộc Tầng 3
                var filtered = allRooms.Where(r => r.Tang == "3").ToList();
                DisplayRoomsOnListView(filtered);
            }
            else if (e.Node.Tag != null)
            {
                // Bấm vào 1 phòng cụ thể: Chỉ hiển thị đúng phòng đó
                string soPhongClick = e.Node.Tag.ToString();
                var filtered = allRooms.Where(r => r.SoPhong == soPhongClick).ToList();
                DisplayRoomsOnListView(filtered);
            }
        }

        private void xóaPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string soPhongCanXoa = "";

            // 1. Kiểm tra xem người dùng đang chọn phòng nào trên ListView (Sơ đồ)
            if (lvSoDo.SelectedItems.Count > 0)
            {
                // Lấy mã phòng từ thuộc tính Tag đã gán lúc nạp dữ liệu
                soPhongCanXoa = lvSoDo.SelectedItems[0].Tag?.ToString();
            }
            // 2. Nếu không chọn trên ListView, kiểm tra xem có đang chọn phòng cụ thể trên TreeView không
            else if (tvRoom.SelectedNode != null && tvRoom.SelectedNode.Tag != null)
            {
                soPhongCanXoa = tvRoom.SelectedNode.Tag.ToString();
            }

            // 3. Nếu chưa chọn phòng nào hợp lệ
            if (string.IsNullOrEmpty(soPhongCanXoa))
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa trên sơ đồ hoặc danh sách tầng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Hiển thị hộp thoại xác nhận MessageBox.OKCancel theo yêu cầu
            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc muốn xóa phòng {soPhongCanXoa} này không?",
                "Xác nhận xóa",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            // 5. Nếu người dùng bấm OK
            if (dr == DialogResult.OK)
            {
                // Xóa phòng khỏi danh sách trong bộ nhớ (allRooms)
                allRooms.RemoveAll(r => r.SoPhong == soPhongCanXoa);

                // Ghi đè lại toàn bộ danh sách mới vào file Phong.txt
                List<string> lines = new List<string>();
                foreach (var room in allRooms)
                {
                    lines.Add($"{room.SoPhong}|{room.LoaiPhong}|{room.Tang}|{room.TrangThai}");
                }
                File.WriteAllLines(filePath, lines);

                // Cập nhật lại giao diện TreeView và ListView ngay lập tức
                BuildTreeView();
                DisplayRoomsOnListView(allRooms);

                MessageBox.Show("Đã xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void sửaPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string soPhongDangChon = "";

            // 1. Kiểm tra xem người dùng đang chọn phòng nào trên ListView (Sơ đồ)
            if (lvSoDo.SelectedItems.Count > 0)
            {
                soPhongDangChon = lvSoDo.SelectedItems[0].Tag?.ToString();
            }
            // 2. Hoặc kiểm tra xem đang chọn phòng nào trên TreeView (Danh sách tầng)
            else if (tvRoom.SelectedNode != null && tvRoom.SelectedNode.Tag != null)
            {
                soPhongDangChon = tvRoom.SelectedNode.Tag.ToString();
            }

            // 3. Nếu chưa chọn phòng hợp lệ
            if (string.IsNullOrEmpty(soPhongDangChon))
            {
                MessageBox.Show("Vui lòng chọn một phòng cụ thể trên sơ đồ hoặc danh sách tầng để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tìm thông tin phòng trong danh sách bộ nhớ (allRooms)
            var roomToEdit = allRooms.FirstOrDefault(r => r.SoPhong == soPhongDangChon);
            if (roomToEdit == null) return;

            // 4. Mở form EditRoomForm và truyền dữ liệu hiện tại vào
            using (frmEditRoom frm = new frmEditRoom(roomToEdit.SoPhong, roomToEdit.Tang, roomToEdit.LoaiPhong, roomToEdit.TrangThai))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Cập nhật thông tin mới vào đối tượng phòng
                    roomToEdit.SoPhong = frm.SoPhong;
                    roomToEdit.Tang = frm.Tang;
                    roomToEdit.LoaiPhong = frm.LoaiPhong;
                    roomToEdit.TrangThai = frm.TrangThai;

                    // 5. Ghi đè toàn bộ danh sách mới xuống file Phong.txt
                    List<string> lines = new List<string>();
                    foreach (var room in allRooms)
                    {
                        lines.Add($"{room.SoPhong}|{room.LoaiPhong}|{room.Tang}|{room.TrangThai}");
                    }
                    File.WriteAllLines(filePath, lines);

                    // 6. Cập nhật lại giao diện TreeView và ListView ngay lập tức
                    BuildTreeView();
                    DisplayRoomsOnListView(allRooms);

                    MessageBox.Show("Cập nhật thông tin phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
