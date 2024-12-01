using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_LoaiTP
    {
        KVCDataContext kvc = new KVCDataContext();
        public DataTable getAllData()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM LoaiTP");
        }
        public bool themLoaiThucPham(LoaiTP a)
        {
            bool kq = false;
            try
            {
                kvc.LoaiTPs.InsertOnSubmit(a);
                kvc.SubmitChanges();
                kq = true;
            }
            catch
            {
                kq = false;
            }
            return kq;
        }
        public bool suaLoaiThucPham(string maLoai, LoaiTP sua)
        {
            try
            {
                string query = string.Format(
                    "UPDATE LoaiTP SET TenLoai = N'{1}' WHERE MaLoai = '{0}'",
                    sua.MaLoai, sua.TenLoai);
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool xoaLoaiThucPham(string maLoai)
        {
            bool kq = false;
            try
            {
                LoaiTP m = kvc.LoaiTPs.FirstOrDefault(t => t.MaLoai == maLoai);
                if (m != null)
                {
                    kvc.LoaiTPs.DeleteOnSubmit(m);
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
            var kc = from l in kvc.LoaiTPs where l.MaLoai == ma select l;
            if (kc.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string getTenLoai(string maLoai)
        {
            var loai = kvc.LoaiTPs.FirstOrDefault(t => t.MaLoai == maLoai);
            return loai != null ? loai.TenLoai.ToString() : "";
        }
    }
}
