using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DAO.Implement;
using System.Data.Entity;

namespace UnitTest.DAO
{
    [TestClass]
    public class TestTrangThaiPhongDAO
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
            TRANGTHAIPHONG trangThaiPhong = new TRANGTHAIPHONG
            {
                MaPhong = TestCommon.LEN_10,
                NgayKham = TestCommon.LEN_8,
                SttCaoNhat = 1,
            };
            TrangThaiPhongDAO dao = new TrangThaiPhongDAO();
            string actual = dao.Save(db, trangThaiPhong);
            string expected = "0000";
            Assert.Equals(expected, actual);
        }
        // Test insert NgayKham or MaPhong is null
        [TestMethod]
        public void Insert_TestCase2()
        {
            TRANGTHAIPHONG trangThaiPhong = new TRANGTHAIPHONG
            {
                SttCaoNhat = 1,
            };
            TrangThaiPhongDAO dao = new TrangThaiPhongDAO();
            string actual = dao.Save(db, trangThaiPhong);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test insert max lenght string
        [TestMethod]
        public void Insert_TestCase3()
        {
            TRANGTHAIPHONG trangThaiPhong = new TRANGTHAIPHONG
            {
                MaPhong = TestCommon.LEN_10 + "1",
                NgayKham = TestCommon.LEN_8 + "1",
                SttCaoNhat = 1,
            };
            TrangThaiPhongDAO dao = new TrangThaiPhongDAO();
            string actual = dao.Save(db, trangThaiPhong);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test insert MaPhong doesn't exist in table PHONG
        [TestMethod]
        public void Insert_TestCase4()
        {
            TRANGTHAIPHONG trangThaiPhong = new TRANGTHAIPHONG
            {
                MaPhong = "123",
                NgayKham = TestCommon.LEN_8,
                SttCaoNhat = 1,
            };
            TrangThaiPhongDAO dao = new TrangThaiPhongDAO();
            string actual = dao.Save(db, trangThaiPhong);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }


        // Test update success
        [TestMethod]
        public void Update_TestCase5()
        {
            TrangThaiPhongDAO dao = new TrangThaiPhongDAO();
            TRANGTHAIPHONG trangThaiPhong = new TRANGTHAIPHONG
            {
                MaPhong = TestCommon.LEN_10,
                NgayKham = TestCommon.LEN_8,
                SttCaoNhat = 1,

            };
            dao.Save(db, trangThaiPhong);
            TRANGTHAIPHONG trangThaiPhongUpdate = new TRANGTHAIPHONG
            {
                MaPhong = TestCommon.LEN_10,
                NgayKham = TestCommon.LEN_8,
                SttCaoNhat = 2,
            };
            string actual = dao.Save(db, trangThaiPhongUpdate);
            // Biến kết quả
            string expected = "0000";
            // Test 
            Assert.Equals(expected, actual);
        }

        // Test update NgayKham or MaPhong is null
        [TestMethod]
        public void Update_TestCase6()
        {
            TrangThaiPhongDAO dao = new TrangThaiPhongDAO();
            TRANGTHAIPHONG trangThaiPhong = new TRANGTHAIPHONG
            {
                MaPhong = TestCommon.LEN_10,
                NgayKham = TestCommon.LEN_8,
                SttCaoNhat = 1,

            };
            dao.Save(db, trangThaiPhong);
            TRANGTHAIPHONG trangThaiPhongUpdate = new TRANGTHAIPHONG
            {
                SttCaoNhat = 2,
            };
            string actual = dao.Save(db, trangThaiPhongUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }
        // Test update max lenght string
        [TestMethod]
        public void Update_TestCase7()
        {
            TrangThaiPhongDAO dao = new TrangThaiPhongDAO();
            TRANGTHAIPHONG trangThaiPhong = new TRANGTHAIPHONG
            {
                MaPhong = TestCommon.LEN_10,
                NgayKham = TestCommon.LEN_8,
                SttCaoNhat = 1,

            };
            dao.Save(db, trangThaiPhong);
            TRANGTHAIPHONG trangThaiPhongUpdate = new TRANGTHAIPHONG
            {
                MaPhong = TestCommon.LEN_10 + "1",
                NgayKham = TestCommon.LEN_8 + "1",
                SttCaoNhat = 2,
            };
            string actual = dao.Save(db, trangThaiPhongUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }
        // Test update MaPhong doesn't exist in table PHONG
        [TestMethod]
        public void Update_TestCase8()
        {
            TrangThaiPhongDAO dao = new TrangThaiPhongDAO();
            TRANGTHAIPHONG trangThaiPhong = new TRANGTHAIPHONG
            {
                MaPhong = TestCommon.LEN_10,
                NgayKham = TestCommon.LEN_8,
                SttCaoNhat = 1,

            };
            dao.Save(db, trangThaiPhong);
            TRANGTHAIPHONG trangThaiPhongUpdate = new TRANGTHAIPHONG
            {
                MaPhong = "1234",
                NgayKham = TestCommon.LEN_8,
                SttCaoNhat = 2,
            };
            string actual = dao.Save(db, trangThaiPhongUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }


        // Test delete sucesses
        [TestMethod]
        public void Delete_TestCase9()
        {
            TRANGTHAIPHONG trangThaiPhong = new TRANGTHAIPHONG
            {
                MaPhong = TestCommon.LEN_10,
                NgayKham = TestCommon.LEN_8,
                SttCaoNhat = 1,
            };
            TrangThaiPhongDAO dao = new TrangThaiPhongDAO();
            string actual = dao.Save(db, trangThaiPhong);
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
