using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using COM;
using BUS.Imp;
using DAO;
using BUS.Com;

namespace BUS.Mdl
{
    public class DangNhapModule
    {   
        const int ID_SUCCESS = 0;
        const int ID_ERROR_BACK_LOGIN = 1;
        const int ID_ERROR_CHANGE_PASSWORD = 2;

        public string DangNhapProcess(TaiKhoanEnity TaiKhoan, ref List<MessageError> Messages, out int IdScreen)
        {
            TAIKHOAN TaiKhoanDAO = new TAIKHOAN();
            DangNhapImplement dangNhapImplement = new DangNhapImplement();
            dangNhapImplement.EncodePassword(ref TaiKhoan);
            if(dangNhapImplement.CheckTaiKhoan(TaiKhoan, out TaiKhoanDAO, ref Messages).Equals(Constant.RES_FAI))
            {
                Messages.Add(new MessageError { IdError = Constant.MES_PRE, Message = "Tài khoản hoặc mật khẩu không đúng!"});
                IdScreen = ID_ERROR_BACK_LOGIN;
                return Constant.RES_FAI;
            }
            if (dangNhapImplement.CheckDayLastChange(TaiKhoanDAO).Equals(Constant.RES_FAI))
            {
                Messages.Add(new MessageError { IdError = Constant.MES_PRE, Message = "Tài khoản của bạn cần thay đổi mật khẩu!" });
                IdScreen = ID_ERROR_CHANGE_PASSWORD;
                return Constant.RES_FAI;
            }
            IdScreen = ID_SUCCESS;
            ObjectCommon.UserLogin = new TAIKHOAN();
            Utils.CopyPropertiesFrom(TaiKhoanDAO, ObjectCommon.UserLogin);
            return Constant.RES_SUC;
        }

        public string ChangePasswordProcess(TaiKhoanEnity TaiKhoan, ref List<MessageError> Messages)
        {
            // check Validation
            DangNhapImplement dangNhapImplement = new DangNhapImplement();
            dangNhapImplement.EncodePassword(ref TaiKhoan);
            if(dangNhapImplement.Update(TaiKhoan, ref Messages).Equals(Constant.RES_FAI))
            {
                Messages.Add(new MessageError { IdError = Constant.MES_PRE, Message = "Thay đồi mật khẩu không thành công!" });
                return Constant.RES_FAI;
            }
            ObjectCommon.UserLogin = new TAIKHOAN();
            Utils.CopyPropertiesFrom(TaiKhoan, ObjectCommon.UserLogin);
            return Constant.RES_SUC;
        }
    }
}
