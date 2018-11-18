using System.Collections.Generic;
using DAO;
using DTO;
using COM;

namespace BUS.Service
{
    interface IDangNhapService
    {
        // HÀM MÃ HÓA MẬT KHẨU
        string EncodePassword(ref TaiKhoanEnity TaiKhoan);
        // HÀM KIỂM TRA
        string CheckTaiKhoan(QLPHONGKHAMEntities db, TaiKhoanEnity TaiKhoanInput, out TAIKHOAN TaiKhoanOuput);
        // HÀM KIỂM TRA NGÀY THAY ĐỔI PASSWORD CUỐI CÙNG
        string CheckDayLastChange(TAIKHOAN TaiKhoan);
        // UPDATE VÀ SAVE
        string Update(QLPHONGKHAMEntities db, TaiKhoanEnity TaiKhoanUpdate);
    }
}
