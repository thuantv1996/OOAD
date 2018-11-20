using DAO;
using DTO;

namespace BUS.Service
{
    interface IDangNhapService
    {
        // HÀM MÃ HÓA MẬT KHẨU
        string EncodePassword(ref TaiKhoanDTO TaiKhoan);
        // HÀM KIỂM TRA
        string CheckTaiKhoan(QLPHONGKHAMEntities db, TaiKhoanDTO TaiKhoanInput, out TAIKHOAN TaiKhoanOuput);
        // HÀM KIỂM TRA NGÀY THAY ĐỔI PASSWORD CUỐI CÙNG
        string CheckDayLastChange(TAIKHOAN TaiKhoan);
        // UPDATE VÀ SAVE
        string Update(QLPHONGKHAMEntities db, TaiKhoanDTO TaiKhoanUpdate);
    }
}
