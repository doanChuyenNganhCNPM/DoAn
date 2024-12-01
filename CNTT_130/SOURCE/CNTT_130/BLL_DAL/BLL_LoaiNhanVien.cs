using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_LoaiNhanVien
    {
        KVCDataContext kvc = new KVCDataContext();

        public List<LoaiNV> GetLoaiNVs()
        {
            var loaiNVs = kvc.LoaiNVs
                         .Select(loai => new { loai.MaLoai, loai.ChucVu })
                         .ToList();
            var result = loaiNVs.Select(loai => new LoaiNV
            {
                MaLoai = loai.MaLoai,
                ChucVu = loai.ChucVu
            }).ToList();
            return result;
        }

        public string GetEmployeeTypeName(string maxNV)
        {
            var tenLoaiNV = kvc.LoaiNVs
                .Where(loai => loai.MaLoai == maxNV)
                .Select(loai => loai.ChucVu) 
                .FirstOrDefault();
            return tenLoaiNV ?? "Không xác định"; 
        }
    }
}
