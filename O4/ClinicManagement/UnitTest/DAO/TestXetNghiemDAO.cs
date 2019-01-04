using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DAO.Implement;
using System.Data.Entity;

namespace UnitTest.DAO
{
    [TestClass]
    public class TestXetNghiemDAO
    {
        private static QLPHONGKHAMEntities db;
        private static DbContextTransaction trans;
        // init method
        [TestInitialize]
        public void Init()
        {
            db = new QLPHONGKHAMEntities();
            trans = db.Database.BeginTransaction();
            db.PHONGs.Add(new PHONG { MaPhong = TestCommon.LEN_10 });
        }

        /* BEGIN TEST METHOD */

        // Test insert data sucesses
        [TestMethod]
        public void Insert_TestCase1()
        {
            XETNGHIEM xetNghiem = new XETNGHIEM
            {
                MaXetNghiem = TestCommon.LEN_10,
                TenXetNghiem = TestCommon.LEN_50,
                MaPhong = TestCommon.LEN_10,
                ChiPhi = 100
            };
            XetNghiemDAO dao = new XetNghiemDAO();
            string actual = dao.Save(db, xetNghiem);
            string expected = "0000";
            Assert.AreEqual(expected, actual);
        }

        // Test insert max - length string
        [TestMethod]
        public void Insert_TestCase3()
        {
            XETNGHIEM xetNghiem = new XETNGHIEM
            {
                MaXetNghiem = TestCommon.LEN_10,
                TenXetNghiem = TestCommon.LEN_50 + "1",
                MaPhong = TestCommon.LEN_10,
                ChiPhi = 1000000000000
            };
            XetNghiemDAO dao = new XetNghiemDAO();
            string actual = dao.Save(db, xetNghiem);
            string expected = "0000";
            Assert.AreEqual(expected, actual);
        }


        // Test insert MaPhong not found in table PHONG
        [TestMethod]
        public void Insert_TestCase4()
        {
            XETNGHIEM xetNghiem = new XETNGHIEM
            {
                MaXetNghiem = TestCommon.LEN_10,
                TenXetNghiem = TestCommon.LEN_50 + "1",
                MaPhong = TestCommon.LEN_10,
                ChiPhi = 1000000000000
            };
            XetNghiemDAO dao = new XetNghiemDAO();
            string actual = dao.Save(db, xetNghiem);
            string expected = "0000";
            Assert.AreEqual(expected, actual);
        }

        // Test update success
        [TestMethod]
        public void Update_TestCase5()
        {
            XetNghiemDAO dao = new XetNghiemDAO();
            XETNGHIEM xetNghiem = new XETNGHIEM
            {
                MaXetNghiem = TestCommon.LEN_10,
                TenXetNghiem = "TEST UT",
                MaPhong = TestCommon.LEN_10
                
            };
            dao.Save(db, xetNghiem);
            XETNGHIEM xetNghiemUpdate = new XETNGHIEM
            {
                MaXetNghiem = TestCommon.LEN_10,
                TenXetNghiem = "TEST UT UPDATE",
                MaPhong = TestCommon.LEN_10
            };
            string actual = dao.Save(db, xetNghiemUpdate);
            // Biến kết quả
            string expected = "0000";
            // Test 
            Assert.AreEqual(expected, actual);
        }

        // Test update with MaPhong doesn't exist in table PHONG
        [TestMethod]
        public void Update_TestCase7()
        {
            XetNghiemDAO dao = new XetNghiemDAO();
            XETNGHIEM xetNghiem = new XETNGHIEM
            {
                MaXetNghiem = TestCommon.LEN_10,
                TenXetNghiem = "TEST UT",
                MaPhong = TestCommon.LEN_10

            };
            dao.Save(db, xetNghiem);
            XETNGHIEM xetNghiemUpdate = new XETNGHIEM
            {
                MaXetNghiem = TestCommon.LEN_10,
                TenXetNghiem = "TEST UT",
                MaPhong = "123"
            };
            string actual = dao.Save(db, xetNghiemUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.AreEqual(expected, actual);
        }


        // Test update max-lenght
        [TestMethod]
        public void Update_TestCase8()
        {
            XetNghiemDAO dao = new XetNghiemDAO();
            XETNGHIEM xetNghiem = new XETNGHIEM
            {
                MaXetNghiem = TestCommon.LEN_10,
                TenXetNghiem = "TEST UT",
                MaPhong = TestCommon.LEN_10,
                ChiPhi = 10000
            };
            dao.Save(db, xetNghiem);
            XETNGHIEM xetNghiemUpdate = new XETNGHIEM
            {
                MaXetNghiem = TestCommon.LEN_10,
                TenXetNghiem = TestCommon.LEN_250 + "1",
                MaPhong = TestCommon.LEN_10,
                ChiPhi = 1000000000000
            };
            string actual = dao.Save(db, xetNghiemUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.AreEqual(expected, actual);
        }


        // Test delete sucesses
        [TestMethod]
        public void Delete_TestCase9()
        {
            XETNGHIEM xetNghiem = new XETNGHIEM
            {
                MaXetNghiem = TestCommon.LEN_10,
                TenXetNghiem = "abc",
                MaPhong = TestCommon.LEN_10
            };
            XetNghiemDAO dao = new XetNghiemDAO();
            dao.Save(db, xetNghiem);
            string actual = dao.Delete(db, xetNghiem);
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
