using QuanLyKhachSanMini.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSanMini.Forms
{

    public partial class DichVuForm : Form
    {
        private readonly DichVuRepository _repo = new();
        private readonly ChiTietDichVuRepository _ctRepo = new();
        private List<DichVu> _ds = new();
        private List<DichVu> _dsApDung = new();
        private bool _dangNap = false;

        public DichVuForm()
        {
            InitializeComponent();
            dgvDichVu.CellClick += dgvDichVu_CellClick;
        }

        private void DichVuForm_Load(object sender, EventArgs e)
        {
            dgvDichVu.AutoGenerateColumns = false;
            if (dgvDichVu.Columns.Count == 0)
            {
                dgvDichVu.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMa", HeaderText = "Mã dịch vụ", DataPropertyName = "MaDV" });
                dgvDichVu.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTen", HeaderText = "Tên dịch vụ", DataPropertyName = "TenDV" });
                dgvDichVu.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDonVi", HeaderText = "Đơn vị", DataPropertyName = "DonVi" });
                dgvDichVu.Columns.Add(new DataGridViewTextBoxColumn { Name = "colGia", HeaderText = "Đơn giá (VNĐ)", DataPropertyName = "DonGia", DefaultCellStyle = { Format = "N0" } });
                dgvDichVu.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTrangThai", HeaderText = "Trạng thái" });
                foreach (DataGridViewColumn c in dgvDichVu.Columns)
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            TaiDuLieu();
            LamMoiForm();
            TaiTab2();
        }

        // =====================================================
        // TAB 1: DANH MỤC DỊCH VỤ
        // =====================================================

        private void TaiDuLieu()
        {
            _ds = _repo.LayTatCa();
            dgvDichVu.DataSource = null;
            dgvDichVu.DataSource = _ds;
            if (!dgvDichVu.Columns.Contains("colTrangThai")) return;
            foreach (DataGridViewRow row in dgvDichVu.Rows)
            {
                if (row.DataBoundItem is DichVu d)
                    row.Cells["colTrangThai"].Value = d.DangApDung ? "Đang áp dụng" : "Ngừng áp dụng";
            }
        }

        private void LamMoiForm()
        {
            txtMaDV.Text = _repo.SinhMaMoi();
            txtTenDV.Clear();
            txtDonVi.Clear();
            numDonGia.Value = 0;
            chkApDung.Checked = true;
            dgvDichVu.ClearSelection();
            txtTenDV.Focus();
        }

        private bool KiemTraNhap()
        {
            if (string.IsNullOrWhiteSpace(txtTenDV.Text))
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDV.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDonVi.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonVi.Focus();
                return false;
            }
            if (numDonGia.Value <= 0)
            {
                MessageBox.Show("Đơn giá phải lớn hơn 0.", "Sai dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDonGia.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraNhap()) return;

            if (_ds.Any(d => d.TenDV.Equals(txtTenDV.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Tên dịch vụ đã tồn tại.", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _ds.Add(new DichVu
            {
                MaDV = _repo.SinhMaMoi(),
                TenDV = txtTenDV.Text.Trim(),
                DonVi = txtDonVi.Text.Trim(),
                DonGia = numDonGia.Value,
                DangApDung = chkApDung.Checked
            });
            _repo.LuuTatCa(_ds);
            TaiDuLieu();
            LamMoiForm();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var dv = _ds.FirstOrDefault(d => d.MaDV == txtMaDV.Text);
            if (dv == null)
            {
                MessageBox.Show("Hãy chọn một dịch vụ trong bảng để cập nhật.", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!KiemTraNhap()) return;

            string tenMoi = txtTenDV.Text.Trim();
            if (_ds.Any(x => x.MaDV != dv.MaDV && x.TenDV.Equals(tenMoi, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Tên dịch vụ đã tồn tại.", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dv.TenDV = tenMoi;
            dv.DonVi = txtDonVi.Text.Trim();
            dv.DonGia = numDonGia.Value;
            dv.DangApDung = chkApDung.Checked;
            _repo.LuuTatCa(_ds);
            TaiDuLieu();
            LamMoiForm();
        }

        private void btnNgungKich_Click(object sender, EventArgs e)
        {
            var dv = _ds.FirstOrDefault(d => d.MaDV == txtMaDV.Text);
            if (dv == null)
            {
                MessageBox.Show("Hãy chọn một dịch vụ trong bảng.", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dv.DangApDung = !dv.DangApDung;   // không xóa cứng, chỉ đổi cờ
            _repo.LuuTatCa(_ds);
            TaiDuLieu();
            LamMoiForm();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvDichVu.Rows[e.RowIndex].DataBoundItem is DichVu d)
            {
                txtMaDV.Text = d.MaDV;
                txtTenDV.Text = d.TenDV;
                txtDonVi.Text = d.DonVi;
                numDonGia.Value = d.DonGia;
                chkApDung.Checked = d.DangApDung;
            }
        }

        // =====================================================
        // TAB 2: GHI NHẬN DỊCH VỤ KHÁCH DÙNG
        // =====================================================

        private void TaiTab2()
        {
            _dangNap = true;

            if (dgvDichVuDaDung.Columns.Count == 0)
            {
                dgvDichVuDaDung.AllowUserToAddRows = false;
                dgvDichVuDaDung.ReadOnly = true;
                dgvDichVuDaDung.RowHeadersVisible = false;
                dgvDichVuDaDung.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvDichVuDaDung.MultiSelect = false;
                dgvDichVuDaDung.Columns.Add("colNgay", "Ngày dùng");
                dgvDichVuDaDung.Columns.Add("colTenDV", "Dịch vụ");
                dgvDichVuDaDung.Columns.Add("colSL", "Số lượng");
                dgvDichVuDaDung.Columns.Add("colGia", "Đơn giá");
                dgvDichVuDaDung.Columns.Add("colTT", "Thành tiền");
                foreach (DataGridViewColumn c in dgvDichVuDaDung.Columns)
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            cboLuotLuuTru.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLuotLuuTru.DataSource = LayLuotDangLuuTru();

            _dsApDung = _repo.LayTatCa().Where(d => d.DangApDung).ToList();
            cboDichVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDichVu.DisplayMember = "TenDV";
            cboDichVu.ValueMember = "MaDV";
            cboDichVu.DataSource = _dsApDung;

            numSoLuong.Minimum = 1;
            if (numSoLuong.Value < 1) numSoLuong.Value = 1;
            dtpNgayDung.Format = DateTimePickerFormat.Custom;
            dtpNgayDung.CustomFormat = "dd/MM/yyyy";

            _dangNap = false;
            TaiLuoiDaDung();
            CapNhatThanhTien();
        }

        private List<LuotItem> LayLuotDangLuuTru()
        {
            var dsKhach = DuLieu.DocKhach();
            return DuLieu.DocDatPhong()
                .Where(d => DuLieu.LaTrangThaiDangLuuTru(d.TrangThai))
                .Select(d => new LuotItem
                {
                    MaDatPhong = d.Ma,
                    HienThi = $"{d.Ma} - {dsKhach.FirstOrDefault(k => k.CCCD == d.CCCD)?.HoTen ?? d.CCCD} - Phòng {d.SoPhong}"
                })
                .ToList();
        }

        private void TaiLuoiDaDung()
        {
            dgvDichVuDaDung.Rows.Clear();
            if (cboLuotLuuTru.SelectedItem is not LuotItem luot) return;

            foreach (var ct in _ctRepo.LayTheoDatPhong(luot.MaDatPhong).OrderBy(x => x.NgayDung))
            {
                int i = dgvDichVuDaDung.Rows.Add(
                    ct.NgayDung.ToString("dd/MM/yyyy"), ct.TenDV, ct.SoLuong,
                    ct.DonGiaLucDung.ToString("N0"), ct.ThanhTien.ToString("N0"));
                dgvDichVuDaDung.Rows[i].Tag = ct.MaCT;
            }
        }

        private void CapNhatThanhTien()
        {
            if (cboDichVu.SelectedItem is DichVu dv)
                lblThanhTien.Text = $"{dv.DonGia * numSoLuong.Value:N0} đ";
            else
                lblThanhTien.Text = "0 đ";
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabGhiNhan) TaiTab2();
        }

        private void cboLuotLuuTru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_dangNap) TaiLuoiDaDung();
        }

        private void cboDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_dangNap) CapNhatThanhTien();
        }

        private void numSoLuong_ValueChanged(object sender, EventArgs e)
        {
            if (!_dangNap) CapNhatThanhTien();
        }

        private void btnGhiNhan_Click(object sender, EventArgs e)
        {
            if (cboLuotLuuTru.SelectedItem is not LuotItem luot)
            {
                MessageBox.Show("Chưa có lượt lưu trú nào để ghi nhận.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboDichVu.SelectedItem is not DichVu dv)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đọc lại dịch vụ để tránh ghi theo giá cũ hoặc dịch vụ đã ngừng áp dụng.
            var dvHienTai = _repo.LayTatCa().FirstOrDefault(x =>
                x.MaDV.Equals(dv.MaDV, StringComparison.OrdinalIgnoreCase) && x.DangApDung);
            if (dvHienTai == null)
            {
                MessageBox.Show("Dịch vụ này đã ngừng áp dụng. Vui lòng chọn dịch vụ khác.", "Dịch vụ không còn hiệu lực",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TaiTab2();
                return;
            }

            var datPhong = DuLieu.DocDatPhong().FirstOrDefault(x => x.Ma == luot.MaDatPhong);
            if (datPhong == null || !DuLieu.LaTrangThaiDangLuuTru(datPhong.TrangThai))
            {
                MessageBox.Show("Lượt lưu trú không còn hoạt động. Vui lòng tải lại danh sách.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TaiTab2();
                return;
            }
            if (dtpNgayDung.Value.Date < datPhong.NgayDen.Date || dtpNgayDung.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Ngày sử dụng dịch vụ phải nằm trong thời gian khách lưu trú và không được ở tương lai.",
                    "Ngày sử dụng không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var all = _ctRepo.LayTatCa();
            all.Add(new ChiTietDichVu
            {
                MaCT = _ctRepo.SinhMaMoi(),
                MaDatPhong = luot.MaDatPhong,
                MaDV = dvHienTai.MaDV,
                TenDV = dvHienTai.TenDV,
                SoLuong = (int)numSoLuong.Value,
                DonGiaLucDung = dvHienTai.DonGia,
                NgayDung = dtpNgayDung.Value
            });
            _ctRepo.LuuTatCa(all);

            numSoLuong.Value = 1;
            TaiLuoiDaDung();
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvDichVuDaDung.CurrentRow?.Tag is not string maCT)
            {
                MessageBox.Show("Hãy chọn một dòng cần xóa.", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Xóa dòng dịch vụ này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            var all = _ctRepo.LayTatCa();
            all.RemoveAll(x => x.MaCT == maCT);
            _ctRepo.LuuTatCa(all);
            TaiLuoiDaDung();
        }

        private void DichVuForm_Load_1(object sender, EventArgs e)
        {
            // Designer đang liên kết sự kiện Load tới handler này.
            // Gọi luồng khởi tạo dữ liệu chính để tránh form mở ra nhưng trống.
            DichVuForm_Load(sender, e);
        }
    }
}
