using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;
using DTO;

namespace GUI_Form
{
    public partial class frmPhieuNhap : MetroSet_UI.Forms.MetroSetForm
    {
        BLL_NhapHang nhaphang = new BLL_NhapHang();
        BLL_NhaCC nccBLL = new BLL_NhaCC();
        BLL_ThietBi thietbi = new BLL_ThietBi();
        BLL_ThucPham thucpham = new BLL_ThucPham();
        int flag = 0;
        public frmPhieuNhap()
        {
            InitializeComponent();
            this.Load += FrmPhieuNhap_Load;
            dgvPhieuNhap.CellClick += DgvPhieuNhap_CellClick;
            dgvPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow r = dgvPhieuNhap.Rows[e.RowIndex];

                txtMaPhieu.Text = r.Cells[0].Value?.ToString();
                cmbNhaCC.Text = r.Cells[1].Value?.ToString();
                cmbNhanVien.Text = r.Cells[2].Value?.ToString();
                dateTimePicker1.Text = r.Cells[3].Value?.ToString();
                cmbGhiChu.Text = r.Cells[5].Value?.ToString();
                string tongtien = r.Cells[4].Value?.ToString();
                if (decimal.TryParse(tongtien, out decimal price1))
                {
                    txtTongTien.Text = price1.ToString("N0", CultureInfo.CurrentCulture);
                }
                else
                {
                    txtTongTien.Text = "0";
                }

                string loaincc = nccBLL.getNhaCC(cmbNhaCC.Text);
                string ma = txtMaPhieu.Text.Trim();


                if (loaincc == "1")
                {
                    label18.Visible = DVT.Visible = false;
                    var chiTietThietBi = nhaphang.getCTPN_ThietBi(ma);
                    if (chiTietThietBi == null || chiTietThietBi.Count == 0)
                    {
                        MessageBox.Show("Chi tiết phiếu nhập rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvChiTietPhieuNhap.DataSource = null;
                        return;
                    }
                    groupBox2.Text = "Chi tiết phiếu nhập thiết bị";
                    dgvChiTietPhieuNhap.DataSource = chiTietThietBi;
                    dgvChiTietPhieuNhap.Columns[0].HeaderText = "Mã thiết bị";
                    dgvChiTietPhieuNhap.Columns[1].HeaderText = "Tên thiết bị";
                    dgvChiTietPhieuNhap.Columns[2].HeaderText = "Số lượng";
                    dgvChiTietPhieuNhap.Columns[3].HeaderText = "Giá nhập";
                    dgvChiTietPhieuNhap.Columns[4].HeaderText = "Thành tiền";
                }
                else if (loaincc == "2")
                {
                    label18.Visible = DVT.Visible = true;
                    dgvChiTietPhieuNhap.DataSource = null;
                    var chiTietThucPham = nhaphang.getCTPN_ThucPham(ma);
                    if (chiTietThucPham == null || chiTietThucPham.Count == 0)
                    {
                        MessageBox.Show("Chi tiết phiếu nhập rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvChiTietPhieuNhap.DataSource = null;
                        return;
                    }
                    groupBox2.Text = "Chi tiết phiếu nhập thực phẩm";
                    dgvChiTietPhieuNhap.DataSource = chiTietThucPham;
                    dgvChiTietPhieuNhap.Columns[0].HeaderText = "Mã thực phẩm";
                    dgvChiTietPhieuNhap.Columns[1].HeaderText = "Tên thực phẩm";
                    dgvChiTietPhieuNhap.Columns[2].HeaderText = "Đơn vị tính";
                    dgvChiTietPhieuNhap.Columns[3].HeaderText = "Số lượng";
                    dgvChiTietPhieuNhap.Columns[4].HeaderText = "Giá nhập";
                    dgvChiTietPhieuNhap.Columns[5].HeaderText = "Thành tiền";
                }
                dgvChiTietPhieuNhap.DefaultCellStyle.ForeColor = Color.Black;
                dgvChiTietPhieuNhap.DefaultCellStyle.BackColor = Color.White;
            }
        }
        private void FrmPhieuNhap_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            flag = 0;
            label10.Text = "";
            groupBox2.Text = "Chi tiết phiếu nhập";
            label18.Visible = DVT.Visible = false;
            txtMaPhieu.Enabled = cmbNhaCC.Enabled = cmbNhanVien.Enabled = cmbGhiChu.Enabled = txtTongTien.Enabled = dateTimePicker1.Enabled = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            txtMa.Enabled = txtTen.Enabled = txtGiaNhap.Enabled = DVT.Enabled = txtSoLuong.Enabled = label10.Enabled = false;

            dgvPhieuNhap.RowHeadersVisible = false;
            dgvPhieuNhap.DataSource = null;
            DataTable dt = nhaphang.getAllData();
            dgvPhieuNhap.DataSource = dt;
            dgvPhieuNhap.Update();
            dgvPhieuNhap.Refresh();
            dgvPhieuNhap.Columns[0].HeaderText = "Mã phiếu";
            dgvPhieuNhap.Columns[1].HeaderText = "Mã NCC";
            dgvPhieuNhap.Columns[2].HeaderText = "Mã nhân viên";
            dgvPhieuNhap.Columns[3].HeaderText = "Ngày nhập";
            dgvPhieuNhap.Columns[4].HeaderText = "Tổng tiền";
            dgvPhieuNhap.Columns[5].HeaderText = "Tình trạng";
            dgvPhieuNhap.AutoGenerateColumns = true;
            dgvPhieuNhap.DefaultCellStyle.ForeColor = Color.Black;
            dgvPhieuNhap.DefaultCellStyle.BackColor = Color.White;
            dgvPhieuNhap.ReadOnly = true;

            dgvChiTietPhieuNhap.RowHeadersVisible = false;
            dgvChiTietPhieuNhap.DataSource = null;
            dgvChiTietPhieuNhap.AutoGenerateColumns = true;
        }

