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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Form
{
    public partial class frmQLThietBi : MetroSet_UI.Forms.MetroSetForm
    {
        BLL_ThietBi thietBi = new BLL_ThietBi();
        int flag = 0;
        public frmQLThietBi()
        {
            InitializeComponent();
            dgvQL_ThietBi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQL_ThietBi.RowHeadersVisible = false;
            btnThem.Enabled = false;
        }
        private void load()
        {
            flag = 0;
            btnLuu.Enabled = false;
            btnXoa.Enabled = btnSua.Enabled = true;
            txtMaTB.Enabled = txtTenTB.Enabled = txtGiaBan.Enabled = txtSoLuong.Enabled = false;

            dgvQL_ThietBi.DataSource = null;
            DataTable dt = thietBi.getAllData();
            dgvQL_ThietBi.DataSource = dt;
            dgvQL_ThietBi.Update();
            dgvQL_ThietBi.Refresh();
            dgvQL_ThietBi.Columns[0].HeaderText = "Mã thiết bi";
            dgvQL_ThietBi.Columns[1].HeaderText = "Tên thiết bị";
            dgvQL_ThietBi.Columns[2].HeaderText = "Giá nhập";
            dgvQL_ThietBi.Columns[3].HeaderText = "Số lượng";
            dgvQL_ThietBi.AutoGenerateColumns = true;
            dgvQL_ThietBi.DefaultCellStyle.ForeColor = Color.Black;
            dgvQL_ThietBi.DefaultCellStyle.BackColor = Color.White;

            dgvQL_ThietBi.ReadOnly = true;
        }

        private void dgvQL_ThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvQL_ThietBi.Rows[e.RowIndex];
                txtMaTB.Text = r.Cells[0].Value.ToString();
                txtTenTB.Text = r.Cells[1].Value.ToString();
                txtSoLuong.Text = r.Cells[3].Value.ToString();
                string giaban = r.Cells[2].Value?.ToString();
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

        private void QLThietBi_Load(object sender, EventArgs e)
        {
            load();
        }
        private void reset()
        {
            flag = 0;
            btnXoa.Enabled = btnSua.Enabled = true;
            btnLuu.Enabled = false;
            clear();
            load();

        }
        private void clear()
        {
            txtMaTB.Clear();
            txtTenTB.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            txtTimkiem.Text = string.Empty;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void active()
        {
            txtTenTB.Enabled = txtGiaBan.Enabled = txtSoLuong.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 1;
            clear();
            active();
            btnXoa.Enabled = btnSua.Enabled = false;
            btnLuu.Enabled = true;
            txtMaTB.Enabled = false;
            int sl = dgvQL_ThietBi.Rows.Count;
            txtMaTB.Text = "TB" + sl.ToString("D3");
            while (thietBi.ktkc(txtMaTB.Text))
            {
                sl += 1;
                txtMaTB.Text = "TB" + sl.ToString("D3");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                flag = 0;

                try
                {
                    ThietBi them = new ThietBi()
                    {
                        MaTB = txtMaTB.Text,
                        TenTB = txtTenTB.Text,
                        GiaBan = double.Parse(txtGiaBan.Text),
                        SoLuong = int.Parse(txtSoLuong.Text)
                    };
                    if (thietBi.themThietBi(them))
                    {
                        load();
                        MessageBox.Show(this, "Đã thêm thành công !!");
                        clear();
                        txtTenTB.Enabled = txtGiaBan.Enabled = txtSoLuong.Enabled = false;
                        btnLuu.Enabled = false;
                        btnSua.Enabled = btnXoa.Enabled = true;
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

                if (string.IsNullOrWhiteSpace(txtTenTB.Text) || string.IsNullOrWhiteSpace(txtGiaBan.Text) || string.IsNullOrWhiteSpace(txtSoLuong.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    reset();
                    return;
                }
                string ma = txtMaTB.Text;

                try
                {
                    ThietBi sua = new ThietBi()
                    {
                        MaTB = ma,
                        TenTB = txtTenTB.Text,
                        GiaBan = double.Parse(txtGiaBan.Text),
                        SoLuong = int.Parse(txtSoLuong.Text),
                    };

                    if (thietBi.suaThietBi(ma, sua))
                    {
                        load();
                        MessageBox.Show(this, "Đã sửa thành công !!");
                        btnThem.Enabled = btnXoa.Enabled = true;
                        btnLuu.Enabled = false;
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
            DialogResult result = CustomMessageBox.ShowYesNo("Bạn có muốn xóa thiết bị này không?", "Xác nhận xóa");
            if (result == DialogResult.Yes)
            {
                if (thietBi.xoaThietBi(txtMaTB.Text))
                {
                    load();
                    CustomMessageBox.Show("Đã xóa thành công !!");
                    clear();
                }
                else
                    CustomMessageBox.Show("Lỗi dữ liệu đang được sử dụng !!");
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 2;
            active();
            btnXoa.Enabled = btnThem.Enabled = false;
            btnLuu.Enabled = true;
            txtMaTB.Enabled = false;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTimkiem.Text))
            {
                DataTable kq = thietBi.getDataBySearch(txtTimkiem.Text);
                try
                {
                    if (kq != null)
                    {
                        dgvQL_ThietBi.DataSource = null;
                        dgvQL_ThietBi.DataSource = kq;
                        dgvQL_ThietBi.Update();
                        dgvQL_ThietBi.Refresh();
                        dgvQL_ThietBi.Columns[0].HeaderText = "Mã thiết bị";
                        dgvQL_ThietBi.Columns[1].HeaderText = "Tên thiết bị";
                        dgvQL_ThietBi.Columns[2].HeaderText = "Giá nhập";
                        dgvQL_ThietBi.Columns[3].HeaderText = "Số lượng";
                        dgvQL_ThietBi.AutoGenerateColumns = true;
                        dgvQL_ThietBi.DefaultCellStyle.ForeColor = Color.Black;
                        dgvQL_ThietBi.DefaultCellStyle.BackColor = Color.White;

                        dgvQL_ThietBi.ReadOnly = true;
                    }
                }
                catch
                {
                    CustomMessageBox.Show("Không tìm thấy bất cứ kết quả nào !!", "Thông báo");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát form?", "Xác nhận thoát",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
