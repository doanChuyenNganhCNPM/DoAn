using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_TaiKhoan
    {
        KVCDataContext kvc;
        public BLL_TaiKhoan()
        {
            kvc = new KVCDataContext();
        }
        public string CheckAccount(string username, string password)
        {
            try
            {
                TaiKhoan kq = kvc.TaiKhoans.FirstOrDefault(t => t.Username == username && t.Password == password);
                if(kq != null)
                {
                    return kq.MaNV.ToString().Trim();
                }
                else
                {
                    return "None";
                }
            }
            catch
            {
                return "Error";
            }
        }
        public string getRoleByStaffCode(string staffCode)
        {
            return kvc.TaiKhoans.FirstOrDefault(t=>t.MaNV.ToString().ToLower().Trim().Contains(staffCode.ToLower().Trim())).Role;
        }
    }
}
