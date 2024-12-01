using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;
using DTO;

namespace GUI_Form
{
    public partial class frmQLLoaiTroChoi : MetroSet_UI.Forms.MetroSetForm
    {
        BLL_LoaiTroChoi bll = new BLL_LoaiTroChoi();
        public frmQLLoaiTroChoi()
        {
            InitializeComponent();
            txtMaLTC.Enabled = false;
            LoadLoaiTCData();
            dgvLoaiTroChoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void frmQLLoaiTroChoi_Load(object sender, EventArgs e)
        {
            LoadLoaiTCData();
        }
        private void LoadLoaiTCData()
        {
            DataTable dt = bll.getAllDataLTC();
            dgvLoaiTroChoi.DataSource = dt;
        }

        private void dgvLoaiTroChoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLoaiTroChoi.Rows[e.RowIndex];
                txtMaLTC.Text = row.Cells["MaLoai"].Value.ToString();
                txtTenLTC.Text = row.Cells["TenLoai"].Value.ToString();
                txtMoTa.Text = row.Cells["GhiChu"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTenLTC.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin loại trò chơi.", "Thông báo");
                    return;
                }



                var loaiTC = new LoaiTC
                {
                    TenLoai = txtTenLTC.Text.Trim(),
                    GhiChu = txtMoTa.Text.Trim()
                };

                if (bll.addLoaiTroChoi(loaiTC))
                {
                    MessageBox.Show("Thêm loại trò chơi thành công!", "Thông báo");
                    LoadLoaiTCData();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaLTC.Text))
                {
                    MessageBox.Show("Vui lòng chọn loại trò chơi cần sửa.", "Thông báo");
                    return;
                }


                var sua = new LoaiTC
                {
                    TenLoai = txtTenLTC.Text.Trim(),
                    GhiChu = txtMoTa.Text.Trim()
                };

                if (bll.updateLoaiTroChoi(txtMaLTC.Text.Trim(), sua))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    LoadLoaiTCData();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaLTC.Text))
                {
                    MessageBox.Show("Vui lòng chọn loại trò chơi cần xóa.", "Thông báo");
                    return;
                }

                // Gọi phương thức xóa và lấy thông báo
                string message = bll.removeLoaiTroChoi(txtMaLTC.Text.Trim());

                // Hiển thị thông báo cho người dùng
                MessageBox.Show(message, "Thông báo");

                // Nếu xóa thành công, load lại dữ liệu
                if (message == "Xóa loại trò chơi thành công.")
                {
                    LoadLoaiTCData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaLTC.Clear();
            txtTenLTC.Clear();
            txtMoTa.Clear();
            txtTimkiem.Clear();
            LoadLoaiTCData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dgvLoaiTroChoi.DataSource = bll.getDataBySearch(txtTimkiem.Text.Trim());

        }
    }
}
