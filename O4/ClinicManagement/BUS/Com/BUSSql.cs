using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Com
{
    public class BUSSql
    {
        // SQL SELECT SEARCH BENHNHAN
        public static string SqlSearchBenhNhan(object[] param)
        {
            bool HasPrev = false;
            string SqlCode = "SELECT * FROM NHANVIEN WHERE ";
            if(param[0]!=null && !param[0].Equals(""))
            {
                SqlCode += "MaBenhNhan LIKE N'%'+{0}+'%' ";
                HasPrev = true;
            }
            if (param[1] != null && !param[1].Equals(""))
            {
                if (HasPrev)
                {
                    SqlCode += "AND ";
                }
                SqlCode += "TenBenhNhan LIKE N'%'+{1}+'%' ";
                HasPrev = true;
            }
            if (param[2] != null && !param[2].Equals(""))
            {
                if (HasPrev)
                {
                    SqlCode += "AND ";
                }
                SqlCode += "CMND LIKE {2}";
            }
            return SqlCode;
        }

    }
}
