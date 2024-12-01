using BLL_DAL;
using LiveCharts;
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
    public partial class frmBaoCaoThongKe : MetroSet_UI.Forms.MetroSetForm
    {
        BLL_ThongKe thongKeBLL = new BLL_ThongKe();
        public frmBaoCaoThongKe()
        {
            InitializeComponent();
        }
        public void reLoad()
        {
            rdoBanVe.Checked = rdoCoKM.Checked = rdoLaoiKM.Checked = rdoThemNguoiLon.Checked = false;
        }

        private void btnBieuDo_Click(object sender, EventArgs e)
        {
            if(rdoBanVe.Checked)
            {
                List<BLL_ThongKe.DuLieu> lstData = thongKeBLL.layDoanhThuBanVe(Convert.ToDateTime(dtpStart.Value), Convert.ToDateTime(dtpEnd.Value));
                string[] lables = new string[] { };
                ColumnChart chart = new ColumnChart()
                {
                    Title = "Biểu đồ doanh thu bán vé",
                    PositionX = 10,
                    PositionY = 10,
                    Labels = lstData.Select(item => item.TenDL).ToArray(),
                    Values = new ChartValues<double>(lstData.Select(item => item.GiaTri))
                };
                var cartesianChart = new LiveCharts.WinForms.CartesianChart();
                chart.DrawChart(cartesianChart);
                cartesianChart.Size = new System.Drawing.Size(pnlHienThi.Width - 20, pnlHienThi.Height - 20);
                cartesianChart.Location = new System.Drawing.Point((pnlHienThi.Width - cartesianChart.Width) / 2, (pnlHienThi.Height - cartesianChart.Height) / 2);
                pnlHienThi.Controls.Clear();
                pnlHienThi.Controls.Add(cartesianChart);
            }
        }
    }
}
