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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace GUI_Form
{
    public partial class frmPhanQuyen : MetroSet_UI.Forms.MetroSetForm
    {
        BLL_PhanQuyen phanQuyenBLL = new BLL_PhanQuyen();
        BLL_ManHinh manHinhBLL = new BLL_ManHinh();
        BLL_VaiTro vaiTroBLL = new BLL_VaiTro();
        public frmPhanQuyen()
        {
            InitializeComponent();
            dgvData.ReadOnly = true;
            dgvData.AllowUserToAddRows = dgvData.AllowUserToDeleteRows = false;
        }

        public void reLoad()
        {
            DataTable dt = manHinhBLL.getAll();
            cboManHinh.DataSource = null;
            cboManHinh.DataSource = dt;
            cboManHinh.DisplayMember = "TenMH";
            cboManHinh.ValueMember = "MaMH";
            DataTable dt2 = vaiTroBLL.getAll();
            cboVaiTro.DataSource = null;
            cboVaiTro.DataSource = dt2;
            cboVaiTro.DisplayMember = "TenVaiTro";
            cboVaiTro.ValueMember = "MaVaiTro";
        }

        private void cboVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVaiTro.SelectedIndex >= 0)
            {
                string selectedValue = cboVaiTro.SelectedValue.ToString().Trim();
                dgvData.DataSource = null;
                DataTable dt = phanQuyenBLL.getAllForDataGridView(selectedValue);
                dgvData.DataSource = dt;
                dgvData.Columns[0].Visible = false;
                dgvData.Columns[1].HeaderText = "Mã màn hình";
                dgvData.Columns[2].HeaderText = "Tên màn hình";
                dgvData.Columns[1].Width = 300;
                dgvData.Columns[2].Width = 300;
                dgvData.ColumnHeadersHeight = 40;
                dgvData.Columns[3].Visible = false;
                if (!dgvData.Columns.Contains("quyen"))
                {
                    DataGridViewCheckBoxColumn checkEdit = new DataGridViewCheckBoxColumn
                    {
                        Name = "quyen",
                        HeaderText = "Quyền",
                        ValueType = typeof(bool),
                        TrueValue = 1,
                        FalseValue = 0,
                        DataPropertyName = "HoatDong"
                    };

                    dgvData.Columns.Add(checkEdit);
                }
                dgvData.Columns["quyen"].ReadOnly = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboVaiTro.SelectedIndex >= 0)
            {
                if (cboVaiTro.SelectedValue.ToString().Trim() == null)
                {
                    CustomMessageBox.Show("Vui lòng chọn vai trò !");
                    return;
                }
                string role = cboVaiTro.SelectedValue.ToString().Trim();
                phanQuyenBLL.addAllScreenForRole(role);
                dgvData.DataSource = null;
                DataTable dt = phanQuyenBLL.getAllForDataGridView(role);
                dgvData.DataSource = dt;
                if (dgvData.Columns.Count > 0)
                {
                    dgvData.Columns[0].Visible = false;
                    dgvData.Columns[1].HeaderText = "Mã màn hình";
                    dgvData.Columns[2].HeaderText = "Tên màn hình";
                    dgvData.Columns[1].Width = 300;
                    dgvData.Columns[2].Width = 300;
                    dgvData.ColumnHeadersHeight = 40;
                    dgvData.Columns[3].Visible = false;
                    if (!dgvData.Columns.Contains("quyen"))
                    {
                        DataGridViewCheckBoxColumn checkEdit = new DataGridViewCheckBoxColumn
                        {
                            Name = "quyen",
                            HeaderText = "Quyền",
                            ValueType = typeof(bool),
                            TrueValue = 1,
                            FalseValue = 0,
                            DataPropertyName = "HoatDong"
                        };

                        dgvData.Columns.Add(checkEdit);
                    }
                    dgvData.Columns["quyen"].ReadOnly = false;
                }
            }
            else
            {
                CustomMessageBox.Show("Giá trị của vai trò không phù hợp");
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int rowCount = dgvData.RowCount;
            for (int i = 0; i < rowCount; i++)
            {
                DataGridViewRow rowData = dgvData.Rows[i];
                if (rowData != null)
                {
                    string maVaiTro = rowData.Cells[0].Value?.ToString().Trim();
                    string maMH = rowData.Cells[1].Value?.ToString().Trim();
                    bool hoatDong = (rowData.Cells[3].Value != null && int.Parse(rowData.Cells[3].Value.ToString().Trim()) == 1);
                    PhanQuyen sua = new PhanQuyen()
                    {
                        MaVaiTro = maVaiTro,
                        MaMH = maMH,
                        HoatDong = hoatDong ? 1 : 0
                    };
                    if (!phanQuyenBLL.updateItem(sua))
                        CustomMessageBox.Show("Lỗi cập nhật tại hàng " + (i + 1).ToString() + ".");
                }
            }

            if (cboVaiTro.SelectedIndex >= 0)
            {
                if (cboVaiTro.SelectedValue.ToString().Trim() == null)
                {
                    CustomMessageBox.Show("Vui lòng chọn vai trò !");
                    return;
                }
                string role = cboVaiTro.SelectedValue.ToString().Trim();
                phanQuyenBLL.addAllScreenForRole(role);
                dgvData.DataSource = null;
                DataTable dt = phanQuyenBLL.getAllForDataGridView(role);
                dgvData.DataSource = dt;
                if (dgvData.Columns.Count > 0)
                {
                    dgvData.Columns[0].Visible = false;
                    dgvData.Columns[1].HeaderText = "Mã màn hình";
                    dgvData.Columns[2].HeaderText = "Tên màn hình";
                    dgvData.Columns[1].Width = 300;
                    dgvData.Columns[2].Width = 300;
                    dgvData.ColumnHeadersHeight = 40;
                    dgvData.Columns[3].Visible = false;
                    if (!dgvData.Columns.Contains("quyen"))
                    {
                        DataGridViewCheckBoxColumn checkEdit = new DataGridViewCheckBoxColumn
                        {
                            Name = "quyen",
                            HeaderText = "Quyền",
                            ValueType = typeof(bool),
                            TrueValue = 1,
                            FalseValue = 0,
                            DataPropertyName = "HoatDong"
                        };

                        dgvData.Columns.Add(checkEdit);
                    }
                    dgvData.Columns["quyen"].ReadOnly = false;
                }
            }
        }


        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            reLoad();
        }

        private void cboVaiTro_EditValueChanged(object sender, EventArgs e)
        {
            if (cboVaiTro.SelectedIndex >= 0)
            {
                if (cboVaiTro.SelectedValue.ToString().Trim() == null)
                {
                    CustomMessageBox.Show("Vui lòng chọn vai trò !");
                    return;
                }
                string role = cboVaiTro.SelectedValue.ToString().Trim();
                phanQuyenBLL.addAllScreenForRole(role);
                dgvData.DataSource = null;
                DataTable dt = phanQuyenBLL.getAllForDataGridView(role);
                dgvData.DataSource = dt;
                if (dgvData.Columns.Count > 0)
                {
                    dgvData.Columns[0].Visible = false;
                    dgvData.Columns[1].HeaderText = "Mã màn hình";
                    dgvData.Columns[2].HeaderText = "Tên màn hình";
                    dgvData.Columns[1].Width = 300;
                    dgvData.Columns[2].Width = 300;
                    dgvData.ColumnHeadersHeight = 40;
                    dgvData.Columns[3].Visible = false;
                    if (!dgvData.Columns.Contains("quyen"))
                    {
                        DataGridViewCheckBoxColumn checkEdit = new DataGridViewCheckBoxColumn
                        {
                            Name = "quyen",
                            HeaderText = "Quyền",
                            ValueType = typeof(bool),
                            TrueValue = 1,
                            FalseValue = 0,
                            DataPropertyName = "HoatDong"
                        };

                        dgvData.Columns.Add(checkEdit);
                    }
                    dgvData.Columns["quyen"].ReadOnly = false;
                }
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvData.Rows[e.RowIndex];
                cboManHinh.Text = r.Cells[2].Value.ToString().Trim();
                chkHoatDong.Checked = (r.Cells[3].Value != null && int.Parse(r.Cells[3].Value.ToString().Trim()) == 1);
            }
        }

        private void cboManHinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkHoatDong_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridViewRow r = dgvData.Rows[dgvData.CurrentCell.RowIndex];
            if (r != null)
            {
                r.Cells[3].Value = chkHoatDong.Checked ? 1 : 0;
            }
        }
    }
}
