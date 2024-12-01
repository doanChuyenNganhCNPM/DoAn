using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;

namespace BLL_DAL
{
    static class ConvertUltil
    {
        public static DataTable ConvertListToDataTable<T>(this List<T> iList)
        {
            DataTable dataTable = new DataTable();
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor propertyDescriptor = props[i];
                Type type = propertyDescriptor.PropertyType;

                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    type = Nullable.GetUnderlyingType(type);

                dataTable.Columns.Add(propertyDescriptor.Name, type);
            }
            object[] values = new object[props.Count];
            foreach (T iListItem in iList)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(iListItem);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        static string[] chuSo = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };

        public static string DocBaChuSo(int so)
        {
            string ketQua = "";
            int tram = so / 100;
            int chuc = (so % 100) / 10;
            int donVi = so % 10;

            if (tram != 0)
            {
                ketQua += chuSo[tram] + " trăm";
                if (chuc == 0 && donVi != 0)
                {
                    ketQua += " lẻ";
                }
            }

            if (chuc != 0 && chuc != 1)
            {
                ketQua += " " + chuSo[chuc] + " mươi";
                if (donVi == 1)
                    ketQua += " mốt";
            }
            else if (chuc == 1)
            {
                ketQua += " mười";
            }

            if (donVi != 0)
            {
                if (chuc == 0)
                {
                    ketQua += " lẻ " + chuSo[donVi];
                }
                else if (donVi == 5 && chuc != 0)
                {
                    ketQua += " lăm";
                }
                else
                {
                    ketQua += " " + chuSo[donVi];
                }
            }

            return ketQua.Trim();
        }

        public static string ConvertNumberToString(int so)
        {
            if (so == 0) return "không";

            string ketQua = "";
            int ty = so / 1000000000;
            so = so % 1000000000;
            int trieu = so / 1000000;
            so = so % 1000000;
            int nghin = so / 1000;
            so = so % 1000;
            int donVi = so;

            if (ty > 0)
            {
                ketQua += DocBaChuSo(ty) + " tỷ";
            }
            if (trieu > 0)
            {
                ketQua += " " + DocBaChuSo(trieu) + " triệu";
            }
            if (nghin > 0)
            {
                ketQua += " " + DocBaChuSo(nghin) + " nghìn";
            }
            if (donVi > 0)
            {
                ketQua += " " + DocBaChuSo(donVi);
            }

            return ketQua.Trim();
        }


        public static List<int> ConvertDateTimeToList(DateTime date)
        {
            int day = date.Day;
            int month = date.Month;
            int year = date.Year;
            List<int> dateList = new List<int> { day, month, year };
            return dateList;
        }
        public static bool Ktra_So(string str)
        {
            if(str.Length == 0) return false;
            foreach (char c in str)
            {
                if (c < 48 || c > 57)
                    return false;
            }
            return true;
        }
        public static bool Ktra_SDT(string str)
        {
            if (str.Length == 0 || str.Length > 12 || str[0] != '0') return false;
            return true;
        }
    }
}
