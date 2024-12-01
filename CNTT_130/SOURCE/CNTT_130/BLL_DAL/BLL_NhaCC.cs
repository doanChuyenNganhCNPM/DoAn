using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL_DAL
{
    public class BLL_NhaCC
    {
        KVCDataContext kvc = new KVCDataContext();
        public BLL_NhaCC() { }
        public DataTable getAllData()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM NhaCungCap");
        }
        public DataTable getListProduct(string maNCC)
        {
            string query = "SELECT ds.MaSP, ds.TenSP, ds.GiaBan " +
                           "FROM NhaCungCap ncc, NhaCungCap_DanhSachSP ds " +
                           "WHERE ncc.MaNCC = ds.MaNCC AND ncc.MaNCC = @maNCC";

            return DataProvider.Instance.executeQuery(query, new object[] { maNCC });
        }
        public bool themNhaCungCap(NhaCungCap a)
        {
            bool kq = false;
            try
            {
                kvc.NhaCungCaps.InsertOnSubmit(a);
                kvc.SubmitChanges();
                kq = true;
            }
            catch
            {
                kq = false;
            }
            return kq;
        }
        public bool suaNhaCungCap(string maNCC, NhaCungCap sua)
        {
            try
            {
                string query = string.Format(
                    "UPDATE NhaCungCap SET TenNCC = N'{1}', DiaChi = N'{2}', SoDienThoai = '{3}', Email = '{4}', TinhTrang = N'{5}', LoaiNCC = {6} WHERE MaNCC = '{0}'",
                    sua.MaNCC, sua.TenNCC, sua.DiaChi, sua.SoDienThoai, sua.Email, sua.TinhTrang, sua.LoaiNCC);
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool xoaNhaCungCap(string maNCC)
        {
            bool kq = false;
            try
            {
                NhaCungCap m = kvc.NhaCungCaps.FirstOrDefault(t => t.MaNCC == maNCC);
                if (m != null)
                {
                    kvc.NhaCungCaps.DeleteOnSubmit(m);
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
            var kq = from ncc in kvc.NhaCungCaps
                     where ncc.MaNCC.ToLower().Contains(lowerSearch)
                         || ncc.TenNCC.ToLower().Contains(lowerSearch)
                         || ncc.DiaChi.ToLower().Contains(lowerSearch)
                         || ncc.SoDienThoai.ToString().Contains(lowerSearch)
                         || ncc.Email.ToString().Contains(lowerSearch)
                         || ncc.TinhTrang.ToLower().Contains(lowerSearch)
                         || (ncc.LoaiNCC).ToString().Contains(lowerSearch)
                     select ncc;
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
        public string getNhaCC(string code)
        {
            var loaincc = (from ncc in kvc.NhaCungCaps where ncc.MaNCC == code select ncc.LoaiNCC).FirstOrDefault();
            return loaincc.ToString();
        }
        public bool ktkc(string ma)
        {
            var kc = from ncc in kvc.NhaCungCaps where ncc.MaNCC == ma select ncc;
            if (kc.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
