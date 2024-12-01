using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace BLL_DAL
{
    public class BLL_VaiTro
    {
        KVCDataContext kvc;
        public BLL_VaiTro() {
            kvc = new KVCDataContext();
        }
        public VaiTro getByCode(string code)
        {
            return kvc.VaiTros.Where(t => t.MaVaiTro == code).FirstOrDefault();
        }
        public DataTable getAll()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaVaiTro");
            dt.Columns.Add("TenVaiTro");
           
            foreach (VaiTro nv in kvc.VaiTros)
            {
                dt.Rows.Add(nv.MaVaiTro, nv.TenVaiTro);
            }
            return dt;
        }

        public string getTenManHinh(string maMH)
        {
            return kvc.ManHinhs.Where(t => t.MaMH == maMH).FirstOrDefault() != null ? kvc.ManHinhs.Where(t => t.MaMH == maMH).FirstOrDefault().TenMH.ToString().Trim() : "NULL";
        }

        public bool addVT(string maVT, string tenVT)
        {
            try
            {
                VaiTro nv = new VaiTro
                {
                    MaVaiTro = maVT,
                    TenVaiTro = tenVT
                  

                };
                kvc.VaiTros.InsertOnSubmit(nv);
                kvc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateVT(string maVT, string tenVT)
        {
            try
            {
                VaiTro nv = kvc.VaiTros.FirstOrDefault(n => n.MaVaiTro == maVT);
                if (nv != null)
                {
                    nv.MaVaiTro = maVT;
                    nv.TenVaiTro = tenVT;
                   
                    kvc.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public void deleteVT(string MaVT)
        {
            VaiTro nv = getByCode(MaVT);
            kvc.VaiTros.DeleteOnSubmit(nv);
            kvc.SubmitChanges();
        

         }

}
}
