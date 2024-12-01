using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Text.RegularExpressions;
using System.Runtime.Remoting.Contexts;

namespace BLL_DAL
{
    public class BLL_NhapHang
    {
        KVCDataContext kvc = new KVCDataContext();
        public bool themPhieuNhap(PhieuNhap a)
        {
            bool kq = false;
            try
            {
                kvc.PhieuNhaps.InsertOnSubmit(a);
                kvc.SubmitChanges();
                kq = true;
            }
            catch
            {
                kq = false;
            }
            return kq;
        }
        public bool themctpntp(CTPN_TP a)
        {
            bool kq = false;
            try
            {
                kvc.CTPN_TPs.InsertOnSubmit(a);
                kvc.SubmitChanges();
                kq = true;
            }
            catch
            {
                kq = false;
            }
            return kq;
        }
        public bool themctpntb(CTPN_TB a)
        {
            bool kq = false;
            try
            {
                kvc.CTPN_TBs.InsertOnSubmit(a);
                kvc.SubmitChanges();
                kq = true;
            }
            catch
            {
                kq = false;
            }
            return kq;
        }
        public DataTable getAllData()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM PhieuNhap");
        }
        public DataTable getAllDatacttp()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM CTPN_TP");
        }
        public DataTable getAllDatacttb()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM CTPN_TB");
        }
        public DataTable getAllDatactds()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM NhaCungCap_DanhSachSP");
        }
        public bool ktkc(string ma)
        {
            var kc = from nh in kvc.PhieuNhaps where nh.MaPhieu == ma select nh;
            if (kc.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<object> getNhanVien()
        {
            var nhanviens = from nv in kvc.NhanViens select new { nv.MaNV, nv.TenNV };
            return nhanviens.ToList<object>();
        }
        public DataTable getNhaCC()
        {
            DataTable dt = new DataTable();
            var kq = from ncc in kvc.NhaCungCaps select new { MaLoai = ncc.MaNCC, TenLoai = ncc.TenNCC };
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
        public PhieuNhap getByCode(string code)
        {
            return kvc.PhieuNhaps.Where(t => t.MaPhieu == code).FirstOrDefault();
        }
        public ThucPham getByCodeTP(string code)
        {
            return kvc.ThucPhams.Where(t => t.MaTP == code).FirstOrDefault();
        }
        public ThietBi getByCodeTB(string code)
        {
            return kvc.ThietBis.Where(t => t.MaTB == code).FirstOrDefault();
        }
        public List<dynamic> getCTPN_ThietBi(string maPhieuNhap)
        {
            var query = from pn in kvc.PhieuNhaps
                        join ct in kvc.CTPN_TBs on pn.MaPhieu equals ct.MaPhieu
                        where pn.MaPhieu == maPhieuNhap
                        select new
                        {
                            MaTB = ct.MaTB,
                            TenTB = ct.TenTB,
                            SoLuong = ct.SoLuong,
                            GiaNhap = ct.GiaNhap,
                            ThanhTien = ct.ThanhTien
                        };

            return query.ToList<dynamic>();
        }

        public List<dynamic> getCTPN_ThucPham(string maPhieuNhap)
        {
            var query = from pn in kvc.PhieuNhaps
                        join ct in kvc.CTPN_TPs on pn.MaPhieu equals ct.MaPhieu
                        where pn.MaPhieu == maPhieuNhap
                        select new
                        {
                            MaTP = ct.MaTP,
                            TenTP = ct.TenTP,
                            DVT = ct.DVT,
                            SoLuong = ct.SoLuong,
                            GiaNhap = ct.GiaNhap,
                            ThanhTien = ct.ThanhTien
                        };

            return query.ToList<dynamic>();
        }

        public DataTable getDataBySearch(string search)
        {
            DataTable dt = new DataTable();
            string lowerSearch = search.ToLower();
            var kq = from pn in kvc.PhieuNhaps
                     where pn.MaPhieu.ToLower().Contains(lowerSearch)
                         || pn.MaNCC.ToLower().Contains(lowerSearch)
                         || pn.MaNV.ToLower().Contains(lowerSearch)
                         || pn.NgayNhap.ToString().Contains(lowerSearch)
                         || pn.TongTien.ToString().Contains(lowerSearch)
                         || pn.GhiChu.ToLower().Contains(lowerSearch)
                     select pn;
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
        public void UpdatePhieuNhapStatus(string maPhieu, string ghiChu)
        {
            var phieuNhap = kvc.PhieuNhaps.FirstOrDefault(pn => pn.MaPhieu == maPhieu);
            if (phieuNhap != null)
            {
                phieuNhap.GhiChu = ghiChu;
                kvc.SubmitChanges();
            }
        }
    }
}
