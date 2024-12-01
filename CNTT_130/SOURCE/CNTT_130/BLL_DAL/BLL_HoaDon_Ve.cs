using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_HoaDon_Ve
    {
        KVCDataContext kvc;
        public BLL_HoaDon_Ve()
        {
            kvc = new KVCDataContext();
        }
        public DataTable getAll()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM CTHD_Ve");
        }
        public CTHD_Ve getByCode(string code)
        {
            return kvc.CTHD_Ves.Where(t => t.MaCTHD == code).FirstOrDefault();
        }
        public DataTable getByCodeBill(string code)
        {
            return DataProvider.Instance.executeQuery("SELECT CTHD_Ve.*, CTHD_Ve.SoNguoiLon-CTHD_Ve.SoTreEm, (CTHD_Ve.SoNguoiLon-CTHD_Ve.SoTreEm)*LoaiVe.GiaTien*0.2, LoaiVe.GiaTien FROM CTHD_Ve, Ve, LoaiVe WHERE CTHD_Ve.MaVe = Ve.MaVe AND Ve.LoaiVe = LoaiVe.MaLoai AND CTHD_Ve.MaHD = '" + code + "'");
        }
        public CTHD_Ve getByCodeTicket(string code, string codeTicket)
        {
            return kvc.CTHD_Ves.Where(t => t.MaHD == code && t.MaVe == codeTicket).FirstOrDefault();
        }
        public bool addItem(CTHD_Ve hd)
        {
            try
            {
                kvc.CTHD_Ves.InsertOnSubmit(hd);
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
                CTHD_Ve hd = kvc.CTHD_Ves.FirstOrDefault(t => t.MaCTHD == code);
                if (hd != null)
                {
                    kvc.CTHD_Ves.DeleteOnSubmit(hd);
                    kvc.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateItem(CTHD_Ve hd)
        {
            try
            {
                string query = string.Format(
                    "UPDATE CTHD_Ve SET SoTreEm = {4}, SoNguoiLon = {5}, TinhTrang = N'{6}', ThanhTien = {7} WHERE MaCTHD = '{0}' AND MaHD = '{1}' AND MaNV = '{2}' AND MaVe = '{3}'",
                    hd.MaCTHD, hd.MaHD, hd.MaNV, hd.MaVe, hd.SoTreEm, hd.SoNguoiLon, hd.TinhTrang, hd.ThanhTien
                );
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }
        public DataTable toPrint(string code)
        {
            DataTable dt = new DataTable();
            var kq = from rows in kvc.CTHD_Ves
                     join sp in kvc.Ves on rows.MaVe equals sp.MaVe
                     join loai in kvc.LoaiVes on sp.LoaiVe equals loai.MaLoai
                     where rows.MaHD == code
                     select new
                     {
                         Loai = loai.TenLoai,
                         Gia = loai.GiaTien,
                         SoNguoiLon = rows.SoNguoiLon,
                         SoTreEm = rows.SoTreEm,
                         ThanhTien = rows.ThanhTien,
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
            dt.Columns["Loai"].ColumnName = "Loại vé";
            dt.Columns["Gia"].ColumnName = "Giá";
            dt.Columns["SoNguoiLon"].ColumnName = "Số người lớn";
            dt.Columns["SoTreEm"].ColumnName = "Số trẻ em";
            dt.Columns["ThanhTien"].ColumnName = "Thành tiền";
            return dt;
        }
    }
}
