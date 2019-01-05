using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO;
using System.Data.Entity;
using DAO;
using BUS.Imp;
using BUS.Entities;
using System.Collections.Generic;

namespace UnitTest.BUS
{
    [TestClass]
    public class TestTaiKhoanBUS
    {
        private static QLPHONGKHAMEntities db;
        private static DbContextTransaction trans;
        //init method
        [TestInitialize]
        public void Init()
        {
            db = new QLPHONGKHAMEntities();
            trans = db.Database.BeginTransaction();
            db.NHANVIENs.Add(new NHANVIEN { MaNV = TestCommon.LEN_10 });
        }

        /* BEGIN TEST METHOD */
        // Test update success
        [TestMethod]
        public void Update_TestCase1()
        {
            TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO
            {
                MaTaiKhoan = TestCommon.LEN_10,
                TenDangNhap = TestCommon.LEN_10,
                MatKhau = TestCommon.LEN_10,
                NgayThayDoi = TestCommon.LEN_8,
                MaNhanVien = TestCommon.LEN_10

            };
            DangNhapBUS dangNhapBUS = new DangNhapBUS();

            dangNhapBUS.Update(db, taiKhoanDTO);

            TaiKhoanDTO taiKhoanUpdate = new TaiKhoanDTO
            {
                MaTaiKhoan = TestCommon.LEN_10,
                TenDangNhap = "TESTUPDATE",
                MatKhau = "123",
                NgayThayDoi = TestCommon.LEN_8,
                MaNhanVien = TestCommon.LEN_10
            };
            // execute
            string actual = dangNhapBUS.Update(db, taiKhoanDTO);
            string expected = "0000";

            // compare
            Assert.Equals(expected, actual);
        }

        // Test update max length
        [TestMethod]
        public void Update_TestCase2()
        {
            TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO
            {
                MaTaiKhoan = TestCommon.LEN_10,
                TenDangNhap = TestCommon.LEN_10,
                MatKhau = TestCommon.LEN_10,
                NgayThayDoi = TestCommon.LEN_8,
                MaNhanVien = TestCommon.LEN_10

            };
            DangNhapBUS dangNhapBUS = new DangNhapBUS();

            dangNhapBUS.Update(db, taiKhoanDTO);

            TaiKhoanDTO taiKhoanUpdate = new TaiKhoanDTO
            {
                MaTaiKhoan = TestCommon.LEN_10 + "1",
                TenDangNhap = TestCommon.LEN_10 + "12345678901",
                MatKhau = TestCommon.LEN_10 + "12345678901234567890111",
                NgayThayDoi = TestCommon.LEN_8 + "1",
                MaNhanVien = TestCommon.LEN_10 + "1"
            };
            // execute
            string actual = dangNhapBUS.Update(db, taiKhoanDTO);
            string expected = "1111";

            // compare
            Assert.Equals(expected, actual);

        }
        // Test update with MaNhanVien doesn't exist in table NHANVIEN
        [TestMethod]
        public void Update_TestCase3()
        {
            TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO
            {
                MaTaiKhoan = TestCommon.LEN_10,
                TenDangNhap = TestCommon.LEN_10,
                MatKhau = TestCommon.LEN_10,
                NgayThayDoi = TestCommon.LEN_8,
                MaNhanVien = TestCommon.LEN_10

            };
            DangNhapBUS dangNhapBUS = new DangNhapBUS();

            dangNhapBUS.Update(db, taiKhoanDTO);

            TaiKhoanDTO taiKhoanUpdate = new TaiKhoanDTO
            {
                MaTaiKhoan = TestCommon.LEN_10,
                MaNhanVien = "123"
            };
            // execute
            string actual = dangNhapBUS.Update(db, taiKhoanDTO);
            string expected = "1111";

            // compare
            Assert.Equals(expected, actual);

        }
        // Test update TenDangNhap & MatKhau is null
        [TestMethod]
        public void Update_TestCase4()
        {
            TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO
            {
                MaTaiKhoan = TestCommon.LEN_10,
                TenDangNhap = TestCommon.LEN_10,
                MatKhau = TestCommon.LEN_10,
                NgayThayDoi = TestCommon.LEN_8,
                MaNhanVien = TestCommon.LEN_10

            };
            DangNhapBUS dangNhapBUS = new DangNhapBUS();

            dangNhapBUS.Update(db, taiKhoanDTO);

            TaiKhoanDTO taiKhoanUpdate = new TaiKhoanDTO
            {
                MaTaiKhoan = TestCommon.LEN_10,
                NgayThayDoi = TestCommon.LEN_8,
                MaNhanVien = TestCommon.LEN_10
            };
            // execute
            string actual = dangNhapBUS.Update(db, taiKhoanDTO);
            string expected = "1111";

            // compare
            Assert.Equals(expected, actual);

        }
        /* END TEST METHOD */

        [TestCleanup]
        public void Clean()
        {
            trans.Rollback();
            trans.Dispose();
            db.Dispose();
        }

    }
}
