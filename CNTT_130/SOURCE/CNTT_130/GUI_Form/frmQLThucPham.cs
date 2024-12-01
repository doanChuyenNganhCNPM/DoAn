using BLL_DAL;
using DTO;
using MetroSet_UI.Forms;
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

namespace GUI_Form
{
    public partial class frmQLThucPham : MetroSet_UI.Forms.MetroSetForm
    {
        BLL_ThucPham thucpham = new BLL_ThucPham();
        BLL_LoaiTP loaiTP = new BLL_LoaiTP();
        int flag = 0;
        public frmQLThucPham()
        {
            InitializeComponent();
            dgvQL_ThucPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQL_ThucPham.RowHeadersVisible = false;
        }
        private void load()
        {
            btnLuu.Enabled = false;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = true;
            txtMaTP.Enabled = txtTenTP.Enabled = txtMota.Enabled = txtGiaBan.Enabled = txtSoLuong.Enabled = txtDVT.Enabled = false;
            rdoCo.Enabled = rdoHet.Enabled = false;
            cmbLoaiTP.Enabled = false;

            dgvQL_ThucPham.DataSource = null;
            DataTable dt = thucpham.getAllData();
            dgvQL_ThucPham.DataSource = dt;
            dgvQL_ThucPham.Update();
            dgvQL_ThucPham.Refresh();
            dgvQL_ThucPham.Columns[0].HeaderText = "Mã thực phẩm";
            dgvQL_ThucPham.Columns[1].HeaderText = "Tên thực phẩm";
            dgvQL_ThucPham.Columns[2].HeaderText = "Mô tả";
            dgvQL_ThucPham.Columns[3].HeaderText = "Giá bán";
            dgvQL_ThucPham.Columns[4].HeaderText = "Đơn vị tính";
            dgvQL_ThucPham.Columns[5].HeaderText = "Số lượng";
            dgvQL_ThucPham.Columns[6].HeaderText = "Tên loại";
            dgvQL_ThucPham.Columns[7].HeaderText = "Tình trạng";
            dgvQL_ThucPham.AutoGenerateColumns = true;
            dgvQL_ThucPham.DefaultCellStyle.ForeColor = Color.Black;
            dgvQL_ThucPham.DefaultCellStyle.BackColor = Color.White;

            dgvQL_ThucPham.ReadOnly = true;
        }

