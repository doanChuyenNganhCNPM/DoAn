using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL_DAL
{
    public class BLL_TroChoi
    {
        KVCDataContext kvc = new KVCDataContext();
        public DataTable getAllData()
        {
            //DataTable dt = new DataTable();
            //var kq = from tcs in kvc.TroChois
            //         select tcs;
            //if (kq.Any())
            //{
            //    var firstItem = kq.First();
            //    foreach (var prop in firstItem.GetType().GetProperties())
            //    {
            //        dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            //    }
            //    foreach (var item in kq)
            //    {
            //        var row = dt.NewRow();
            //        foreach (var prop in item.GetType().GetProperties())
            //        {
            //            row[prop.Name] = prop.GetValue(item, null) ?? DBNull.Value;
            //        }
            //        dt.Rows.Add(row);
            //    }
            //}
            //return dt;
            return DataProvider.Instance.executeQuery("SELECT * FROM TroChoi");
        }
        public bool addGame(TroChoi a)
        {
            bool kq = false;
            try
            {
                kvc.TroChois.InsertOnSubmit(a);
                kvc.SubmitChanges();
                kq = true;
            }
            catch
            {
                kq = false;
            }
            return kq;
        }
        public bool updateGame(string maTC, TroChoi sua)
        {
            try
            {
                if (sua.NgayBatDau > sua.NgayKetThuc)
                    return false;
                string ngayBatDauFormatted = sua.NgayBatDau.HasValue ? $"'{sua.NgayBatDau.Value.ToString("yyyy-MM-dd")}'" : "NULL";
                string ngayKetThucFormatted = sua.NgayKetThuc.HasValue ? $"'{sua.NgayKetThuc.Value.ToString("yyyy-MM-dd")}'" : "NULL";
                string query = string.Format(
                    "UPDATE TroChoi SET TenTC = N'{1}', DiaDiem = N'{2}', NgayBatDau = {3}, NgayKetThuc = {4}, TinhTrang = N'{5}', LoaiTroChoi = '{6}' WHERE MaTC = '{0}'",
                    sua.MaTC, sua.TenTC, sua.DiaDiem, ngayBatDauFormatted, ngayKetThucFormatted, sua.TinhTrang, sua.LoaiTroChoi
                );
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool removeGame(string maTC)
        {
            bool kq = false;
            try
            {
                TroChoi m = kvc.TroChois.FirstOrDefault(t => t.MaTC == maTC);
                if (m != null)
                {
                    kvc.TroChois.DeleteOnSubmit(m);
                }
                kvc.SubmitChanges();
                kq = true;
            }
            catch
            {
                kq = false;
            }
            return kq;
        }
        public DataTable getDataBySearch(string search)
        {
            DataTable dt = new DataTable();
            string lowerSearch = search.ToLower();
            var kq = from tcs in kvc.TroChois
                     join loais in kvc.LoaiTCs on tcs.LoaiTroChoi equals loais.MaLoai
                     where tcs.TenTC.ToLower().Contains(lowerSearch)
                         || tcs.MaTC.ToLower().Contains(lowerSearch)
                         || loais.TenLoai.ToLower().Contains(lowerSearch)
                         || tcs.TinhTrang.ToLower().Contains(lowerSearch)
                         || tcs.DiaDiem.ToLower().Contains(lowerSearch)
                     select tcs;
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
        public DataTable getCodeAndName()
        {
            DataTable dt = new DataTable();
            var kq = from tcs in kvc.TroChois
                     select new
                     {
                         MaTC = tcs.MaTC,
                         TenTC = tcs.TenTC
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
        public string getNameByCode(string code)
        {
            return kvc.TroChois.FirstOrDefault(t => t.MaTC == code) != null ? kvc.TroChois.FirstOrDefault(t => t.MaTC == code).TenTC.ToString().Trim() : "Không có";
        }
    }
}
