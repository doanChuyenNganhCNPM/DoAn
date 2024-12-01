using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_ThongKe
    {
        KVCDataContext kvc;
        public BLL_ThongKe()
        {
            kvc = new KVCDataContext();
        }
        public class DuLieu
        {
            private string tenDL;
            private double giaTri;
            public string TenDL { get { return tenDL; } set { tenDL = value; } }
            public double GiaTri { get { return giaTri; } set { giaTri = value; } } 
        }
        public List<DuLieu> layDoanhThuBanVe(DateTime startDate, DateTime endDate)
        {
            List<DuLieu> lst = new List<DuLieu>();
            var kq = from hd in kvc.HoaDons
                     where startDate.Date <= Convert.ToDateTime(hd.NgayIn).Date && endDate.Date >= Convert.ToDateTime(hd.NgayIn).Date
                     select hd;
            var groupedData = kq.Where(hd => hd.NgayIn.HasValue)
                                .GroupBy(hd => new { Year = hd.NgayIn.Value.Year, Month = hd.NgayIn.Value.Month })
                                .Select(group => new
                                {
                                    Month = group.Key.Month,
                                    Year = group.Key.Year,
                                    TotalRevenue = group.Sum(hd => hd.TongTien ?? 0) 
                                });
            foreach (var item in groupedData)
            {
                lst.Add(new DuLieu
                {
                    TenDL = item.Month.ToString("D2") + "/" + item.Year.ToString("D3"),
                    GiaTri = item.TotalRevenue
                });
            }
            return lst;
        }
    }
}
