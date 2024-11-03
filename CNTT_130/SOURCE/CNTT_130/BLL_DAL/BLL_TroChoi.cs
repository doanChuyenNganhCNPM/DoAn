using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL_DAL
{
    public class BLL_TroChoi
    {
        KVCDataContext kvc = new KVCDataContext();
        public DataTable getAllData()
        {
            DataTable dt = new DataTable();
            var kq = from tcs in kvc.TroChois
                     select tcs;
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
        public bool addGame(TroChoi a)
        {
            bool kq = false;
            try
            {
                kvc.TroChois.InsertOnSubmit(a);
                kvc.SubmitChanges();
                kq = true;
            }
            catch
            {
                kq = false;
            }
            return kq;
        }
        public bool updateGame(string maTC, TroChoi a)
        {
            bool kq = false;
            try
            {
                TroChoi m = kvc.TroChois.FirstOrDefault(t=>t.MaTC == maTC);
                if(m != null)
                {
                    m.TenTC = a.TenTC;
                    m.DiaDiem = a.DiaDiem;
                    m.NgayBatDau = a.NgayBatDau;
                    m.NgayKetThuc = a.NgayKetThuc;
                    m.TinhTrang = a.TinhTrang;
                    m.LoaiTroChoi = a.LoaiTroChoi;
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
        public bool removeGame(string maTC)
        {
            bool kq = false;
            try
            {
                TroChoi m = kvc.TroChois.FirstOrDefault(t => t.MaTC == maTC);
                if (m != null)
                {
                    kvc.TroChois.DeleteOnSubmit(m);
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
        public DataTable getDataByCodeType(string maLoai)
        {
            DataTable dt = new DataTable();
            var kq = from tcs in kvc.TroChois
                     join loais in kvc.LoaiTCs on tcs.LoaiTroChoi equals loais.MaLoai
                     where loais.MaLoai == maLoai
                     select tcs;
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
        public DataTable getDataByNameType(string tenLoai)
        {
            DataTable dt = new DataTable();
            var kq = from tcs in kvc.TroChois
                     join loais in kvc.LoaiTCs on tcs.LoaiTroChoi equals loais.MaLoai
                     where loais.TenLoai == tenLoai
                     select tcs;
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
