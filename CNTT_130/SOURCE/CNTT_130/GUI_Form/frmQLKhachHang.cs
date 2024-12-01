using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;
using DTO;


namespace GUI_Form
{
    public partial class frmQLKhachHang : MetroSet_UI.Forms.MetroSetForm
    {

        BLL_KhachHang bllKhachHang = new BLL_KhachHang();
        BLL_LoaiKhachHang bllLoaiKH = new BLL_LoaiKhachHang();
        public frmQLKhachHang()
        {
            InitializeComponent();
            loadKH();
            LoadLoaiKHToComboBox();
            LoadLoaiKH();
            txtMakh.Enabled = false;
            txtDiem.Enabled = false;
            dgvKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
            // Định dạng DateTimePicker
            dptNgaySinh.Format = DateTimePickerFormat.Custom;
            dptNgaySinh.CustomFormat = "dd/MM/yyyy";
            dgvKH.ReadOnly = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmQLKhachHang_Load(object sender, EventArgs e)
        {
            loadKH();
            LoadLoaiKHToComboBox();
            LoadLoaiKH();


        }

        private void LoadLoaiKHToComboBox()
        {
            List<LoaiKH> dsLoaiKH = bllLoaiKH.getAllLoaiKH();
            LoaiKH allLoaiKH = new LoaiKH { MaLoai = "-1", TenLoai = "Tất cả" };
            dsLoaiKH.Insert(0, allLoaiKH);
            cbbLoaiKH.DataSource = dsLoaiKH;
            cbbLoaiKH.DisplayMember = "TenLoai";
            cbbLoaiKH.ValueMember = "MaLoai";


        }

        private void LoadLoaiKH()
        {
            List<LoaiKH> dsLoaiKH = bllLoaiKH.getAllLoaiKH();
            txtLoaiKH.DataSource = dsLoaiKH;
            txtLoaiKH.DisplayMember = "TenLoai";
            txtLoaiKH.ValueMember = "MaLoai";
        }

        private void dgvKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKH.Rows[e.RowIndex];
                txtMakh.Text = row.Cells["MaKH"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                dptNgaySinh.Text = row.Cells["NgaySinh"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtDiem.Text = row.Cells["Diem"].Value.ToString();
                // Lấy mã loại khách hàng
                string maLoaiKH = row.Cells["LoaiKH"].Value.ToString();

                // Gọi hàm BLL để lấy tên loại khách hàng
                txtLoaiKH.Text = bllKhachHang.GetCustomerTypeName(maLoaiKH);
                txtSoTre.Text = row.Cells["SoTreEm"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtLoaiKH.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin khách hàng.");
                    return;
                }
                DateTime ngaySinh;
                if (!DateTime.TryParse(dptNgaySinh.Text, out ngaySinh))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ.");
                    return;
                }

                string Loaikh = txtLoaiKH.SelectedValue.ToString();
                var kh = new KhachHang
                {
                    HoTen = txtHoTen.Text,
                    NgaySinh = ngaySinh.Date,
                    SDT = txtSDT.Text,
                    Diem = 10,
                    LoaiKH = Loaikh,
                    SoTreEm = int.Parse(txtSoTre.Text)
                };
                bool result = bllKhachHang.addCustomer(kh);
                loadKH();
                if (result)
                    MessageBox.Show("Thêm khách hàng thành công!");

                else
                    MessageBox.Show("Thêm khách hàng thất bại!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        public void loadKH()
        {
            DataTable dt = bllKhachHang.getAllData();
            dgvKH.DataSource = dt;

            dgvKH.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
            dgvKH.Columns["HoTen"].HeaderText = "Họ Tên";
            dgvKH.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dgvKH.Columns["SDT"].HeaderText = "Số Điện Thoại";
            dgvKH.Columns["Diem"].HeaderText = "Điểm";
            dgvKH.Columns["LoaiKH"].HeaderText = "Loại Khách Hàng";
            dgvKH.Columns["SoTreEm"].HeaderText = "Số Trẻ Em";

            if (dgvKH.Columns.Contains("LoaiKH1"))
            {
                dgvKH.Columns.Remove("LoaiKH1");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtLoaiKH.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin khách hàng.");
                    return;
                }
                DateTime ngaySinh;
                if (!DateTime.TryParse(dptNgaySinh.Text, out ngaySinh))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ.");
                    return;
                }

                string Loaikh = txtLoaiKH.SelectedValue.ToString();
                var kh = new KhachHang
                {
                    HoTen = txtHoTen.Text,
                    NgaySinh = ngaySinh.Date,
                    SDT = txtSDT.Text,
                    Diem = int.Parse(txtDiem.Text),
                    LoaiKH = Loaikh,
                    SoTreEm = int.Parse(txtSoTre.Text)
                };
                string maKH = txtMakh.Text;
                bool result = bllKhachHang.updateCustomer(maKH, kh);
                loadKH();
                if (result)
                    MessageBox.Show("Cập nhật khách hàng thành công!");
                else
                    MessageBox.Show("Cập nhật khách hàng thất bại!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "";

                if (string.IsNullOrEmpty(txtMakh.Text))
                {
                    MessageBox.Show("Vui lòng chọn khách hàng cần xóa.", "Thông báo");
                    return;
                }
                bool xoaThanhCong = bllKhachHang.removeCustomer(txtMakh.Text.Trim(), ref message);
                if (xoaThanhCong)
                {
                    MessageBox.Show(message, "Thông báo");
                    loadKH();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }
        private bool isResetting = false;
        private void btnReset_Click(object sender, EventArgs e)
        {
            isResetting = true;
            isReset = true;
            txtMakh.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtDiem.Text = string.Empty;
            txtLoaiKH.Text = string.Empty;
            dptNgaySinh.Value = DateTime.Now;
            txtSoTre.Text = string.Empty;
            txTimKiem.Text = string.Empty;
            loadKH();
            isResetting = false;
            isReset = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(searchTerm))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
                    return;
                }
                DataTable result = bllKhachHang.getDataBySearch(searchTerm);
                dgvKH.DataSource = result;
                if (dgvKH.Columns.Contains("LoaiKH1"))
                {
                    dgvKH.Columns.Remove("LoaiKH1");
                }
                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khách hàng phù hợp.");
                    loadKH();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tìm kiếm: {ex.Message}");
            }
        }

        private void cbbLoaiKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedLoaiKH = (LoaiKH)cbbLoaiKH.SelectedItem;
            string maLoai = selectedLoaiKH?.MaLoai;
            if (maLoai == "-1")
            {
                loadKH();
            }
            else if (!string.IsNullOrEmpty(maLoai))
            {
                List<KhachHang> customers = bllKhachHang.getCustomersByLoaiKH(maLoai);
                dgvKH.DataSource = customers;
            }
            else
            {
                dgvKH.DataSource = null;
            }

            if (dgvKH.Columns.Contains("LoaiKH1"))
            {
                dgvKH.Columns.Remove("LoaiKH1");
            }
        }