        private void loadcmb()
        {
            cmbNhaCC.DataSource = null;
            cmbNhaCC.DataSource = nhaphang.getNhaCC();
            cmbNhaCC.DisplayMember = "TenLoai";
            cmbNhaCC.ValueMember = "MaLoai";

            cmbNhanVien.DataSource = null;
            cmbNhanVien.DataSource = nhaphang.getNhanVien();
            cmbNhanVien.DisplayMember = "TenNV";
            cmbNhanVien.ValueMember = "MaNV";

            cmbGhiChu.Text = "Chưa thanh toán";
        }
        private void reset()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Value = DateTime.Now;
            load();
            txtMaPhieu.Text = cmbNhanVien.Text = cmbNhaCC.Text = cmbGhiChu.Text = txtTongTien.Text = string.Empty;
            txtMa.Text = txtTen.Text = txtSoLuong.Text = DVT.Text = txtGiaNhap.Text = string.Empty;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát form?", "Xác nhận thoát",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void cmbNhaCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            change();
        }
        private void change()
        {
            //NhaCungCap ncc = nccBLL.getNhaCC(cmbNhaCC.SelectedValue.ToString().Trim());
            //if (ncc != null)
            //{
            //    if (ncc.LoaiNCC == 1)
            //    {
            //        groupBox2.Text = "Chi tiết phiếu nhập thiết bị";
            //        DVT.Enabled = false;
            //        label8.Text = "Mã thiết bị";
            //        label9.Text = "Tên thiết bị";
            //    }
            //    else if (ncc.LoaiNCC == 2)
            //    {
            //        groupBox2.Text = "Chi tiết phiếu nhập thực phẩm";
            //        DVT.Enabled = true;
            //        label8.Text = "Mã thực phẩm";
            //        label9.Text = "Tên thực phẩm";
            //    }
            //}
        }

