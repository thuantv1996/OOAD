using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DAO.Implement;
using System.Data.Entity;


namespace UnitTest.DAO
{
    [TestClass]
    public class TestChiTietDonThuocDAO
    {
        private static QLPHONGKHAMEntities db;
        private static DbContextTransaction trans;
        // init method
        [TestInitialize]
        public void Init()
        {
            db = new QLPHONGKHAMEntities();
            trans = db.Database.BeginTransaction();
            db.DONTHUOCs.Add(new DONTHUOC { MaDonThuoc = TestCommon.LEN_10 });
            db.THUOCs.Add(new THUOC { MaThuoc = TestCommon.LEN_10 });
        }

        /* BEGIN TEST METHOD */

        // Test insert data sucesses
        [TestMethod]
        public void Insert_TestCase1()
        {
            CHITIETDONTHUOC chiTietDonThuoc = new CHITIETDONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaThuoc = TestCommon.LEN_10,
                SoLuong = 10,
                GhiChu = TestCommon.LEN_250
            };
            ChiTietDonThuocDAO dao = new ChiTietDonThuocDAO();
            string actual = dao.Save(db, chiTietDonThuoc);
            string expected = "0000";
            Assert.AreEqual(expected, actual);
        }

        

        // Test insert max - length string
        [TestMethod]
        public void Insert_TestCase2()
        {
            CHITIETDONTHUOC chiTietDonThuoc = new CHITIETDONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10 + "1",
                MaThuoc = TestCommon.LEN_10 + "1",
                SoLuong = 10,
                GhiChu = TestCommon.LEN_250 + "1"
            };
            ChiTietDonThuocDAO dao = new ChiTietDonThuocDAO();
            string actual = dao.Save(db, chiTietDonThuoc);
            string expected = "1111";
            Assert.AreEqual(expected, actual);
        }

        // Test insert MaDonThuoc, MaThuoc not found in table
        [TestMethod]
        public void Insert_TestCase3()
        {
            CHITIETDONTHUOC chiTietDonThuoc = new CHITIETDONTHUOC
            {
                MaDonThuoc = "123",
                MaThuoc = "123",
            };
            ChiTietDonThuocDAO dao = new ChiTietDonThuocDAO();
            string actual = dao.Save(db, chiTietDonThuoc);
            string expected = "1111";
            Assert.AreEqual(expected, actual);
        }

        // Test insert MaDonThuoc, MaThuoc is null
        [TestMethod]
        public void Insert_TestCase4()
        {
            CHITIETDONTHUOC chiTietDonThuoc = new CHITIETDONTHUOC{};
            ChiTietDonThuocDAO dao = new ChiTietDonThuocDAO();
            string actual = dao.Save(db, chiTietDonThuoc);
            string expected = "1111";
            Assert.AreEqual(expected, actual);
        }

        // Test insert SoLuong is negative
        [TestMethod]
        public void Insert_TestCase5()
        {
            CHITIETDONTHUOC chiTietDonThuoc = new CHITIETDONTHUOC
            {
                MaDonThuoc = "123",
                MaThuoc = "123",
                SoLuong = -1,
            };
            ChiTietDonThuocDAO dao = new ChiTietDonThuocDAO();
            string actual = dao.Save(db, chiTietDonThuoc);
            string expected = "1111";
            Assert.AreEqual(expected, actual);
        }

        // Test update success
        [TestMethod]
        public void Update_TestCase6()
        {
            ChiTietDonThuocDAO dao = new ChiTietDonThuocDAO();
            CHITIETDONTHUOC chiTietDonThuoc = new CHITIETDONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaThuoc = TestCommon.LEN_10,
                SoLuong = 10,
                GhiChu = TestCommon.LEN_250

            };
            dao.Save(db, chiTietDonThuoc);
            CHITIETDONTHUOC chiTietDonThuocUpdate = new CHITIETDONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaThuoc = TestCommon.LEN_10,
                SoLuong = 123,
                GhiChu = "abc"
            };
            string actual = dao.Save(db, chiTietDonThuocUpdate);
            // Biến kết quả
            string expected = "0000";
            // Test 
            Assert.AreEqual(expected, actual);
        }

        // Test update with MaDonThuoc, MaThuoc is null
        [TestMethod]
        public void Update_TestCase7()
        {
            ChiTietDonThuocDAO dao = new ChiTietDonThuocDAO();
            CHITIETDONTHUOC chiTietDonThuoc = new CHITIETDONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaThuoc = TestCommon.LEN_10,
            };
            dao.Save(db, chiTietDonThuoc);
            CHITIETDONTHUOC chiTietDonThuocUpdate = new CHITIETDONTHUOC {};
            string actual = dao.Save(db, chiTietDonThuocUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.AreEqual(expected, actual);
        }

        // Test update with MaDonThuoc, MaThuoc doesn't exist in table
        [TestMethod]
        public void Update_TestCase8()
        {
            ChiTietDonThuocDAO dao = new ChiTietDonThuocDAO();
            CHITIETDONTHUOC chiTietDonThuoc = new CHITIETDONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaThuoc = TestCommon.LEN_10,
                SoLuong = 10,
                GhiChu = TestCommon.LEN_250

            };
            dao.Save(db, chiTietDonThuoc);
            CHITIETDONTHUOC chiTietDonThuocUpdate = new CHITIETDONTHUOC
            {
                MaDonThuoc = "TEST UPDATE",
                MaThuoc = "TEST UPDATE",
                SoLuong = 123,
                GhiChu = "abc"
            };
            string actual = dao.Save(db, chiTietDonThuocUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.AreEqual(expected, actual);
        }

        // Test update max-lenght
        [TestMethod]
        public void Update_TestCase9()
        {
            ChiTietDonThuocDAO dao = new ChiTietDonThuocDAO();
            CHITIETDONTHUOC chiTietDonThuoc = new CHITIETDONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaThuoc = TestCommon.LEN_10,
                SoLuong = 10,
                GhiChu = TestCommon.LEN_250

            };
            dao.Save(db, chiTietDonThuoc);
            CHITIETDONTHUOC chiTietDonThuocUpdate = new CHITIETDONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10 + "1",
                MaThuoc = TestCommon.LEN_10 + "1",
                SoLuong = 123,
                GhiChu = "abc"
            };
            string actual = dao.Save(db, chiTietDonThuocUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.AreEqual(expected, actual);
        }

        // Test update SoLuong is negative
        [TestMethod]
        public void Update_TestCase10()
        {
            ChiTietDonThuocDAO dao = new ChiTietDonThuocDAO();
            CHITIETDONTHUOC chiTietDonThuoc = new CHITIETDONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaThuoc = TestCommon.LEN_10,
                SoLuong = 10,
                GhiChu = TestCommon.LEN_250

            };
            dao.Save(db, chiTietDonThuoc);
            CHITIETDONTHUOC chiTietDonThuocUpdate = new CHITIETDONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaThuoc = TestCommon.LEN_10,
                SoLuong = -10,
                GhiChu = "abc"
            };
            string actual = dao.Save(db, chiTietDonThuocUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.AreEqual(expected, actual);
        }

        // Test delete sucesses
        [TestMethod]
        public void Delete_TestCase11()
        {
            CHITIETDONTHUOC chiTietDonThuoc = new CHITIETDONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaThuoc = TestCommon.LEN_10,
                SoLuong = 123,
                GhiChu = "abc"
            };
            ChiTietDonThuocDAO dao = new ChiTietDonThuocDAO();
            dao.Save(db, chiTietDonThuoc);
            string actual = dao.Delete(db, chiTietDonThuoc);
            string expected = "0000";
            Assert.AreEqual(expected, actual);
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
