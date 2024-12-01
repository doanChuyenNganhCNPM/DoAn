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
    public partial class frmVe : MetroSet_UI.Forms.MetroSetForm
    {
        BLL_LoaiVe loaiVeBLL = new BLL_LoaiVe();
        BLL_TroChoi trochoiBLL = new BLL_TroChoi();
        BLL_Ve veBLL = new BLL_Ve();
        bool isAdd = false, isUpdate = false;

        public void reload()
        {
            dgvData.DataSource = null;
            DataTable dt = veBLL.getAll();
            dgvData.DataSource = dt;
            dgvData.Refresh();
            dgvData.Columns[0].HeaderText = "Mã vé";
            dgvData.Columns[1].HeaderText = "Loại vé";
            dgvData.Columns[2].HeaderText = "Thời gian bán";
            dgvData.Columns[3].HeaderText = "Số lượng";
            dgvData.Columns[4].HeaderText = "Tình trạng";
            dgvData.Columns[5].HeaderText = "Mã trò chơi";
            List<string> list = new List<string>();
            list.Add("Mới");
            list.Add("Hết hạn");
            list.Add("Đã sử dụng");
            cboTinhTrang.Items.Clear();
            foreach (var item in list)
            {
                cboTinhTrang.Items.Add(item);
            }
            cboLoaiVe.DataSource = null;
            cboLoaiVe.DataSource = loaiVeBLL.getCodeAndName();
            cboLoaiVe.DisplayMember = "TenLoai";
            cboLoaiVe.ValueMember = "MaLoai";
            cboTroChoi.DataSource = null;
            cboTroChoi.DataSource = trochoiBLL.getCodeAndName();
            cboTroChoi.DisplayMember = "TenTC";
            cboTroChoi.ValueMember = "MaTC";
            dgvData.ReadOnly = true;
        }
        private void frmVe_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdd = true;
            btnLuu.Enabled = !btnLuu.Enabled;
            btnHuy.Enabled = !btnHuy.Enabled;
            int sl = veBLL.getAll().Rows.Count + 1;
            string maVe = "VE" + sl.ToString("D3");
            while (veBLL.getByCode(maVe) != null)
            {
                sl++;
                maVe = "VE" + sl.ToString("D3");
            }
            txtMaVe.Text = maVe;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isUpdate = true;
            btnLuu.Enabled = !btnLuu.Enabled;
            btnHuy.Enabled = !btnHuy.Enabled;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = CustomMessageBox.ShowYesNo("Bạn có muốn xóa vé này không?", "Xác nhận xóa");
            if (result == DialogResult.Yes)
            {
                if (veBLL.removeItem(txtMaVe.Text))
                {
                    reload();
                    CustomMessageBox.Show("Đã xóa thành công !!");
                }
                else
                    CustomMessageBox.Show("Lỗi khi xóa dữ liệu !!");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                isAdd = false;
                Ve them = new Ve() { 
                    MaVe = txtMaVe.Text, 
                    LoaiVe = cboLoaiVe.SelectedValue.ToString(), 
                    ThoiGianBan = Convert.ToDateTime(dtpNgayBan.Text), 
                    SoLuong = 1, 
                    TinhTrang = cboTinhTrang.Text, 
                    TroChoi = cboTroChoi.Text == "Không có"? null : cboTroChoi.SelectedValue.ToString(),
                };
                if (veBLL.addItem(them))
                {
                    reload();
                    CustomMessageBox.Show("Đã thêm thành công !!");
                }
                else
                    CustomMessageBox.Show("Lỗi khi thêm dữ liệu !!");
            }
            else if (isUpdate)
            {
                isUpdate = false;
                Ve sua = new Ve()
                {
                    MaVe = txtMaVe.Text,
                    LoaiVe = cboLoaiVe.SelectedValue.ToString(),
                    ThoiGianBan = Convert.ToDateTime(dtpNgayBan.Text),
                    SoLuong = 1,
                    TinhTrang = cboTinhTrang.Text,
                    TroChoi = cboTroChoi.Text == "Không có" ? null : cboTroChoi.SelectedValue.ToString(),
                };
                if (veBLL.updateItem(sua))
                {
                    reload();
                    CustomMessageBox.Show("Đã sửa thành công !!");
                }
                else
                    CustomMessageBox.Show("Lỗi khi sửa dữ liệu !!");
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

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dgvData.Rows.Count)
            {
                DataGridViewRow r = dgvData.Rows[e.RowIndex];
                txtMaVe.Text = r.Cells[0].Value.ToString();
                cboLoaiVe.Text = loaiVeBLL.getNameByCode(r.Cells[1].Value.ToString());
                txtGia.Text = loaiVeBLL.getPriceByCode(r.Cells[1].Value.ToString()).ToString();
                dtpNgayBan.Text = r.Cells[2].Value.ToString();
                cboTinhTrang.Text = r.Cells[4].Value.ToString();
                cboTroChoi.Text = trochoiBLL.getNameByCode(r.Cells[5].Value.ToString());
            }
        }

        private void cboLoaiVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboLoaiVe.SelectedValue != null)
            {
                txtGia.Text = loaiVeBLL.getPriceByCode(cboLoaiVe.SelectedValue.ToString()).ToString();
            }
            if(cboLoaiVe.SelectedIndex == 0 || cboLoaiVe.Text == "Không có")
            {
                cboTroChoi.Text = "Không có";
                cboTroChoi.Enabled = false;
            }
            if(cboLoaiVe.SelectedIndex == 1)
            {
                cboTroChoi.Enabled = true;
            }
        }

        public frmVe()
        {
            InitializeComponent();
            btnHuy.Enabled = btnLuu.Enabled = txtMaVe.Enabled = txtGia.Enabled = false;
        }
    }
}
