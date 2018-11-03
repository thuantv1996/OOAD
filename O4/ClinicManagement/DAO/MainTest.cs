﻿using DAO.Imp;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COM;

namespace DAO
{
    class MainTest
    {
        public static void Main(string[] args)
        {
            // lấy ngày hệ thống
            DateTime SystemDate = DateTime.Now;
            // Lấy ngày modify
            DateTime ModifyDate = new DateTime(2018,
                                               11,
                                               1);
            // trừ hai ngày
            TimeSpan SubTime = SystemDate.Subtract(ModifyDate);
            //int e = 0;
            // Hướng dẫn sử dụng DAO

            /* Dùng DAO select Dữ liệu từ một bảng*/
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                // Khai báo DAO
                BaseDAO dao = new BaseDAO();
                // Danh sách kết quả trả về
                List<LOAIHOSO> LstRest = null;
                // Danh sách MessageError
                List<MessageError> MessageError = null;
                // return Id
                string IdResult = "";
                // Ví dụ lấy tất cả data bảng LOAIHOSO
                IdResult = dao.Select(db, out LstRest,ref MessageError);
                // Hoặc để minh bạch hơn có thể viết lệnh như sau
                IdResult = dao.Select<LOAIHOSO>(db, out LstRest, ref MessageError);
                // hai lệnh trên gọi đến cùng một function

                // Để Select có điều kiện bắt buộc các bạn cần phải biết Linq
                // Ví dụ select tất cả các bảng ghi có mã Loại hồ sơ là LHS0000001
                IdResult = dao.Select(db, lhs => lhs.MaLoaiHoSo == "LHS0000001", out LstRest, ref MessageError);
                // Chú ý trong ví dụ trên tham số thứ 2 là Lamda function các bạn cần tìm hiểu cái này
                // Cái này khá quen thuộc và cần thiết khi các bạn làm việc với JS react native
                // Các bạn có thể hiểu nôm na là các phần tử trước '=>' là tham số truyền vào hàm lambda
                // Các mã viết sau '=>' là biểu thức thực hiện hàm lambda đó

                // Để thực hiện các câu Select phức tạp hơn cần viết SQL
                // ví dụ thực hiện Lấy Ra danh sách Nhân viên có Mã Loại Nhân Viên LNV0000001
                string sql = "Select NHANVIEN.HoTenNV AS TenNhanVien,LOAINHANVIEN.TenLoaiNV AS TenLoaiNhanVien " +
                             "from NHANVIEN,LOAINHANVIEN " +
                             "WHERE NHANVIEN.MaLoaiNV = LOAINHANVIEN.MaLoaiNV and LOAINHANVIEN.MaLoaiNV={0}";
                List<ExtendEmployee> LstRestEmp = null;
                object[] param = { "LNV0000001" };
                dao.Select<ExtendEmployee>(db, sql, param, out LstRestEmp, ref MessageError);
            }

            /* Dùng DAO insert Dữ liệu vào một bảng*/
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                // Transaction quản lý việc thực thi chuỗi nghiệp vụ
                using (var transaction = db.Database.BeginTransaction())
                {
                    // Khai báo DAO
                    BaseDAO dao = new BaseDAO();
                    // Danh sách kết quả trả về
                    //List<LOAIHOSO> LstRest = null;
                    // Danh sách MessageError
                    List<MessageError> MessageError = null;
                    // return Id
                    string IdResult = "";
                    // Entity
                    LOAIHOSO entity = new LOAIHOSO { MaLoaiHoSo = "LHS0000001", TenLoaiHoSo = "Hồ sơ khám mới" };
                    // thực thi insert 
                    IdResult = dao.Insert(entity, db, ref MessageError);

                    if (IdResult == Constant.RES_SUC)
                    {
                        // Cần phải commit data sau khi thực thi chuỗi nghiệp vụ
                        transaction.Commit();
                    }
                    else
                    {
                        // nếu có bất cứ thực thi nào error thì phải rollback data
                        transaction.Rollback();
                    }
                }
            }
            // Các lệnh Update, Delete sử dụng tương tự lệnh insert
        }

        public static void Test1()
        {
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                // Khai báo DAO
                BaseDAO dao = new BaseDAO();
                // Danh sách kết quả trả về
                List<LOAIHOSO> LstRest = null;
                // Danh sách MessageError
                List<MessageError> MessageError = null;

                string sql = "Select * from LOAIHOSO where MaLoaiHoSo Like N''+{0}+'%' and TenLoaiHoSo LIKE N''+{1}+'%'";
                object[] param = { "" , "" };
                dao.Select(db, sql, param, out LstRest, ref MessageError);
            }
        }
    }
    class ExtendEmployee
    {
            public string TenNhanVien { get; set; }
            public String TenLoaiNhanVien { get; set; }
    }
    
}