        private void dgvKH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.ForeColor = Color.Black;
        }

        private void txtDiem_TextChanged(object sender, EventArgs e)
        {
            if (txtSDT.Text.Length > 11)
            {
                txtSDT.Text = txtSDT.Text.Substring(0, 11);
                txtSDT.SelectionStart = txtSDT.Text.Length;
            }
        }

        private void txtSoTre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoTre_TextChanged(object sender, EventArgs e)
        {

            if (!isResetting)
            {
                if (!int.TryParse(txtSoTre.Text, out int result) || result <= 0 || result >= 10)
                {

                    MessageBox.Show("Số trẻ em phải lớn hơn 0 và nhỏ hơn 10.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    txtSoTre.Text = string.Empty;
                }
            }
        }

        private void txtDiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (txtSDT.Text.Length > 11)
            {
                txtSDT.Text = txtSDT.Text.Substring(0, 11);
                txtSDT.SelectionStart = txtSDT.Text.Length;
            }
        }

        private bool isReset = false;
        private void dptNgaySinh_ValueChanged(object sender, EventArgs e)
        {

            if (isReset) return;
            DateTime selectedDate = dptNgaySinh.Value;
            DateTime currentDate = DateTime.Now;


            int age = currentDate.Year - selectedDate.Year;


            if (selectedDate > currentDate.AddYears(-age))
            {
                age--;
            }


            if (age < 18)
            {
                MessageBox.Show("Nhân viên phải trên 18 tuổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                dptNgaySinh.Value = currentDate.AddYears(-18);
            }
        }
    }
}
