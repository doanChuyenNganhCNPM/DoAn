using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class LichLamviec
    {
        KVCDataContext kvc = new KVCDataContext();

        public List<dynamic> GetMaxNVSchedule()
        {
            var schedules = (from tkb in kvc.TKBs
                             join lich in kvc.LichLamViecs on tkb.MaLich equals lich.MaLich
                             join nv in kvc.NhanViens on tkb.MaNV equals nv.MaNV 
                             select new
                             {
                                 MaxNV = tkb.MaNV,
                                 TenNV = nv.TenNV, 
                                 NgayLam = tkb.NgayLam,
                                 CaLam = lich.Ca,
                                 ThoiGianLam = lich.ThoiGianLam
                             }).ToList();
            return schedules.Cast<dynamic>().ToList();
        }

        // lấy ds ca lam 
        public List<int?> GetCaLams()
        {
            var caLams = kvc.LichLamViecs
                .Where(llv => llv.Ca != null)  // Lọc những dòng có "Ca" không null
                .Select(llv => llv.Ca)  // Lấy chỉ cột "Ca"
                .Distinct()  // Lọc ra các giá trị "Ca" duy nhất
                .ToList();

            return caLams;
        }

        // Phương thức lấy thời gian làm từ ca làm
        public string GetThoiGianLamByCa(int caLam)
        {
            var thoiGianLam = kvc.LichLamViecs
                .Where(llv => llv.Ca == caLam)  // Tìm kiếm theo ca làm
                .Select(llv => llv.ThoiGianLam)  // Lấy thời gian làm
                .FirstOrDefault();  // Lấy kết quả đầu tiên hoặc null nếu không tìm thấy

            return thoiGianLam;  // Trả về thời gian làm hoặc null
        }

        // thêm ca 
        public string SaveToTKB(string maNV, DateTime ngayLam, int caLam, int chamCong)
        {
            string message = "";

            try
            {
                // Truy vấn để lấy MaLich từ bảng LichLamViec
                var maLich = (from l in kvc.LichLamViecs
                              where l.Ca == caLam  // Lọc theo ca làm
                              select l.MaLich).FirstOrDefault();  // Lấy MaLich đầu tiên nếu có

                if (!string.IsNullOrEmpty(maLich))
                {
                    // Kiểm tra xem dòng dữ liệu đã tồn tại chưa
                    var existingSchedule = (from tkb in kvc.TKBs
                                            where tkb.MaLich == maLich &&
                                                  tkb.MaNV == maNV &&
                                                  tkb.NgayLam.Date == ngayLam.Date
                                            select tkb).FirstOrDefault();

                    if (existingSchedule != null)
                    {
                        // Nếu đã tồn tại, thông báo lỗi
                        message = "Nhân viên đã có ca làm trong ngày này.";
                    }
                    else
                    {
                        // Nếu chưa tồn tại, thêm mới
                        var tkb = new TKB
                        {
                            MaLich = maLich,   // MaLich từ truy vấn
                            MaNV = maNV,       // MaNV từ tham số
                            NgayLam = ngayLam, // Ngày làm từ tham số
                            ChamCong = chamCong // Truyền trực tiếp trạng thái từ checkbox
                        };

                        // Thêm bản ghi vào bảng TKB
                        kvc.TKBs.InsertOnSubmit(tkb);

                        // Lưu thay đổi vào cơ sở dữ liệu
                        kvc.SubmitChanges();

                        message = "Tạo lịch làm thành công";
                    }
                }
                else
                {
                    // Nếu không tìm thấy MaLich tương ứng, thông báo lỗi
                    message = "Không tìm thấy lịch làm tương ứng.";
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                message = "Lỗi: " + ex.Message;
            }

            return message;
        }


        // Láy theo ngày
        public List<dynamic> GetMaxNVSchedule(DateTime selectedDate)
        {
            // Lọc danh sách theo ngày được chọn
            var schedules = (from tkb in kvc.TKBs
                             join lich in kvc.LichLamViecs on tkb.MaLich equals lich.MaLich
                             join nv in kvc.NhanViens on tkb.MaNV equals nv.MaNV
                             where tkb.NgayLam.Date == selectedDate.Date // So sánh theo ngày
                             select new
                             {
                                 MaNV = tkb.MaNV,
                                 TenNV = nv.TenNV,
                                 NgayLam = tkb.NgayLam,
                                 CaLam = lich.Ca,
                                 ThoiGianLam = lich.ThoiGianLam
                             }).ToList();

            // Chuyển đổi danh sách ẩn danh sang danh sách dynamic
            return schedules.Cast<dynamic>().ToList();
        }


    }
}
