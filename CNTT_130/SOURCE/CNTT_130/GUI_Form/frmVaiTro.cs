using BLL_DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Form
{
    public partial class frmVaiTro : MetroSet_UI.Forms.MetroSetForm
    {
        BLL_VaiTro vaiTroBLL = new BLL_VaiTro();
        public frmVaiTro()
        {
            InitializeComponent();
        }

        public void LoadVT()
        {
            try
            {
                DataTable dt = vaiTroBLL.getAll();
                dgvVaiTro.DataSource = dt;
                dgvVaiTro.ReadOnly = true;
                dgvVaiTro.Columns["MaVaiTro"].HeaderText = "Mã vai trò";
                dgvVaiTro.Columns["TenVaiTro"].HeaderText = "Tên vai trò";
                dgvVaiTro.Columns[0].Width = 300;
                dgvVaiTro.Columns[1].Width = 300;

            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            bool result = vaiTroBLL.addVT(txtMaVaiTro.Text, txtTenVaiTro.Text);
            if (result)
            {
                CustomMessageBox.Show("Thêm nhân viên thành công!");
                LoadVT();
            }
            else
            {
                CustomMessageBox.Show("Thêm nhân viên thất bại.");
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            string maNV = txtMaVaiTro.Text;
            DTO.VaiTro nv = vaiTroBLL.getByCode(maNV);
            if (nv != null)
            {
                vaiTroBLL.deleteVT(maNV);
                LoadVT();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bool result = vaiTroBLL.updateVT(txtMaVaiTro.Text, txtTenVaiTro.Text);
            if (result)
            {
                CustomMessageBox.Show("Cập nhật nhân viên thành công!");
                LoadVT();
            }
            else
            {
                CustomMessageBox.Show("Cập nhật nhân viên thất bại.");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaVaiTro.Text = "";
            txtTenVaiTro.Text = "";
        }

        private void VaiTro_Load(object sender, EventArgs e)
        {
            LoadVT();
        }

        private void dgvVaiTro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvVaiTro.Rows[e.RowIndex];
                txtMaVaiTro.Text = r.Cells[0].Value.ToString();
                txtTenVaiTro.Text = r.Cells[1].Value.ToString();

            }
        }
    }
}