        private void dgvQL_ThucPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvQL_ThucPham.Rows[e.RowIndex];
                txtMaTP.Text = r.Cells[0].Value.ToString();
                txtTenTP.Text = r.Cells[1].Value.ToString();
                txtMota.Text = r.Cells[2].Value.ToString();
                txtDVT.Text = r.Cells[4].Value.ToString();
                txtSoLuong.Text = r.Cells[5].Value.ToString();
                cmbLoaiTP.Text = loaiTP.getTenLoai(r.Cells[6].Value.ToString().Trim());
                string tinhTrang = r.Cells[7].Value.ToString().Trim();
                if (tinhTrang == "Còn hàng")
                {
                    rdoCo.Checked = true;
                    rdoHet.Checked = false;
                }
                else if (tinhTrang == "Hết hàng")
                {
                    rdoCo.Checked = false;
                    rdoHet.Checked = true;
                }
                string giaban = r.Cells[3].Value?.ToString();
                if (decimal.TryParse(giaban, out decimal price1))
                {
                    txtGiaBan.Text = price1.ToString("N0", CultureInfo.CurrentCulture);
                }
                else
                {
                    txtGiaBan.Text = "0";
                }
            }
        }
        private void loadcmb()
        {

            cmbLoaiTP.DataSource = null;
            cmbLoaiTP.DataSource = loaiTP.getAllData();
            cmbLoaiTP.DisplayMember = "TenLoai";
            cmbLoaiTP.ValueMember = "MaLoai";
        }
        private void frmQLThucPham_Load(object sender, EventArgs e)
        {
            load();
        }
        private void reset()
        {
            flag = 0;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = true;
            btnLuu.Enabled = false;
            clear();
            load();

        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void clear()
        {
            txtMaTP.Clear();
            txtTenTP.Clear();
            txtMota.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            txtDVT.Clear();
            cmbLoaiTP.Text = "";
            rdoCo.Checked = rdoHet.Checked = false;
            txtTimkiem.Text = string.Empty;
        }
        private void active()
        {
            txtTenTP.Enabled = txtMota.Enabled = txtGiaBan.Enabled = txtSoLuong.Enabled = txtDVT.Enabled = cmbLoaiTP.Enabled = true;
            rdoCo.Enabled = rdoHet.Enabled = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 1;
            clear();
            active();
            loadcmb();
            btnXoa.Enabled = btnSua.Enabled = false;
            btnLuu.Enabled = true;
            txtMaTP.Enabled = false;
            int sl = dgvQL_ThucPham.Rows.Count;
            txtMaTP.Text = "TP" + sl.ToString("D3");
            while (thucpham.ktkc(txtMaTP.Text))
            {
                sl += 1;
                txtMaTP.Text = "TP" + sl.ToString("D3");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Thêm
            if (flag == 1)
            {
                flag = 0;

                if (string.IsNullOrWhiteSpace(txtMaTP.Text) || string.IsNullOrWhiteSpace(txtTenTP.Text) ||
                    string.IsNullOrWhiteSpace(txtGiaBan.Text) || string.IsNullOrWhiteSpace(txtDVT.Text) ||
                    string.IsNullOrWhiteSpace(txtSoLuong.Text) || cmbLoaiTP.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    reset();
                    return;
                }

                string tinhtrang = rdoCo.Checked ? "Còn hàng" : (rdoHet.Checked ? "Hết hàng" : "");

                try
                {
                    ThucPham them = new ThucPham()
                    {
                        MaTP = txtMaTP.Text,
                        TenTP = txtTenTP.Text,
                        MoTa = txtMota.Text,
                        GiaBan = double.Parse(txtGiaBan.Text),
                        DVT = txtDVT.Text,
                        SoLuong = int.Parse(txtSoLuong.Text),
                        MaLoai = cmbLoaiTP.SelectedValue.ToString(),
                        TinhTrang = tinhtrang
                    };

                    if (thucpham.themThucPham(them))
                    {
                        load();
                        MessageBox.Show(this, "Đã thêm thành công !!");
                        clear();
                        txtTenTP.Enabled = txtMota.Enabled = txtGiaBan.Enabled = txtSoLuong.Enabled = false;
                        btnLuu.Enabled = false;
                        btnSua.Enabled = btnXoa.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show(this, "Lỗi khi thêm dữ liệu !!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    load();
                    clear();
                }
            }

            // Sửa
            if (flag == 2)
            {
                flag = 0;

                if (string.IsNullOrWhiteSpace(txtTenTP.Text) || string.IsNullOrWhiteSpace(txtGiaBan.Text) ||
                    string.IsNullOrWhiteSpace(txtDVT.Text) || string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                    cmbLoaiTP.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    reset();
                    return;
                }

                string tinhtrang = rdoCo.Checked ? "Còn hàng" : (rdoHet.Checked ? "Hết hàng" : "");

                string ma = txtMaTP.Text;

                try
                {
                    ThucPham sua = new ThucPham()
                    {
                        MaTP = ma,
                        TenTP = txtTenTP.Text,
                        MoTa = txtMota.Text,
                        GiaBan = double.Parse(txtGiaBan.Text),
                        DVT = txtDVT.Text,
                        SoLuong = int.Parse(txtSoLuong.Text),
                        MaLoai = cmbLoaiTP.SelectedValue.ToString(),
                        TinhTrang = tinhtrang
                    };

                    if (thucpham.suaThucPham(ma, sua))
                    {
                        load();
                        MessageBox.Show(this, "Đã sửa thành công !!");
                        btnThem.Enabled = btnXoa.Enabled = true;
                        btnLuu.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show(this, "Lỗi khi sửa dữ liệu !!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Lỗi khi sửa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    load();
                    clear();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = CustomMessageBox.ShowYesNo("Bạn có muốn xóa thực phẩm này không?", "Xác nhận xóa");
            if (result == DialogResult.Yes)
            {
                if (thucpham.xoaThucPham(txtMaTP.Text))
                {
                    load();
                    CustomMessageBox.Show("Đã xóa thành công !!");
                    clear();
                }
                else
                    CustomMessageBox.Show("Lỗi khi xóa dữ liệu !!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 2;
            active();
            loadcmb();
            btnXoa.Enabled = btnThem.Enabled = false;
            btnLuu.Enabled = true;
            txtMaTP.Enabled = false;
        }

        private string searchKeyword = "";

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtTimkiem.Text))
            {
                searchKeyword = txtTimkiem.Text.ToLower(); // Lưu từ khóa tìm kiếm
                DataTable kq = thucpham.getDataBySearch(searchKeyword); // Lấy kết quả tìm kiếm từ lớp thucpham
                try
                {
                    if (kq != null && kq.Rows.Count > 0)
                    {
                        // Cập nhật dữ liệu vào DataGridView
                        dgvQL_ThucPham.DataSource = null;
                        dgvQL_ThucPham.DataSource = kq;
                        dgvQL_ThucPham.Update();
                        dgvQL_ThucPham.Refresh();

                        if (dgvQL_ThucPham.Columns.Contains("LoaiTP"))
                        {
                            dgvQL_ThucPham.Columns.Remove("LoaiTP");
                        }
                        // Cấu hình tiêu đề cột
                        dgvQL_ThucPham.Columns[0].HeaderText = "Mã thực phẩm";
                        dgvQL_ThucPham.Columns[1].HeaderText = "Tên thực phẩm";
                        dgvQL_ThucPham.Columns[2].HeaderText = "Mô tả";
                        dgvQL_ThucPham.Columns[3].HeaderText = "Giá bán";
                        dgvQL_ThucPham.Columns[4].HeaderText = "Đơn vị tính";
                        dgvQL_ThucPham.Columns[5].HeaderText = "Số lượng";
                        dgvQL_ThucPham.Columns[6].HeaderText = "Tên loại";
                        dgvQL_ThucPham.Columns[7].HeaderText = "Tình trạng";

                        // Cấu hình DataGridView
                        dgvQL_ThucPham.AutoGenerateColumns = true;
                        dgvQL_ThucPham.DefaultCellStyle.ForeColor = Color.Black;
                        dgvQL_ThucPham.DefaultCellStyle.BackColor = Color.White;
                        dgvQL_ThucPham.ReadOnly = true;

                        // Liên kết sự kiện CellFormatting để tô màu highlight
                        dgvQL_ThucPham.CellFormatting -= dgvQL_ThucPham_CellFormatting;
                        dgvQL_ThucPham.CellFormatting += dgvQL_ThucPham_CellFormatting;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bất cứ kết quả nào!", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
                }
            }
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

        private void dgvQL_ThucPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && !string.IsNullOrEmpty(searchKeyword))
            {
                string cellText = e.Value.ToString().ToLower(); // Lấy nội dung ô dưới dạng chữ thường
                if (cellText.Contains(searchKeyword)) // Kiểm tra xem nội dung ô có chứa từ khóa không
                {
                    // Tô màu nền ô và làm đậm chữ
                    e.CellStyle.BackColor = Color.DarkGray;
                    e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Font chữ đậm
                    e.CellStyle.ForeColor = Color.Black; // Màu chữ đen
                }
                else
                {
                    // Khôi phục màu nền và font chữ mặc định nếu không trùng khớp
                    e.CellStyle.BackColor = Color.White;
                    e.CellStyle.ForeColor = Color.Black;
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
