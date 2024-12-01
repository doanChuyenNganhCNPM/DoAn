using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL_DAL
{
    public class BLL_HoaDon
    {
        KVCDataContext kvc;
        public BLL_HoaDon()
        {
            kvc = new KVCDataContext();
        }
        public DataTable getAll()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM HoaDon");
        }
        public DataTable getByDate(string dateStart, string dateEnd)
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM HoaDon WHERE NgayIn <= '" + dateEnd + "' and NgayIn >= '" + dateStart + "'");
        }
        public DataTable search(DateTime dateStart, DateTime dateEnd, string maHD, string maKM, string tenKH)
        {
            DataTable dt = new DataTable();
            var kq = from hd in kvc.HoaDons
                     join kh in kvc.KhachHangs on hd.MaKH equals kh.MaKH
                     where (dateStart.Date <= Convert.ToDateTime(hd.NgayIn).Date && dateEnd.Date >= Convert.ToDateTime(hd.NgayIn).Date)
                            && (maHD != "NULL" ? hd.MaHD.ToString().ToLower().Trim().Contains(maHD.ToLower().Trim()) : true)
                            && (maKM != "NULL" ? hd.MaKM.ToString().ToLower().Trim().Contains(maKM.ToLower().Trim()) : true)
                            && (tenKH != "NULL" ? kh.HoTen.ToString().ToLower().Trim().Contains(tenKH.ToLower().Trim()): true)
                     select hd;
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
            else
            {
                dt.Columns.Add("MaHD", typeof(string));
                dt.Columns.Add("MaKH", typeof(string));
                dt.Columns.Add("MaKM", typeof(string));
                dt.Columns.Add("NgayIn", typeof(DateTime));
                dt.Columns.Add("TongTien", typeof(decimal));
            }
            return dt;
        }
        public HoaDon getByCode(string code)
        {
            return kvc.HoaDons.Where(t => t.MaHD == code).FirstOrDefault();
        }
        public bool addItem(HoaDon hd)
        {
            try
            {
                string ngayInFormatted = hd.NgayIn.HasValue ? $"'{hd.NgayIn.Value.ToString("yyyy-MM-dd")}'" : "NULL";
                string query = "";
                if (hd.MaKM != "NULL")
                {
                    string khuyenMaiFormatted = hd.MaKM != null ? $"'{hd.MaKM}'" : "NULL";
                    query = string.Format(
                        "INSERT INTO HoaDon (MaHD, MaKH, MaKM, NgayIn, TongTien) VALUES\r\n('{0}', '{1}', {2}, {3}, {4})",
                        hd.MaHD, hd.MaKH, khuyenMaiFormatted, ngayInFormatted, hd.TongTien
                    );
                }
                else
                {
                    query = string.Format(
                        "INSERT INTO HoaDon (MaHD, MaKH, MaKM, NgayIn, TongTien) VALUES\r\n('{0}', '{1}', NULL, {2}, {3})",
                        hd.MaHD, hd.MaKH, ngayInFormatted, hd.TongTien
                    );
                }
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
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
                HoaDon hd = kvc.HoaDons.FirstOrDefault(t => t.MaHD == code);
                if (hd != null)
                {
                    kvc.HoaDons.DeleteOnSubmit(hd);
                    kvc.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateItem(HoaDon hd)
        {
            try
            {
                string ngayInFormatted = hd.NgayIn.HasValue ? $"'{hd.NgayIn.Value.ToString("yyyy-MM-dd")}'" : "NULL";
                string query = "";
                if (hd.MaKM != "NULL")
                {
                    string khuyenMaiFormatted = hd.MaKM != null ? $"'{hd.MaKM}'" : "NULL";
                    query = string.Format(
                        "UPDATE HoaDon SET MaKH = '{1}', MaKM = {2}, NgayIn = {3}, TongTien = {4} WHERE MaHD = '{0}'",
                        hd.MaHD, hd.MaKH, khuyenMaiFormatted, ngayInFormatted, hd.TongTien
                    );
                }
                else
                {
                    query = string.Format(
                        "UPDATE HoaDon SET MaKH = '{1}', NgayIn = {2}, TongTien = {3} WHERE MaHD = '{0}'",
                        hd.MaHD, hd.MaKH, ngayInFormatted, hd.TongTien
                    );
                }
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }
        public List<dynamic> GetHoaDonData()
        {
            var query = from hd in kvc.HoaDons
                        join cthd in kvc.CTHD_Ves on hd.MaHD equals cthd.MaHD
                        join kh in kvc.KhachHangs on hd.MaKH equals kh.MaKH into khGroup
                        from kh in khGroup.DefaultIfEmpty()
                        join lkh in kvc.LoaiKHs on kh.LoaiKH equals lkh.MaLoai into lkhGroup
                        from lkh in lkhGroup.DefaultIfEmpty()
                        join km in kvc.KhuyenMais on hd.MaKM equals km.MaKM into kmGroup
                        from km in kmGroup.DefaultIfEmpty()
                        join nv in kvc.NhanViens on cthd.MaNV equals nv.MaNV into nvGroup
                        from nv in nvGroup.DefaultIfEmpty()
                        group cthd by new
                        {
                            hd.MaHD,
                            hd.NgayIn,
                            MaNV = cthd.MaNV,
                            TenNhanVien = nv != null ? nv.TenNV : null,
                            kh.MaKH,
                            kh.HoTen,
                            LoaiKhachHang = lkh != null ? lkh.TenLoai : null,
                            kh.SDT,
                            TenKhuyenMai = km != null ? km.TenKM : null,
                            hd.TongTien
                        } into g
                        select new
                        {
                            MaHD = g.Key.MaHD,
                            NgayLap = g.Key.NgayIn,
                            MaNV = g.Key.MaNV,
                            TenNhanVien = g.Key.TenNhanVien,
                            MaKH = g.Key.MaKH,
                            TenKH = g.Key.HoTen,
                            LoaiKH = g.Key.LoaiKhachHang,
                            SDTKH = g.Key.SDT,
                            TenKhuyenMai = g.Key.TenKhuyenMai,
                            TongTien = g.Key.TongTien,
                            SoVe = g.Count()
                        };
            var result = query.AsEnumerable()
                              .Select(x => new
                              {
                                  x.MaHD,
                                  NgayLap = x.NgayLap?.ToString("dd/MM/yyyy"),
                                  x.MaNV,
                                  x.TenNhanVien,
                                  x.MaKH,
                                  x.TenKH,
                                  x.LoaiKH,
                                  x.SDTKH,
                                  x.TenKhuyenMai,
                                  x.TongTien,
                                  x.SoVe
                              }).ToList();

            return result.Cast<dynamic>().ToList();
        }

        public List<dynamic> GetCTHoaDonData(string maHoaDon)
        {
            var query = from lv in kvc.LoaiVes
                        join v in kvc.Ves on lv.MaLoai equals v.LoaiVe
                        join cthd in kvc.CTHD_Ves on v.MaVe equals cthd.MaVe
                        where cthd.MaHD == maHoaDon
                        select new
                        {
                            MaLoaiVe = lv.MaLoai,
                            TenLoaiVe = lv.TenLoai,
                            GiaVe = lv.GiaTien,
                            SoTreEm = cthd.SoTreEm,
                            SoNguoiLon = cthd.SoNguoiLon,
                            ThanhTien = cthd.ThanhTien
                        };
            var result = query.AsEnumerable().Select(x => (dynamic)x).ToList();

            return result;
        }

        public List<dynamic> SearchHoaDonData(string maHoaDon)
        {
            if (string.IsNullOrEmpty(maHoaDon))
            {
                return new List<dynamic> { "Không tìm thấy hóa đơn" };
            }

            var query = from hd in kvc.HoaDons
                        join cthd in kvc.CTHD_Ves on hd.MaHD equals cthd.MaHD
                        join kh in kvc.KhachHangs on hd.MaKH equals kh.MaKH into khGroup
                        from kh in khGroup.DefaultIfEmpty()
                        join lkh in kvc.LoaiKHs on kh.LoaiKH equals lkh.MaLoai into lkhGroup
                        from lkh in lkhGroup.DefaultIfEmpty()
                        join km in kvc.KhuyenMais on hd.MaKM equals km.MaKM into kmGroup
                        from km in kmGroup.DefaultIfEmpty()
                        join nv in kvc.NhanViens on cthd.MaNV equals nv.MaNV into nvGroup
                        from nv in nvGroup.DefaultIfEmpty()
                        where hd.MaHD == maHoaDon
                        group cthd by new
                        {
                            hd.MaHD,
                            hd.NgayIn,
                            MaNV = cthd.MaNV,
                            TenNhanVien = nv != null ? nv.TenNV : null,
                            kh.MaKH,
                            kh.HoTen,
                            LoaiKhachHang = lkh != null ? lkh.TenLoai : null,
                            kh.SDT,
                            TenKhuyenMai = km != null ? km.TenKM : null,
                            hd.TongTien
                        } into g
                        select new
                        {
                            MaHD = g.Key.MaHD,
                            NgayLap = g.Key.NgayIn,
                            MaNV = g.Key.MaNV,
                            TenNhanVien = g.Key.TenNhanVien,
                            MaKH = g.Key.MaKH,
                            TenKH = g.Key.HoTen,
                            LoaiKH = g.Key.LoaiKhachHang,
                            SDTKH = g.Key.SDT,
                            TenKhuyenMai = g.Key.TenKhuyenMai,
                            TongTien = g.Key.TongTien,
                            SoVe = g.Count()
                        };
            var result = query.AsEnumerable()
                              .Select(x => new
                              {
                                  x.MaHD,
                                  NgayLap = x.NgayLap?.ToString("dd/MM/yyyy"),
                                  x.MaNV,
                                  x.TenNhanVien,
                                  x.MaKH,
                                  x.TenKH,
                                  x.LoaiKH,
                                  x.SDTKH,
                                  x.TenKhuyenMai,
                                  x.TongTien,
                                  x.SoVe
                              })
                              .Cast<dynamic>()
                              .ToList();
            if (result == null || result.Count == 0)
            {
                return new List<dynamic> { "Không tìm thấy hóa đơn" };
            }

            return result; 
        }
    }
}
