using System.Collections.Generic;
using DAO;
using DTO;
using COM;

namespace BUS.Service
{
    interface IDangNhapService
    {
        // ĐÂY LÀ TẤT CẢ CÁC HÀM ANH VIẾT.
        // EM CHÚ Ý VÀO CLASS DIAGRAM

        // HÀM MÃ HÓA MẬT KHẨU
        string EncodePassword(ref TaiKhoanEnity TaiKhoan);
        // HÀM KIỂM TRA
        string CheckTaiKhoan(TaiKhoanEnity TaiKhoanInput, out TAIKHOAN TaiKhoanOuput, ref List<MessageError> Messages);
        // HÀM KIỂM TRA NGÀY THAY ĐỔI PASSWORD CUỐI CÙNG
        string CheckDayLastChange(TAIKHOAN TaiKhoan, ref List<MessageError> Messages);
        // UPDATE VÀ SAVE
        string Update(TaiKhoanEnity TaiKhoanUpdate, ref List<MessageError> Messages);



        // ĐÂY LÀ TẤT CẢ CÁC HÀM EM VIẾT
        string GetListTaiKhoan(Enities.DangNhapSearchEntity DangNhapSearchEntity, out List<TaiKhoanEnity> ListTaiKhoan, out List<string> MessageError);

        string UpdatePass(TaiKhoanEnity MaTaiKhoan, TaiKhoanEnity MatKhau, out List<string> MessageError);

        string DangNhapSelect(TaiKhoanEnity MaTaiKhoan, TaiKhoanEnity MatKhau, out List<string> MessageError);

        string Update(Enities.DangNhapSearchEntity DangNhapSearchEntity, out List<TaiKhoanEnity> ListTaiKhoan, out List<string> MessageError);

        string Delete(TaiKhoanEnity MaTaiKhoan, out List<string> MessageError);


    }
}
