using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_KhachHang
    {
        KVCDataContext kvc;
        public BLL_KhachHang()
        {
            kvc = new KVCDataContext();
        }

        public DataTable getCustomerForComboBox()
        {
            DataTable dt = new DataTable();
            var kq = from tcs in kvc.KhachHangs
                     select new
                     {
                         MaLoai = tcs.MaKH,
                         TenLoai = tcs.HoTen,
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

        public KhachHang getCustomerByName(string name)
        {
            if(string.IsNullOrEmpty(name)) return null;
            return kvc.KhachHangs.FirstOrDefault(t=>t.HoTen.ToString().ToLower().Trim().Contains(name.ToLower().Trim()));
        }

        public bool removeCustomer(string maKH)
        {
            bool kq = false;
            try
            {
                KhachHang m = kvc.KhachHangs.FirstOrDefault(k => k.MaKH == maKH);
                if (m != null)
                {
                    kvc.KhachHangs.DeleteOnSubmit(m);
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
        public KhachHang getByCode(string code)
        {
            return kvc.KhachHangs.Where(t => t.MaKH == code).FirstOrDefault();
        }
        public DataTable getAllData()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM KhachHang");
        }
        public bool addCustomer(KhachHang kh)
        {
            bool kq = false;
            try
            {

                var lastCustomer = kvc.KhachHangs.OrderByDescending(k => k.MaKH).FirstOrDefault();
                string lastCode = lastCustomer?.MaKH ?? "KH00";
                string numberPart = lastCode.Substring(3);
                int newNumber = int.Parse(numberPart) + 1;
                string newCode = "KH0" + newNumber.ToString("D2");
                kh.MaKH = newCode;
                kvc.KhachHangs.InsertOnSubmit(kh);
                kvc.SubmitChanges();
                kq = true;
            }
            catch (Exception ex)
            {
                kq = false;
            }
            return kq;
        }
        public bool updateCustomer(string maKH, KhachHang sua)
        {
            try
            {
                string ngaySinhFormatted = sua.NgaySinh.HasValue ? sua.NgaySinh.Value.ToString("yyyy-MM-dd") : "NULL";
                string query = string.Format(
                    "UPDATE KhachHang SET HoTen = N'{1}', NgaySinh = '{2}', SDT = '{3}', Diem = '{4}', LoaiKH = '{5}', SoTreEm = '{6}' WHERE MaKH = '{0}'",
                    maKH, sua.HoTen, ngaySinhFormatted, sua.SDT, sua.Diem, sua.LoaiKH, sua.SoTreEm
                );
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool removeCustomer(string maKH, ref string message)
        {
            bool kq = false;
            try
            {
                KhachHang khachHang = kvc.KhachHangs.FirstOrDefault(k => k.MaKH == maKH);

                if (khachHang != null)
                {
                    var hoaDon = kvc.HoaDons.FirstOrDefault(h => h.MaKH == maKH);

                    if (hoaDon != null)
                    {
                        message = "Khách hàng đã mua vé, không thể xóa!";
                        kq = false;
                    }
                    else
                    {
                        kvc.KhachHangs.DeleteOnSubmit(khachHang);
                        kvc.SubmitChanges();
                        message = "Xóa thành công!";
                        kq = true;
                    }
                }
                else
                {
                    message = "Không tìm thấy khách hàng!";
                    kq = false;
                }
            }
            catch (Exception ex)
            {
                message = "Lỗi: " + ex.Message;
                kq = false;
            }
            return kq;
        }

        public DataTable getDataBySearch(string search)
        {
            DataTable dt = new DataTable();
            string lowerSearch = search.ToLower();
            var kq = from kh in kvc.KhachHangs
                     where kh.HoTen.ToLower().Contains(lowerSearch)
                     select kh;

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

        public List<KhachHang> getCustomersByLoaiKH(string maLoai)
        {
            var result = from kh in kvc.KhachHangs
                         where kh.LoaiKH == maLoai
                         select kh;
            return result.ToList();
        }

        public string GetCustomerTypeName(string maLoaiKH)
        {
            var tenLoaiKH = kvc.LoaiKHs
                .Where(loai => loai.MaLoai == maLoaiKH)
                .Select(loai => loai.TenLoai)
                .FirstOrDefault();
            return tenLoaiKH ?? "Không xác định";
        }
    }
}
