using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;
using DTO;

namespace GUI_Form
{
    public partial class frmQLHoaDon : MetroSet_UI.Forms.MetroSetForm
    {
        BLL_HoaDon hd = new BLL_HoaDon();
        BLL_HoaDon_Ve hoaDonVeBLL = new BLL_HoaDon_Ve();
        BLL_KhachHang khachHangBLL = new BLL_KhachHang();
        BLL_Ve veBLL = new BLL_Ve();
        BLL_KhuyenMai khuyenMaiBLL = new BLL_KhuyenMai();
        BLL_LoaiVe loaiVeBLL = new BLL_LoaiVe();
        BLL_NhanVien nhanVienBLL = new BLL_NhanVien();
        public frmQLHoaDon()
        {
            InitializeComponent();
            dgvHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadHD();
            LoadCTHD();
            DisableTextBoxes();
        }



        private void frmQLHoaDon_Load(object sender, EventArgs e)
        {
            LoadHD();
            LoadCTHD();
        }


        private void LoadHD()
        {
            var hoaDonData = hd.GetHoaDonData();

            // Gán kết quả vào DataGridView
            dgvHD.DataSource = hoaDonData;
        }
        private void LoadCTHD()
        {
            string maHoaDon = txtMaHD.Text.Trim();

            if (string.IsNullOrEmpty(maHoaDon))
            {
                // Nếu txtMaHD rỗng hoặc null, chỉ hiển thị tiêu đề mà không có dữ liệu
                dgvCTHD.DataSource = null; // Xóa dữ liệu hiện tại trong DataGridView
                dgvCTHD.Rows.Clear(); // Xóa tất cả các hàng hiện tại
                dgvCTHD.Columns.Clear(); // Xóa tất cả các cột hiện tại (nếu có)

                // Tạo các cột tiêu đề rỗng
                dgvCTHD.Columns.Add("MaLoaiVe", "Mã Loại Vé");
                dgvCTHD.Columns.Add("TenLoaiVe", "Tên Loại Vé");
                dgvCTHD.Columns.Add("GiaVe", "Giá Vé");
                dgvCTHD.Columns.Add("SoTreEm", "Số Trẻ Em");
                dgvCTHD.Columns.Add("SoNguoiLon", "Số Người Lớn");
                dgvCTHD.Columns.Add("ThanhTien", "Thành Tiền");
            }
            else
            {

                // Nếu txtMaHD có giá trị, tiến hành truy vấn dữ liệu
                var cthdData = hd.GetCTHoaDonData(maHoaDon);

                if (cthdData != null && cthdData.Count > 0)
                {
                    // Nếu có dữ liệu, gán vào DataGridView
                    // Nếu không có dữ liệu, xóa các hàng hiện tại
                    dgvCTHD.DataSource = null;
                    dgvCTHD.Columns.Clear();
                    dgvCTHD.DataSource = cthdData;
                }
                else
                {
                    // Nếu không có dữ liệu, xóa các hàng hiện tại
                    dgvCTHD.DataSource = null;
                    dgvCTHD.Rows.Clear();
                }
            }
        }


        private void dgvHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvHD.Rows[e.RowIndex];

