using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_KhuyenMai
    {
        KVCDataContext kvc;
        public BLL_KhuyenMai()
        {
            kvc = new KVCDataContext();
        }
        public DataTable getAll()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM KhuyenMai");
        }
        public KhuyenMai getByCode(string code)
        {
            return kvc.KhuyenMais.FirstOrDefault(t => t.MaKM == code);
        }
        public DataTable getForComboBox()
        {
            DataTable dt = new DataTable();
            var kq = from tcs in kvc.KhuyenMais
                     select new { 
                        MaLoai = tcs.MaKM,
                        TenLoai = tcs.TenKM,
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

        public DataTable getForComboBoxValid()
        {
            DataTable dt = new DataTable();
            DateTime date = DateTime.Now;
            var kq = from tcs in kvc.KhuyenMais
                     where (tcs.NgayBatDau <= date.Date && tcs.NgayKetThuc >= date.Date) && tcs.TinhTrang.ToString().ToLower().Trim().Contains("Đang áp dụng".ToLower().Trim())
                     select new
                     {
                         MaLoai = tcs.MaKM,
                         TenLoai = tcs.TenKM,
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
            else
            {
                dt.Columns.Add("MaLoai", typeof(string));
                dt.Columns.Add("TenLoai", typeof (string));
            }
            return dt;
        }

        public DataTable getByDate(string date)
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM KhuyenMai WHERE NgayBatDau <= '" + date + "' and NgayKetThuc >= '" + date + "'");
        }
        public bool addItem(KhuyenMai km)
        {
            try
            {
                kvc.KhuyenMais.InsertOnSubmit(km);
                kvc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool removeItem(string code)
        {
            try
            {
                KhuyenMai km = kvc.KhuyenMais.FirstOrDefault(t => t.MaKM == code);
                if (km != null)
                {
                    kvc.KhuyenMais.DeleteOnSubmit(km);
                    kvc.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateItem(KhuyenMai km)
        {
            try
            {
                if (km.NgayBatDau > km.NgayKetThuc)
                    return false;
                string ngayBatDauFormatted = km.NgayBatDau.HasValue ? $"'{km.NgayBatDau.Value.ToString("yyyy-MM-dd")}'" : "NULL";
                string ngayKetThucFormatted = km.NgayKetThuc.HasValue ? $"'{km.NgayKetThuc.Value.ToString("yyyy-MM-dd")}'" : "NULL";
                string query = string.Format(
                    "UPDATE KhuyenMai SET TenKM = N'{1}', NgayBatDau = {2}, NgayKetThuc = {3}, PhanTramGiam = {4}, TinhTrang = N'{5}', MoTa = N'{6}' WHERE MaKM = '{0}'",
                    km.MaKM, km.TenKM, ngayBatDauFormatted, ngayKetThucFormatted, km.PhanTramGiam, km.TinhTrang, km.MoTa
                );

                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
