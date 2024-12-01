using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace BLL_DAL
{
    public class BLL_ThucPham
    {
        KVCDataContext kvc = new KVCDataContext();
        public DataTable getAllData()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM ThucPham");
        }
        public bool themThucPham(ThucPham a)
        {
            bool kq = false;
            try
            {
                kvc.ThucPhams.InsertOnSubmit(a);
                kvc.SubmitChanges();
                kq = true;
            }
            catch
            {
                kq = false;
            }
            return kq;
        }
        public bool suaThucPham(string maTP, ThucPham sua)
        {
            try
            {
                string query = string.Format(
                    "UPDATE ThucPham SET TenTP = N'{1}', MoTa = N'{2}', GiaBan = {3}, DVT = N'{4}', SoLuong = {5}, MaLoai = '{6}', TinhTrang = N'{7}' WHERE MaTP = '{0}'",
                    sua.MaTP, sua.TenTP, sua.MoTa, sua.GiaBan, sua.DVT, sua.SoLuong, sua.MaLoai, sua.TinhTrang);
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool xoaThucPham(string maTP)
        {
            bool kq = false;
            try
            {
                ThucPham m = kvc.ThucPhams.FirstOrDefault(t => t.MaTP == maTP);
                if (m != null)
                {
                    kvc.ThucPhams.DeleteOnSubmit(m);
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
            var kq = from tp in kvc.ThucPhams
                     where tp.MaTP.ToLower().Contains(lowerSearch)
                         || tp.TenTP.ToLower().Contains(lowerSearch)
                         || tp.MoTa.ToLower().Contains(lowerSearch)
                         || (tp.GiaBan).ToString().Contains(lowerSearch)
                         || (tp.SoLuong).ToString().Contains(lowerSearch)
                         || tp.TinhTrang.ToLower().Contains(lowerSearch)
                         || tp.DVT.ToLower().Contains(lowerSearch)
                         || (tp.MaLoai).ToLower().Contains(lowerSearch)
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
            var kc = from tp in kvc.ThucPhams where tp.MaTP == ma select tp;
            if (kc.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ThucPham getByName(string code)
        {
            return kvc.ThucPhams.Where(t => t.TenTP == code).FirstOrDefault();
        }
        public void UpdateThucPhamQuantity(string tenThucPham, int soLuongThem)
        {
            var thucPham = kvc.ThucPhams.FirstOrDefault(tb => tb.TenTP == tenThucPham);
            if (thucPham != null)
            {
                thucPham.SoLuong += soLuongThem;
                kvc.SubmitChanges();
            }
        }
    }
}
