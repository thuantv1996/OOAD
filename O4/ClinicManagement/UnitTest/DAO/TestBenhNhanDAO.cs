using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DAO.Implement;
using System.Data.Entity;

namespace UnitTest.DAO
{
    [TestClass]
    public class TestBenhNhanDAO
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

        /* BEGIN TEST METHOD */

        // Test insert data sucesses
        [TestMethod]
        public void Insert_TestCase1()
        {
            BENHNHAN benhNhan = new BENHNHAN
            {
                MaBenhNhan = TestCommon.LEN_10,
                HoTen = TestCommon.LEN_50,
                CMND = "123456789012",
                NgaySinh = TestCommon.LEN_8,
                GioiTinh = true,
                SoDienThoai = "1235678901",
                DiaChi = TestCommon.LEN_250,
                GhiChu = TestCommon.LEN_250
            };
            BenhNhanDAO dao = new BenhNhanDAO();
            string actual = dao.Save(db, benhNhan);
            string expected = "0000";
            Assert.AreEqual(expected, actual);
        }

        // Test insert max length
        [TestMethod]
        public void Insert_TestCase2()
        {
            BENHNHAN benhNhan = new BENHNHAN
            {
                MaBenhNhan = TestCommon.LEN_10 + "1",
                HoTen = TestCommon.LEN_50 + "1",
                CMND = "1234567890121",
                NgaySinh = TestCommon.LEN_8 + "1",
                GioiTinh = true,
                SoDienThoai = "12356789011",
                DiaChi = TestCommon.LEN_250 + "1",
                GhiChu = TestCommon.LEN_250 + "1"
            };
            BenhNhanDAO dao = new BenhNhanDAO();
            string actual = dao.Save(db, benhNhan);
            string expected = "1111";
            Assert.AreEqual(expected, actual);
        }

        // Test insert HoTen is null
        [TestMethod]
        public void Insert_TestCase3()
        {
            BENHNHAN benhNhan = new BENHNHAN
            {
                MaBenhNhan = TestCommon.LEN_10,
            };
            BenhNhanDAO dao = new BenhNhanDAO();
            string actual = dao.Save(db, benhNhan);
            string expected = "1111";
            Assert.AreEqual(expected, actual);
        }

        // Test update success
        [TestMethod]
        public void Update_TestCase5()
        {
            BenhNhanDAO dao = new BenhNhanDAO();
            BENHNHAN benhNhan = new BENHNHAN
            {
                MaBenhNhan = TestCommon.LEN_10,
                HoTen = TestCommon.LEN_50,
                CMND = "123456789012",
            };
            dao.Save(db, benhNhan);
            BENHNHAN benhNhanUpdate = new BENHNHAN
            {
                MaBenhNhan = TestCommon.LEN_10,
                HoTen = "TEST UPDATE",
                CMND = "123456789012",
            };
            string actual = dao.Save(db, benhNhanUpdate);
            // Biến kết quả
            string expected = "0000";
            // Test 
            Assert.AreEqual(expected, actual);
        }

        // Test update max length
        [TestMethod]
        public void Update_TestCase6()
        {
            BenhNhanDAO dao = new BenhNhanDAO();
            BENHNHAN benhNhan = new BENHNHAN
            {
                MaBenhNhan = TestCommon.LEN_10,
                HoTen = TestCommon.LEN_50,
                CMND = "123456789012",
            };
            dao.Save(db, benhNhan);
            BENHNHAN benhNhanUpdate = new BENHNHAN
            {
                MaBenhNhan = TestCommon.LEN_10 + "1",
                HoTen = TestCommon.LEN_50 + "1",
                CMND = "1234567890121",
            };
            string actual = dao.Save(db, benhNhanUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.AreEqual(expected, actual);
        }
        // Test update with HoTen is null
        [TestMethod]
        public void Update_TestCase7()
        {
            BenhNhanDAO dao = new BenhNhanDAO();
            BENHNHAN benhNhan = new BENHNHAN
            {
                MaBenhNhan = TestCommon.LEN_10,
                HoTen = TestCommon.LEN_50,
                CMND = "123456789012",
            };
            dao.Save(db, benhNhan);
            BENHNHAN benhNhanUpdate = new BENHNHAN
            {
                MaBenhNhan = TestCommon.LEN_10,
            };
            string actual = dao.Save(db, benhNhanUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.AreEqual(expected, actual);
        }

        // Test delete sucesses
        [TestMethod]
        public void Delete_TestCase8()
        {
            BENHNHAN benhNhan = new BENHNHAN
            {
                MaBenhNhan = TestCommon.LEN_10,
                HoTen = TestCommon.LEN_50,
                CMND = "123456789012",
            };
            BenhNhanDAO dao = new BenhNhanDAO();
            dao.Save(db, benhNhan);
            string actual = dao.Delete(db, benhNhan);
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
