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
        string CheckTaiKhoan(TaiKhoanEnity TaiKhoanInput, out TAIKHOAN TaiKhoanOuput, ref List<MessageError> Messages);
        // HÀM KIỂM TRA NGÀY THAY ĐỔI PASSWORD CUỐI CÙNG
        string CheckDayLastChange(TAIKHOAN TaiKhoan);
        // UPDATE VÀ SAVE
        string Update(TaiKhoanEnity TaiKhoanUpdate, ref List<MessageError> Messages);
    }
}
