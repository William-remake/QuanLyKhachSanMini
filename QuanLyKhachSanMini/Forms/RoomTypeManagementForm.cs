using QuanLyKhachSanMini.Models;
using System.Globalization;

namespace QuanLyKhachSanMini.Forms
{
    public partial class frmQuanLyLoaiPhong : Form
    {
        private List<LoaiPhong> _banDau = new();

        public frmQuanLyLoaiPhong()
        {
            InitializeComponent();
        }

        private void frmQuanLyLoaiPhong_Load(object sender, EventArgs e)
        {
            dgvLoaiPhong.AllowUserToAddRows = false;
            dgvLoaiPhong.ReadOnly = false;
            dgvLoaiPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoaiPhong.MultiSelect = false;
            dgvLoaiPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoaiPhong.Columns[0].ReadOnly = true; // Mã loại được quản lý bằng khóa duy nhất.
            colGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            TaiDanhSach();
        }

        private void TaiDanhSach()
        {
            _banDau = DuLieu.DocLoaiPhong();
            dgvLoaiPhong.Rows.Clear();
            foreach (var lp in _banDau)
                dgvLoaiPhong.Rows.Add(lp.MaLoai, lp.TenLoai, lp.Gia.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (frmThemLoaiPhong frm = new frmThemLoaiPhong())
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                bool trungMa = dgvLoaiPhong.Rows.Cast<DataGridViewRow>().Any(r =>
                    string.Equals(Convert.ToString(r.Cells["colMaLoai"].Value)?.Trim(), frm.MaLoai, StringComparison.OrdinalIgnoreCase));
                bool trungTen = dgvLoaiPhong.Rows.Cast<DataGridViewRow>().Any(r =>
                    string.Equals(Convert.ToString(r.Cells["colTenLoai"].Value)?.Trim(), frm.TenLoai, StringComparison.OrdinalIgnoreCase));
                if (trungMa || trungTen)
                {
                    MessageBox.Show("Mã loại hoặc tên loại phòng đã tồn tại.", "Trùng dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvLoaiPhong.Rows.Add(frm.MaLoai, frm.TenLoai,
                    frm.Gia.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")));
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLoaiPhong.CurrentRow == null || dgvLoaiPhong.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần sửa.", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cho phép sửa trực tiếp Tên loại và Giá trên lưới hiện tại.
            dgvLoaiPhong.CurrentCell = dgvLoaiPhong.CurrentRow.Cells["colTenLoai"];
            dgvLoaiPhong.BeginEdit(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLoaiPhong.CurrentRow == null || dgvLoaiPhong.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần xóa.", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maLoai = Convert.ToString(dgvLoaiPhong.CurrentRow.Cells["colMaLoai"].Value)?.Trim() ?? "";
            string tenLoai = Convert.ToString(dgvLoaiPhong.CurrentRow.Cells["colTenLoai"].Value)?.Trim() ?? "";
            if (DuLieu.DocPhong().Any(p => p.Loai.Equals(tenLoai, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Có phòng đang sử dụng loại phòng này. Hãy đổi loại cho các phòng trước khi xóa.",
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xóa loại phòng {maLoai} - {tenLoai}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgvLoaiPhong.Rows.Remove(dgvLoaiPhong.CurrentRow);
        }

        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            dgvLoaiPhong.EndEdit();
            var dsMoi = new List<LoaiPhong>();
            foreach (DataGridViewRow row in dgvLoaiPhong.Rows)
            {
                if (row.IsNewRow) continue;
                string ma = Convert.ToString(row.Cells["colMaLoai"].Value)?.Trim() ?? "";
                string ten = Convert.ToString(row.Cells["colTenLoai"].Value)?.Trim() ?? "";
                string giaText = Convert.ToString(row.Cells["colGia"].Value)?.Trim() ?? "";

                if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten)
                    || ma.Contains('|') || ten.Contains('|')
                    || !TryParseGia(giaText, out decimal gia) || gia <= 0)
                {
                    MessageBox.Show("Mỗi loại phòng phải có mã, tên và giá lớn hơn 0 hợp lệ.",
                        "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dsMoi.Add(new LoaiPhong { MaLoai = ma, TenLoai = ten, Gia = gia });
            }

            if (dsMoi.Count == 0)
            {
                MessageBox.Show("Phải có ít nhất một loại phòng.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dsMoi.Select(x => x.MaLoai).Distinct(StringComparer.OrdinalIgnoreCase).Count() != dsMoi.Count
                || dsMoi.Select(x => x.TenLoai).Distinct(StringComparer.OrdinalIgnoreCase).Count() != dsMoi.Count)
            {
                MessageBox.Show("Mã loại và tên loại phòng không được trùng nhau.", "Trùng dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Không cho xóa một loại vẫn còn được một phòng tham chiếu.
            var rooms = DuLieu.DocPhong();
            var tenLoaiConDuocDung = rooms.Select(x => x.Loai).ToHashSet(StringComparer.OrdinalIgnoreCase);
            foreach (var oldType in _banDau)
            {
                bool conTonTai = dsMoi.Any(x => x.MaLoai.Equals(oldType.MaLoai, StringComparison.OrdinalIgnoreCase));
                if (!conTonTai && tenLoaiConDuocDung.Contains(oldType.TenLoai))
                {
                    MessageBox.Show($"Loại {oldType.TenLoai} đang được gán cho phòng. Không thể xóa.",
                        "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Đồng bộ danh mục loại phòng và tên loại đang được các phòng tham chiếu trong cùng giao dịch.
            DuLieu.ThucHienGiaoDich(() =>
            {
                foreach (var oldType in _banDau)
                {
                    var newType = dsMoi.FirstOrDefault(x => x.MaLoai.Equals(oldType.MaLoai, StringComparison.OrdinalIgnoreCase));
                    if (newType != null && !newType.TenLoai.Equals(oldType.TenLoai, StringComparison.OrdinalIgnoreCase))
                        DuLieu.CapNhatTenLoaiPhongThamChieu(oldType.TenLoai, newType.TenLoai);
                }

                DuLieu.GhiLoaiPhong(dsMoi);
            }, "LoaiPhong.txt", "Phong.txt");
            _banDau = dsMoi.Select(x => new LoaiPhong { MaLoai = x.MaLoai, TenLoai = x.TenLoai, Gia = x.Gia }).ToList();
            TaiDanhSach();
            MessageBox.Show("Đã lưu loại phòng và đồng bộ với danh sách phòng.", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static bool TryParseGia(string text, out decimal gia)
        {
            return decimal.TryParse(text, NumberStyles.Number, CultureInfo.GetCultureInfo("vi-VN"), out gia)
                || decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out gia);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
