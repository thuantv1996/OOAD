using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Com
{
    public class BusConstant
    {
        // thành công
        public static string RES_SUC = "0000";

        // thất bại
        public static string RES_FAI = "1111";

        // check input thất bại
        public static string RES_INC_FAI = "9999";

        // Độ dài họ tên bệnh nhân
        public static int LENGTH_HOTEN_BENHNHAN = 50;
        // Độ dài số cmnd bệnh nhân
        public static int LENGTH_CMND_BENHNHAN = 12;
        // Độ dài ngày sinh bệnh nhân
        public static int LENGTH_NGAYSINH_BENHNHAN = 8;
        // Độ dài số điện thoại bệnh nhân
        public static int LENGTH_SODIENTHOAI_BENHNHAN = 11;
        // Độ dài địa chỉ bệnh nhân
        public static int LENGTH_DIACHI_BENHNHAN = 250;
        // Độ dài ghi chú bệnh nhân
        public static int LENGTH_GHICHU_BENHNHAN = 250;
    }
}