                // Điền thông tin vào các TextBox
                txtMaHD.Text = selectedRow.Cells["MaHD"].Value.ToString();
                txtNL.Text = selectedRow.Cells["NgayLap"].Value.ToString();
                txtMNV.Text = selectedRow.Cells["MaNV"].Value.ToString();
                txtTenNV.Text = selectedRow.Cells["TenNhanVien"].Value.ToString();
                txtMaKH.Text = selectedRow.Cells["MaKH"].Value.ToString();
                txtTenKH.Text = selectedRow.Cells["TenKH"].Value.ToString();
                txtLoaiKH.Text = selectedRow.Cells["LoaiKH"].Value.ToString();
                txtSDT.Text = selectedRow.Cells["SDTKH"].Value.ToString();
                txtKM.Text = selectedRow.Cells["TenKhuyenMai"].Value.ToString();
                txtTT.Text = selectedRow.Cells["TongTien"].Value.ToString();
                txtSoVe.Text = selectedRow.Cells["SoVe"].Value.ToString();
            }
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            LoadCTHD();
            resetVe();
        }

        private void dgvCTHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng đã nhấp
                var row = dgvCTHD.Rows[e.RowIndex];

                txtLV.Text = row.Cells["TenLoaiVe"].Value?.ToString();
                txtGV.Text = row.Cells["GiaVe"].Value?.ToString();
                txtSotre.Text = row.Cells["SoTreEm"].Value?.ToString();
                txtSoNguoiLon.Text = row.Cells["SoNguoiLon"].Value?.ToString();
                txtThanhTien.Text = row.Cells["ThanhTien"].Value?.ToString();
            }
        }

        private void resetVe()
        {
            txtLV.Text = string.Empty;
            txtGV.Text = string.Empty;
            txtSotre.Text = string.Empty;
            txtSoNguoiLon.Text = string.Empty;
            txtThanhTien.Text = string.Empty;
        }

        private void resetThongTin()
        {
            txtMaHD.Text = string.Empty;
            txtNL.Text = string.Empty;
            txtMNV.Text = string.Empty;
            txtTenNV.Text = string.Empty;
            txtMaKH.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            txtLoaiKH.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtSoVe.Text = string.Empty;
            txtTT.Text = string.Empty;
            txtKM.Text = string.Empty;
            txTimKiem.Text = string.Empty;
        }

        private void DisableTextBoxes()
        {
            txtMaHD.ReadOnly = true;
            txtNL.ReadOnly = true;
            txtMNV.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtMaKH.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            txtLoaiKH.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtSoVe.ReadOnly = true;
            txtTT.ReadOnly = true;
            txtKM.ReadOnly = true;
            txtLV.ReadOnly = true;
            txtGV.ReadOnly = true;
            txtSotre.ReadOnly = true;
            txtSoNguoiLon.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
        }
        private void Reset()
        {
            resetVe();
            resetThongTin();
            LoadHD();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string maHoaDon = txTimKiem.Text.Trim();

            // Gọi hàm GetHoaDonData để lấy kết quả tìm kiếm
            var result = hd.SearchHoaDonData(maHoaDon);

            // Kiểm tra nếu kết quả tìm kiếm có dữ liệu
            if (result.Count == 1 && result[0] is string && result[0].ToString() == "Không tìm thấy hóa đơn")
            {
                // Nếu không có hóa đơn, hiển thị thông báo
                MessageBox.Show(result[0].ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadHD();
            }
            else
            {
                // Nếu có dữ liệu, gán vào DataGridView

                dgvHD.DataSource = result;
            }
            resetThongTin();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            DataTable dt = hoaDonVeBLL.toPrint(dgvHD.Rows[dgvHD.CurrentCell.RowIndex].Cells[0].Value.ToString());
            dt.PrimaryKey = null;
            List<int> lst = ConvertUltil.ConvertDateTimeToList(DateTime.Now);
            HoaDon hd1 = hd.getByCode(txtMaHD.Text);
            NhanVien nv = nhanVienBLL.getByCode(dgvHD.Rows[dgvHD.CurrentCell.RowIndex].Cells[2].Value.ToString());
            KhachHang kh = khachHangBLL.getByCode(dgvHD.Rows[dgvHD.CurrentCell.RowIndex].Cells[4].Value.ToString());
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("MaHD", txtMaHD.Text.Trim());
            dic.Add("NgayIn", lst[0].ToString() + "/" + lst[1].ToString() + "/" + lst[2].ToString());
            dic.Add("TenNV", nv.TenNV.ToString().Trim());
            dic.Add("KH", kh.HoTen.ToString().Trim());
            dic.Add("Diem", kh.Diem.ToString().Trim());
            dic.Add("TenLoaiKH", kh.LoaiKH1.TenLoai.ToString().Trim());
            int soluong = 0;
            double thanhtien = 0;
            foreach (DataGridViewRow r in dgvCTHD.Rows)
            {
                soluong += int.Parse(r.Cells[4].Value.ToString());
                thanhtien += double.Parse(r.Cells[5].Value.ToString());
            }
            dic.Add("SoLuongVe", soluong.ToString());
            dic.Add("TongTien", string.Format("{0:N0} VNĐ", Convert.ToDecimal(thanhtien.ToString())));
            dic.Add("KhuyenMai", !string.IsNullOrEmpty(dgvHD.Rows[dgvHD.CurrentCell.RowIndex].Cells["TenKhuyenMai"].Value.ToString()) ? (thanhtien * hd1.KhuyenMai.PhanTramGiam / 100).ToString() + " VNĐ" : "0" + " VNĐ");
            dic.Add("ThanhTien", string.Format("{0:N0} VNĐ", Convert.ToDecimal(hd1.TongTien.ToString())));
            WordExport wd = new WordExport(Application.StartupPath + "\\InHoaDon.dotx", true);
            wd.WriteFields(dic);
            wd.WriteTable(dt, 1);
            CustomMessageBox.Show("Xuất xong !!");
        }
    }
}
