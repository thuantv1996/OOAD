using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.Enities;
using BUS.Service;
using DAO;
using DTO;

namespace BUS.Imp
{
    class DangNhapImplement : IDangNhapService
    {
        public string DangNhapSelect(DangNhapEnity MaTaiKhoan, DangNhapEnity MatKhau, out List<string> MessageError)
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

        public string Delete(DangNhapEnity MaTaiKhoan, out List<string> MessageError)
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

        public string GetListTaiKhoan(DangNhapSearchEntity DangNhapSearchEntity, out List<DangNhapEnity> ListTaiKhoan, out List<string> MessageError)
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



        public string Update(DangNhapSearchEntity DangNhapSearchEntity, out List<DangNhapEnity> ListTaiKhoan, out List<string> MessageError)
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

        public string UpdatePass(DangNhapEnity MaTaiKhoan, DangNhapEnity MatKhau, out List<string> MessageError)
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
    }
}
