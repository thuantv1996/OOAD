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
        public string DangNhapProcess(TaiKhoanDTO taiKhoan, out string MaNV)
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
                MaNV = "";
                // return fail
                return Constant.RES_FAI;
            }
            MaNV = ObjectCommon.UserLogin.MaNhanVien;
            // return success
            return Constant.RES_SUC;
        }


        // lay thong tin nhan vien theo ma
        public string GetInformationNhanVien(string MaNV, out NhanVienDTO nhanVien)
        {
            NhanVienBUS nhanVienBUS = new NhanVienBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                return nhanVienBUS.GetInfomationNhanVien(db, MaNV, out nhanVien);
            }
        }
    }
}
