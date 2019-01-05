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
    public class TestChiTietDonThuocBUS
    {
        private static QLPHONGKHAMEntities db;
        private static DbContextTransaction trans;
        //init method
        [TestInitialize]
        public void Init()
        {
            db = new QLPHONGKHAMEntities();
            trans = db.Database.BeginTransaction();
            db.DONTHUOCs.Add(new DONTHUOC { MaDonThuoc = TestCommon.LEN_10 });
            db.THUOCs.Add(new THUOC { MaThuoc = TestCommon.LEN_10 });
        }

        // Test insert data sucesses
        [TestMethod]
        public void Save_TestCase1()
        {
            ChiTietDonThuocDTO chiTietDonThuocDTO = new ChiTietDonThuocDTO
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaThuoc = TestCommon.LEN_10,
                SoLuong = 10,
                GhiChu = TestCommon.LEN_250
            };

            ChiTietDonThuocBUS chiTietDonThuocBUS = new ChiTietDonThuocBUS();

            // execute
            string actual = chiTietDonThuocBUS.SaveChiTietDonThuoc(db, chiTietDonThuocDTO);
            string expected = "0000";

            // compare
            Assert.Equals(actual, expected);

        }

        // Test insert max - length string
        [TestMethod]
        public void Save_TestCase2()
        {
            ChiTietDonThuocDTO chiTietDonThuocDTO = new ChiTietDonThuocDTO
            {
                MaDonThuoc = TestCommon.LEN_10 + "1",
                MaThuoc = TestCommon.LEN_10 + "1",
                SoLuong = 10,
                GhiChu = TestCommon.LEN_250 + "1"
            };

            ChiTietDonThuocBUS chiTietDonThuocBUS = new ChiTietDonThuocBUS();

            // execute
            string actual = chiTietDonThuocBUS.SaveChiTietDonThuoc(db, chiTietDonThuocDTO);
            string expected = "1111";

            // compare
            Assert.Equals(actual, expected);
        }

        // Test insert MaDonThuoc, MaThuoc not found in table
        [TestMethod]
        public void Save_TestCase3()
        {
            ChiTietDonThuocDTO chiTietDonThuocDTO = new ChiTietDonThuocDTO
            {
                MaDonThuoc = "123",
                MaThuoc = "123"
            };

            ChiTietDonThuocBUS chiTietDonThuocBUS = new ChiTietDonThuocBUS();

            // execute
            string actual = chiTietDonThuocBUS.SaveChiTietDonThuoc(db, chiTietDonThuocDTO);
            string expected = "1111";

            // compare
            Assert.Equals(actual, expected);
        }

        // Test insert MaDonThuoc, MaThuoc is null
        [TestMethod]
        public void Save_TestCase4()
        {
            ChiTietDonThuocDTO chiTietDonThuocDTO = new ChiTietDonThuocDTO { };
            ChiTietDonThuocBUS chiTietDonThuocBUS = new ChiTietDonThuocBUS();

            // execute
            string actual = chiTietDonThuocBUS.SaveChiTietDonThuoc(db, chiTietDonThuocDTO);
            string expected = "1111";

            // compare
            Assert.Equals(actual, expected);
        }

        // Test insert SoLuong is negative
        [TestMethod]
        public void Save_TestCase5()
        {
            ChiTietDonThuocDTO chiTietDonThuocDTO = new ChiTietDonThuocDTO
            {
                MaDonThuoc = "123",
                MaThuoc = "123",
                SoLuong = -1,
            };

            ChiTietDonThuocBUS chiTietDonThuocBUS = new ChiTietDonThuocBUS();

            // execute
            string actual = chiTietDonThuocBUS.SaveChiTietDonThuoc(db, chiTietDonThuocDTO);
            string expected = "1111";

            // compare
            Assert.Equals(actual, expected);

        }
        // Test update success
        [TestMethod]
        public void Update_TestCase1()
        {
            // insert chi tiet don thuoc moi
            ChiTietDonThuocDTO chiTietDonThuocDTO = new ChiTietDonThuocDTO
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaThuoc = TestCommon.LEN_10,
                SoLuong = 10,
                GhiChu = TestCommon.LEN_250
            };

            ChiTietDonThuocBUS chiTietDonThuocBUS = new ChiTietDonThuocBUS();

            chiTietDonThuocBUS.SaveChiTietDonThuoc(db, chiTietDonThuocDTO);
            //Update chi tiet don thuoc
            CHITIETDONTHUOC chiTietDonThuocUpdate = new CHITIETDONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaThuoc = TestCommon.LEN_10,
                SoLuong = 123,
                GhiChu = "abc"
            };

            // execute
            string actual = chiTietDonThuocBUS.SaveChiTietDonThuoc(db, chiTietDonThuocDTO);
            string expected = "0000";

            // compare
            Assert.Equals(expected, actual);
        }
        // Test update with MaDonThuoc, MaThuoc is null
        [TestMethod]
        public void Update_TestCase2()
        {
            // insert chi tiet don thuoc moi
            ChiTietDonThuocDTO chiTietDonThuocDTO = new ChiTietDonThuocDTO
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaThuoc = TestCommon.LEN_10,

            };

            ChiTietDonThuocBUS chiTietDonThuocBUS = new ChiTietDonThuocBUS();

            chiTietDonThuocBUS.SaveChiTietDonThuoc(db, chiTietDonThuocDTO);
            //Update chi tiet don thuoc
            CHITIETDONTHUOC chiTietDonThuocUpdate = new CHITIETDONTHUOC { };

            // execute
            string actual = chiTietDonThuocBUS.SaveChiTietDonThuoc(db, chiTietDonThuocDTO);
            string expected = "1111";

            // compare
            Assert.Equals(expected, actual);
        }
        // Test update with MaDonThuoc, MaThuoc doesn't exist in table
        [TestMethod]
        public void Update_TestCase3()
        {
            // insert chi tiet don thuoc moi
            ChiTietDonThuocDTO chiTietDonThuocDTO = new ChiTietDonThuocDTO
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaThuoc = TestCommon.LEN_10,
                SoLuong = 10,
                GhiChu = TestCommon.LEN_250

            };

            ChiTietDonThuocBUS chiTietDonThuocBUS = new ChiTietDonThuocBUS();

            chiTietDonThuocBUS.SaveChiTietDonThuoc(db, chiTietDonThuocDTO);
            //Update chi tiet don thuoc
            CHITIETDONTHUOC chiTietDonThuocUpdate = new CHITIETDONTHUOC
            {
                MaDonThuoc = "TEST UPDATE",
                MaThuoc = "TEST UPDATE",
                SoLuong = 123,
                GhiChu = "abc"
            };

            // execute
            string actual = chiTietDonThuocBUS.SaveChiTietDonThuoc(db, chiTietDonThuocDTO);
            string expected = "1111";

            // compare
            Assert.Equals(expected, actual);
        }
        // Test update max-lenght
        [TestMethod]
        public void Update_TestCase4()
        {
            // insert chi tiet don thuoc moi
            ChiTietDonThuocDTO chiTietDonThuocDTO = new ChiTietDonThuocDTO
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaThuoc = TestCommon.LEN_10,
                SoLuong = 10,
                GhiChu = TestCommon.LEN_250

            };

            ChiTietDonThuocBUS chiTietDonThuocBUS = new ChiTietDonThuocBUS();

            chiTietDonThuocBUS.SaveChiTietDonThuoc(db, chiTietDonThuocDTO);
            //Update chi tiet don thuoc
            CHITIETDONTHUOC chiTietDonThuocUpdate = new CHITIETDONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10 + "1",
                MaThuoc = TestCommon.LEN_10 + "1",
                SoLuong = 123,
                GhiChu = "abc"
            };

            // execute
            string actual = chiTietDonThuocBUS.SaveChiTietDonThuoc(db, chiTietDonThuocDTO);
            string expected = "1111";

            // compare
            Assert.Equals(expected, actual);
        }
        // Test update SoLuong is negative
        [TestMethod]
        public void Update_TestCase5()
        {
            // insert chi tiet don thuoc moi
            ChiTietDonThuocDTO chiTietDonThuocDTO = new ChiTietDonThuocDTO
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaThuoc = TestCommon.LEN_10,
                SoLuong = 10,
                GhiChu = TestCommon.LEN_250

            };

            ChiTietDonThuocBUS chiTietDonThuocBUS = new ChiTietDonThuocBUS();

            chiTietDonThuocBUS.SaveChiTietDonThuoc(db, chiTietDonThuocDTO);
            //Update chi tiet don thuoc
            CHITIETDONTHUOC chiTietDonThuocUpdate = new CHITIETDONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaThuoc = TestCommon.LEN_10,
                SoLuong = -10,
                GhiChu = "abc"
            };
            // execute
            string actual = chiTietDonThuocBUS.SaveChiTietDonThuoc(db, chiTietDonThuocDTO);
            string expected = "1111";
            // compare
            Assert.Equals(expected, actual);
        }

        // Test delete sucesses
        [TestMethod]
        public void Delete_TestCase1()
        {

            ChiTietDonThuocDTO chiTietDonThuocDTO = new ChiTietDonThuocDTO
            {
                MaDonThuoc = TestCommon.LEN_10 + "1",
                MaThuoc = TestCommon.LEN_10 + "1",
                SoLuong = 123,
                GhiChu = "abc"

            };
            ChiTietDonThuocBUS chiTietDonThuocBUS = new ChiTietDonThuocBUS();
            // execute
            string actual = chiTietDonThuocBUS.SaveChiTietDonThuoc(db, chiTietDonThuocDTO);
            // compare
            Assert.Equals(null, actual);
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
