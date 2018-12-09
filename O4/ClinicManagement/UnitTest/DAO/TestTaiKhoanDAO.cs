using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DAO.Implement;
using System.Data.Entity;

namespace UnitTest.DAO
{
    [TestClass]
    public class TestTaiKhoanDAO
    {
        private static QLPHONGKHAMEntities db;
        private static DbContextTransaction trans;
        // init method
        [TestInitialize]
        public void Init()
        {
            db = new QLPHONGKHAMEntities();
            trans = db.Database.BeginTransaction();
            db.NHANVIENs.Add(new NHANVIEN { MaNV = TestCommon.LEN_10 });
        }

        /* BEGIN TEST METHOD */

        // Test insert data sucesses
        [TestMethod]
        public void Insert_TestCase1()
        {
            TAIKHOAN taiKhoan = new TAIKHOAN
            {
                MaTaiKhoan = TestCommon.LEN_10,
                TenDangNhap = TestCommon.LEN_10 + "1234567890",
                MatKhau = TestCommon.LEN_10 + "1234567890",
                NgayThayDoi = TestCommon.LEN_8,
                MaNhanVien = TestCommon.LEN_10
            };
            TaiKhoanDAO dao = new TaiKhoanDAO();
            string actual = dao.Save(db, taiKhoan);
            string expected = "0000";
            Assert.Equals(expected, actual);
        }


        // Test insert max length
        [TestMethod]
        public void Insert_TestCase2()
        {
            TAIKHOAN taiKhoan = new TAIKHOAN
            {
                MaTaiKhoan = TestCommon.LEN_10 + "1",
                TenDangNhap = TestCommon.LEN_10 + "12345678901",
                MatKhau = TestCommon.LEN_10 + "12345678901234567890111",
                NgayThayDoi = TestCommon.LEN_8 +"1",
                MaNhanVien = TestCommon.LEN_10 + "1"
            };
            TaiKhoanDAO dao = new TaiKhoanDAO();
            string actual = dao.Save(db, taiKhoan);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }


        // Test insert with MaNhanVien doesn't exist in table NHANVIEN
        [TestMethod]
        public void Insert_TestCase3()
        {
            TAIKHOAN taiKhoan = new TAIKHOAN
            {
                MaTaiKhoan = TestCommon.LEN_10,
                TenDangNhap = TestCommon.LEN_10,
                MatKhau = TestCommon.LEN_10,
                NgayThayDoi = TestCommon.LEN_8 ,
                MaNhanVien = "123"
            };
            TaiKhoanDAO dao = new TaiKhoanDAO();
            string actual = dao.Save(db, taiKhoan);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test insert TenDangNhap & MatKhau is null
        [TestMethod]
        public void Insert_TestCase4()
        {
            TAIKHOAN taiKhoan = new TAIKHOAN
            {
                MaTaiKhoan = TestCommon.LEN_10,
                MaNhanVien = TestCommon.LEN_10
            };
            TaiKhoanDAO dao = new TaiKhoanDAO();
            string actual = dao.Save(db, taiKhoan);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test update success
        [TestMethod]
        public void Update_TestCase5()
        {
            TaiKhoanDAO dao = new TaiKhoanDAO();
            TAIKHOAN taiKhoan = new TAIKHOAN
            {
                MaTaiKhoan = TestCommon.LEN_10,
                TenDangNhap = TestCommon.LEN_10,
                MatKhau = TestCommon.LEN_10,
                NgayThayDoi = TestCommon.LEN_8,
                MaNhanVien = TestCommon.LEN_10
            };
            dao.Save(db, taiKhoan);
            TAIKHOAN taiKhoanUpdate = new TAIKHOAN
            {
                MaTaiKhoan = TestCommon.LEN_10,
                TenDangNhap = "TESTUPDATE",
                MatKhau = "123",
                NgayThayDoi = TestCommon.LEN_8,
                MaNhanVien = TestCommon.LEN_10
            };
            string actual = dao.Save(db, taiKhoanUpdate);
            // Biến kết quả
            string expected = "0000";
            // Test 
            Assert.Equals(expected, actual);
        }

        // Test update max length
        [TestMethod]
        public void Update_TestCase6()
        {
            TaiKhoanDAO dao = new TaiKhoanDAO();
            TAIKHOAN taiKhoan = new TAIKHOAN
            {
                MaTaiKhoan = TestCommon.LEN_10,
                TenDangNhap = TestCommon.LEN_10,
                MatKhau = TestCommon.LEN_10,
                NgayThayDoi = TestCommon.LEN_8,
                MaNhanVien = TestCommon.LEN_10
            };
            dao.Save(db, taiKhoan);
            TAIKHOAN taiKhoanUpdate = new TAIKHOAN
            {
                MaTaiKhoan = TestCommon.LEN_10 + "1",
                TenDangNhap = TestCommon.LEN_10 + "12345678901",
                MatKhau = TestCommon.LEN_10 + "12345678901234567890111",
                NgayThayDoi = TestCommon.LEN_8 + "1",
                MaNhanVien = TestCommon.LEN_10 + "1"
            };
            string actual = dao.Save(db, taiKhoanUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }


        // Test update with MaNhanVien doesn't exist in table NHANVIEN
        [TestMethod]
        public void Update_TestCase7()
        {
            TaiKhoanDAO dao = new TaiKhoanDAO();
            TAIKHOAN taiKhoan = new TAIKHOAN
            {
                MaTaiKhoan = TestCommon.LEN_10,
                TenDangNhap = TestCommon.LEN_10,
                MatKhau = TestCommon.LEN_10,
                NgayThayDoi = TestCommon.LEN_8,
                MaNhanVien = TestCommon.LEN_10
            };
            dao.Save(db, taiKhoan);
            TAIKHOAN taiKhoanUpdate = new TAIKHOAN
            {
                MaTaiKhoan = TestCommon.LEN_10,
                MaNhanVien = "123"
            };
            string actual = dao.Save(db, taiKhoanUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }

        // Test update TenDangNhap & MatKhau is null
        [TestMethod]
        public void Update_TestCase8()
        {
            TaiKhoanDAO dao = new TaiKhoanDAO();
            TAIKHOAN taiKhoan = new TAIKHOAN
            {
                MaTaiKhoan = TestCommon.LEN_10,
                TenDangNhap = TestCommon.LEN_10,
                MatKhau = TestCommon.LEN_10,
                NgayThayDoi = TestCommon.LEN_8,
                MaNhanVien = TestCommon.LEN_10
            };
            dao.Save(db, taiKhoan);
            TAIKHOAN taiKhoanUpdate = new TAIKHOAN
            {
                MaTaiKhoan = TestCommon.LEN_10,
                NgayThayDoi = TestCommon.LEN_8,
                MaNhanVien = TestCommon.LEN_10
            };
            string actual = dao.Save(db, taiKhoanUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }

        // Test delete sucesses
        [TestMethod]
        public void Delete_TestCase9()
        {
            TAIKHOAN taiKhoan = new TAIKHOAN
            {
                MaTaiKhoan = TestCommon.LEN_10,
                TenDangNhap = "abc",
                MatKhau = "abc",
                MaNhanVien = TestCommon.LEN_10
            };
            TaiKhoanDAO dao = new TaiKhoanDAO();
            string actual = dao.Save(db, taiKhoan);
            Assert.Equals(null, actual);
        }
        /* END TEST METHOD */

        // clean method
        [TestCleanup]
        public void Clean()
        {
            trans.Rollback();
            trans.Dispose();
            db.Dispose();
        }
    }
}
