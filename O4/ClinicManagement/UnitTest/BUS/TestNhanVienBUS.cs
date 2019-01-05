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
    public class TestNhanVienBUS
    {
        private static QLPHONGKHAMEntities db;
        private static DbContextTransaction trans;
        // init method
        [TestInitialize]
        public void Init()
        {
            db = new QLPHONGKHAMEntities();
            trans = db.Database.BeginTransaction();
        }

        /*Begin test method*/

        //Test success
        [TestMethod] 
        public void GetInformation_TestCase1()
        {
            // create data search
            db.NHANVIENs.Add(new NHANVIEN { MaNV = "1234567890" });
            db.NHANVIENs.Add(new NHANVIEN { MaNV = "1234567891" });
            db.NHANVIENs.Add(new NHANVIEN { MaNV = "1234567892" });

            NhanVienDTO nhanVienDTO = null;
            NhanVienBUS nhanVienBUS = new NhanVienBUS();

            string actual = nhanVienBUS.GetInfomationNhanVien(db, "1234567890", out nhanVienDTO);
            string expected = "0000";

            Assert.Equals(actual, expected);


        }
        [TestMethod]
        public void GetInformation_TestCase2()
        {
           

            NhanVienDTO nhanVienDTO = null;
            NhanVienBUS nhanVienBUS = new NhanVienBUS();

            string actual = nhanVienBUS.GetInfomationNhanVien(db, "1234567890", out nhanVienDTO);
            string expected = "1111";

            Assert.Equals(actual, expected);
        }

        [TestMethod]
        public void GetList_TestCase1()
        {
            // create data search
            db.NHANVIENs.Add(new NHANVIEN { MaNV = "1234567890" });
            db.NHANVIENs.Add(new NHANVIEN { MaNV = "1234567891" });
            db.NHANVIENs.Add(new NHANVIEN { MaNV = "1234567892" });

            List<NhanVienDTO> listNhanVien = null;
            NhanVienBUS nhanVienBUS = new NhanVienBUS();

            string actual = nhanVienBUS.GetListNhanVien(db, out listNhanVien);
            string expected = "0000";

            Assert.Equals(actual, expected);
        }
        [TestMethod]
        public void GetList_TestCase2()
        {
            

            List<NhanVienDTO> listNhanVien = null;
            NhanVienBUS nhanVienBUS = new NhanVienBUS();

            string actual = nhanVienBUS.GetListNhanVien(db, out listNhanVien);
            string expected = "0000";

            Assert.Equals(actual, expected);
        }
        /* END TEST METHOD */

        //clean method
        [TestCleanup]
        public void Clear()
        {
            trans.Rollback();
            trans.Dispose();
            db.Dispose();
        }

    }
}
