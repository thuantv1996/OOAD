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
        
        public string DangNhapSelect(TaiKhoanEnity MaTaiKhoan, TaiKhoanEnity MatKhau, out List<string> MessageError)
        {
            // Danh sách tai khoan (DTO) trả về
            //ListTaiKhoan = new List<DangNhapEnity>();
            // Danh sách Tai Khoan (DAO) Nhận được từ function select
            List<TAIKHOAN> LstResult = null;
            // Result code
            string IdResult = "";
            // Khởi tạo Database
            using (var db = new QLPHONGKHAMEntities())
            {
                // Khởi tạo Transaction
                using (var trans = db.Database.BeginTransaction())
                {
                    // Khởi tạo lớp DAO
                    DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                    // Tạo Paramester search
                    object[] param = { MaTaiKhoan, MatKhau };
                    string[] name = new string[2];
                    param = new object[2];

                    name[0] = "@MaTaiKhoan"; param[0] = MaTaiKhoan;
                    name[1] = "@MatKhau"; param[1] = MatKhau;

                    // thực thi hàm select 

                    IdResult = Dao.Select("DangNhap_Select", name, param, 2, out LstResult, out MessageError);

                    // Nếu không thực hiện được lệnh SELECT
                    if (IdResult == BUS.Com.BusConstant.RES_FAI)
                    {
                        if (MessageError == null)
                        {
                            MessageError = new List<string>();
                        }
                        // Thêm thông báo lỗi
                        MessageError.Insert(0, "Lỗi Database trong truy vấn select table TAIKHOAN");
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                    }
                    // Nếu không tìm thấy trường
                    if (LstResult.Count == 0)
                    {
                        if (MessageError == null)
                        {
                            MessageError = new List<string>();
                        }
                        // Thêm thông báo lỗi
                        MessageError.Insert(0, "Không select được dữ liệu (Data is empty)");
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                    }
                }

            }
            throw new NotImplementedException();
        }

        public string Delete(TaiKhoanEnity MaTaiKhoan, out List<string> MessageError)
        {
            // Danh sách tai khoan (DTO) trả về
            //ListTaiKhoan = new List<DangNhapEnity>();
            // Danh sách Tai Khoan (DAO) Nhận được từ function select
            List<TAIKHOAN> LstResult = null;
            // Result code
            string IdResult = "";
            // Khởi tạo Database
            using (var db = new QLPHONGKHAMEntities())
            {
                // Khởi tạo Transaction
                using (var trans = db.Database.BeginTransaction())
                {
                    // Khởi tạo lớp DAO
                    DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                    // Tạo Paramester search
                    object[] param = { MaTaiKhoan };
                    string[] name = new string[1];
                    param = new object[1];

                    name[0] = "@MaTaiKhoan"; param[0] = MaTaiKhoan;


                    // thực thi hàm select 

                    IdResult = Dao.Select("Delete", name, param, 1, out LstResult, out MessageError);

                    // Nếu không thực hiện được lệnh SELECT
                    if (IdResult == BUS.Com.BusConstant.RES_FAI)
                    {
                        if (MessageError == null)
                        {
                            MessageError = new List<string>();
                        }
                        // Thêm thông báo lỗi
                        MessageError.Insert(0, "Lỗi Database trong truy vấn select table TAIKHOAN");
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                    }
                    // Nếu không tìm thấy trường
                    if (LstResult.Count == 0)
                    {
                        if (MessageError == null)
                        {
                            MessageError = new List<string>();
                        }
                        // Thêm thông báo lỗi
                        MessageError.Insert(0, "Không select được dữ liệu (Data is empty)");
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                    }
                }
            }
            throw new NotImplementedException();
        }

        public string GetListTaiKhoan(DangNhapSearchEntity DangNhapSearchEntity, out List<TaiKhoanEnity> ListTaiKhoan, out List<string> MessageError)
        {
            // Danh sách tai khoan (DTO) trả về
            //ListTaiKhoan = new List<DangNhapEnity>();
            // Danh sách Tai Khoan (DAO) Nhận được từ function select
            List<TAIKHOAN> LstResult = null;
            // Result code
            string IdResult = "";
            // Khởi tạo Database
            using (var db = new QLPHONGKHAMEntities())
            {
                // Khởi tạo Transaction
                using (var trans = db.Database.BeginTransaction())
                {
                    // Khởi tạo lớp DAO
                    DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                    // Tạo Paramester search
                    object[] param = { DangNhapSearchEntity.MaTaiKhoan, DangNhapSearchEntity.MatKhau, DangNhapSearchEntity.TenDangNhap,
                                       DangNhapSearchEntity.NgayThayDoi, DangNhapSearchEntity.MaNhanVien };
                    string[] name = new string[5];
                    param = new object[5];

                    name[0] = "@MaTaiKhoan"; param[0] = DangNhapSearchEntity.MaTaiKhoan;
                    name[1] = "@MatKhau"; param[1] = DangNhapSearchEntity.MatKhau;
                    name[2] = "@TenDangNhap"; param[2] = DangNhapSearchEntity.TenDangNhap;
                    name[3] = "@NgayThayDoi"; param[3] = DangNhapSearchEntity.NgayThayDoi;
                    name[4] = "@MaNhanVien"; param[4] = DangNhapSearchEntity.MaNhanVien;


                    // thực thi hàm select 

                    IdResult = Dao.Select("Insert", name, param, 5, out LstResult, out MessageError);

                    // Nếu không thực hiện được lệnh SELECT
                    if (IdResult == BUS.Com.BusConstant.RES_FAI)
                    {
                        if (MessageError == null)
                        {
                            MessageError = new List<string>();
                        }
                        // Thêm thông báo lỗi
                        MessageError.Insert(0, "Lỗi Database trong truy vấn select table TAIKHOAN");
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                    }
                    // Nếu không tìm thấy trường
                    if (LstResult.Count == 0)
                    {
                        if (MessageError == null)
                        {
                            MessageError = new List<string>();
                        }
                        // Thêm thông báo lỗi
                        MessageError.Insert(0, "Không select được dữ liệu (Data is empty)");
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                    }
                }

                throw new NotImplementedException();
            }
        }

        public string Update(DangNhapSearchEntity DangNhapSearchEntity, out List<TaiKhoanEnity> ListTaiKhoan, out List<string> MessageError)
        {

            // Danh sách tai khoan (DTO) trả về
            //ListTaiKhoan = new List<DangNhapEnity>();
            // Danh sách Tai Khoan (DAO) Nhận được từ function select
            List<TAIKHOAN> LstResult = null;
            // Result code
            string IdResult = "";
            // Khởi tạo Database
            using (var db = new QLPHONGKHAMEntities())
            {
                // Khởi tạo Transaction
                using (var trans = db.Database.BeginTransaction())
                {
                    // Khởi tạo lớp DAO
                    DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                    // Tạo Paramester search
                    object[] param = { DangNhapSearchEntity.MaTaiKhoan, DangNhapSearchEntity.MatKhau, DangNhapSearchEntity.TenDangNhap,
                                       DangNhapSearchEntity.NgayThayDoi, DangNhapSearchEntity.MaNhanVien };
                    string[] name = new string[4];
                    param = new object[4];

                    name[0] = "@MaTaiKhoan"; param[0] = DangNhapSearchEntity.MaTaiKhoan;
                    name[1] = "@MatKhau"; param[1] = DangNhapSearchEntity.MatKhau;
                    name[2] = "@NgayThayDoi"; param[2] = DangNhapSearchEntity.NgayThayDoi;
                    name[3] = "@MaNhanVien"; param[3] = DangNhapSearchEntity.MaNhanVien;


                    // thực thi hàm select 

                    IdResult = Dao.Select("Update", name, param, 4, out LstResult, out MessageError);

                    // Nếu không thực hiện được lệnh SELECT
                    if (IdResult == BUS.Com.BusConstant.RES_FAI)
                    {
                        if (MessageError == null)
                        {
                            MessageError = new List<string>();
                        }
                        // Thêm thông báo lỗi
                        MessageError.Insert(0, "Lỗi Database trong truy vấn select table TAIKHOAN");
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                    }
                    // Nếu không tìm thấy trường
                    if (LstResult.Count == 0)
                    {
                        if (MessageError == null)
                        {
                            MessageError = new List<string>();
                        }
                        // Thêm thông báo lỗi
                        MessageError.Insert(0, "Không select được dữ liệu (Data is empty)");
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                    }
                }

                throw new NotImplementedException();
            }
        }

        public string UpdatePass(TaiKhoanEnity MaTaiKhoan, TaiKhoanEnity MatKhau, out List<string> MessageError)
        //đây là thủ tục sẽ dùng ở form đăng nhập, với điều kiện là trùng mã tài khoản và mật khẩu.
        {
            // Danh sách tai khoan (DTO) trả về
            //ListTaiKhoan = new List<DangNhapEnity>();
            // Danh sách Tai Khoan (DAO) Nhận được từ function select
            List<TAIKHOAN> LstResult = null;
            // Result code
            string IdResult = "";
            // Khởi tạo Database
            using (var db = new QLPHONGKHAMEntities())
            {
                // Khởi tạo Transaction
                using (var trans = db.Database.BeginTransaction())
                {
                    // Khởi tạo lớp DAO
                    DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                    // Tạo Paramester search
                    object[] param = { MaTaiKhoan, MatKhau };
                    string[] name = new string[2];
                    param = new object[2];

                    name[0] = "@MaTaiKhoan"; param[0] = MaTaiKhoan;
                    name[1] = "@MatKhau"; param[1] = MatKhau;

                    // thực thi hàm select 

                    IdResult = Dao.Select("Update_Password", name, param, 2, out LstResult, out MessageError);

                    // Nếu không thực hiện được lệnh SELECT
                    if (IdResult == BUS.Com.BusConstant.RES_FAI)
                    {
                        if (MessageError == null)
                        {
                            MessageError = new List<string>();
                        }
                        // Thêm thông báo lỗi
                        MessageError.Insert(0, "Lỗi Database trong truy vấn select table TAIKHOAN");
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                    }
                    // Nếu không tìm thấy trường
                    if (LstResult.Count == 0)
                    {
                        if (MessageError == null)
                        {
                            MessageError = new List<string>();
                        }
                        // Thêm thông báo lỗi
                        MessageError.Insert(0, "Không select được dữ liệu (Data is empty)");
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                    }
                }

            }
            throw new NotImplementedException();
        }


        // CODE ANH VIẾT TẠI ĐÂY
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
