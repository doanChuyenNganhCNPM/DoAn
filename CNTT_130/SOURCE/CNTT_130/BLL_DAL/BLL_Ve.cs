using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_Ve
    {
        KVCDataContext kvc;
        public BLL_Ve()
        {
            kvc = new KVCDataContext();
        }
        public DataTable getAll()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM Ve");
        }
        public Ve getByCode(string code)
        {
            return kvc.Ves.FirstOrDefault(t => t.MaVe == code);
        }
        public DataTable getByDateSell(string date)
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM Ve WHERE ThoiGianBan = '" + date + "'");
        }
        public DataTable getByType(string type)
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM Ve WHERE LoaiVe = '" + type + "'");
        }
        public bool addItem(Ve ve)
        {
            try
            {
                kvc.Ves.InsertOnSubmit(ve);
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
                Ve ve = kvc.Ves.FirstOrDefault(t=>t.MaVe == code);
                if (ve != null)
                {
                    kvc.Ves.DeleteOnSubmit(ve);
                    kvc.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateItem(Ve ve)
        {
            try
            {
                string ngaybanFormatted = ve.ThoiGianBan.HasValue ? $"'{ve.ThoiGianBan.Value.ToString("yyyy-MM-dd")}'" : "NULL";
                string troChoiFormatted = ve.TroChoi != null ? $"'{ve.TroChoi}'" : "NULL";
                string query = string.Format(
                    "UPDATE Ve SET LoaiVe = '{1}', TinhTrang = N'{2}', ThoiGianBan = {3}, TroChoi = {4}, SoLuong = {5} WHERE MaVe = '{0}'",
                    ve.MaVe, ve.LoaiVe, ve.TinhTrang, ngaybanFormatted, troChoiFormatted, ve.SoLuong
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
