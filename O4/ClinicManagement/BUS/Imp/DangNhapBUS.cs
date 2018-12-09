using System;
using DAO;
using COM;
using DAO.Implement;
using DTO;

namespace BUS.Imp
{
    public class DangNhapBUS
    {
        private TaiKhoanDAO taiKhoanServices = null;

        public DangNhapBUS()
        {
            taiKhoanServices = new TaiKhoanDAO();
        }

        public string EncodePassword(ref TaiKhoanDTO TaiKhoan)
        {
            TaiKhoan.MatKhau = BUS.Com.Utils.CreateMD5(TaiKhoan.MatKhau);
            return Constant.RES_SUC;
        }
        
        public string CheckDayLastChange(TAIKHOAN TaiKhoan)
        {
            // lấy ngày hệ thống
            DateTime SystemDate = DateTime.Now;
            // Lấy ngày modify
            DateTime ModifyDate = new DateTime(Int32.Parse(TaiKhoan.NgayThayDoi.Substring(0,4)),
                                               Int32.Parse(TaiKhoan.NgayThayDoi.Substring(4, 2)),
                                               Int32.Parse(TaiKhoan.NgayThayDoi.Substring(6, 2)));
            // trừ hai ngày
            TimeSpan SubTime = SystemDate.Subtract(ModifyDate);
            // kiểm tra số ngày trừ ra có lớn hơn 30 hay không.
            if (SubTime.TotalDays > 30)
            {
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }

        public string CheckTaiKhoan(QLPHONGKHAMEntities db, TaiKhoanDTO TaiKhoanInput, out TAIKHOAN TaiKhoanOuput)
        {
            object[] param = { TaiKhoanInput.TenDangNhap, TaiKhoanInput.MatKhau};
            return taiKhoanServices.FindByParameter(db, param, out TaiKhoanOuput);
        }

        public string Update(QLPHONGKHAMEntities db, TaiKhoanDTO TaiKhoanUpdate)
        {
            TAIKHOAN taiKhoanDAO = new TAIKHOAN();
            BUS.Com.Utils.CopyPropertiesFrom(TaiKhoanUpdate, taiKhoanDAO);
            return taiKhoanServices.Save(db,taiKhoanDAO);
        }
    }
}
