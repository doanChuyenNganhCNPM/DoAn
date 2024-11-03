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
        public frmMain2()
        {
            InitializeComponent();
            pnlButtonHD.BorderColor = Color.Transparent;
            pnlButtonQL.BorderColor = Color.Transparent;
            pnlFormHD.BorderColor = Color.Transparent;
            pnlFormQL.BorderColor = Color.Transparent;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {

        }

        private void btnVe_Click(object sender, EventArgs e)
        {

        }

        private void btnNVKH_Click(object sender, EventArgs e)
        {

        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void btnTroChoi_Click(object sender, EventArgs e)
        {
            pnlFormQL.Controls.Clear();
            frmQLTroChoi frm = new frmQLTroChoi();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlFormQL.Controls.Add(frm);
            frm.Show();
        }

        private void btnLich_Click(object sender, EventArgs e)
        {

        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btnThucPham_Click(object sender, EventArgs e)
        {

        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {

        }

        private void btnBanVe_Click(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {

        }
    }
}
