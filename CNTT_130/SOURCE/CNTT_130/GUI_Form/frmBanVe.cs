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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Form
{
    public partial class frmBanVe : MetroSet_UI.Forms.MetroSetForm
    {
        BLL_HoaDon hoaDonBLL =  new BLL_HoaDon();
        BLL_HoaDon_Ve hoaDonVeBLL = new BLL_HoaDon_Ve();
        BLL_KhachHang khachHangBLL = new BLL_KhachHang();
        BLL_Ve veBLL = new BLL_Ve();
        BLL_KhuyenMai khuyenMaiBLL = new BLL_KhuyenMai();
        BLL_LoaiVe loaiVeBLL = new BLL_LoaiVe();
        BLL_NhanVien nhanVienBLL = new BLL_NhanVien();
        private string maNV = string.Empty;
        private int soTEtruoc = 0, soNLtruoc = 0;
        public frmBanVe()
        {
            InitializeComponent();
            dgvHoaDon.ReadOnly = true;
            dgvVe.AllowUserToAddRows = dgvHoaDon.AllowUserToAddRows = dgvHoaDonVe.AllowUserToAddRows = false;
            dgvVe.AllowUserToDeleteRows = dgvHoaDon.AllowUserToDeleteRows = dgvHoaDonVe.AllowUserToDeleteRows = false;
            btnLuuToanBo.Enabled = false;
        }
        public frmBanVe(string maNVDN)
        {
            InitializeComponent();
            dgvHoaDon.ReadOnly = true;
            dgvVe.AllowUserToAddRows = dgvHoaDon.AllowUserToAddRows = dgvHoaDonVe.AllowUserToAddRows = false;
            dgvVe.AllowUserToDeleteRows = dgvHoaDon.AllowUserToDeleteRows = dgvHoaDonVe.AllowUserToDeleteRows = false;
            maNV = maNVDN;
            btnLuuToanBo.Enabled = false;
        }
        public void reLoad()
        {
            DataTable dt = loaiVeBLL.getCodeAndName();
            cboLoaiVe.DataSource = null;
            cboLoaiVe.DataSource = dt;
            cboLoaiVe.DisplayMember = "TenLoai";
            cboLoaiVe.ValueMember = "MaLoai";
            DataTable dt2 = khuyenMaiBLL.getForComboBox();
            DataRow dr = dt2.NewRow();
            dr["MaLoai"] = DBNull.Value;
            dr["TenLoai"] = "Không có";
            dt2.Rows.InsertAt(dr, 0);
            cboSearchMaKM.DataSource = null;
            cboSearchMaKM.DataSource = dt2;
            cboSearchMaKM.DisplayMember = "TenLoai";
            cboSearchMaKM.ValueMember = "MaLoai";
            DataTable dt4 = khuyenMaiBLL.getForComboBoxValid();
            DataRow dr3 = dt4.NewRow();
            dr3["MaLoai"] = DBNull.Value;
            dr3["TenLoai"] = "Không có";
            dt4.Rows.InsertAt(dr3, 0);
            cboKhuyenMai.DataSource = null;
            cboKhuyenMai.DataSource = dt4;
            cboKhuyenMai.DisplayMember = "TenLoai";
            cboKhuyenMai.ValueMember = "MaLoai";
            DataTable dt3 = khachHangBLL.getCustomerForComboBox();
            DataRow dr2 = dt3.NewRow();
            dr2["MaLoai"] = DBNull.Value;
            dr2["TenLoai"] = "Không có";
            dt3.Rows.InsertAt(dr2, 0);
            cboKhachHang.DataSource = null;
            cboKhachHang.DataSource = dt3;
            cboKhachHang.DisplayMember = "TenLoai";
            cboKhachHang.ValueMember = "MaLoai";
            List<string> list = new List<string>();
            list.Add("Đã thanh toán");
            list.Add("Chưa thanh toán");
            cboTinhTrang.Items.Clear();
            foreach (var item in list)
            {
                cboTinhTrang.Items.Add(item);
            }
        }

        private void frmBanVe_Load(object sender, EventArgs e)
        {
            reLoad();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable dt = hoaDonBLL.search(
                                            Convert.ToDateTime(dtpStart.Value),
                                            Convert.ToDateTime(dtpEnd.Value),
                                            string.IsNullOrEmpty(txtSearchMaHD.Text) ? "NULL" : txtSearchMaHD.Text,
                                            cboSearchMaKM.SelectedIndex > 0 ? cboSearchMaKM.SelectedValue.ToString() : "NULL",
                                            string.IsNullOrEmpty(txtSearchMaKH.Text) ? "NULL" : txtSearchMaKH.Text);

            dgvHoaDon.DataSource = null;
            dgvHoaDon.DataSource = dt;
            dgvHoaDon.Columns[0].HeaderText = "Mã hóa đơn";
            dgvHoaDon.Columns[1].HeaderText = "Mã khách hàng";
            dgvHoaDon.Columns[2].HeaderText = "Mã khuyến mãi";
            dgvHoaDon.Columns[3].HeaderText = "Ngày in";
            dgvHoaDon.Columns[4].HeaderText = "Tổng tiền";
            if(dgvHoaDon.Columns.Count > 5)
            {
                dgvHoaDon.Columns[5].Visible = false;
                dgvHoaDon.Columns[6].Visible = false;
            }
            string maHD = string.IsNullOrEmpty(txtSearchMaHD.Text) ? "NULL" : txtSearchMaHD.Text.ToLower().Trim();
            string maKM = cboSearchMaKM.SelectedIndex > 0 ? cboSearchMaKM.SelectedValue.ToString().ToLower().Trim() : "NULL";
            KhachHang kh = khachHangBLL.getCustomerByName(txtSearchMaKH.Text);
            string maKH = kh == null ? "NULL" : kh.MaKH.ToLower().Trim();
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.IsNewRow) continue;
                foreach (DataGridViewCell cell in row.Cells)
                    if (cell.ColumnIndex == 0 && maHD != "NULL" && row.Cells[cell.ColumnIndex].Value.ToString().ToLower().Contains(maHD))
                    {
                        cell.Style.BackColor = Color.LightBlue;
                    }
                    else if (cell.ColumnIndex == 1 && maKH != "NULL" && row.Cells[cell.ColumnIndex].Value.ToString().ToLower().Contains(maKH))
                    {
                        cell.Style.BackColor = Color.Yellow;
                    }
                    else if (cell.ColumnIndex == 2 && maKM != "NULL" && row.Cells[cell.ColumnIndex].Value.ToString().ToLower().Contains(maKM))
                    {
                        cell.Style.BackColor = Color.LightGreen;
                    }
                    else if (cell.ColumnIndex == 2 && maKM == "NULL" && row.Cells[cell.ColumnIndex].Value.ToString().Length == 0)
                    {
                        cell.Style.BackColor = Color.LightGreen;
                    }
                    else if (cell.ColumnIndex == 3 && (Convert.ToDateTime(dtpStart.Value).Date <= Convert.ToDateTime(row.Cells[cell.ColumnIndex].Value.ToString()).Date && Convert.ToDateTime(dtpEnd.Value).Date >= Convert.ToDateTime(row.Cells[cell.ColumnIndex].Value.ToString()).Date))
                    {
                        cell.Style.BackColor = Color.LightPink;
                    }    
                    else
                    {
                        cell.Style.BackColor = Color.White;
                    }
            }
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            double tong = 0;
            foreach (DataGridViewRow r in dgvVe.Rows)
            {
                if (!r.IsNewRow)
                {
                    bool isChecked = Convert.ToBoolean(r.Cells[0].Value);
                    if (isChecked)
                    {
                        CTHD_Ve ct = new CTHD_Ve();
                        ct.MaHD = txtMaHD.Text;
                        Ve sp = veBLL.getByCode(r.Cells[1].Value.ToString());
                        if (sp != null)
                        {
                            bool exists = false;
                            foreach (DataGridViewRow existingRow in dgvHoaDonVe.Rows)
                            {
                                if (existingRow.Cells["MaVe"].Value?.ToString() == sp.MaVe)
                                {
                                    exists = true;
                                    break;
                                }
                            }

                            if (!exists)
                            {
                                DataTable dt2 = hoaDonVeBLL.getAll();
                                int dem = dt2.Rows.Count;
                                string ma = "CTHD" + (dem + 1).ToString("D3");
                                while (hoaDonVeBLL.getByCode(ma) != null)
                                {
                                    dem++;
                                    ma = "CTHD" + (dem + 1).ToString("D3");
                                }
                                foreach(DataGridViewRow row in dgvHoaDonVe.Rows)
                                {
                                    if(ma == row.Cells[0].Value.ToString().Trim())
                                    {
                                        dem++;
                                        ma = "CTHD" + (dem + 1).ToString("D3");
                                    }
                                }
                                ct.MaCTHD = ma;
                                ct.MaVe = sp.MaVe;
                                ct.SoTreEm = 1;
                                ct.SoNguoiLon = 1;
                                ct.MaNV = maNV;
                                ct.TinhTrang = "Chưa thanh toán";
                                ct.ThanhTien = ct.SoTreEm * sp.LoaiVe1.GiaTien;
                                tong += (double)ct.ThanhTien;
                                DataTable dt = (DataTable)dgvHoaDonVe.DataSource;
                                DataRow dr = dt.NewRow();
                                dr["MaCTHD"] = ct.MaCTHD;
                                dr["MaHD"] = ct.MaHD;
                                dr["MaNV"] = ct.MaNV;
                                dr["MaVe"] = ct.MaVe;
                                dr["SoTreEm"] = ct.SoTreEm;
                                dr["SoNguoiLon"] = ct.SoNguoiLon;
                                dr["TinhTrang"] = ct.TinhTrang;
                                dr["ThanhTien"] = ct.ThanhTien;
                                dr["SoNguoiLonTP"] = 0;
                                dr["TienThem"] = 0;
                                dr["GiaGoc"] = ct.ThanhTien;
                                dt.Rows.Add(dr);
                            }
                        }
                    }
                }
            }
            foreach (DataGridViewRow r in dgvHoaDon.Rows)
            {
                if (r.Cells[0].Value.ToString().Trim() == txtMaHD.Text.Trim())
                {
                    if (cboKhuyenMai.SelectedIndex == 0)
                    {
                        r.Cells[2].Value = "NULL";
                    }
                    else
                    {
                        KhuyenMai km = khuyenMaiBLL.getByCode(cboKhuyenMai.SelectedValue.ToString());
                        if (km != null)
                        {
                            r.Cells[2].Value = km.MaKM;
                        }
                    }
                    r.Cells[1].Value = cboKhachHang.SelectedValue.ToString().Trim();
                    r.Cells[4].Value = tong;
                }
            }
            btnLuuToanBo.Enabled = true;
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            string maKH = cboKhachHang.SelectedValue.ToString().Trim();
            if (string.IsNullOrEmpty(maKH))
            {
                CustomMessageBox.Show("Không thể để trống khách hàng !");
                return;
            }
            HoaDon pn = new HoaDon();
            pn.TongTien = 0;
            pn.MaKH = maKH;
            DateTime dt = DateTime.Now;
            pn.NgayIn = dt.Date;
            DataTable dt2 = hoaDonBLL.getAll();
            int dem = dt2.Rows.Count;
            string ma = "HD" + (dem + 1).ToString("D3");
            while (hoaDonBLL.getByCode(ma) != null)
            {
                dem++;
                ma = "HD" + (dem + 1).ToString("D3");
            }
            pn.MaHD = ma;
            DataTable listPN = hoaDonBLL.getAll();
            DataRow newRow = listPN.NewRow();
            newRow["MaHD"] = pn.MaHD;
            newRow["MaKH"] = pn.MaKH;
            newRow["MaKM"] = pn.MaKM;
            newRow["NgayIn"] = pn.NgayIn;
            newRow["TongTien"] = pn.TongTien;
            listPN.Rows.Add(newRow);
            dgvHoaDon.DataSource = null;
            dgvHoaDon.DataSource = listPN;
            dgvHoaDon.Columns[0].HeaderText = "Mã hóa đơn";
            dgvHoaDon.Columns[1].HeaderText = "Mã khách hàng";
            dgvHoaDon.Columns[2].HeaderText = "Mã khuyến mãi";
            dgvHoaDon.Columns[3].HeaderText = "Ngày in";
            dgvHoaDon.Columns[4].HeaderText = "Tổng tiền";
            btnLuuToanBo.Enabled = true;
        }

        private void btnLuuToanBo_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow r in dgvHoaDon.Rows)
                {
                    if (r.IsNewRow) continue;
                    var maHD = r.Cells[0].Value?.ToString();
                    if (string.IsNullOrEmpty(maHD)) continue;
                    HoaDon kq = hoaDonBLL.getByCode(maHD);
                    if (kq == null)
                    {
                        string maKH = cboKhachHang.SelectedValue.ToString().Trim();
                        string maKM = r.Cells[2].Value?.ToString();
                        DateTime ngayIn = r.Cells[3].Value != null && DateTime.TryParse(r.Cells[3].Value.ToString(), out DateTime parsedNgayIn)
                                            ? parsedNgayIn
                                            : DateTime.Now;
                        double tongTien = 0;
                        foreach(DataGridViewRow row in dgvHoaDonVe.Rows)
                        {
                            tongTien += double.Parse(row.Cells[7].Value.ToString());
                        }
                        HoaDon hd = new HoaDon
                        {
                            MaHD = maHD,
                            MaKH = maKH,
                            MaKM = string.IsNullOrEmpty(maKM) ? null : maKM,
                            TongTien = tongTien,
                            NgayIn = ngayIn,
                        };
                        if (!hoaDonBLL.addItem(hd))
                        {
                            CustomMessageBox.Show("Không thể lưu hóa đơn: " + maHD);
                        }
                    }
                }
                double tong = 0;
                foreach (DataGridViewRow r in dgvHoaDonVe.Rows)
                {
                    if (r.IsNewRow) continue;
                    string maHD = r.Cells[1].Value?.ToString();
                    string maVe = r.Cells[3].Value?.ToString();
                    int soLuong;
                    if (string.IsNullOrEmpty(maHD) || string.IsNullOrEmpty(maVe) ||
                        !int.TryParse(r.Cells[5].Value?.ToString(), out soLuong))
                    {
                        CustomMessageBox.Show("Dữ liệu không hợp lệ! Vui lòng kiểm tra lại các trường dữ liệu.");
                        continue;
                    }
                    Ve sp = veBLL.getByCode(maVe);
                    if (sp != null)
                    {
                        if (sp.SoLuong >= soLuong)
                        {
                            sp.SoLuong -= soLuong;
                            veBLL.updateItem(sp);
                        }
                        else if (sp.SoLuong <= 0 || soLuong > sp.SoLuong)
                        {
                            CustomMessageBox.Show("Số lượng vé không đủ cho hóa đơn "+ maHD + " và mã vé "+ maVe, "Thông báo", 800, 300);
                            continue;
                        }
                    }
                    CTHD_Ve ct = hoaDonVeBLL.getByCodeTicket(maHD, maVe);
                    if (ct != null)
                    {
                        Ve ve = veBLL.getByCode(maVe);
                        ct.SoTreEm = soLuong;
                        ct.SoNguoiLon = int.Parse(txtSoNguoiLon.Text);
                        double phiNguoiLon = 0;
                        if(ct.SoNguoiLon > ct.SoTreEm)
                        {
                            phiNguoiLon = (double)((ct.SoNguoiLon - ct.SoTreEm) * ve.LoaiVe1.GiaTien * 0.2);
                            r.Cells[8].Value = (ct.SoNguoiLon - ct.SoTreEm).ToString();
                            r.Cells[9].Value = phiNguoiLon.ToString();
                        }
                        ct.ThanhTien = ve.LoaiVe1.GiaTien + phiNguoiLon;
                        hoaDonVeBLL.updateItem(ct);
                        tong += (double)ct.ThanhTien;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(maHD))
                        {
                            Ve ve = veBLL.getByCode(maVe);
                            DataTable dt2 = hoaDonVeBLL.getAll();
                            int dem = dt2.Rows.Count;
                            r.Cells[8].Value = (int.Parse(r.Cells[4].Value.ToString()) - soLuong).ToString();
                            r.Cells[9].Value = ((int.Parse(r.Cells[4].Value.ToString()) - soLuong) * ve.LoaiVe1.GiaTien * 0.2).ToString();
                            CTHD_Ve newCT = new CTHD_Ve
                            {
                                MaCTHD = r.Cells[0].Value?.ToString(),
                                MaHD = maHD,
                                MaVe = maVe,
                                MaNV = maNV,
                                SoTreEm = soLuong,
                                SoNguoiLon = int.Parse(r.Cells[4].Value.ToString()),
                                TinhTrang = r.Cells[6].Value.ToString(),
                                ThanhTien = double.Parse(r.Cells[7].Value.ToString())
                            };
                            tong += (double)newCT.ThanhTien;
                            hoaDonVeBLL.addItem(newCT);
                        }
                        else
                        {
                            CustomMessageBox.Show("Mã hóa đơn không được để trống. Vui lòng nhập dữ liệu hợp lệ.");
                        }
                    }
                }
                HoaDon pn = hoaDonBLL.getByCode(txtMaHD.Text);
                if (pn != null)
                {
                    pn.TongTien = tong;
                    if (cboKhuyenMai.SelectedIndex > 0)
                    {
                        KhuyenMai km = khuyenMaiBLL.getByCode(cboKhuyenMai.SelectedValue.ToString());
                        pn.TongTien = tong * (1 - (km.PhanTramGiam / 100));
                    }
                }
                else
                {
                    CustomMessageBox.Show("Không tìm thấy hóa đơn với mã: " + txtMaHD.Text);
                }
                hoaDonBLL.updateItem(pn);
                DataTable dt = hoaDonBLL.getAll();
                dgvHoaDon.DataSource = null;
                dgvHoaDon.DataSource = dt;
                dgvHoaDon.Columns[0].HeaderText = "Mã hóa đơn";
                dgvHoaDon.Columns[1].HeaderText = "Mã khách hàng";
                dgvHoaDon.Columns[2].HeaderText = "Mã khuyến mãi";
                dgvHoaDon.Columns[3].HeaderText = "Ngày in";
                dgvHoaDon.Columns[4].HeaderText = "Tổng tiền";
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                btnLuuToanBo.Enabled = false;
            }
        }

        private void cboLoaiVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiVe.SelectedIndex >= 0)
            {
                try
                {
                    dgvVe.DataSource = null;
                    DataTable dt = veBLL.getByType(cboLoaiVe.SelectedValue.ToString());
                    if (!dgvVe.Columns.Contains("them"))
                    {
                        DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                        {
                            Name = "them",
                            HeaderText = "Thêm"
                        };
                        dgvVe.Columns.Add(checkBoxColumn);
                    }
                    dgvVe.DataSource = dt;
                    dgvVe.Columns[1].HeaderText = "Mã vé";
                    dgvVe.Columns[2].HeaderText = "Loại vé";
                    dgvVe.Columns[3].HeaderText = "Thời gian bán";
                    dgvVe.Columns[4].HeaderText = "Số lượng";
                    dgvVe.Columns[5].HeaderText = "Tình trạng";
                    dgvVe.Columns[6].HeaderText = "Mã trò chơi";
                    dgvVe.Columns[2].Visible = false;
                    foreach(DataGridViewRow r in  dgvVe.Rows)
                    {
                        int sl = int.Parse(r.Cells[4].Value.ToString());
                        if(sl <= 0)
                        {
                            r.Cells[0].ReadOnly = true;
                            r.Cells[0].Style.BackColor = Color.LightGray;
                        }
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];
                txtMaHD.Text = row.Cells[0].Value.ToString();
                KhachHang kh = khachHangBLL.getByCode(row.Cells[1].Value.ToString());
                KhuyenMai km = khuyenMaiBLL.getByCode(row.Cells[2].Value.ToString());
                cboKhachHang.Text = kh != null ? kh.HoTen.ToString().Trim() : "Không có";
                cboKhuyenMai.Text = km != null ? km.TenKM.ToString().Trim() : "Không có";
                txtTongTien.Text = string.Format("{0:N0} VNĐ", Convert.ToDecimal(row.Cells[4].Value));
                txtTongTien.TextAlign = HorizontalAlignment.Right;
                DataTable dt = hoaDonVeBLL.getByCodeBill(txtMaHD.Text);
                dgvHoaDonVe.DataSource = null;
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvHoaDonVe.DataSource = dt;
                }
                else
                {
                    DataTable emptyTable = new DataTable();
                    emptyTable.Columns.Add("MaCTHD");
                    emptyTable.Columns.Add("MaHD");
                    emptyTable.Columns.Add("MaNV");
                    emptyTable.Columns.Add("MaVe");
                    emptyTable.Columns.Add("SoNguoiLon");
                    emptyTable.Columns.Add("SoTreEm");
                    emptyTable.Columns.Add("TinhTrang");
                    emptyTable.Columns.Add("ThanhTien");
                    emptyTable.Columns.Add("SoNguoiLonTP");
                    emptyTable.Columns.Add("TienThem");
                    emptyTable.Columns.Add("GiaGoc");
                    dgvHoaDonVe.DataSource = emptyTable;
                }
                dgvHoaDonVe.Columns[0].HeaderText = "Mã chi tiết";
                dgvHoaDonVe.Columns[1].HeaderText = "Mã hóa đơn";
                dgvHoaDonVe.Columns[2].HeaderText = "Mã nhân viên";
                dgvHoaDonVe.Columns[3].HeaderText = "Mã vé";
                dgvHoaDonVe.Columns[4].HeaderText = "Số người lớn";
                dgvHoaDonVe.Columns[5].HeaderText = "Số trẻ em";
                dgvHoaDonVe.Columns[6].HeaderText = "Tình trạng";
                dgvHoaDonVe.Columns[7].HeaderText = "Thành tiền";
                dgvHoaDonVe.Columns[8].HeaderText = "Số người lớn thêm";
                dgvHoaDonVe.Columns[9].HeaderText = "Tiền thêm";
                dgvHoaDonVe.Columns[10].HeaderText = "Giá gốc";
            }
        }

        private void dgvHoaDonVe_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvHoaDonVe.Columns["SoTreEm"].Index)
            {
                try
                {
                    Ve sp = veBLL.getByCode(dgvHoaDonVe.Rows[e.RowIndex].Cells[3].Value.ToString());
                    KhachHang kh = khachHangBLL.getByCode(cboKhachHang.SelectedValue.ToString());
                    int soluong = Convert.ToInt32(dgvHoaDonVe.Rows[e.RowIndex].Cells["SoTreEm"].Value);
                    if (soluong > kh.SoTreEm)
                    {
                        CustomMessageBox.Show("Số trẻ em lớn hơn số trẻ em được khai báo trong hệ thống.", "Thông báo", 800, 400);
                        dgvHoaDonVe.Rows[e.RowIndex].Cells["SoTreEm"].Value = soTEtruoc;
                    }
                    else if (soluong <= sp.SoLuong)
                    {
                        btnLuuToanBo.Enabled = true;
                        dgvHoaDonVe.Rows[e.RowIndex].Cells["SoTreEm"].Value = soluong;
                    }
                    else
                    {
                        CustomMessageBox.Show("Không đủ số lượng vé cho trẻ em.");
                        dgvHoaDonVe.Rows[e.RowIndex].Cells["SoTreEm"].Value = soTEtruoc;
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Có lỗi khi tính toán lại số lượng vé cho trẻ em: " + ex.Message);
                }
            }
            if (e.ColumnIndex == dgvHoaDonVe.Columns["SoNguoiLon"].Index)
            {
                try
                {
                    Ve sp = veBLL.getByCode(dgvHoaDonVe.Rows[e.RowIndex].Cells[3].Value.ToString());
                    int soluong = Convert.ToInt32(dgvHoaDonVe.Rows[e.RowIndex].Cells["SoNguoiLon"].Value);
                    int soTE = Convert.ToInt32(dgvHoaDonVe.Rows[e.RowIndex].Cells["SoTreEm"].Value);
                    double thanhtien = sp.LoaiVe1.GiaTien ?? 0;
                    if (soluong <= soTE)
                    {
                        btnLuuToanBo.Enabled = true;
                    }
                    else
                    {
                        double phiNguoiLon = 0;
                        phiNguoiLon = (double)((soluong - soTE) * sp.LoaiVe1.GiaTien * 0.2);
                        dgvHoaDonVe.Rows[e.RowIndex].Cells["SoNguoiLon"].Value = soluong;
                        dgvHoaDonVe.Rows[e.RowIndex].Cells["ThanhTien"].Value = thanhtien + phiNguoiLon;
                        dgvHoaDonVe.Rows[e.RowIndex].Cells["SoNguoiLonTP"].Value = soluong - soTE;
                        dgvHoaDonVe.Rows[e.RowIndex].Cells["TienThem"].Value = phiNguoiLon;
                        btnLuuToanBo.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Có lỗi khi tính toán lại số lượng vé cho người lớn: " + ex.Message);
                }
            }
            //if (e.ColumnIndex == dgvHoaDonVe.Columns["TinhTrang"].Index)
            //{
            //    try
            //    {
            //        dgvHoaDonVe.Rows[e.RowIndex].Cells["TinhTrang"].Value = cboTinhTrang.SelectedText;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Có lỗi khi thêm tình trạng vào: " + ex.Message);
            //    }
            //}
        }

        private void dgvHoaDonVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoaDonVe.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells[2].Value.ToString();
                txtMaVe.Text = row.Cells[3].Value.ToString();
                txtSoNguoiLon.Text = row.Cells[4].Value.ToString();
                txtSoLuong.Text = row.Cells[5].Value.ToString();
                cboTinhTrang.Text = row.Cells[6].Value.ToString();
                txtThanhTien.Text = string.Format("{0:N0} VNĐ", Convert.ToDecimal(row.Cells[7].Value));
                txtSoLuong.TextAlign = HorizontalAlignment.Right;
                txtSoNguoiLon.TextAlign = HorizontalAlignment.Right;
                txtThanhTien.TextAlign = HorizontalAlignment.Right;
                txtTongTien.TextAlign = HorizontalAlignment.Right;
            }
        }

        private void cboTinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvHoaDonVe.CurrentCell != null)
            {
                dgvHoaDonVe.Rows[dgvHoaDonVe.CurrentCell.RowIndex].Cells["TinhTrang"].Value = cboTinhTrang.Text.Trim();
            }
        }
        private void dgvHoaDonVe_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == dgvHoaDonVe.Columns["SoTreEm"].Index)
            {
                soTEtruoc = int.Parse(dgvHoaDonVe.Rows[e.RowIndex].Cells["SoTreEm"].Value.ToString());
            }
            if (e.ColumnIndex == dgvHoaDonVe.Columns["SoNguoiLon"].Index)
            {
                soNLtruoc = int.Parse(dgvHoaDonVe.Rows[e.RowIndex].Cells["SoNguoiLon"].Value.ToString());
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataTable dt = hoaDonVeBLL.toPrint(dgvHoaDon.Rows[dgvHoaDon.CurrentCell.RowIndex].Cells[0].Value.ToString());
            dt.PrimaryKey = null;
            List<int> lst = ConvertUltil.ConvertDateTimeToList(DateTime.Now);
            HoaDon hd = hoaDonBLL.getByCode(txtMaHD.Text);
            NhanVien nv = nhanVienBLL.getByCode(dgvHoaDonVe.Rows[0].Cells[2].Value.ToString());
            KhachHang kh = khachHangBLL.getByCode(dgvHoaDon.Rows[dgvHoaDon.CurrentCell.RowIndex].Cells[1].Value.ToString());
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("MaHD", txtMaHD.Text.Trim());
            dic.Add("NgayIn", lst[0].ToString() + "/" + lst[1].ToString() + "/" + lst[2].ToString());
            dic.Add("TenNV", nv.TenNV.ToString().Trim());
            dic.Add("KH", kh.HoTen.ToString().Trim());
            dic.Add("Diem", kh.Diem.ToString().Trim());
            dic.Add("TenLoaiKH", kh.LoaiKH1.TenLoai.ToString().Trim());
            int soluong = 0;
            double thanhtien = 0;
            foreach(DataGridViewRow r in dgvHoaDonVe.Rows)
            {
                soluong += int.Parse(r.Cells[5].Value.ToString());
                thanhtien += double.Parse(r.Cells[7].Value.ToString());
            }
            dic.Add("SoLuongVe", soluong.ToString());
            dic.Add("TongTien", string.Format("{0:N0} VNĐ", Convert.ToDecimal(thanhtien.ToString())));
            dic.Add("KhuyenMai", cboKhuyenMai.SelectedIndex > 0 ? (thanhtien * hd.KhuyenMai.PhanTramGiam / 100).ToString() + " VNĐ" : "0" + " VNĐ");
            dic.Add("ThanhTien", string.Format("{0:N0} VNĐ", Convert.ToDecimal(hd.TongTien.ToString())));
            WordExport wd = new WordExport(Application.StartupPath + "\\InHoaDon.dotx", true);
            wd.WriteFields(dic);
            wd.WriteTable(dt, 1);
            CustomMessageBox.Show("Xuất xong !!");
        }

        private void txtSoNguoiLon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
