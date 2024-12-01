using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_ManHinh
    {
        KVCDataContext kvc = new KVCDataContext();

        public DataTable getAllByCode(string code)
        {
            DataTable dt = new DataTable();
            var kq = from tcs in kvc.ManHinhs
                     where tcs.MaMH == code
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

        public DataTable getAll()
        {
            var kq = from tcs in kvc.ManHinhs select tcs;

            if (!kq.Any()) return null;

            var dt = new DataTable();
            foreach (var prop in typeof(ManHinh).GetProperties())
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
            return dt;
        }


        public ManHinh getByCode(string code)
        {
            return kvc.ManHinhs.Where(t => t.MaMH == code).FirstOrDefault();
        }

        public string GetNextMaMH()
        {
            // Lấy giá trị MaMH lớn nhất hiện tại trong danh sách nhà cung cấp
            var maxMaMH = kvc.ManHinhs
                .OrderByDescending(t => t.MaMH)
                .FirstOrDefault()?.MaMH;

            if (maxMaMH == null)
            {
                // Nếu không có mã màn hình nào, trả về mã mặc định
                return "MH001";
            }

            //Dạng Mã Nhà Cung Cấp là 'MH001'
            string prefix = new string(maxMaMH.TakeWhile(char.IsLetter).ToArray());
            string numberPart = maxMaMH.Substring(prefix.Length);

            if (int.TryParse(numberPart, out int number))
            {
                // Tăng giá trị số và tạo mã mới
                number++;
                return $"{prefix}{number:D3}"; // D3 định dạng số có 3 chữ số
            }

            throw new InvalidOperationException("Invalid MaMH format.");
        }


        public bool addItemMH(ManHinh a)
        {
            bool b = false;
            if (a != null)
            {
                try
                {
                    kvc.ManHinhs.InsertOnSubmit(a);
                    kvc.SubmitChanges();
                    b = true;
                }
                catch
                {
                    b = false;
                }
            }
            return b;
        }

        public bool updateItemMH(ManHinh a, ManHinh d)
        {
            try
            {
                // Câu truy vấn SQL để cập nhật thông tin nhà cung cấp
                string query = string.Format("UPDATE ManHinh SET TenMH = '{1}' WHERE MaMH = '{0}'",
                                            a.MaMH,
                                            d.TenMH != null && d.TenMH != "" ? d.TenMH : a.TenMH);

                // Thực thi câu truy vấn
                int result = DataProvider.Instance.executeNonQuery(query);

                // Trả về true nếu có ít nhất 1 dòng bị ảnh hưởng
                return result > 0;
            }
            catch (Exception ex)
            {
                // Ghi lại thông tin lỗi để kiểm tra
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool deleteItemMH(ManHinh a)
        {
            bool b = false;
            if (a != null)
            {
                try
                {
                    kvc.ManHinhs.DeleteOnSubmit(a);
                    kvc.SubmitChanges();
                    b = true;
                }
                catch
                {
                    b = false;
                }
            }
            return b;
        }


    }
}