        private void dgvChiTietPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string loaincc = nccBLL.getNhaCC(cmbNhaCC.Text);
            if (loaincc == "1")
            {
                DataGridViewRow r = dgvChiTietPhieuNhap.Rows[e.RowIndex];

                txtMa.Text = r.Cells[0].Value?.ToString();
                txtTen.Text = r.Cells[1].Value?.ToString();
                txtSoLuong.Text = r.Cells[2].Value?.ToString();
                string rawPrice = r.Cells[3].Value?.ToString();
                if (decimal.TryParse(rawPrice, out decimal price1))
                {
                    txtGiaNhap.Text = price1.ToString("N0", CultureInfo.CurrentCulture);
                }
                else
                {
                    txtGiaNhap.Text = "0";
                }
                string thanhtien = r.Cells[4].Value?.ToString();
                if (decimal.TryParse(thanhtien, out decimal price2))
                {
                    label10.Text = price2.ToString("N0", CultureInfo.CurrentCulture);
                }
                else
                {
                    label10.Text = "0";
                }
            }
            else if (loaincc == "2")
            {
                DataGridViewRow r = dgvChiTietPhieuNhap.Rows[e.RowIndex];

                txtMa.Text = r.Cells[0].Value?.ToString();
                txtTen.Text = r.Cells[1].Value?.ToString();
                DVT.Text = r.Cells[2].Value?.ToString();
                txtSoLuong.Text = r.Cells[3].Value?.ToString();
                label10.Text = r.Cells[5].Value?.ToString();
                string giaban = r.Cells[4].Value?.ToString();
                if (decimal.TryParse(giaban, out decimal price1))
                {
                    txtGiaNhap.Text = price1.ToString("N0", CultureInfo.CurrentCulture);
                }
                else
                {
                    txtGiaNhap.Text = "0";
                }
                string thanhtien = r.Cells[5].Value?.ToString();
                if (decimal.TryParse(thanhtien, out decimal price2))
                {
                    label10.Text = price2.ToString("N0", CultureInfo.CurrentCulture);
                }
                else
                {
                    label10.Text = "0";
                }
            }
        }

        private void txTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTK_Click(sender, e); // Gọi phương thức tìm kiếm khi nhấn Enter
                e.Handled = true;
                e.SuppressKeyPress = true; // Chặn beep mặc định khi nhấn Enter
            }
        }
        private string searchKeyword = "";
        private void btnTK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txTimKiem.Text))
            {
                searchKeyword = txTimKiem.Text.ToLower(); // Lưu từ khóa tìm kiếm
                DataTable kq = nhaphang.getDataBySearch(searchKeyword);

                try
                {
                    if (kq != null && kq.Rows.Count > 0)
                    {
                        dgvPhieuNhap.DataSource = null;
                        dgvPhieuNhap.DataSource = kq;
                        dgvPhieuNhap.Update();
                        dgvPhieuNhap.Refresh();

                        if (dgvPhieuNhap.Columns.Contains("NhanVien"))
                        {
                            dgvPhieuNhap.Columns.Remove("NhanVien");
                        }
                        if (dgvPhieuNhap.Columns.Contains("NhaCungCap"))
                        {
                            dgvPhieuNhap.Columns.Remove("NhaCungCap");
                        }
                        // Thiết lập header
                        dgvPhieuNhap.Columns[0].HeaderText = "Mã phiếu";
                        dgvPhieuNhap.Columns[1].HeaderText = "Mã nhà cung cấp";
                        dgvPhieuNhap.Columns[2].HeaderText = "Mã nhân viên";
                        dgvPhieuNhap.Columns[3].HeaderText = "Ngày nhập";
                        dgvPhieuNhap.Columns[4].HeaderText = "Tổng tiền";
                        dgvPhieuNhap.Columns[5].HeaderText = "Tình trạng";

                        // Định dạng DataGridView
                        dgvPhieuNhap.AutoGenerateColumns = true;
                        dgvPhieuNhap.DefaultCellStyle.ForeColor = Color.Black;
                        dgvPhieuNhap.DefaultCellStyle.BackColor = Color.White;
                        dgvPhieuNhap.ReadOnly = true;

                        // Gắn sự kiện CellFormatting để tô màu phần trùng
                        dgvPhieuNhap.CellFormatting -= dgvPhieuNhap_CellFormatting;
                        dgvPhieuNhap.CellFormatting += dgvPhieuNhap_CellFormatting; // Không cần tham số searchKeyword
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bất cứ kết quả nào !!", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Thông báo");
                }
            }
        }

        private void dgvPhieuNhap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && !string.IsNullOrEmpty(searchKeyword))
            {
                string cellText = e.Value.ToString().ToLower(); // Văn bản trong ô
                if (cellText.Contains(searchKeyword))
                {
                    e.CellStyle.BackColor = Color.DarkGray;
                    e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
                else
                {
                    // Khôi phục màu mặc định nếu không khớp
                    e.CellStyle.BackColor = Color.White;
                    e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                }
            }
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            // Kiểm tra tình trạng phiếu nhập
            if (cmbGhiChu.Text == "Đã thanh toán")
            {
                MessageBox.Show("Phiếu nhập này đã thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maPhieu = txtMaPhieu.Text.Trim();
            string loaiNCC = nccBLL.getNhaCC(cmbNhaCC.Text); // Lấy loại nhà cung cấp

            try
            {
                if (loaiNCC == "1") // Nhà cung cấp thiết bị
                {
                    foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
                    {

                        string matb = row.Cells[0].Value?.ToString();
                        string tentb = row.Cells[1].Value?.ToString();
                        int sl = int.Parse(row.Cells[2].Value?.ToString());
                        double giaban = double.Parse(row.Cells[3].Value?.ToString());
                        ThietBi tb = new ThietBi();
                        tb.MaTB = matb; tb.TenTB = tentb; tb.SoLuong = sl; tb.GiaBan = giaban;
                        // Kiểm tra thiết bị trong bảng Thiết Bị
                        var thietBi = thietbi.getByName(tentb);
                        if (thietBi == null)
                        {
                            // Nếu thiết bị chưa tồn tại, thêm mới
                            thietbi.themThietBi(tb);
                        }
                        else
                        {
                            // Nếu thiết bị đã tồn tại, cộng dồn số lượng
                            thietbi.UpdateThietBiQuantity(tentb, sl);
                        }
                    }
                }
                else if (loaiNCC == "2") // Nhà cung cấp thực phẩm
                {
                    foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
                    {
                        string maThucPham = row.Cells[0].Value?.ToString();
                        string tenThucPham = row.Cells[1].Value?.ToString();
                        string dvt = row.Cells[2].Value?.ToString();
                        int soLuong = int.Parse(row.Cells[3].Value?.ToString());
                        double giaNhap = double.Parse(row.Cells[4].Value?.ToString());

                        ThucPham tp = new ThucPham();
                        tp.MaTP = maThucPham; tp.TenTP = tenThucPham; tp.DVT = dvt; tp.SoLuong = soLuong; tp.GiaBan = giaNhap * 1.2;
                        //tp.MoTa = "Không có";
                        tp.TinhTrang = "Còn hàng";
                        if (tenThucPham.ToLower().Contains("nước"))
                        {
                            tp.MaLoai = "L001";
                        }
                        if (tenThucPham.ToLower().Contains("bánh"))
                        {
                            tp.MaLoai = "L002";
                        }
                        if (tenThucPham.ToLower().Contains("kem"))
                        {
                            tp.MaLoai = "L003";
                        }
                        // Kiểm tra thực phẩm trong bảng Thực Phẩm
                        var thucPham = thucpham.getByName(tenThucPham);
                        if (thucPham == null)
                        {
                            // Nếu thực phẩm chưa tồn tại, thêm mới
                            thucpham.themThucPham(tp);
                        }
                        else
                        {
                            // Nếu thực phẩm đã tồn tại, cộng dồn số lượng
                            thucpham.UpdateThucPhamQuantity(tenThucPham, soLuong);
                        }
                    }
                }

                // Cập nhật trạng thái phiếu nhập thành "Đã thanh toán"
                nhaphang.UpdatePhieuNhapStatus(maPhieu, "Đã thanh toán");

                // Hiển thị thông báo thành công
                MessageBox.Show("Thanh toán phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset(); // Reset form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
