using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_PhanQuyen
    {
        KVCDataContext kvc;
        public BLL_PhanQuyen()
        {
            kvc = new KVCDataContext();
        }
        public List<string> getAllScreenForRole(string role)
        {
            List<PhanQuyen> screens = kvc.PhanQuyens.Where(t=>t.MaVaiTro == role).ToList();
            if(screens.Count > 0 )
            {
                List<string> list = new List<string>();
                foreach (PhanQuyen screen in screens)
                {
                    if (screen.HoatDong == 1)
                        list.Add(screen.ManHinh.TenMH);
                }
                return list;
            }
            return new List<string>();
        }

        public bool ktraQuyen(List<string> mhs, string mh)
        {
            foreach (string a in mhs)
            {
                if (a.ToLower().Contains(mh.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public bool addAllScreenForRole(string role)
        {
            try
            {
                List<ManHinh> screens = kvc.ManHinhs.ToList();
                foreach (ManHinh screen in screens)
                {
                    PhanQuyen addPQ = new PhanQuyen()
                    {
                        MaVaiTro = role,
                        MaMH = screen.MaMH.Trim(),
                        HoatDong = 0
                    };
                    addItem(addPQ);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataTable getAllForDataGridView(string role)
        {
            return DataProvider.Instance.executeQuery("SELECT PhanQuyen.MaVaiTro, PhanQuyen.MaMH, ManHinh.TenMH, PhanQuyen.HoatDong FROM PhanQuyen, ManHinh WHERE PhanQuyen.MaMH = ManHinh.MaMH AND MaVaiTro = '" + role + "'");
        }
        public DataTable getAllForDataGridView2(string screen)
        {
            return DataProvider.Instance.executeQuery("SELECT PhanQuyen.*, VaiTro.TenVaiTro FROM PhanQuyen, VaiTro WHERE PhanQuyen.MaVaiTro = VaiTro.MaVaiTro AND MaMH = '" + screen + "'");
        }
        public int isHaveScreen(string role, string screenName)
        {
            return DataProvider.Instance.executeNonQuery("SELECT HoatDong FROM PhanQuyen, ManHinh WHERE PhanQuyen.MaMH = ManHinh.MaMH AND MaVaiTro = '" + role + "' AND ManHinh.TenMH = N'" + screenName + "'");
        }
        public bool addItem(PhanQuyen a)
        {
            try
            {
                string query = string.Format("INSERT INTO PhanQuyen VALUES ('{0}', '{1}', {2})", a.MaVaiTro, a.MaMH, a.HoatDong);
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }
        public bool updateItem(PhanQuyen a)
        {
            try
            {
                string query = string.Format("update PhanQuyen set HoatDong = {2} where MaVaiTro = '{0}' and MaMH = '{1}'", a.MaVaiTro, a.MaMH, a.HoatDong);
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
