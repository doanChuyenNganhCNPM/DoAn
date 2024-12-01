using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_LoaiVe
    {
        KVCDataContext kvc;
        public BLL_LoaiVe()
        {
            kvc = new KVCDataContext();
        }
        public DataTable getCodeAndName()
        {
            DataTable dt = new DataTable();
            var kq = from tcs in kvc.LoaiVes
                     select new
                     {
                         MaLoai = tcs.MaLoai,
                         TenLoai = tcs.TenLoai
                     };
            if (kq.Any())
            {
                var firstItem = kq.First();
                foreach (var prop in firstItem.GetType().GetProperties())
                {
                    dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                foreach (var item in kq)
                {
                    var row = dt.NewRow();
                    foreach (var prop in item.GetType().GetProperties())
                    {
                        row[prop.Name] = prop.GetValue(item, null) ?? DBNull.Value;
                    }
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }
        public double getPriceByCode(string code)
        {
            return kvc.LoaiVes.FirstOrDefault(t => t.MaLoai == code) != null ? kvc.LoaiVes.FirstOrDefault(t => t.MaLoai == code).GiaTien.Value : 0;
        }
        public string getNameByCode(string code)
        {
            return kvc.LoaiVes.FirstOrDefault(t => t.MaLoai == code) != null ? kvc.LoaiVes.FirstOrDefault(t => t.MaLoai == code).TenLoai.ToString().Trim() : "Không có";
        }
    }
}
