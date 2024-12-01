using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;
using DTO;

namespace GUI_Form
{
    public partial class frmLoaiTP : MetroSet_UI.Forms.MetroSetForm
    {
        BLL_LoaiTP loaitp = new BLL_LoaiTP();
        int flag = 0;
        public frmLoaiTP()
        {
            InitializeComponent();
            this.Load += FrmLoaiTP_Load;
            dgvQL_LoaiThucPham.CellClick += DgvQL_LoaiThucPham_CellClick;
            dgvQL_LoaiThucPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQL_LoaiThucPham.RowHeadersVisible = false;
        }

        private void DgvQL_LoaiThucPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvQL_LoaiThucPham.Rows[e.RowIndex];
                txtMaLoai.Text = r.Cells[0].Value.ToString();
                txtTenLoai.Text = r.Cells[1].Value.ToString();
            }
        }

        private void FrmLoaiTP_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            btnLuu.Enabled = false;
            txtMaLoai.Enabled = txtTenLoai.Enabled = false;

            dgvQL_LoaiThucPham.DataSource = null;
            DataTable dt = loaitp.getAllData();
            dgvQL_LoaiThucPham.DataSource = dt;
            dgvQL_LoaiThucPham.Update();
            dgvQL_LoaiThucPham.Refresh();
            dgvQL_LoaiThucPham.Columns[0].HeaderText = "Mã loại";
            dgvQL_LoaiThucPham.Columns[1].HeaderText = "Tên loại";
            dgvQL_LoaiThucPham.AutoGenerateColumns = true;
            dgvQL_LoaiThucPham.DefaultCellStyle.ForeColor = Color.Black;
            dgvQL_LoaiThucPham.DefaultCellStyle.BackColor = Color.White;
            dgvQL_LoaiThucPham.ReadOnly = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 1;
            txtMaLoai.Clear(); txtTenLoai.Clear();
            btnXoa.Enabled = btnSua.Enabled = false;
            btnLuu.Enabled = true;
            txtTenLoai.Enabled = true;
            int sl = dgvQL_LoaiThucPham.Rows.Count;
            txtMaLoai.Text = "L" + sl.ToString("D3");
            while (loaitp.ktkc(txtMaLoai.Text))
            {
                sl += 1;
                txtMaLoai.Text = "L" + sl.ToString("D3");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Thêm
            if (flag == 1)
            {
                flag = 0;
                try
                {
                    LoaiTP them = new LoaiTP() { MaLoai = txtMaLoai.Text, TenLoai = txtTenLoai.Text };
                    if (loaitp.themLoaiThucPham(them))
                    {
                        load();
                        MessageBox.Show(this, "Đã thêm thành công !!");
                        txtMaLoai.Clear(); txtTenLoai.Clear();
                        txtMaLoai.Enabled = txtTenLoai.Enabled = false;
                        btnLuu.Enabled = false;
                        btnSua.Enabled = btnXoa.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Lỗi khi thêm dữ liệu !!");
                    btnSua.Enabled = btnXoa.Enabled = true;
                }
            }
            //sửa
            if (flag == 2)
            {
                flag = 0;
                string ma = txtMaLoai.Text;
                try
                {
                    LoaiTP sua = new LoaiTP()
                    {
                        MaLoai = ma,
                        TenLoai = txtTenLoai.Text
                    };
                    if (loaitp.suaLoaiThucPham(ma, sua))
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
                    btnThem.Enabled = btnXoa.Enabled = true;
                }
            }
        }

        private void reset()
        {
            txtMaLoai.Enabled = txtTenLoai.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            flag = 0;
            txtMaLoai.Clear(); txtTenLoai.Clear();
            load();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 2;
            txtTenLoai.Enabled = true;
            btnXoa.Enabled = btnThem.Enabled = false;
            btnLuu.Enabled = true;
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Bạn có muốn xóa loại thực phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                flag = 0;
                if (loaitp.xoaLoaiThucPham(txtMaLoai.Text))
                {
                    load();
                    MessageBox.Show(this, "Đã xóa thành công !!");
                    txtMaLoai.Clear(); txtTenLoai.Clear();
                }
                else
                {
                    MessageBox.Show(this, "Lỗi dữ liệu đã được sử dụng ở bảng khác !!");

                }
            }
        }
    }
}
