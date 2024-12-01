using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_LoaiKhachHang
    {
        KVCDataContext kvc = new KVCDataContext();

        public List<LoaiKH> getAllLoaiKH()
        {
            var loaiKHs = kvc.LoaiKHs
                .Select(loai => new { loai.MaLoai, loai.TenLoai })
                .ToList();
            var result = loaiKHs.Select(loai => new LoaiKH
            {
                MaLoai = loai.MaLoai,
                TenLoai = loai.TenLoai
            }).ToList();

            return result;
        }
    }
}
