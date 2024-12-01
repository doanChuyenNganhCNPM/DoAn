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
    public partial class frmManHinh : MetroSet_UI.Forms.MetroSetForm
    {
        BLL_ManHinh mh = new BLL_ManHinh();
        bool isAdd = false, isUpdate = false;
        public frmManHinh()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            dgvDataMH.DataSource = null;
            DataTable dt = mh.getAll();
            dgvDataMH.DataSource = dt;
            dgvDataMH.Columns[0].HeaderText = "Mã màn hình";
            dgvDataMH.Columns[1].HeaderText = "Tên màn hình";
            dgvDataMH.Columns[0].Width = 300;
            dgvDataMH.Columns[1].Width = 300;
        }

        public void clearData()
        {
            txtMaMH.Clear();
            txtTenMH.Clear();
        }

        private void dgvDataMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int index = e.RowIndex;
                txtMaMH.Text = dgvDataMH.Rows[index].Cells[0].Value.ToString();
                txtTenMH.Text = dgvDataMH.Rows[index].Cells[1].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdd = true;
            txtTenMH.Enabled = true;
            clearData();
            txtMaMH.Text = mh.GetNextMaMH();
            btnHuy.Enabled = btnLuu.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Hiển thị MessageBox xác nhận
            DialogResult result = CustomMessageBox.ShowYesNo("Bạn có chắc chắn muốn xóa màn hình này?", "Xóa");

            // Kiểm tra kết quả trả về từ MessageBox
            if (result == DialogResult.Yes)
            {
                var manHinh = mh.getByCode(txtMaMH.Text); // Lấy thông tin màn hình được chọn

                if (manHinh != null)
                {

                    mh.deleteItemMH(manHinh);

                    CustomMessageBox.Show("Xóa màn hình thành công!", "Thành công");
                    loadData();
                }
                else
                {
                    CustomMessageBox.Show("Không tìm thấy màn hình để xóa.", "Lỗi");
                }
            }
            else
            {
                CustomMessageBox.Show("Hủy thao tác xóa.", "Thông báo");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isAdd = false;
            isUpdate = true;
            txtTenMH.Enabled = true;
            btnHuy.Enabled = btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                // Kiểm tra xem các TextBox có giá trị hay không
                if (string.IsNullOrEmpty(txtMaMH.Text) || string.IsNullOrEmpty(txtTenMH.Text))
                {
                    CustomMessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Tạo đối tượng MH mới từ dữ liệu nhập vào
                var manHinh = new ManHinh()
                {
                    MaMH = txtMaMH.Text,
                    TenMH = txtTenMH.Text,
                };

                // Gọi phương thức thêm nhà cung cấp
                if (mh.addItemMH(manHinh))
                {
                    CustomMessageBox.Show("Thêm màn hình thành công!", "Thành công");
                    loadData();
                }
                else
                {
                    CustomMessageBox.Show("Lỗi khi thêm màn hình.", "Lỗi");
                }
            }
            else if (isUpdate)
            {
                // Kiểm tra lại các TextBox
                if (string.IsNullOrEmpty(txtMaMH.Text) || string.IsNullOrEmpty(txtTenMH.Text))
                {
                    CustomMessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Tạo đối tượng màn hình cũ (trước khi sửa) và đối tượng màn hình mới (sau khi sửa)
                var manHinhCurrent = new ManHinh()
                {
                    MaMH = txtMaMH.Text,
                    TenMH = ""
                };
                var manHinhNew = new ManHinh()
                {
                    MaMH = txtMaMH.Text,
                    TenMH = txtTenMH.Text,
                };

                // Gọi phương thức sửa màn hình, truyền cả đối tượng cũ và mới
                if (mh.updateItemMH(manHinhCurrent, manHinhNew))
                {
                    CustomMessageBox.Show("Sửa màn hình thành công!", "Thành công");
                    loadData();
                }
                else
                {
                    CustomMessageBox.Show("Lỗi khi sửa màn hình.", "Lỗi");
                }
            }
            btnHuy.Enabled = btnLuu.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clearData();
            btnHuy.Enabled = btnLuu.Enabled = false;
        }
    }
}
