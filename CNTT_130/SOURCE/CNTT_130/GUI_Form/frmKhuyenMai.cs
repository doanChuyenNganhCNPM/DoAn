using BLL_DAL;
using DTO;
using MetroSet_UI.Forms;
using Microsoft.Office.Interop.Word;
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
    public partial class frmKhuyenMai : MetroSet_UI.Forms.MetroSetForm
    {
        BLL_KhuyenMai khuyenMaiBLL = new BLL_KhuyenMai();
        bool isAdd = false, isUpdate = false;
        public void reload()
        {
            dgvData.DataSource = null;
            System.Data.DataTable dt = khuyenMaiBLL.getAll();
            dgvData.DataSource = dt;
            dgvData.Refresh();
            dgvData.Columns[0].HeaderText = "Mã khuyến mãi";
            dgvData.Columns[1].HeaderText = "Tên khuyến mãi";
            dgvData.Columns[2].HeaderText = "Ngày bắt đầu";
            dgvData.Columns[3].HeaderText = "Ngày kết thúc";
            dgvData.Columns[4].HeaderText = "Phần trăm giảm";
            dgvData.Columns[5].HeaderText = "Tình trạng";
            dgvData.Columns[6].HeaderText = "Mô tả";
            List<string> list = new List<string>();
            list.Add("Sắp diễn ra");
            list.Add("Hết hạn");
            list.Add("Đang áp dụng");
            cboTinhTrang.Items.Clear();
            foreach (var item in list)
            {
                cboTinhTrang.Items.Add(item);
            }
            dgvData.ReadOnly = true;
        }
        private void frmKhuyenMai_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            isAdd = true;
            btnLuu.Enabled = !btnLuu.Enabled;
            btnHuy.Enabled = !btnHuy.Enabled;
            int sl = khuyenMaiBLL.getAll().Rows.Count + 1;
            string ma = "KM" + sl.ToString("D3");
            while (khuyenMaiBLL.getByCode(ma) != null)
            {
                sl++;
                ma = "KM" + sl.ToString("D3");
            }
            txtMaKM.Text = ma;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = CustomMessageBox.ShowYesNo("Bạn có muốn xóa khuyến mãi này không?", "Xác nhận xóa");
            if (result == DialogResult.Yes)
            {
                if (khuyenMaiBLL.removeItem(txtMaKM.Text))
                {
                    reload();
                    CustomMessageBox.Show("Đã xóa thành công !!");
                }
                else
                    CustomMessageBox.Show("Lỗi khi xóa dữ liệu !!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isUpdate = true;
            btnLuu.Enabled = !btnLuu.Enabled;
            btnHuy.Enabled = !btnHuy.Enabled;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                isAdd = false;
                KhuyenMai them = new KhuyenMai()
                {
                    MaKM = txtMaKM.Text,
                    TenKM = txtTenKM.Text,
                    NgayBatDau = Convert.ToDateTime(dtpNgayBatDau.Text),
                    NgayKetThuc = Convert.ToDateTime(dtpNgayKetThuc.Text),
                    PhanTramGiam = double.Parse(txtPhanTramGiam.Text),
                    TinhTrang = cboTinhTrang.Text,
                    MoTa = txtMoTa.Text,
                };
                if (khuyenMaiBLL.addItem(them))
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
                KhuyenMai sua = new KhuyenMai()
                {
                    MaKM = txtMaKM.Text,
                    TenKM = txtTenKM.Text,
                    NgayBatDau = Convert.ToDateTime(dtpNgayBatDau.Text),
                    NgayKetThuc = Convert.ToDateTime(dtpNgayKetThuc.Text),
                    PhanTramGiam = double.Parse(txtPhanTramGiam.Text),
                    TinhTrang = cboTinhTrang.Text,
                    MoTa = txtMoTa.Text,
                };
                if (khuyenMaiBLL.updateItem(sua))
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

        private void button4_Click(object sender, EventArgs e)
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
                txtMaKM.Text = r.Cells[0].Value.ToString();
                txtTenKM.Text = r.Cells[1].Value.ToString();
                dtpNgayBatDau.Text = r.Cells[2].Value.ToString();
                dtpNgayKetThuc.Text = r.Cells[3].Value.ToString();
                cboTinhTrang.Text = r.Cells[5].Value.ToString();
                txtPhanTramGiam.Text = r.Cells[4].Value.ToString();
                txtMoTa.Text = r.Cells[6].Value.ToString();
            }
        }

        public frmKhuyenMai()
        {
            InitializeComponent();
            txtMaKM.Enabled = btnHuy.Enabled = btnLuu.Enabled = false;
        }
    }
}
