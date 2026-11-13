using QuanLyKhachSanMini.Forms;
using QuanLyKhachSanMini.Models;

namespace QuanLyKhachSanMini
{
    public partial class frmRoomMain : Form
    {
        // Dùng chung thư mục Data với toàn bộ form và repository.
        private string filePath => DuLieu.LayDuongDanData("Phong.txt");

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
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                string soPhong = frm.SoPhong;
                string loaiPhong = frm.LoaiPhong;
                string tang = frm.Tang;
                string trangThai = frm.TrangThai;

                var rooms = DuLieu.DocPhong();
                if (rooms.Any(r => r.SoPhong.Equals(soPhong, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Số phòng đã tồn tại.", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (DuLieu.ChuanHoaTrangThaiPhong(trangThai) == "Có khách")
                {
                    MessageBox.Show("Chỉ chuyển phòng sang Có khách thông qua chức năng Nhận phòng.", "Trạng thái không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!DuLieu.DocLoaiPhong().Any(x => x.TenLoai.Equals(loaiPhong, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Loại phòng không còn tồn tại. Vui lòng chọn lại loại phòng.", "Dữ liệu không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                rooms.Add((soPhong, loaiPhong, tang, trangThai));
                DuLieu.GhiPhong(rooms);
                LoadDataFromFile();
                BuildTreeView();
                DisplayRoomsOnListView(allRooms);
                MessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RoomMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đóng màn hình quản lý phòng?", "Xác nhận", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void cácLoạiPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var f = new frmQuanLyLoaiPhong();
            f.ShowDialog(this);
            LoadDataFromFile();
            BuildTreeView();
            DisplayRoomsOnListView(allRooms);
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
            if (!File.Exists(filePath))
                DuLieu.GhiPhong(Array.Empty<(string SoPhong, string Loai, string Tang, string TrangThai)>());
        }

        private void LoadDataFromFile()
        {
            allRooms = DuLieu.DocPhong().Select(p => new RoomInfo
            {
                SoPhong = p.SoPhong,
                LoaiPhong = p.Loai,
                Tang = p.Tang,
                TrangThai = p.TrangThai
            }).ToList();
        }

        private void LuuDanhSachPhong()
        {
            DuLieu.GhiPhong(allRooms.Select(r => (r.SoPhong, r.LoaiPhong, r.Tang, r.TrangThai)));
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
                if (DuLieu.DocDatPhong().Any(d => d.SoPhong.Equals(soPhongCanXoa, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Phòng đã có lịch sử đặt phòng nên không thể xóa để bảo toàn dữ liệu.",
                        "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                allRooms.RemoveAll(r => r.SoPhong == soPhongCanXoa);
                LuuDanhSachPhong();
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
                    if (!frm.SoPhong.Equals(roomToEdit.SoPhong, StringComparison.OrdinalIgnoreCase)
                        && (DuLieu.DocDatPhong().Any(d => d.SoPhong.Equals(roomToEdit.SoPhong, StringComparison.OrdinalIgnoreCase))
                            || allRooms.Any(r => !ReferenceEquals(r, roomToEdit)
                                && r.SoPhong.Equals(frm.SoPhong, StringComparison.OrdinalIgnoreCase))))
                    {
                        MessageBox.Show("Không thể đổi số phòng đã có lịch sử đặt phòng hoặc số phòng mới đã tồn tại.",
                            "Không thể cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!DuLieu.DocLoaiPhong().Any(x => x.TenLoai.Equals(frm.LoaiPhong, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("Loại phòng đã bị xóa hoặc không hợp lệ. Vui lòng chọn lại.",
                            "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    var lichSuPhong = DuLieu.DocDatPhong().Where(d =>
                        d.SoPhong.Equals(roomToEdit.SoPhong, StringComparison.OrdinalIgnoreCase)).ToList();
                    bool dangCoKhach = lichSuPhong.Any(d => DuLieu.LaTrangThaiDangLuuTru(d.TrangThai));
                    bool conDatPhong = lichSuPhong.Any(d => d.TrangThai == "DaDat" || DuLieu.LaTrangThaiDangLuuTru(d.TrangThai));
                    if (conDatPhong && !roomToEdit.LoaiPhong.Equals(frm.LoaiPhong, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Không thể đổi loại phòng khi phòng đã có lượt đặt/đang lưu trú. Đơn giá đã được chốt theo lượt đặt.",
                            "Không thể đổi loại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string trangThaiMoi = DuLieu.ChuanHoaTrangThaiPhong(frm.TrangThai);
                    if (dangCoKhach && !trangThaiMoi.Equals("Có khách", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Phòng đang có lượt lưu trú. Chỉ được đổi trạng thái sau khi khách trả phòng.",
                            "Không thể đổi trạng thái", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!dangCoKhach && trangThaiMoi.Equals("Có khách", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Chỉ chuyển phòng sang Có khách thông qua chức năng Nhận phòng.",
                            "Trạng thái không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    roomToEdit.SoPhong = frm.SoPhong;
                    roomToEdit.Tang = frm.Tang;
                    roomToEdit.LoaiPhong = frm.LoaiPhong;
                    roomToEdit.TrangThai = frm.TrangThai;

                    LuuDanhSachPhong();
                    BuildTreeView();
                    DisplayRoomsOnListView(allRooms);
                    MessageBox.Show("Cập nhật thông tin phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
