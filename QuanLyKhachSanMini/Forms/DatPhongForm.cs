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
    public partial class DatPhongForm : Form
    {
        private List<DatPhong> dsDat = new();
        private List<KhachHang> dsKhach = new();
        private string soPhongChon = "";
        private string filePath = "Data\\Phong.txt";

        public DatPhongForm()
        {
            InitializeComponent();

            Load += DatPhongForm_Load;
            btnTimPhong.Click += BtnTimPhong_Click;
            btnDatPhong.Click += BtnDatPhong_Click;
            btnNhanPhong.Click += BtnNhanPhong_Click;
            btnHuyDat.Click += BtnHuyDat_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            dgvPhongTrong.CellClick += DgvPhongTrong_CellClick;
        }

        private void DatPhongForm_Load(object? sender, EventArgs e)
        {
            CauHinhLuoi(dgvPhongTrong);
            CauHinhLuoi(dgvDatPhong);

            dtpNgayDen.Format = DateTimePickerFormat.Short;
            dtpNgayDi.Format = DateTimePickerFormat.Short;
            dtpNgayDen.Value = DateTime.Today;
            dtpNgayDi.Value = DateTime.Today.AddDays(1);

            NapLoaiPhong();
            NapKhach();
            TaiDatPhong();
            CapNhatPhongChon("");
        }

        private static void CauHinhLuoi(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ---------- Nạp dữ liệu ----------

        private void NapLoaiPhong()
        {
            var loai = DuLieu.DocPhong().Select(p => p.Loai).Distinct().ToList();
            loai.Insert(0, "Tất cả");
            cboLoaiPhong.DataSource = loai;
        }

        private void NapKhach()
        {
            dsKhach = DuLieu.DocKhach();
            var hienThi = dsKhach
                .Select(k => new { k.CCCD, Ten = $"{k.CCCD} - {k.HoTen}" })
                .ToList();
            cboKhach.DataSource = null;
            cboKhach.DisplayMember = "Ten";
            cboKhach.ValueMember = "CCCD";
            cboKhach.DataSource = hienThi;
            if (hienThi.Count == 0) cboKhach.SelectedIndex = -1;
        }

        private void TaiDatPhong()
        {
            dsDat = DuLieu.DocDatPhong();
            var hienThi = dsDat.Select(d => new
            {
                Ma = d.Ma,
                CCCD = d.CCCD,
                HoTen = dsKhach.FirstOrDefault(k => k.CCCD == d.CCCD)?.HoTen ?? "",
                SoPhong = d.SoPhong,
                NgayDen = d.NgayDen.ToString("dd/MM/yyyy"),
                NgayDi = d.NgayDi.ToString("dd/MM/yyyy"),
                TrangThai = TenTrangThai(d.TrangThai)
            }).ToList();

            dgvDatPhong.DataSource = null;
            dgvDatPhong.DataSource = hienThi;
            if (dgvDatPhong.Columns.Count >= 7)
            {
                dgvDatPhong.Columns["Ma"].HeaderText = "Mã";
                dgvDatPhong.Columns["HoTen"].HeaderText = "Họ tên";
                dgvDatPhong.Columns["SoPhong"].HeaderText = "Số phòng";
                dgvDatPhong.Columns["NgayDen"].HeaderText = "Ngày đến";
                dgvDatPhong.Columns["NgayDi"].HeaderText = "Ngày đi";
                dgvDatPhong.Columns["TrangThai"].HeaderText = "Trạng thái";
            }
            dgvDatPhong.ClearSelection();
        }

        private static string TenTrangThai(string tt) => tt switch
        {
            "DaDat" => "Đã đặt",
            "DaNhan" => "Đang ở",
            "DaTra" => "Đã trả",
            "DaHuy" => "Đã hủy",
            _ => tt
        };

        private void CapNhatPhongChon(string soPhong)
        {
            soPhongChon = soPhong;
            lblPhongChon.Text = soPhong == "" ? "Chưa chọn phòng" : $"Phòng đã chọn: {soPhong}";
        }

        // Hàm hỗ trợ cập nhật trạng thái phòng trong file Phong.txt khi có thay đổi (Nhận phòng, Trả phòng, Hủy...)
        private void CapNhatTrangThaiPhongTrongFile(string soPhongCanSua, string trangThaiMoi)
        {
            if (!File.Exists(filePath)) return;

            string[] lines = File.ReadAllLines(filePath);
            List<string> updatedLines = new List<string>();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');
                if (parts.Length >= 4)
                {
                    string soPhong = parts[0].Trim();
                    string loaiPhong = parts[1].Trim();
                    string tang = parts[2].Trim();
                    string trangThai = parts[3].Trim();

                    // Nếu đúng số phòng cần đổi trạng thái
                    if (soPhong == soPhongCanSua)
                    {
                        trangThai = trangThaiMoi; // Cập nhật trạng thái mới (VD: "Có khách", "Trống"...)
                    }

                    updatedLines.Add($"{soPhong}|{loaiPhong}|{tang}|{trangThai}");
                }
            }

            File.WriteAllLines(filePath, updatedLines);
        }

        // ---------- Kiểm tra trùng lịch ----------

        // Hai khoảng [den, di) và [d.NgayDen, d.NgayDi) trùng nhau khi:
        // den < d.NgayDi && d.NgayDen < di
        private bool PhongBiTrung(string soPhong, DateTime den, DateTime di)
        {
            return dsDat.Any(d =>
                d.SoPhong == soPhong &&
                (d.TrangThai == "DaDat" || d.TrangThai == "DaNhan") &&
                den < d.NgayDi && d.NgayDen < di);
        }

        private bool KiemTraNgay(out DateTime den, out DateTime di)
        {
            den = dtpNgayDen.Value.Date;
            di = dtpNgayDi.Value.Date;

            if (den < DateTime.Today)
            {
                Canh("Ngày đến không được nhỏ hơn hôm nay.");
                return false;
            }
            if (di <= den)
            {
                Canh("Ngày đi phải sau ngày đến.");
                return false;
            }
            return true;
        }

        private static void Canh(string msg) =>
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        // ---------- Chức năng ----------

        private void BtnTimPhong_Click(object? sender, EventArgs e)
        {
            if (!KiemTraNgay(out var den, out var di)) return;

            dsDat = DuLieu.DocDatPhong();
            string loai = cboLoaiPhong.Text;

            var ketQua = DuLieu.DocPhong()
                .Where(p => loai == "Tất cả" || p.Loai == loai)
                .Where(p => p.TrangThai != "Đang dọn" || den > DateTime.Today)
                .Where(p => !PhongBiTrung(p.SoPhong, den, di))
                .Select(p => new { SoPhong = p.SoPhong, Loai = p.Loai, Tang = p.Tang })
                .ToList();

            dgvPhongTrong.DataSource = null;
            dgvPhongTrong.DataSource = ketQua;
            if (dgvPhongTrong.Columns.Count >= 3)
            {
                dgvPhongTrong.Columns["SoPhong"].HeaderText = "Số phòng";
                dgvPhongTrong.Columns["Loai"].HeaderText = "Loại phòng";
                dgvPhongTrong.Columns["Tang"].HeaderText = "Tầng";
            }
            dgvPhongTrong.ClearSelection();
            CapNhatPhongChon("");

            if (ketQua.Count == 0)
                MessageBox.Show("Không có phòng trống phù hợp.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DgvPhongTrong_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string so = dgvPhongTrong.Rows[e.RowIndex].Cells["SoPhong"].Value?.ToString() ?? "";
            CapNhatPhongChon(so);
        }

        private void BtnDatPhong_Click(object? sender, EventArgs e)
        {
            if (cboKhach.SelectedValue == null)
            {
                Canh("Hãy chọn khách hàng. Nếu chưa có, thêm khách ở form Quản lý khách.");
                return;
            }
            if (soPhongChon == "")
            {
                Canh("Hãy tìm phòng trống và chọn một phòng.");
                return;
            }
            if (!KiemTraNgay(out var den, out var di)) return;

            dsDat = DuLieu.DocDatPhong(); // đọc lại để tránh dữ liệu cũ
            if (PhongBiTrung(soPhongChon, den, di))
            {
                Canh("Phòng này đã có người đặt trong khoảng ngày đã chọn.");
                return;
            }

            int max = dsDat
                .Select(d => int.TryParse(d.Ma.Replace("DP", ""), out var n) ? n : 0)
                .DefaultIfEmpty(0).Max();

            dsDat.Add(new DatPhong
            {
                Ma = $"DP{max + 1:000}",
                CCCD = cboKhach.SelectedValue.ToString()!,
                SoPhong = soPhongChon,
                NgayDen = den,
                NgayDi = di,
                TrangThai = "DaDat"
            });

            DuLieu.GhiDatPhong(dsDat);
            TaiDatPhong();
            dgvPhongTrong.DataSource = null;
            CapNhatPhongChon("");
            MessageBox.Show("Đặt phòng thành công.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private DatPhong? LayDatDangChon()
        {
            if (dgvDatPhong.CurrentRow == null || dgvDatPhong.SelectedRows.Count == 0)
            {
                Canh("Hãy chọn một dòng trong danh sách đặt phòng.");
                return null;
            }
            string ma = dgvDatPhong.SelectedRows[0].Cells["Ma"].Value?.ToString() ?? "";
            return dsDat.FirstOrDefault(d => d.Ma == ma);
        }

        private void BtnNhanPhong_Click(object? sender, EventArgs e)
        {
            var d = LayDatDangChon();
            if (d == null) return;

            if (d.TrangThai != "DaDat")
            {
                Canh("Chỉ nhận phòng được với đặt phòng ở trạng thái 'Đã đặt'.");
                return;
            }
            if (DateTime.Today < d.NgayDen)
            {
                Canh($"Chưa đến ngày nhận phòng ({d.NgayDen:dd/MM/yyyy}).");
                return;
            }
            if (DateTime.Today >= d.NgayDi)
            {
                Canh("Đặt phòng này đã quá hạn.");
                return;
            }

            d.TrangThai = "DaNhan";
            DuLieu.GhiDatPhong(dsDat);
            TaiDatPhong();

            //BỔ SUNG ĐOẠN NÀY ĐỂ ĐỔI TRẠNG THÁI PHÒNG THÀNH "Có khách" TRONG Phong.txt
            CapNhatTrangThaiPhongTrongFile(d.SoPhong, "Có khách");

            MessageBox.Show("Nhận phòng thành công.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnHuyDat_Click(object? sender, EventArgs e)
        {
            var d = LayDatDangChon();
            if (d == null) return;

            if (d.TrangThai != "DaDat")
            {
                Canh("Chỉ hủy được đặt phòng ở trạng thái 'Đã đặt'.");
                return;
            }

            var kq = MessageBox.Show($"Hủy đặt phòng {d.Ma} (phòng {d.SoPhong})?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq != DialogResult.Yes) return;

            d.TrangThai = "DaHuy";
            DuLieu.GhiDatPhong(dsDat);
            TaiDatPhong();

            //Khi hủy đặt phòng, chuyển trạng thái phòng trong Phong.txt về lại "Trống"
            CapNhatTrangThaiPhongTrongFile(d.SoPhong, "Trống");
        }

        private void BtnLamMoi_Click(object? sender, EventArgs e)
        {
            dtpNgayDen.Value = DateTime.Today;
            dtpNgayDi.Value = DateTime.Today.AddDays(1);
            cboLoaiPhong.SelectedIndex = 0;
            NapKhach();
            TaiDatPhong();
            dgvPhongTrong.DataSource = null;
            CapNhatPhongChon("");
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNhanPhong_Click_1(object sender, EventArgs e)
        {

        }
    }
}
