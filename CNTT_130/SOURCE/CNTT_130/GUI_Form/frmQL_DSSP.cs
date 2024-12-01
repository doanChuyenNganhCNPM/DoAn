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
    public partial class frmQL_DSSP : MetroSet_UI.Forms.MetroSetForm
    {
        BLL_DSSP dssp = new BLL_DSSP();
        int flag = 0;
        public frmQL_DSSP()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += FrmQL_DSSP_Load;
            dgvDS.CellClick += DgvDS_CellClick;
            dgvDS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvDS.Rows[e.RowIndex];
                txtMaSP.Text = r.Cells[0].Value?.ToString();
                txtTenSP.Text = r.Cells[1].Value?.ToString();

                string rawPrice = r.Cells[2].Value?.ToString();
                if (decimal.TryParse(rawPrice, out decimal price))
                {
                    txtGiaBan.Text = price.ToString("N0", CultureInfo.CurrentCulture);
                }
                else
                {
                    txtGiaBan.Text = "0";
                }
            }
        }

        private void FrmQL_DSSP_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            btnLuu.Enabled = false;
            txtMaNCC.Enabled = txtMaSP.Enabled = txtTenSP.Enabled = txtGiaBan.Enabled = false;
            txtMaNCC.Text = frmNhaCungCap.MaNCC;

            dgvDS.RowHeadersVisible = false;
            dgvDS.DataSource = null;
            DataTable dt1 = dssp.getListProduct(txtMaNCC.Text);
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

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 1;
            clear();
            btnXoa.Enabled = btnSua.Enabled = false;
            btnLuu.Enabled = true;
            txtTenSP.Enabled = txtGiaBan.Enabled = true;
            int sl = dgvDS.Rows.Count;
            txtMaSP.Text = "SP" + sl.ToString("D3");
            while (dssp.ktkc(txtMaSP.Text))
            {
                sl += 1;
                txtMaSP.Text = "SP" + sl.ToString("D3");
            }
        }
        private void clear()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGiaBan.Clear();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = true;
            btnLuu.Enabled = false;
            clear();
            load();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Thêm
            if (flag == 1)
            {
                flag = 0;
                try
                {
                    NhaCungCap_DanhSachSP them = new NhaCungCap_DanhSachSP() { MaNCC = txtMaNCC.Text, MaSP = txtMaSP.Text, TenSP = txtTenSP.Text, GiaBan = double.Parse(txtGiaBan.Text) };
                    if (dssp.themDSSP(them))
                    {
                        load();
                        MessageBox.Show(this, "Đã thêm thành công !!");
                        clear();
                        txtTenSP.Enabled = txtGiaBan.Enabled = false;
                        btnLuu.Enabled = false;
                        btnSua.Enabled = btnXoa.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Lỗi khi thêm dữ liệu !!");
                }
            }

            if (flag == 2)
            {
                flag = 0;
                string mancc = txtMaNCC.Text;
                string masp = txtMaSP.Text;
                try
                {
                    NhaCungCap_DanhSachSP sua = new NhaCungCap_DanhSachSP()
                    {
                        MaNCC = mancc,
                        MaSP = masp,
                        TenSP = txtTenSP.Text,
                        GiaBan = double.Parse(txtGiaBan.Text)
                    };
                    if (dssp.suaDSSP(mancc, masp, sua))
                    {
                        load();
                        MessageBox.Show(this, "Đã sửa thành công !!");
                        btnThem.Enabled = btnXoa.Enabled = true;
                        btnLuu.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Lỗi khi sửa dữ liệu !!");
                    btnSua.Enabled = btnXoa.Enabled = true;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 2;
            btnXoa.Enabled = btnThem.Enabled = false;
            btnLuu.Enabled = true;
            txtTenSP.Enabled = txtGiaBan.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Bạn có muốn xóa thực phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (dssp.xoaDSSP(txtMaNCC.Text, txtMaSP.Text))
                {
                    load();
                    MessageBox.Show(this, "Đã xóa thành công !!");
                    clear();
                }
                else
                    MessageBox.Show(this, "Lỗi dữ liệu đang được sử dụng !!");
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
