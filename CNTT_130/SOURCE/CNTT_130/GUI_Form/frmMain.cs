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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            SidePanel.Height = btnDatVe.Height;
            SidePanel.Top = btnDatVe.Top;
        }

        private void ShowFormInPanel(Form childForm)
        {
            // Xóa form cũ nếu có
            mainPanel.Controls.Clear();

            // Thiết lập các thuộc tính cho form con
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Căn giữa form con trong panel
            childForm.StartPosition = FormStartPosition.Manual;
            childForm.Location = new Point(
                (mainPanel.Width - childForm.Width) / 2,
                (mainPanel.Height - childForm.Height) / 2
            );

            // Thêm form con vào panel và hiển thị
            mainPanel.Controls.Add(childForm);
            mainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnDatVe_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnDatVe.Height;
            SidePanel.Top = btnDatVe.Top;
            ShowFormInPanel(new frmDatVe());
        }

        private void btnQLVe_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnQLVe.Height;
            SidePanel.Top = btnQLVe.Top;
            ShowFormInPanel(new frmVe());
        }

        private void btnBanVe_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnBanVe.Height;
            SidePanel.Top = btnBanVe.Top;
            ShowFormInPanel(new frmBanVe());
        }

        private void btnQLKhuyenMai_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnQLKhuyenMai.Height;
            SidePanel.Top = btnQLKhuyenMai.Top;
            ShowFormInPanel(new frmKhuyenMai());
        }

        private void btnQLKH_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnQLKH.Height;
            SidePanel.Top = btnQLKH.Top;
            ShowFormInPanel(new frmQLKhachHang());
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnQLNV.Height;
            SidePanel.Top = btnQLNV.Top;
            ShowFormInPanel(new frmQLNhanVien());
        }

        private void btnQLLoaiTC_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnQLLoaiTC.Height;
            SidePanel.Top = btnQLLoaiTC.Top;
            ShowFormInPanel(new frmQLLoaiTroChoi());
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btnQLTC_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnQLTC.Height;
            SidePanel.Top = btnQLTC.Top;
            ShowFormInPanel(new frmQLTroChoi());
        }

        private void btnQLHD_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnQLHD.Height;
            SidePanel.Top = btnQLHD.Top;
            ShowFormInPanel(new frmQLHoaDon());
        }

        private void btnQLTP_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnQLTP.Height;
            SidePanel.Top = btnQLTP.Top;
            ShowFormInPanel(new frmQLThucPham());
        }

        private void btnBCTK_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnBCTK.Height;
            SidePanel.Top = btnBCTK.Top;
            ShowFormInPanel(new frmBaoCaoThongKe());
        }

        private void btnDatVe_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            // Chuyển đổi sender thành Button và thay đổi màu nền
            Button button = sender as Button;
            if (button != null)
            {
                button.BackColor = Color.Green; // Đổi màu nền khi hover
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            // Chuyển đổi sender thành Button và trả lại màu nền mặc định
            Button button = sender as Button;
            if (button != null)
            {
                button.BackColor = Color.Transparent; // Làm cho nút trong suốt khi rời chuột
                button.FlatStyle = FlatStyle.Flat; // Đặt kiểu nút là Flat để nền trong suốt
                button.FlatAppearance.BorderSize = 0;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDangNhap frmDN = new FrmDangNhap();
            frmDN.ShowDialog();
        }
    }
}
