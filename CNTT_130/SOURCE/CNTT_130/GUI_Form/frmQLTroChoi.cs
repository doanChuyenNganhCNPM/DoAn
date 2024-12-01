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
                cmbDiaDiem.Text = r.Cells[2].Value.ToString();
                cmbTheLoai.Text = loaiTroChoi.getTenLoai(r.Cells[3].Value.ToString().Trim());
                dtpNgayBatDau.Text = r.Cells[4].Value.ToString();
                dtpNgayKetThuc.Text = r.Cells[5].Value.ToString();
                cmbTinhTrang.Text = r.Cells[6].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdd = true;
            btnLuu.Enabled = !btnLuu.Enabled;
            btnHuy.Enabled = !btnHuy.Enabled;
            int sl = troChoi.getAllData().Rows.Count + 1;
            txtMaTroChoi.Text = "TC" + sl.ToString("D3");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = CustomMessageBox.ShowYesNo("Bạn có muốn xóa trò chơi này không?", "Xác nhận xóa");
            if (result == DialogResult.Yes)
            {
                if (troChoi.removeGame(txtMaTroChoi.Text))
                {
                    reLoad();
                    CustomMessageBox.Show("Đã xóa thành công !!");
                }
                else
                    CustomMessageBox.Show("Lỗi khi xóa dữ liệu !!");
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
                TroChoi them = new TroChoi() { MaTC = txtMaTroChoi.Text, TenTC = txtTenTroChoi.Text, DiaDiem = cmbDiaDiem.Text, LoaiTroChoi = cmbTheLoai.SelectedValue.ToString(), NgayBatDau = Convert.ToDateTime(dtpNgayBatDau.Text), NgayKetThuc = Convert.ToDateTime(dtpNgayKetThuc.Text), TinhTrang = cmbTinhTrang.Text };
                if (troChoi.addGame(them))
                {
                    reLoad();
                    CustomMessageBox.Show("Đã thêm thành công !!");
                }
                else
                    CustomMessageBox.Show("Lỗi khi thêm dữ liệu !!");
            }
            else if (isUpdate)
            {
                isUpdate = false;
                string ma = txtMaTroChoi.Text;
                TroChoi sua = new TroChoi()
                {
                    MaTC = ma,
                    TenTC = txtTenTroChoi.Text,
                    DiaDiem = cmbDiaDiem.Text,
                    LoaiTroChoi = cmbTheLoai.SelectedValue.ToString(),
                    NgayBatDau = dtpNgayBatDau.Value,
                    NgayKetThuc = dtpNgayKetThuc.Value,
                    TinhTrang = cmbTinhTrang.Text
                };
                if (troChoi.updateGame(ma, sua))
                {
                    reLoad();
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            reLoad();
            txtTimkiem.Text = string.Empty;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtTimkiem.Text))
            {
                DataTable kq = troChoi.getDataBySearch(txtTimkiem.Text);
                if (kq != null)
                {
                    dgvQLTroChoi.DataSource = null;
                    dgvQLTroChoi.DataSource = kq;
                    dgvQLTroChoi.Refresh();
                    //dgvQLTroChoi.Columns[7].Visible = false;
                    dgvQLTroChoi.Columns[0].HeaderText = "Mã trò chơi";
                    dgvQLTroChoi.Columns[1].HeaderText = "Tên trò chơi";
                    dgvQLTroChoi.Columns[2].HeaderText = "Địa điểm";
                    dgvQLTroChoi.Columns[3].HeaderText = "Mã loại";
                    dgvQLTroChoi.Columns[4].HeaderText = "Ngày bắt đầu";
                    dgvQLTroChoi.Columns[5].HeaderText = "Ngày kết thúc";
                    dgvQLTroChoi.Columns[6].HeaderText = "Tình trạng";
                    dgvQLTroChoi.ReadOnly = true;
                }
                else
                {
                    CustomMessageBox.Show("Không tìm thấy bất cứ kết quả nào !!", "Thông báo");
                }
            }
        }

        public void reLoad()
        {
            dgvQLTroChoi.DataSource = null;
            DataTable dt = troChoi.getAllData();
            dgvQLTroChoi.DataSource = dt;
            dgvQLTroChoi.Refresh();
            //dgvQLTroChoi.Columns[7].Visible = false;
            dgvQLTroChoi.Columns[0].HeaderText = "Mã trò chơi";
            dgvQLTroChoi.Columns[1].HeaderText = "Tên trò chơi";
            dgvQLTroChoi.Columns[2].HeaderText = "Địa điểm";
            dgvQLTroChoi.Columns[3].HeaderText = "Mã loại";
            dgvQLTroChoi.Columns[4].HeaderText = "Ngày bắt đầu";
            dgvQLTroChoi.Columns[5].HeaderText = "Ngày kết thúc";
            dgvQLTroChoi.Columns[6].HeaderText = "Tình trạng";
            dgvQLTroChoi.ReadOnly = true;
            List<string> list = new List<string>();
            list.Add("Hoạt động");
            list.Add("Bảo trì");
            cmbTinhTrang.Items.Clear();
            foreach (var item in list)
            {
                cmbTinhTrang.Items.Add(item);
            }
            List<string> listDD = new List<string>();
            listDD.Add("Khu vực A");
            listDD.Add("Khu vực B");
            listDD.Add("Khu vực C");
            listDD.Add("Khu vực D");
            listDD.Add("Khu vực E");
            listDD.Add("Khu vực F");
            cmbDiaDiem.Items.Clear();
            foreach (var item in listDD)
            {
                cmbDiaDiem.Items.Add(item);
            }
            cmbTheLoai.DataSource = null;
            cmbTheLoai.DataSource = loaiTroChoi.getAllDataForComboBox();
            cmbTheLoai.DisplayMember = "TenLoai";
            cmbTheLoai.ValueMember = "MaLoai";
        }
    }
}
