using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL_DAL
{
    public class BLL_DSSP
    {
        KVCDataContext kvc = new KVCDataContext();
        public BLL_DSSP() { }
        public DataTable getAllData()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM NhaCungCap_DanhSachSP");
        }
        public DataTable getListProduct(string maNCC)
        {
            string query = "SELECT MaSP, TenSP, GiaBan " +
                           "FROM NhaCungCap_DanhSachSP " +
                           "WHERE MaNCC = @maNCC";

            return DataProvider.Instance.executeQuery(query, new object[] { maNCC });
        }
        public bool themDSSP(NhaCungCap_DanhSachSP a)
        {
            bool kq = false;
            try
            {
                kvc.NhaCungCap_DanhSachSPs.InsertOnSubmit(a);
                kvc.SubmitChanges();
                kq = true;
            }
            catch
            {
                kq = false;
            }
            return kq;
        }
        public bool suaDSSP(string maNCC, string maSP, NhaCungCap_DanhSachSP sua)
        {
            try
            {
                string query = string.Format(
                    "UPDATE NhaCungCap_DanhSachSP SET TenSP = N'{2}', GiaBan = N'{3}' WHERE MaNCC = '{0}' and MaSP = '{1}'",
                    sua.MaNCC, sua.MaSP, sua.TenSP, sua.GiaBan);
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool xoaDSSP(string maNCC, string maSP)
        {
            bool kq = false;
            try
            {
                NhaCungCap_DanhSachSP m = kvc.NhaCungCap_DanhSachSPs.FirstOrDefault(t => t.MaNCC == maNCC && t.MaSP == maSP);
                if (m != null)
                {
                    kvc.NhaCungCap_DanhSachSPs.DeleteOnSubmit(m);
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
        public bool ktkc(string ma)
        {
            var kc = from ds in kvc.NhaCungCap_DanhSachSPs where ds.MaSP == ma select ds;
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
