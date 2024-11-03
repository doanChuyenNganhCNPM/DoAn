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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Form
{
    public partial class frmQLTroChoi : MetroSet_UI.Forms.MetroSetForm
    {
        BLL_TroChoi troChoi = new BLL_TroChoi();
        BLL_LoaiTroChoi loaiTroChoi = new BLL_LoaiTroChoi();
        bool isAdd = false, isUpdate = false;
        public frmQLTroChoi()
        {
            InitializeComponent();
            btnHuy.Enabled = btnLuu.Enabled = false;
            txtMaTroChoi.Enabled = false;
        }

        private void frmQLTroChoi_Load(object sender, EventArgs e)
        {
            reLoad();
        }

        private void dgvQLTroChoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvQLTroChoi.Rows[e.RowIndex];
                txtMaTroChoi.Text = r.Cells[0].Value.ToString();
                txtTenTroChoi.Text = r.Cells[1].Value.ToString();
                txtDiaDiem.Text = r.Cells[2].Value.ToString();
                cmbTheLoai.Text = loaiTroChoi.getTenLoai(r.Cells[3].Value.ToString().Trim());
                dateTimePicker1.Text = r.Cells[4].Value.ToString();
                dateTimePicker2.Text = r.Cells[5].Value.ToString();
                cmbTinhTrang.Text = r.Cells[6].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdd = true;
            btnLuu.Enabled = !btnLuu.Enabled;
            btnHuy.Enabled = !btnHuy.Enabled;
            int sl = dgvQLTroChoi.Rows.Count;
            txtMaTroChoi.Text = "TC" + sl.ToString("D3");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MetroSetMessageBox.Show(this, "Bạn có muốn xóa trò chơi này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (troChoi.removeGame(txtMaTroChoi.Text))
                {
                    reLoad();
                    MetroSetMessageBox.Show(this, "Đã xóa thành công !!");
                }
                else
                    MetroSetMessageBox.Show(this, "Lỗi khi xóa dữ liệu !!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isUpdate = true;
            btnLuu.Enabled = !btnLuu.Enabled;
            btnHuy.Enabled = !btnHuy.Enabled;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                isAdd = false;
                TroChoi them = new TroChoi() { MaTC = txtMaTroChoi.Text, TenTC = txtTenTroChoi.Text, DiaDiem = txtDiaDiem.Text, LoaiTroChoi = cmbTheLoai.SelectedValue.ToString(), NgayBatDau = Convert.ToDateTime(dateTimePicker1.Text), NgayKetThuc = Convert.ToDateTime(dateTimePicker2.Text), TinhTrang = cmbTinhTrang.Text };
                if (troChoi.addGame(them))
                {
                    reLoad();
                    MetroSetMessageBox.Show(this, "Đã thêm thành công !!");
                }
                else
                    MetroSetMessageBox.Show(this, "Lỗi khi thêm dữ liệu !!");
            }
            else if (isUpdate)
            {
                isUpdate = false;
                string ma = txtMaTroChoi.Text;
                TroChoi sua = new TroChoi() {MaTC = ma, TenTC = txtTenTroChoi.Text, DiaDiem = txtDiaDiem.Text, LoaiTroChoi = cmbTheLoai.SelectedValue.ToString(), NgayBatDau = Convert.ToDateTime(dateTimePicker1.Text), NgayKetThuc = Convert.ToDateTime(dateTimePicker2.Text), TinhTrang = cmbTinhTrang.Text};
                if (troChoi.updateGame(ma, sua))
                {
                    reLoad();
                    MetroSetMessageBox.Show(this, "Đã sửa thành công !!");
                }
                else
                    MetroSetMessageBox.Show(this, "Lỗi khi sửa dữ liệu !!");
            }
            btnLuu.Enabled = !btnLuu.Enabled;
            btnHuy.Enabled = !btnHuy.Enabled;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = !btnLuu.Enabled;
            btnHuy.Enabled = !btnHuy.Enabled;
            isAdd = isUpdate = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reLoad();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (rdoMaLoai.Checked)
            {
                DataTable dt = troChoi.getDataByCodeType(txtTimkiem.Text.ToString().Trim());
                if (dt != null)
                {
                    dgvQLTroChoi.DataSource = null;
                    dgvQLTroChoi.DataSource = dt;
                    dgvQLTroChoi.Columns[7].Visible = false;
                }
            }
            else if(rdoTenLoai.Checked)
            {
                DataTable dt = troChoi.getDataByNameType(txtTimkiem.Text.ToString().Trim());
                if (dt != null)
                {
                    dgvQLTroChoi.DataSource = null;
                    dgvQLTroChoi.DataSource = dt;
                    dgvQLTroChoi.Columns[7].Visible = false;
                }
            }
        }

        public void reLoad()
        {
            dgvQLTroChoi.DataSource = null;
            DataTable dt = troChoi.getAllData();
            dgvQLTroChoi.DataSource = dt;
            dgvQLTroChoi.Columns[7].Visible = false;
            List<string> list = new List<string>();
            list.Add("Hoạt động");
            list.Add("Bảo trì");
            cmbTinhTrang.Items.Clear();
            cmbTinhTrang.Items.Add(list);
            cmbTheLoai.DataSource = null;
            cmbTheLoai.DataSource = loaiTroChoi.getAllDataForComboBox();
            cmbTheLoai.DisplayMember = "TenLoai";
            cmbTheLoai.ValueMember = "MaLoai";
        }
    }
}
