using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_ThietBi
    {
        KVCDataContext kvc = new KVCDataContext();
        public DataTable getAllData()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM ThietBi");
        }
        public bool themThietBi(ThietBi a)
        {
            bool kq = false;
            try
            {
                kvc.ThietBis.InsertOnSubmit(a);
                kvc.SubmitChanges();
                kq = true;
            }
            catch
            {
                kq = false;
            }
            return kq;
        }
        public bool suaThietBi(string maTB, ThietBi sua)
        {
            try
            {
                string query = string.Format(
                    "UPDATE ThietBi SET TenTB = N'{1}', GiaBan = {2}, SoLuong = {3} WHERE MaTB = '{0}'",
                    sua.MaTB, sua.TenTB, sua.GiaBan, sua.SoLuong);
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool xoaThietBi(string maTB)
        {
            bool kq = false;
            try
            {
                ThietBi m = kvc.ThietBis.FirstOrDefault(t => t.MaTB == maTB);
                if (m != null)
                {
                    kvc.ThietBis.DeleteOnSubmit(m);
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
            var kq = from tp in kvc.ThietBis
                     where tp.MaTB.ToLower().Contains(lowerSearch)
                         || tp.TenTB.ToLower().Contains(lowerSearch)
                         || tp.SoLuong.ToString().Contains(lowerSearch)
                         || (tp.GiaBan).ToString().Contains(lowerSearch)
                     select tp;
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
        public bool ktkc(string ma)
        {
            var kc = from tp in kvc.ThietBis where tp.MaTB == ma select tp;
            if (kc.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ThietBi getByName(string code)
        {
            return kvc.ThietBis.Where(t => t.TenTB == code).FirstOrDefault();
        }
        public void UpdateThietBiQuantity(string tenThietBi, int soLuongThem)
        {
            var thietBi = kvc.ThietBis.FirstOrDefault(tb => tb.TenTB == tenThietBi);
            if (thietBi != null)
            {
                thietBi.SoLuong += soLuongThem;
                kvc.SubmitChanges();
            }
        }
    }
}
