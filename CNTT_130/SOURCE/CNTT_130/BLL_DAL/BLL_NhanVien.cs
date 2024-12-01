using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_NhanVien
    {
        KVCDataContext kvc;
        public BLL_NhanVien()
        {
            kvc = new KVCDataContext();
        }
        public NhanVien getByCode(string code)
        {
            return kvc.NhanViens.FirstOrDefault(t => t.MaNV.ToString().ToLower().Trim().Contains(code.ToLower().Trim()));
        }

        public string getRole(string maNV)
        {
            return kvc.TaiKhoans.FirstOrDefault(t=>t.MaNV == maNV).Role ?? "NULL";
        }

        public DataTable getAllData()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM NhanVien");
        }

        public bool addEmployee(NhanVien nv)
        {
            bool kq = false;
            try
            {
                var lastEmployee = kvc.NhanViens.OrderByDescending(n => n.MaNV).FirstOrDefault();
                string lastCode = lastEmployee == null ? "NV000" : lastEmployee.MaNV;
                string numberPart = lastCode.Substring(2);
                int newNumber = int.Parse(numberPart) + 1;
                string newCode = "NV" + newNumber.ToString("D3");
                nv.MaNV = newCode;
                kvc.NhanViens.InsertOnSubmit(nv);
                kvc.SubmitChanges();
                kq = true;
            }
            catch (Exception ex)
            {
                kq = false;

            }
            return kq;
        }

        public bool updateEmployee(string maNV, NhanVien sua)
        {
            try
            {
                string ngaySinhFormatted = sua.NgaySinh.HasValue ? sua.NgaySinh.Value.ToString("yyyy-MM-dd") : "NULL";
                string query = string.Format(
                    "UPDATE NhanVien SET TenNV = N'{1}', GioiTinh = N'{2}', NgaySinh = '{3}', CCCD = '{4}', LoaiNV = '{5}' WHERE MaNV = '{0}'",
                    maNV, sua.TenNV, sua.GioiTinh, ngaySinhFormatted, sua.CCCD, sua.LoaiNV
                );
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool removeEmployee(string maNV)
        {
            bool kq = false;
            try
            {
                NhanVien m = kvc.NhanViens.FirstOrDefault(n => n.MaNV == maNV);
                if (m != null)
                {
                    kvc.NhanViens.DeleteOnSubmit(m);
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

        public DataTable getDataBySearch(string search)
        {
            DataTable dt = new DataTable();
            string lowerSearch = search.ToLower();
            var kq = from nv in kvc.NhanViens
                     where nv.TenNV.ToLower().Contains(lowerSearch)
                     select nv;

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

        public List<NhanVien> getNhanViensByLoaiNV(string maLoai)
        {
            return kvc.NhanViens.Where(nv => nv.LoaiNV == maLoai).ToList();
        }

        public List<string> GetEmployeesWorkingToday()
        {
            List<string> employeeIds = new List<string>();
            try
            {
                employeeIds = (from tkb in kvc.TKBs
                               where tkb.NgayLam == DateTime.Today
                               select tkb.MaNV).Distinct().ToList();
            }
            catch
            {
                employeeIds = new List<string>();
            }
            return employeeIds;
        }

        public List<dynamic> GetWorkScheduleByExactDate(DateTime targetDate)
        {
            var result = (from tkb in kvc.TKBs
                          join lich in kvc.LichLamViecs on tkb.MaLich equals lich.MaLich
                          join nv in kvc.NhanViens on tkb.MaNV equals nv.MaNV
                          join loaiNV in kvc.LoaiNVs on nv.LoaiNV equals loaiNV.MaLoai
                          where tkb.NgayLam.Date == targetDate.Date
                          select new
                          {
                              MaNV = tkb.MaNV,
                              TenNV = nv.TenNV,
                              ChucVu = loaiNV.ChucVu,
                              NgayLam = tkb.NgayLam,
                              ThoiGianLam = lich.ThoiGianLam,
                              Ca = lich.Ca,
                              ChamCong = tkb.ChamCong
                          }).AsEnumerable()
                          .Select(item => (dynamic)item)
                          .ToList();

            return result;
        }

        public List<dynamic> TinhLuongNhanVien(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            var result = (from tkb in kvc.TKBs
                          join nv in kvc.NhanViens on tkb.MaNV equals nv.MaNV
                          join loaiNV in kvc.LoaiNVs on nv.LoaiNV equals loaiNV.MaLoai
                          where tkb.NgayLam.Date >= ngayBatDau.Date
                                && tkb.NgayLam.Date <= ngayKetThuc.Date
                                && tkb.ChamCong == 1
                          group tkb by new { nv.MaNV, nv.TenNV, loaiNV.LuongCB, loaiNV.HeSoLuong, loaiNV.ChucVu } into g
                          select new
                          {
                              MaNV = g.Key.MaNV,
                              TenNV = g.Key.TenNV,
                              ChucVu = g.Key.ChucVu,
                              LuongCB = g.Key.LuongCB,
                              HeSoLuong = g.Key.HeSoLuong,
                              SoCaLamViec = g.Count(),
                              LuongTheoCa = g.Count() * g.Key.LuongCB * g.Key.HeSoLuong
                          })
                          .AsEnumerable() 
                          .Select(item => (dynamic)item) 
                          .ToList();

            return result;
        }

        public List<string> GetEmployeeNames()
        {
            var employeeNames = kvc.NhanViens
                .Select(nv => nv.TenNV)
                .ToList();
            return employeeNames;
        }

        public string GetMaNhanVienByName(string tenNhanVien)
        {
            var maNV = kvc.NhanViens
                .Where(nv => nv.TenNV.Contains(tenNhanVien)) 
                .Select(nv => nv.MaNV) 
                .FirstOrDefault();
            return maNV; 
        }
    }
}
