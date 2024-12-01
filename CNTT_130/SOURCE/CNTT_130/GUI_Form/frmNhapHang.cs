using BLL_DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Form
{
    public partial class frmNhapHang : Form
    {
        BLL_NhapHang nhaphang = new BLL_NhapHang();
        BLL_NhaCC nhacungcap = new BLL_NhaCC();
        BLL_NhaCC nccBLL = new BLL_NhaCC();
        BLL_ThucPham thucpham = new BLL_ThucPham();
        BLL_ThietBi thietBi = new BLL_ThietBi();
        private string maNV = string.Empty;
        private DataTable chiTietTable; // Dùng để lưu toàn bộ chi tiết phiếu nhập

        public frmNhapHang()
        {
            InitializeComponent();
            this.Load += FrmNhapHang_Load;
            dgvPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        public frmNhapHang(string maNVDN)
        {
            InitializeComponent();
            this.Load += FrmNhapHang_Load;
            dgvPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieuNhap.ReadOnly = true;
            dgvPhieuNhap.AllowUserToAddRows = dgvChiTietPhieuNhap.AllowUserToAddRows = dgvDS.AllowUserToAddRows = false;
            dgvPhieuNhap.AllowUserToDeleteRows = dgvChiTietPhieuNhap.AllowUserToDeleteRows = dgvDS.AllowUserToDeleteRows = false;
            maNV = maNVDN;
            btnLuuToanBo.Enabled = false;
            txtNhanVien.Text = maNVDN;
        }
        private void FrmNhapHang_Load(object sender, EventArgs e)
        {
            load();

        }
        private void load()
        {
            txtMa.Enabled = txtTen.Enabled = txtSoLuong.Enabled = DVT.Enabled = txtGiaNhap.Enabled = false;
            dateTimePicker1.Enabled = txtTrangThai.Enabled = false;
            btnIn.Enabled = true;
            txtNhanVien.Enabled = false;
            //List<string> items = new List<string> { "Thùng", "Lon", "Chai", "Phần", "Ly" };
            DVT.DataSource = null;
            //DVT.DataSource = items;
            DVT.Visible = false;
            label18.Visible = false;
            label10.Visible = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dgvChiTietPhieuNhap.RowHeadersVisible = false;
            dgvPhieuNhap.RowHeadersVisible = false;
            dgvDS.RowHeadersVisible = false;

            DataTable danhSachNhaCC = nhaphang.getNhaCC();

            // Chuyển đổi DataTable thành danh sách các đối tượng
            var danhSachHienThi = new List<object> {
    new { MaLoai = "", TenLoai = "  -- Chọn nhà cung cấp --" } // Thêm mục mặc định
};

            // Duyệt từng dòng trong DataTable và thêm vào danh sách
            foreach (DataRow row in danhSachNhaCC.Rows)
            {
                danhSachHienThi.Add(new
                {
                    MaLoai = row["MaLoai"].ToString(),
                    TenLoai = row["TenLoai"].ToString()
                });
            }

            // Gán danh sách vào ComboBox
            cmbNhaCC.DataSource = danhSachHienThi;
            cmbNhaCC.DisplayMember = "TenLoai";
            cmbNhaCC.ValueMember = "MaLoai";

            // Đặt mục mặc định được chọn
            cmbNhaCC.SelectedIndex = 0;

            txtTrangThai.Text = "Chưa thanh toán";

            dgvDS.DataSource = null;
            DataTable dt1 = nhacungcap.getListProduct(cmbNhaCC.SelectedValue.ToString());
            dgvDS.DataSource = dt1;
            dgvDS.Update();
            dgvDS.Refresh();
            dgvDS.Columns[0].HeaderText = "Mã sản phẩm";
            dgvDS.Columns[1].HeaderText = "Tên sản phẩm";
            dgvDS.Columns[2].HeaderText = "Giá bán";
            dgvDS.AutoGenerateColumns = true;
            dgvDS.DefaultCellStyle.ForeColor = Color.Black;
            dgvDS.DefaultCellStyle.BackColor = Color.White;

            dgvPhieuNhap.ReadOnly = true;
        }

        private void btnTaoPhieuNhap_Click(object sender, EventArgs e)
        {
            string mancc = cmbNhaCC.SelectedValue.ToString().Trim();
            if (string.IsNullOrEmpty(mancc))
            {
                CustomMessageBox.Show("Không được để trống nhà cung cấp !");
                return;
            }
            PhieuNhap pn = new PhieuNhap();
            pn.TongTien = 0;
            pn.MaNCC = mancc;
            DateTime dt = DateTime.Now;
            pn.NgayNhap = dt.Date;

            DataTable dt2 = nhaphang.getAllData();
            int dem = dt2.Rows.Count;
            string ma = "PN" + (dem + 1).ToString("D3");
            while (nhaphang.getByCode(ma) != null)
            {
                dem++;
                ma = "PN" + (dem + 1).ToString("D3");
            }
            pn.MaPhieu = ma;
            pn.GhiChu = "Chưa thanh toán";
            pn.MaNV = maNV;

            DataTable listPN = nhaphang.getAllData();
            DataRow newRow = listPN.NewRow();
            newRow["MaPhieu"] = pn.MaPhieu;
            newRow["MaNCC"] = pn.MaNCC;
            newRow["MaNV"] = pn.MaNV;
            newRow["NgayNhap"] = pn.NgayNhap;
            newRow["TongTien"] = pn.TongTien;
            newRow["GhiChu"] = pn.GhiChu;
            listPN.Rows.Add(newRow);

            txtMaPhieu.Text = pn.MaPhieu;
            txtNhanVien.Text = pn.MaNV;
            label4.Text = (pn.TongTien).ToString();

            dgvPhieuNhap.DataSource = null;
            dgvPhieuNhap.DataSource = listPN;
            dgvPhieuNhap.Columns[0].HeaderText = "Mã phiếu";
            dgvPhieuNhap.Columns[1].HeaderText = "Mã NCC";
            dgvPhieuNhap.Columns[2].HeaderText = "Mã nhân viên";
            dgvPhieuNhap.Columns[3].HeaderText = "Ngày nhập";
            dgvPhieuNhap.Columns[4].HeaderText = "Tổng tiền";
            dgvPhieuNhap.Columns[5].HeaderText = "Tình trạng";
            btnLuuToanBo.Enabled = true;
        }
        private void cmbNhaCC_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbNhaCC.SelectedIndex >= 0)
            {
                dgvDS.DataSource = null;
                DataTable dt1 = nhacungcap.getListProduct(cmbNhaCC.SelectedValue.ToString());
                dgvDS.DataSource = dt1;
                dgvDS.Update();
                dgvDS.Refresh();
                dgvDS.Columns[0].HeaderText = "Mã sản phẩm";
                dgvDS.Columns[1].HeaderText = "Tên sản phẩm";
                dgvDS.Columns[2].HeaderText = "Giá bán";
                dgvDS.AutoGenerateColumns = true;
                dgvDS.DefaultCellStyle.ForeColor = Color.Black;
                dgvDS.DefaultCellStyle.BackColor = Color.White;

                string loaincc = nccBLL.getNhaCC(cmbNhaCC.SelectedValue.ToString());
                if (loaincc == "2")
                {
                    // Khởi tạo DataTable cho Chi Tiết Phiếu Nhập
                    chiTietTable = new DataTable();
                    chiTietTable.Columns.Add("MaPhieu", typeof(string));
                    chiTietTable.Columns.Add("MaTP", typeof(string));
                    chiTietTable.Columns.Add("TenTP", typeof(string));
                    chiTietTable.Columns.Add("DVT", typeof(string));
                    chiTietTable.Columns.Add("SoLuong", typeof(int));
                    chiTietTable.Columns.Add("GiaNhap", typeof(float));
                    chiTietTable.Columns.Add("ThanhTien", typeof(float));
                }
                else if (loaincc == "1")
                {
                    chiTietTable = new DataTable();
                    chiTietTable.Columns.Add("MaPhieu", typeof(string));
                    chiTietTable.Columns.Add("MaTB", typeof(string));
                    chiTietTable.Columns.Add("TenTB", typeof(string));
                    chiTietTable.Columns.Add("SoLuong", typeof(int));
                    chiTietTable.Columns.Add("GiaNhap", typeof(float));
                    chiTietTable.Columns.Add("ThanhTien", typeof(float));
                }
                dgvChiTietPhieuNhap.DataSource = chiTietTable;
                if (loaincc == "2")
                {
                    label18.Visible = true;
                    DVT.Visible = true;

                }
                else if (loaincc == "1")
                {
                    DVT.Visible = false;
                    label18.Visible = false;
                }
            }
        }

        private void dgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtSoLuong.Enabled = true;
                DataGridViewRow r = dgvDS.Rows[e.RowIndex];
                string loaincc = nccBLL.getNhaCC(cmbNhaCC.Text);
                txtMa.Text = r.Cells[0].Value.ToString();
                txtTen.Text = r.Cells[1].Value.ToString();
                string gianhap = r.Cells[2].Value.ToString();

                if (decimal.TryParse(gianhap, out decimal price1))
                {
                    txtGiaNhap.Text = price1.ToString("N0", CultureInfo.CurrentCulture);
                }
                else
                {
                    txtGiaNhap.Text = "0";
                }

                string tenSanPham = txtTen.Text.ToLower();

                if (tenSanPham.Contains("nước"))
                {
                    DVT.Text = "Thùng";
                }
                else if (tenSanPham.Contains("bánh"))
                {
                    DVT.Text = "Phần";
                }
                else if (tenSanPham.Contains("kem"))
                {
                    DVT.Text = "Ly";
                }
                else
                {
                    DVT.Text = null;
                }
            }
        }
        private DataTable listPN = new DataTable();
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnTaoPhieuNhap.Enabled = false;
            string loaincc = nccBLL.getNhaCC(cmbNhaCC.SelectedValue.ToString());
            if (loaincc == "2")
            {
                CTPN_TP ctpntp = new CTPN_TP();
                ctpntp.MaPhieu = txtMaPhieu.Text;

                DataTable dt2 = thucpham.getAllData();
                int dem = dt2.Rows.Count;
                string ma = "TP" + (dem + 1).ToString("D3");
                while (nhaphang.getByCode(ma) != null)
                {
                    dem++;
                    ma = "TP" + (dem + 1).ToString("D3");
                }

                bool productExists = false;
                foreach (DataGridViewRow r in dgvChiTietPhieuNhap.Rows)
                {
                    if (r.IsNewRow) continue;  // Bỏ qua dòng mới chưa nhập
                    if (string.IsNullOrEmpty(r.Cells[1].Value.ToString()) || r.Cells[1].Value == null) continue;  // Bỏ qua ô trống

                    // So sánh tên thực phẩm (tên thực phẩm nhập vào và tên trong bảng)
                    if (r.Cells["TenTP"].Value != null && r.Cells["TenTP"].Value.ToString().Trim().ToLower() == txtTen.Text.Trim().ToLower())
                    {
                        // Nếu tìm thấy sản phẩm trùng tên, cộng số lượng và tính lại thành tiền
                        int currentQuantity = Convert.ToInt32(r.Cells["SoLuong"].Value);
                        int newQuantity = currentQuantity + int.Parse(txtSoLuong.Text);
                        r.Cells["SoLuong"].Value = newQuantity;

                        float price = float.Parse(txtGiaNhap.Text);
                        r.Cells["ThanhTien"].Value = newQuantity * price;

                        productExists = true; // Đánh dấu là sản phẩm đã tồn tại
                        break; // Thoát khỏi vòng lặp nếu đã cập nhật
                    }
                }
                if (!productExists)
                {
                    foreach (DataGridViewRow r in dgvChiTietPhieuNhap.Rows)
                    {
                        if (r.IsNewRow) continue;
                        if (string.IsNullOrEmpty(r.Cells[1].Value.ToString()) || r.Cells[1].Value == null) continue;
                        if (r.Cells[1].Value.ToString().Trim().ToLower().Contains(ma.Trim().ToLower()))
                        {
                            dem++;
                            ma = "TP" + (dem + 1).ToString("D3");
                        }
                    }
                    ctpntp.MaTP = ma;
                    ctpntp.TenTP = txtTen.Text;
                    ctpntp.DVT = DVT.Text;
                    ctpntp.SoLuong = int.Parse(txtSoLuong.Text);
                    ctpntp.GiaNhap = float.Parse(txtGiaNhap.Text);
                    ctpntp.ThanhTien = ctpntp.SoLuong * ctpntp.GiaNhap;



                    DataTable dt = (DataTable)chiTietTable;
                    DataRow newRow = dt.NewRow();
                    newRow["MaPhieu"] = ctpntp.MaPhieu;
                    newRow["MaTP"] = ctpntp.MaTP;
                    newRow["TenTP"] = ctpntp.TenTP;
                    newRow["DVT"] = ctpntp.DVT;
                    newRow["SoLuong"] = ctpntp.SoLuong;
                    newRow["GiaNhap"] = ctpntp.GiaNhap;
                    newRow["ThanhTien"] = ctpntp.ThanhTien;
                    dt.Rows.Add(newRow);
                }
                txtMa.Text = txtTen.Text = txtSoLuong.Text = txtGiaNhap.Text = DVT.Text = label10.Text = "";

                dgvChiTietPhieuNhap.DataSource = null;
                dgvChiTietPhieuNhap.DataSource = chiTietTable;

                dgvChiTietPhieuNhap.Columns[0].HeaderText = "Mã phiếu";
                dgvChiTietPhieuNhap.Columns[1].HeaderText = "Mã thực phẩm";
                dgvChiTietPhieuNhap.Columns[2].HeaderText = "Tên thực phẩm";
                dgvChiTietPhieuNhap.Columns[3].HeaderText = "Đơn vị tính";
                dgvChiTietPhieuNhap.Columns[4].HeaderText = "Số lượng";
                dgvChiTietPhieuNhap.Columns[5].HeaderText = "Giá nhập";
                dgvChiTietPhieuNhap.Columns[6].HeaderText = "Thành tiền";
                UpdateTotalAmount();
            }
            else if (loaincc == "1")
            {
                CTPN_TB ctpntp = new CTPN_TB();
                ctpntp.MaPhieu = txtMaPhieu.Text;

                DataTable dt2 = thietBi.getAllData();
                int dem = dt2.Rows.Count;
                string ma = "TB" + (dem + 1).ToString("D3");

                // Kiểm tra mã thiết bị có tồn tại không
                while (nhaphang.getByCode(ma) != null)
                {
                    dem++;
                    ma = "TB" + (dem + 1).ToString("D3");
                }
                bool productExists = false;
                foreach (DataGridViewRow r in dgvChiTietPhieuNhap.Rows)
                {
                    if (r.IsNewRow) continue;  // Bỏ qua dòng mới chưa nhập
                    if (string.IsNullOrEmpty(r.Cells[1].Value.ToString()) || r.Cells[1].Value == null) continue;  // Bỏ qua ô trống

                    // So sánh tên thực phẩm (tên thực phẩm nhập vào và tên trong bảng)
                    if (r.Cells["TenTB"].Value != null && r.Cells["TenTB"].Value.ToString().Trim().ToLower() == txtTen.Text.Trim().ToLower())
                    {
                        // Nếu tìm thấy sản phẩm trùng tên, cộng số lượng và tính lại thành tiền
                        int currentQuantity = Convert.ToInt32(r.Cells["SoLuong"].Value);
                        int newQuantity = currentQuantity + int.Parse(txtSoLuong.Text);
                        r.Cells["SoLuong"].Value = newQuantity;

                        float price = float.Parse(txtGiaNhap.Text);
                        r.Cells["ThanhTien"].Value = newQuantity * price;

                        productExists = true; // Đánh dấu là sản phẩm đã tồn tại
                        break; // Thoát khỏi vòng lặp nếu đã cập nhật
                    }
                }
                if (!productExists)
                {
                    foreach (DataGridViewRow r in dgvChiTietPhieuNhap.Rows)
                    {
                        if (r.IsNewRow) continue;
                        if (string.IsNullOrEmpty(r.Cells[1].Value.ToString()) || r.Cells[1].Value == null) continue;
                        if (r.Cells[1].Value.ToString().Trim().ToLower().Contains(ma.Trim().ToLower()))
                        {
                            dem++;
                            ma = "TB" + (dem + 1).ToString("D3");
                        }
                    }
                    ctpntp.MaTB = ma;
                    ctpntp.TenTB = txtTen.Text;
                    ctpntp.SoLuong = int.Parse(txtSoLuong.Text);
                    ctpntp.GiaNhap = float.Parse(txtGiaNhap.Text);
                    ctpntp.ThanhTien = ctpntp.SoLuong * ctpntp.GiaNhap;

                    // Thêm dữ liệu vào DataTable
                    DataTable dt = (DataTable)chiTietTable;
                    DataRow newRow = dt.NewRow();
                    newRow["MaPhieu"] = ctpntp.MaPhieu;
                    newRow["MaTB"] = ctpntp.MaTB;
                    newRow["TenTB"] = ctpntp.TenTB;
                    newRow["SoLuong"] = ctpntp.SoLuong;
                    newRow["GiaNhap"] = ctpntp.GiaNhap;
                    newRow["ThanhTien"] = ctpntp.ThanhTien;
                    dt.Rows.Add(newRow);
                }



                // Làm sạch các textbox sau khi thêm thành công
                txtMa.Text = txtTen.Text = txtSoLuong.Text = txtGiaNhap.Text = DVT.Text = label10.Text = "";

                // Cập nhật lại DataGridView
                dgvChiTietPhieuNhap.DataSource = null;
                dgvChiTietPhieuNhap.DataSource = chiTietTable;

                dgvChiTietPhieuNhap.Columns[0].HeaderText = "Mã phiếu";
                dgvChiTietPhieuNhap.Columns[1].HeaderText = "Mã thiết bị";
                dgvChiTietPhieuNhap.Columns[2].HeaderText = "Tên thiết bị";
                dgvChiTietPhieuNhap.Columns[3].HeaderText = "Số lượng";
                dgvChiTietPhieuNhap.Columns[4].HeaderText = "Giá nhập";
                dgvChiTietPhieuNhap.Columns[5].HeaderText = "Thành tiền";

                UpdateTotalAmount();
            }
        }

        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                label10.Visible = true;
                if (decimal.TryParse(txtGiaNhap.Text, out decimal giaBan) &&
                    int.TryParse(txtSoLuong.Text, out int soLuong))
                {
                    decimal thanhTien = giaBan * soLuong;

                    label10.Text = $"{thanhTien:N0}";
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập giá bán và số lượng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnLuuToanBo_Click(object sender, EventArgs e)
        {
            string loaincc = nccBLL.getNhaCC(cmbNhaCC.SelectedValue.ToString());
            if (string.IsNullOrEmpty(txtMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu.");
                return;
            }

            // Tạo đối tượng phiếu nhập và thiết lập thông tin
            PhieuNhap phieuNhap = new PhieuNhap();
            phieuNhap.MaPhieu = txtMaPhieu.Text;
            phieuNhap.NgayNhap = dateTimePicker1.Value;
            phieuNhap.MaNV = txtNhanVien.Text;
            phieuNhap.GhiChu = txtTrangThai.Text;
            phieuNhap.MaNCC = cmbNhaCC.SelectedValue.ToString();
            phieuNhap.TongTien = double.Parse(label4.Text);

            // Lưu phiếu nhập vào cơ sở dữ liệu
            bool isPhieuNhapSaved = nhaphang.themPhieuNhap(phieuNhap);

            if (!isPhieuNhapSaved)
            {
                MessageBox.Show("Lưu phiếu nhập thất bại.");
                return;
            }
            else
            {
                if (loaincc == "2") // Nếu là loại nhà cung cấp thực phẩm
                {
                    foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
                    {
                        if (row.IsNewRow) continue; // Bỏ qua dòng mới chưa nhập

                        // Lấy thông tin chi tiết phiếu nhập từ từng dòng
                        string ten = row.Cells[2]?.Value?.ToString();
                        string ma = row.Cells[1]?.Value?.ToString();
                        string dvt = row.Cells[3]?.Value?.ToString();
                        int soLuong = Convert.ToInt32(row.Cells[4]?.Value ?? 0);
                        float giaNhap = Convert.ToSingle(row.Cells[5]?.Value ?? 0);
                        double thanhtien = Convert.ToSingle(row.Cells[6]?.Value ?? 0);
                        string maphieu = row.Cells[0]?.Value?.ToString();

                        CTPN_TP ctpntp = new CTPN_TP();
                        ctpntp.MaPhieu = maphieu;
                        ctpntp.MaTP = ma;
                        ctpntp.TenTP = ten;
                        ctpntp.DVT = dvt;
                        ctpntp.SoLuong = soLuong;
                        ctpntp.GiaNhap = giaNhap;
                        ctpntp.ThanhTien = thanhtien;

                        // Lưu chi tiết phiếu nhập thực phẩm
                        bool isCTPNTPSaved = nhaphang.themctpntp(ctpntp);
                        if (!isCTPNTPSaved)
                        {
                            MessageBox.Show("Lưu chi tiết phiếu nhập thực phẩm thất bại.");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Nhập thực phẩm thành công");
                            return;
                        }
                    }
                }
                load();
                if (loaincc == "1") // Nếu là loại nhà cung cấp thực phẩm
                {
                    foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
                    {
                        if (row.IsNewRow) continue; // Bỏ qua dòng mới chưa nhập

                        // Lấy thông tin chi tiết phiếu nhập từ từng dòng
                        string ten = row.Cells["TenTB"]?.Value?.ToString();
                        string ma = row.Cells["MaTB"]?.Value?.ToString();
                        int soLuong = Convert.ToInt32(row.Cells["SoLuong"]?.Value ?? 0);
                        float giaNhap = Convert.ToSingle(row.Cells["GiaNhap"]?.Value ?? 0);
                        double thanhtien = Convert.ToSingle(row.Cells["ThanhTien"]?.Value ?? 0);

                        CTPN_TB ctpntb = new CTPN_TB();
                        ctpntb.MaPhieu = phieuNhap.MaPhieu;
                        ctpntb.MaTB = ma;
                        ctpntb.TenTB = ten;
                        ctpntb.SoLuong = soLuong;
                        ctpntb.GiaNhap = giaNhap;
                        ctpntb.ThanhTien = soLuong * giaNhap;

                        // Lưu chi tiết phiếu nhập thực phẩm
                        bool isCTPNTPSaved = nhaphang.themctpntb(ctpntb);
                        if (!isCTPNTPSaved)
                        {
                            MessageBox.Show("Lưu chi tiết phiếu nhập thiết bị thất bại.");
                        }
                        else
                        {
                            MessageBox.Show("Nhập thiết bị thành công");
                        }
                    }
                }
                load();
            }
        }

        private void dgvChiTietPhieuNhap_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChiTietPhieuNhap.Rows[e.RowIndex];

                if (decimal.TryParse(row.Cells["GiaNhap"].Value?.ToString(), out decimal giaNhap) &&
                    int.TryParse(row.Cells["SoLuong"].Value?.ToString(), out int soLuong))
                {
                    row.Cells["ThanhTien"].Value = giaNhap * soLuong; // Tính lại Thành tiền
                }

                UpdateTotalAmount(); // Cập nhật tổng tiền sau khi chỉnh sửa
            }
        }

        private void dgvChiTietPhieuNhap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Kiểm tra ô hợp lệ
            {
                UpdateTotalAmount(); // Cập nhật tổng tiền
            }
        }
        private void UpdateTotalAmount()
        {
            decimal totalAmount = 0;

            // Duyệt qua tất cả các hàng trong DataGridView
            foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
            {
                if (!row.IsNewRow) // Bỏ qua hàng trống khi thêm mới
                {
                    if (decimal.TryParse(row.Cells["ThanhTien"].Value?.ToString(), out decimal thanhTien))
                    {
                        totalAmount += thanhTien;
                    }
                }
            }

            // Hiển thị tổng tiền
            label4.Text = totalAmount.ToString("N0", CultureInfo.CurrentCulture); // label4 là nơi hiển thị tổng tiền
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }
    }
}
