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
    public partial class frmTP_LTP : MetroSet_UI.Forms.MetroSetForm
    {
        public frmTP_LTP()
        {
            InitializeComponent();
            this.btnThucPham.ForeColor = BackColor;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThucPham_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmQLThucPham frm = new frmQLThucPham();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panel1.Controls.Add(frm);
            frm.Show();
        }

        private void btnLoaiTP_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmLoaiTP frm = new frmLoaiTP();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panel1.Controls.Add(frm);
            frm.Show();
        }
    }
}
