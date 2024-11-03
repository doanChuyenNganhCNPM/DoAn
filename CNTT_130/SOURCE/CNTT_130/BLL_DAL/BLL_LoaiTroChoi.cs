using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_LoaiTroChoi
    {
        KVCDataContext kvc = new KVCDataContext();
        public DataTable getAllDataForComboBox()
        {
            DataTable dt = new DataTable();
            var kq = from tcs in kvc.LoaiTCs
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
        public string getTenLoai(string maLoai)
        {
            var loai = kvc.LoaiTCs.FirstOrDefault(t => t.MaLoai == maLoai);
            return loai != null ? loai.TenLoai.ToString() : "";
        }
    }
}
