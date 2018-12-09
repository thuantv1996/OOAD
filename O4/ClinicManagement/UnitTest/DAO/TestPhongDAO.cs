using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DAO.Implement;
using System.Data.Entity;

namespace UnitTest.DAO
{
    [TestClass]
    public class TestPhongDAO
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
        [TestMethod]
        // Test insert data sucesses
        public void Insert_TestCase1()
        {
            PHONG phong = new PHONG
            {
                MaPhong = TestCommon.LEN_10,
                TenPhong = TestCommon.LEN_50,
                ChuyenKhoa = TestCommon.LEN_250,
                GhiChu = TestCommon.LEN_250
            };
            PhongDAO dao = new PhongDAO();
            string actual = dao.Save(db, phong);
            string expected = "0000";
            Assert.Equals(expected, actual);
        }

        // Test insert with TenPhong is null
        [TestMethod]
        public void Insert_TestCase2()
        {
            PHONG phong = new PHONG { MaPhong = TestCommon.LEN_10 };
            PhongDAO dao = new PhongDAO();
            string actual = dao.Save(db, phong);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test insert max - length string
        [TestMethod]
        public void Insert_TestCase3()
        {
            PHONG phong = new PHONG
            {
                MaPhong = TestCommon.LEN_10,
                TenPhong = TestCommon.LEN_50 + "1",
                ChuyenKhoa = TestCommon.LEN_250 + "1",
                GhiChu = TestCommon.LEN_250 + "1"
            };
            PhongDAO dao = new PhongDAO();
            string actual = dao.Save(db, phong);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test update data sucesses
        [TestMethod]
        public void Update_TestCase4()
        {
            // Khởi tạo dao
            PhongDAO dao = new PhongDAO();
            PHONG phong = new PHONG
            {
                MaPhong = TestCommon.LEN_10,
                TenPhong = TestCommon.LEN_50 + "1",
            };
            dao.Save(db, phong);
            PHONG phongUpdate = new PHONG
            {
                MaPhong = TestCommon.LEN_10,
                TenPhong = "TEST UT UPDATE"
            };
            string actual = dao.Save(db, phongUpdate);
            // Biến kết quả
            string expected = "0000";
            // Test 
            Assert.Equals(expected, actual);
        }

        // Test update without TenPhong
        [TestMethod]
        public void Update_TestCase5()
        {
            PhongDAO dao = new PhongDAO();
            PHONG phong = new PHONG
            {
                MaPhong = TestCommon.LEN_10,
                TenPhong = TestCommon.LEN_50,
            };
            dao.Save(db, phong);
            PHONG phongUpdate = new PHONG
            {
                MaPhong = TestCommon.LEN_10,
            };
            string actual = dao.Save(db, phongUpdate);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test update max length
        [TestMethod]
        public void Update_TestCase7()
        {
            PhongDAO dao = new PhongDAO();
            PHONG phong = new PHONG
            {
                MaPhong = TestCommon.LEN_10,
                TenPhong = TestCommon.LEN_50,
            };
            dao.Save(db, phong);
            PHONG phongUpdate = new PHONG
            {
                MaPhong = TestCommon.LEN_10,
                TenPhong = TestCommon.LEN_50 + "1",
                ChuyenKhoa = TestCommon.LEN_250 + "1",
                GhiChu = TestCommon.LEN_250 + "1"
            };
            string actual = dao.Save(db, phongUpdate);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test delete sucesses
        [TestMethod]
        public void Delete_TestCase9()
        {
            PHONG phong = new PHONG
            {
                MaPhong = TestCommon.LEN_10,
                TenPhong = "abc",
            };
            PhongDAO dao = new PhongDAO();
            string actual = dao.Save(db, phong);
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
