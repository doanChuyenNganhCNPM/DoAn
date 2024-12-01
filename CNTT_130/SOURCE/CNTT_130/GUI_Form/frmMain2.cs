using BLL_DAL;
using DTO;
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
    public partial class frmMain2 : MetroSet_UI.Forms.MetroSetForm
    {
        List<string> lst;
        BLL_PhanQuyen phanQuyenBLL = new BLL_PhanQuyen();
        BLL_NhanVien nhanVienBLL = new BLL_NhanVien();
        BLL_TaiKhoan taiKhoanBLL = new BLL_TaiKhoan();
        string maNVDN = string.Empty;
        public frmMain2()
        {
            InitializeComponent();
            pnlButtonHD.BorderColor = Color.Transparent;
            pnlButtonQL.BorderColor = Color.Transparent;
            pnlFormHD.BorderColor = Color.Transparent;
            pnlFormQL.BorderColor = Color.Transparent;
            metroSetTabControl1.SelectedIndex = 0;
        }
        public frmMain2(string maNV)
        {
            InitializeComponent();
            pnlButtonHD.BorderColor = Color.Transparent;
            pnlButtonQL.BorderColor = Color.Transparent;
            pnlFormHD.BorderColor = Color.Transparent;
            pnlFormQL.BorderColor = Color.Transparent;
            metroSetTabControl1.SelectedIndex = 0;
            metroSetControlBox1.Location = new System.Drawing.Point(this.Width - 150, 10);
            maNVDN = maNV;
            if (maNVDN != string.Empty)
            {
                txtMaNV.Text = maNVDN;
                NhanVien nv = nhanVienBLL.getByCode(maNVDN);
                string role = taiKhoanBLL.getRoleByStaffCode(maNVDN);
                if (!string.IsNullOrEmpty(role))
                {
                    lst = new List<string>();
                    lst = phanQuyenBLL.getAllScreenForRole(role);
                }
            }
            //metroSetLabel1.Size = new System.Drawing.Size(this.Width - 20, this.Height - 100);
            //int width = this.Width - 220, height = this.Height - 3;
            //pnlFormHD.Size = pnlFormQL.Size = new System.Drawing.Size(width, height);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void ShowForm(string formType)
        {
            for (int i = pnlFormQL.Controls.Count - 1; i >= 0; i--)
            {
                if (pnlFormQL.Controls[i] is Form && !(pnlFormQL.Controls[i] is ComboBox))
                {
                    pnlFormQL.Controls.RemoveAt(i);
                }
            }
            Form frm;
            if (formType == "Nhân viên")
            {
                frm = new frmQLNhanVien();
            }
            else
            {
                frm = new frmQLKhachHang();
            }

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            // frm.Dock = DockStyle.Fill;
            pnlFormQL.Controls.Add(frm);
            frm.Show();
        }

        private void setFont(Control.ControlCollection controls, string fontName, float fontSize = 12)
        {
            foreach (Control c in controls)
            {
                if (c is GroupBox || (c is Label && c.Height < 37) || c is TextBox || c is DataGridView || c is ComboBox || c is NumericUpDown)
                {
                    c.Font = new System.Drawing.Font(fontName, fontSize, FontStyle.Regular);
                }
                if (c.Controls.Count > 0)
                {
                    setFont(c.Controls, fontName, fontSize);
                }
            }
        }



        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            pnlFormQL.Controls.Clear();
            Label lblDanhMuc = new Label();
            lblDanhMuc.Text = "Chọn Form loại:";
            lblDanhMuc.Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            lblDanhMuc.Size = new Size(150, 30);
            lblDanhMuc.ForeColor = Color.Black;
            lblDanhMuc.Top = 10;
            lblDanhMuc.Left = 10;
            pnlFormQL.Controls.Add(lblDanhMuc);
            ComboBox cboDanhMuc = new ComboBox();
            cboDanhMuc.Font = new System.Drawing.Font("Arial", 12, FontStyle.Regular);
            cboDanhMuc.Location = new System.Drawing.Point((10 + lblDanhMuc.Width + 10), 10);
            List<string> list = new List<string>();
            list.Add("Loại trò chơi");
            cboDanhMuc.Items.Clear();
            foreach (var item in list)
            {
                cboDanhMuc.Items.Add(item);
            }
            cboDanhMuc.SelectedIndexChanged += cboDanhMuc_SelectedIndexChanged;
            pnlFormQL.Controls.Add(cboDanhMuc);
            Panel newPn = new Panel();
            newPn.Size = new Size(pnlFormQL.Width, pnlFormQL.Height - 30); ;
            newPn.Top = 30;
            newPn.Left = 0;
            newPn.Name = "NewQLPanel";
            pnlFormQL.Controls.Add((newPn));
        }
        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            if (cbo.SelectedIndex >= 0)
            {
                switch (cbo.SelectedIndex)
                {
                    case 0:
                        {
                            Panel newPn = pnlFormQL.Controls.OfType<Panel>().FirstOrDefault(p => p.Name == "NewQLPanel");
                            if (newPn != null)
                            {
                                newPn.Controls.Clear();
                                frmQLLoaiTroChoi frm = new frmQLLoaiTroChoi
                                {
                                    TopLevel = false,
                                    FormBorderStyle = FormBorderStyle.None,
                                    Dock = DockStyle.Fill
                                };
                                newPn.Controls.Add(frm);
                                frm.Show();
                            }
                        }
                        break;
                }
            }
        }

        private void btnVe_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmVe"))
            {
                pnlFormQL.Controls.Clear();
                frmVe frm = new frmVe();
                setFont(frm.Controls, "Arial");
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void btnTroChoi_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmQLTroChoi"))
            {
                pnlFormQL.Controls.Clear();
                frmQLTroChoi frm = new frmQLTroChoi();
                setFont(frm.Controls, "Arial");
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnLich_Click(object sender, EventArgs e)
        {

        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmQLHoaDon"))
            {
                pnlFormQL.Controls.Clear();
                frmQLHoaDon frm = new frmQLHoaDon();
                setFont(frm.Controls, "Arial");
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnThucPham_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmTP_LTP"))
            {
                pnlFormQL.Controls.Clear();
                frmTP_LTP frm = new frmTP_LTP();
                setFont(frm.Controls, "Arial");
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmKhuyenMai"))
            {
                pnlFormQL.Controls.Clear();
                frmKhuyenMai frm = new frmKhuyenMai();
                setFont(frm.Controls, "Arial");
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnBanVe_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmBanVe"))
            {
                pnlFormHD.Controls.Clear();
                frmBanVe frm = new frmBanVe(maNVDN);
                setFont(frm.Controls, "Arial");
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormHD.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {


        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmBaoCaoThongKe"))
            {
                pnlFormHD.Controls.Clear();
                frmBaoCaoThongKe frm = new frmBaoCaoThongKe();
                setFont(frm.Controls, "Arial");
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormHD.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmQLKhachHang"))
            {
                pnlFormQL.Controls.Clear();
                frmQLKhachHang frm = new frmQLKhachHang();
                setFont(frm.Controls, "Arial");
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmQLNhanVien"))
            {
                pnlFormQL.Controls.Clear();
                frmQLNhanVien frm = new frmQLNhanVien();
                setFont(frm.Controls, "Arial");
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnNhaCC_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmNhaCungCap"))
            {
                pnlFormHD.Controls.Clear();
                frmNhaCungCap frm = new frmNhaCungCap();
                setFont(frm.Controls, "Arial");
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormHD.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void bntNhapHang_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmNhapHang"))
            {
                pnlFormHD.Controls.Clear();
                frmNhapHang frm = new frmNhapHang();
                setFont(frm.Controls, "Arial");
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormHD.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnManHinh_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmManHinh"))
            {
                pnlFormQL.Controls.Clear();
                frmManHinh frm = new frmManHinh();
                setFont(frm.Controls, "Arial");
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnVaiTro_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmVaiTro"))
            {
                pnlFormQL.Controls.Clear();
                frmVaiTro frm = new frmVaiTro();
                setFont(frm.Controls, "Arial");
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmPhanQuyen"))
            {
                pnlFormQL.Controls.Clear();
                frmPhanQuyen frm = new frmPhanQuyen();
                setFont(frm.Controls, "Arial");
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmPhieuNhap"))
            {
                pnlFormQL.Controls.Clear();
                frmPhieuNhap frm = new frmPhieuNhap();
                setFont(frm.Controls, "Arial");
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }
    }
}
