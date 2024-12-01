using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_LoaiTroChoi
    {
        KVCDataContext kvc = new KVCDataContext();
        public DataTable getAllDataForComboBox()
        {
            DataTable dt = new DataTable();
            var kq = from tcs in kvc.LoaiTCs
                     select new
                     {
                         MaLoai = tcs.MaLoai,
                         TenLoai = tcs.TenLoai
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
            return dt;
        }
        public string getTenLoai(string maLoai)
        {
            var loai = kvc.LoaiTCs.FirstOrDefault(t => t.MaLoai == maLoai);
            return loai != null ? loai.TenLoai.ToString() : "";
        }

        public DataTable getAllDataLTC()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM LoaiTC");
        }

        public bool addLoaiTroChoi(LoaiTC loaiTC)
        {
            bool kq = false;
            try
            {
                var lastLoai = kvc.LoaiTCs.OrderByDescending(l => l.MaLoai).FirstOrDefault();
                string lastCode = lastLoai?.MaLoai ?? "LTC00";
                string numberPart = lastCode.Substring(3);
                int newNumber = int.Parse(numberPart) + 1;
                string newCode = "LTC" + newNumber.ToString("D2");
                loaiTC.MaLoai = newCode;
                kvc.LoaiTCs.InsertOnSubmit(loaiTC);
                kvc.SubmitChanges();
                kq = true;
            }
            catch (Exception ex)
            {
                kq = false;
            }
            return kq;
        }

        public bool updateLoaiTroChoi(string maLoai, LoaiTC sua)
        {
            try
            {
                string query = string.Format(
                    "UPDATE LoaiTC SET TenLoai = N'{1}', GhiChu = N'{2}' WHERE MaLoai = '{0}'",
                    maLoai, sua.TenLoai, sua.GhiChu
                );
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string removeLoaiTroChoi(string maLoai)
        {
            string message = string.Empty;
            try
            {
                LoaiTC loai = kvc.LoaiTCs.FirstOrDefault(l => l.MaLoai == maLoai);
                if (loai != null)
                {
                    bool isReferenced = kvc.TroChois.Any(tc => tc.LoaiTroChoi == maLoai);
                    if (isReferenced)
                    {
                        message = "Loại trò chơi đang có trò chơi, không thể xóa.";
                    }
                    else
                    {
                        kvc.LoaiTCs.DeleteOnSubmit(loai);
                        kvc.SubmitChanges();
                        message = "Xóa loại trò chơi thành công.";
                    }
                }
                else
                {
                    message = "Không tìm thấy loại trò chơi với mã " + maLoai;
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi xóa loại trò chơi: " + ex.Message;
            }
            return message;
        }

        public DataTable getDataBySearch(string search)
        {
            DataTable dt = new DataTable();
            string lowerSearch = search.ToLower();
            var kq = from loai in kvc.LoaiTCs
                     where loai.TenLoai.ToLower().Contains(lowerSearch)
                     select loai;
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
    }
}
