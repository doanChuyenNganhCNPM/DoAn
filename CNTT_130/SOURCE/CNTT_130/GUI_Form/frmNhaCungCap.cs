using BLL_DAL;
using DTO;
using MetroSet_UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Form
{
    public partial class frmNhaCungCap : MetroSet_UI.Forms.MetroSetForm
    {
        BLL_NhaCC nhacungcap = new BLL_NhaCC();
        int flag = 0;
        public static string MaNCC { get; set; }

        public frmNhaCungCap()
        {
            InitializeComponent();
            this.Load += FrmNhaCungCap_Load;
            dgvNhaCungCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhaCungCap.CellClick += DgvNhaCungCap_CellClick;
            MaNCC = txtMaNCC.Text;
        }

        private void DgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnChinhSua.Enabled = true;
                DataGridViewRow r = dgvNhaCungCap.Rows[e.RowIndex];
                txtMaNCC.Text = r.Cells[0].Value.ToString();
                txtTenNCC.Text = r.Cells[1].Value.ToString();
                txtDiaChi.Text = r.Cells[2].Value.ToString();
                txtSDT.Text = r.Cells[3].Value.ToString();
                txtEmail.Text = r.Cells[4].Value.ToString();
                string tinhTrang = r.Cells[5].Value.ToString().Trim();
                if (tinhTrang == "Hoạt động")
                {
                    rdoHD.Checked = true;
                    rdoNHD.Checked = false;
                }
                else if (tinhTrang == "Ngừng hoạt động")
                {
                    rdoHD.Checked = false;
                    rdoNHD.Checked = true;
                }
                string loaiNCC = r.Cells[6].Value.ToString();
                if (loaiNCC == "1")
                {
                    rdoTroChoi.Checked = true;
                    rdoThucPham.Checked = false;
                }
                else if (loaiNCC == "2")
                {
                    rdoTroChoi.Checked = false;
                    rdoThucPham.Checked = true;
                }
                MaNCC = txtMaNCC.Text;
            }
            dgvDS.DataSource = null;
            DataTable dt1 = nhacungcap.getListProduct(txtMaNCC.Text);
            dgvDS.DataSource = dt1;
            dgvDS.Update();
            dgvDS.Refresh();
            dgvDS.Columns[0].HeaderText = "Mã sản phẩm";
            dgvDS.Columns[1].HeaderText = "Tên sản phẩm";
            dgvDS.Columns[2].HeaderText = "Giá bán";
            dgvDS.AutoGenerateColumns = true;
            dgvDS.DefaultCellStyle.ForeColor = Color.Black;
            dgvDS.DefaultCellStyle.BackColor = Color.White;

            dgvDS.ReadOnly = true;
        }
        private void load()
        {
            flag = 0;
            btnChinhSua.Enabled = btnLuu.Enabled = false;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = true;
            txtMaNCC.Enabled = txtTenNCC.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtEmail.Enabled = false;
            rdoHD.Enabled = rdoNHD.Enabled = rdoThucPham.Enabled = rdoTroChoi.Enabled = false;

            dgvNhaCungCap.RowHeadersVisible = false;
            dgvNhaCungCap.DataSource = null;
            DataTable dt = nhacungcap.getAllData();
            dgvNhaCungCap.DataSource = dt;
            dgvNhaCungCap.Update();
            dgvNhaCungCap.Refresh();
            dgvNhaCungCap.Columns[0].HeaderText = "Mã nhà cung cấp";
            dgvNhaCungCap.Columns[1].HeaderText = "Tên nhà cung cấp";
            dgvNhaCungCap.Columns[2].HeaderText = "Địa chỉ";
            dgvNhaCungCap.Columns[3].HeaderText = "Điện thoại";
            dgvNhaCungCap.Columns[4].HeaderText = "Email";
            dgvNhaCungCap.Columns[5].HeaderText = "Tình trạng";
            dgvNhaCungCap.AutoGenerateColumns = true;
            dgvNhaCungCap.DefaultCellStyle.ForeColor = Color.Black;
            dgvNhaCungCap.DefaultCellStyle.BackColor = Color.White;

            dgvNhaCungCap.ReadOnly = true;

            dgvDS.RowHeadersVisible = false;

            dgvDS.DataSource = null;

        }
        private void FrmNhaCungCap_Load(object sender, EventArgs e)
        {
            load();
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
        private void clear()
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            rdoHD.Checked = rdoNHD.Checked = false;
            rdoTroChoi.Checked = rdoThucPham.Checked = false;
            txtTimkiem.Text = string.Empty;
            dgvDS.DataSource = null;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = true;
            btnLuu.Enabled = false;
            clear();
            load();
        }
        private void active()
        {
            txtTenNCC.Enabled = txtDiaChi.Enabled = txtEmail.Enabled = txtSDT.Enabled = true;
            rdoHD.Enabled = rdoNHD.Enabled = rdoThucPham.Enabled = rdoTroChoi.Enabled = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 1;
            clear();
            active();
            btnXoa.Enabled = btnSua.Enabled = false;
            btnLuu.Enabled = true;
            txtMaNCC.Enabled = false;
            int sl = dgvNhaCungCap.Rows.Count;
            txtMaNCC.Text = "NCC" + sl.ToString("D3");
            while (nhacungcap.ktkc(txtMaNCC.Text))
            {
                sl += 1;
                txtMaNCC.Text = "NCC" + sl.ToString("D3");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 2;
            active();
            btnXoa.Enabled = btnThem.Enabled = false;
            btnLuu.Enabled = true;
            txtMaNCC.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Thêm
            if (flag == 1)
            {
                flag = 0;
                if (string.IsNullOrWhiteSpace(txtMaNCC.Text) || string.IsNullOrWhiteSpace(txtTenNCC.Text) ||
                    string.IsNullOrWhiteSpace(txtDiaChi.Text) || string.IsNullOrWhiteSpace(txtSDT.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) || !rdoHD.Checked && !rdoNHD.Checked ||
                    !rdoTroChoi.Checked && !rdoThucPham.Checked)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    clear();
                    load();
                    return;
                }
                string tinhtrang = rdoHD.Checked ? "Hoạt động" : (rdoNHD.Checked ? "Ngừng hoạt động" : "");
                string loaiNCC = rdoTroChoi.Checked ? "1" : (rdoThucPham.Checked ? "2" : "");

                try
                {
                    NhaCungCap them = new NhaCungCap()
                    {
                        MaNCC = txtMaNCC.Text,
                        TenNCC = txtTenNCC.Text,
                        DiaChi = txtDiaChi.Text,
                        SoDienThoai = txtSDT.Text,
                        Email = txtEmail.Text,
                        TinhTrang = tinhtrang,
                        LoaiNCC = int.Parse(loaiNCC)
                    };
                    if (nhacungcap.themNhaCungCap(them))
                    {
                        load();
                        MessageBox.Show(this, "Đã thêm thành công !!");
                        clear();
                        txtTenNCC.Enabled = txtDiaChi.Enabled = txtEmail.Enabled = txtSDT.Enabled = false;
                        rdoHD.Enabled = rdoNHD.Enabled = rdoThucPham.Enabled = rdoTroChoi.Enabled = false;
                        btnLuu.Enabled = false;
                        btnSua.Enabled = btnXoa.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    clear();
                    load();
                    MessageBox.Show(this, "Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Sửa
            if (flag == 2)
            {
                flag = 0;
                if (string.IsNullOrWhiteSpace(txtMaNCC.Text) || string.IsNullOrWhiteSpace(txtTenNCC.Text) ||
                    string.IsNullOrWhiteSpace(txtDiaChi.Text) || string.IsNullOrWhiteSpace(txtSDT.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) || !rdoHD.Checked && !rdoNHD.Checked ||
                    !rdoTroChoi.Checked && !rdoThucPham.Checked)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    clear();
                    load();
                    return;
                }
                string tinhtrang = rdoHD.Checked ? "Hoạt động" : (rdoNHD.Checked ? "Ngừng hoạt động" : "");
                string loaiNCC = rdoTroChoi.Checked ? "1" : (rdoThucPham.Checked ? "2" : "");
                string ma = txtMaNCC.Text;

                try
                {
                    NhaCungCap sua = new NhaCungCap()
                    {
                        MaNCC = ma,
                        TenNCC = txtTenNCC.Text,
                        DiaChi = txtDiaChi.Text,
                        SoDienThoai = txtSDT.Text,
                        Email = txtEmail.Text,
                        TinhTrang = tinhtrang,
                        LoaiNCC = int.Parse(loaiNCC)
                    };
                    if (nhacungcap.suaNhaCungCap(ma, sua))
                    {
                        load();
                        MessageBox.Show(this, "Đã sửa thành công !!");
                        btnThem.Enabled = btnXoa.Enabled = true;
                        btnLuu.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    clear();
                    load();
                    MessageBox.Show(this, "Lỗi khi sửa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Bạn có muốn xóa thực phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (nhacungcap.xoaNhaCungCap(txtMaNCC.Text))
                {
                    load();
                    MessageBox.Show(this, "Đã xóa thành công !!");
                    clear();
                }
                else
                    MessageBox.Show(this, "Lỗi dữ liệu đang được sử dụng !!");
            }
        }
        private string searchKeyword = "";
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTimkiem.Text))
            {
                searchKeyword = txtTimkiem.Text.ToLower(); // Lưu từ khóa tìm kiếm
                DataTable kq = nhacungcap.getDataBySearch(searchKeyword);

                try
                {
                    if (kq != null && kq.Rows.Count > 0)
                    {
                        dgvNhaCungCap.DataSource = null;
                        dgvNhaCungCap.DataSource = kq;
                        dgvNhaCungCap.Update();
                        dgvNhaCungCap.Refresh();

                        // Thiết lập header
                        dgvNhaCungCap.Columns[0].HeaderText = "Mã nhà cung cấp";
                        dgvNhaCungCap.Columns[1].HeaderText = "Tên nhà cung cấp";
                        dgvNhaCungCap.Columns[2].HeaderText = "Địa chỉ";
                        dgvNhaCungCap.Columns[3].HeaderText = "Số điện thoại";
                        dgvNhaCungCap.Columns[4].HeaderText = "Email";
                        dgvNhaCungCap.Columns[5].HeaderText = "Tình trạng";
                        dgvNhaCungCap.Columns[6].HeaderText = "Loại";

                        // Định dạng DataGridView
                        dgvNhaCungCap.AutoGenerateColumns = true;
                        dgvNhaCungCap.DefaultCellStyle.ForeColor = Color.Black;
                        dgvNhaCungCap.DefaultCellStyle.BackColor = Color.White;
                        dgvNhaCungCap.ReadOnly = true;

                        // Gắn sự kiện CellFormatting để tô màu phần trùng
                        dgvNhaCungCap.CellFormatting -= dgvNhaCungCap_CellFormatting;
                        dgvNhaCungCap.CellFormatting += dgvNhaCungCap_CellFormatting; // Không cần tham số searchKeyword
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

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            frmQL_DSSP frm = new frmQL_DSSP();
            frm.ShowDialog();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text.Trim();
            if (!string.IsNullOrWhiteSpace(sdt) && sdt[0] != '0')
            {
                errorProvider1.SetError(txtSDT, "Số điện thoại phải bắt đầu bằng 0.");
            }
            else if (sdt.Length < 10 || sdt.Length > 11)
            {
                errorProvider1.SetError(txtSDT, "Số điện thoại phải bao gồm 10 hoặc 11 chữ số.");
            }
            else
            {
                errorProvider1.SetError(txtSDT, "");
            }

        }
        private void ValidateEmail()
        {
            string email = txtEmail.Text.Trim();
            string emailPattern = @"^[^@\s]+@[^@\s]+\.com$";

            if (!Regex.IsMatch(email, emailPattern))
            {
                errorProvider1.SetError(txtEmail, "Email không đúng định dạng.");
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            ValidateEmail();
        }

        private void dgvNhaCungCap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void txtTimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e); // Gọi phương thức tìm kiếm khi nhấn Enter
                e.Handled = true;
                e.SuppressKeyPress = true; // Chặn beep mặc định khi nhấn Enter
            }
        }
    }
}
