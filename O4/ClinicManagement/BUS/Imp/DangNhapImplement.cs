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
        public string EncodePassword(ref TaiKhoanEnity TaiKhoan)
        {
            TaiKhoan.MatKhau = BUS.Com.Utils.CreateMD5(TaiKhoan.MatKhau);
            return Constant.RES_SUC;
        }
        public string CheckTaiKhoan(TaiKhoanEnity TaiKhoanInput, out TAIKHOAN TaiKhoanOuput, ref List<MessageError> Messages)
        {
            string ProgramName = "DangNhapImplement-CheckTaiKhoan";
            TaiKhoanOuput = new TAIKHOAN();
            // khai báo các biến đón kết quả rả về từ Select
            List<TAIKHOAN> ListSelectResult = null;
            string IdResult;
            // CREATE DB
            using(QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                // tạo đối tượng dao
                DAO.Imp.BaseDAO dao = new DAO.Imp.BaseDAO();
                // thực hiện lệnh select
                IdResult = dao.Select<TAIKHOAN>(db, 
                                                tk => tk.TenDangNhap.Equals(TaiKhoanInput.TenDangNhap) && tk.MatKhau.Equals(TaiKhoanInput.MatKhau),
                                                out ListSelectResult, 
                                                ref Messages);
                // nếu select  error
                if (IdResult.Equals(Constant.RES_FAI))
                {
                    Messages.Add(new MessageError
                    {
                        IdError = Constant.MES_DB,
                        Message = String.Format("Lỗi xãy ra khi lấy dữ liệu từ Table TAIKHOAN - {0}", ProgramName)
                    });
                    return Constant.RES_FAI;
                }
                // nếu không select được bất kỳ record nào
                if(ListSelectResult.Count == 0)
                {
                    Messages.Add(new MessageError
                    {
                        IdError = Constant.MES_DB,
                        Message = String.Format("Không lấy được dữ liệu từ Table TAIKHOAN - {0}", ProgramName)
                    });
                    return Constant.RES_FAI;
                }
                // nếu select được nhiều hơn 1 record 
                if (ListSelectResult.Count > 1)
                {
                    Messages.Add(new MessageError
                    {
                        IdError = Constant.MES_DB,
                        Message = String.Format("Select được 2 record trở lên trong Table TAIKHOAN - {0}", ProgramName)
                    });
                    return Constant.RES_FAI;
                }
            }
            TaiKhoanOuput = ListSelectResult.ElementAt(0);
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
        public string Update(TaiKhoanEnity TaiKhoanUpdate, ref List<MessageError> Messages)
        {
            string ProgramName = "DangNhapImplement-Update";
            TAIKHOAN TaiKhoanDAO = new TAIKHOAN();
            BUS.Com.Utils.CopyPropertiesFrom(TaiKhoanUpdate, TaiKhoanDAO);
            string IdResult;
            using(QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    DAO.Imp.BaseDAO dao = new DAO.Imp.BaseDAO();
                    IdResult = dao.Update(TaiKhoanDAO, db,ref Messages);
                    if (IdResult.Equals(Constant.RES_FAI))
                    {
                        Messages.Add(new MessageError
                        {
                            IdError = Constant.MES_DB,
                            Message = String.Format("Update vào Table TAIKHOAN thất bại - {0}", ProgramName)
                        });
                        trans.Rollback();
                        return Constant.RES_FAI;
                    }
                    else
                    {
                        trans.Commit();
                    }
                }
            }
            return Constant.RES_SUC;
        }
    }
}
