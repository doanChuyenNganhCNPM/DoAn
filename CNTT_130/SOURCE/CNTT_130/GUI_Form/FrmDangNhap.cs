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
    public partial class FrmDangNhap : MetroSet_UI.Forms.MetroSetForm
    {
        BLL_TaiKhoan taiKhoanBLL = new BLL_TaiKhoan();
        BLL_NhanVien nhanVienBLL = new BLL_NhanVien();
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnLogin.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnExit.BackColor = Color.FromArgb(50, 0, 0, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text.Length == 0 || txtUsername.Text.Length == 0)
            {
                CustomMessageBox.Show("Không thể để trống tài khoản hoặc mật khẩu !!", "Thông báo");
                return;
            }
            string kq = taiKhoanBLL.CheckAccount(txtUsername.Text, txtPassword.Text);
            if(kq == "None")
            {
                CustomMessageBox.Show("Sai thông tin tài khoản hoặc mật khẩu !!", "Thông báo");
                return;
            }
            else if(kq == "Error")
            {
                CustomMessageBox.Show("Xảy ra lỗi !!", "Thông báo");
                return;
            }
            frmMain2 frm = new frmMain2(kq);
            this.Visible = false;
            frm.Show();
        }
    }
}
