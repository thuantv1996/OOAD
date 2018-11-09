using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Com
{
    public class BusConstant
    {
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

        // Loại hồ sơ
        // Hồ sơ khám mới
        public static string HS_KHAMMOI = "LHS0000001";
        // Hồ sơ tái khám
        public static string HS_TAIKHAM = "LHS0000002";

        // Node trong luồn công việc
        public static string NODE_KHAM = "00001";
        public static string NODE_THANH_TOAN_XET_NGHIEM = "00002";
        public static string NODE_XET_NGHIEM = "00003";
        public static string NODE_KHAM_SAU_XN = "00004";
        public static string NODE_HOAN_TAT = "00005";
    }
}
