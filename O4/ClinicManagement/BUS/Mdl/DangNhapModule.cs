using System.Collections.Generic;
using COM;
using BUS.Imp;
using DAO;
using BUS.Com;
using DTO;

namespace BUS.Mdl
{
    public class DangNhapModule
    {
        public string DangNhapProcess(TaiKhoanDTO taiKhoan, ref List<MessageError> Messages)
        {
            // khởi tạo BUS
            DangNhapBUS dangNhapBUS = new DangNhapBUS();
            // biến đón kết quả trả về
            string result;
            // tạo kết nối database
            using(QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                // thực hiện mã hóa mật khẩu
                dangNhapBUS.EncodePassword(ref taiKhoan);
                // thực hiện check tài khoản
                result = dangNhapBUS.CheckTaiKhoan(db, taiKhoan,out ObjectCommon.UserLogin);
            }
            // nếu kết quả check là fail
            if (result == Constant.RES_FAI)
            {
                // return fail
                return Constant.RES_FAI;
            }
            // return success
            return Constant.RES_SUC;
        }
    }
}
