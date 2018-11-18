using System;
using System.Collections.Generic;
using System.Linq;
using BUS.Enities;
using BUS.Service;
using DAO;
using DTO;
using COM;

namespace BUS.Imp
{
    class DangNhapImplement : IDangNhapService
    {
        private DAO.Interface.ITaiKhoanServices taiKhoanServices = null;

        public DangNhapImplement()
        {
            taiKhoanServices = new DAO.Implement.TaiKhoanImplement();
        }

        public string EncodePassword(ref TaiKhoanEnity TaiKhoan)
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

        public string CheckTaiKhoan(QLPHONGKHAMEntities db, TaiKhoanEnity TaiKhoanInput, out TAIKHOAN TaiKhoanOuput)
        {
            object[] param = { TaiKhoanInput.TenDangNhap, TaiKhoanInput.MatKhau};
            return taiKhoanServices.FindByParameter(db, param, out TaiKhoanOuput);
        }

        public string Update(QLPHONGKHAMEntities db, TaiKhoanEnity TaiKhoanUpdate)
        {
            TAIKHOAN taiKhoanDAO = new TAIKHOAN();
            BUS.Com.Utils.CopyPropertiesFrom(TaiKhoanUpdate, taiKhoanDAO);
            return taiKhoanServices.Save(db,taiKhoanDAO);
        }
    }
}
