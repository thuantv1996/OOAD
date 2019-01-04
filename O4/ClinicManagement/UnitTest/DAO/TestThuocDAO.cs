using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DAO.Implement;
using System.Data.Entity;

namespace UnitTest.DAO
{
    [TestClass]
    public class TestThuocDAO
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
            THUOC thuoc = new THUOC
            {
                MaThuoc = TestCommon.LEN_10,
                TenThuoc = TestCommon.LEN_50,
                ChiDinh = TestCommon.LEN_250,
                ChongChiDinh = TestCommon.LEN_250
            };
            ThuocDAO dao = new ThuocDAO();
            string actual = dao.Save(db, thuoc);
            string expected = "0000";
            Assert.AreEqual(expected, actual);
        }

        // Test insert max - length string
        [TestMethod]
        public void Insert_TestCase3()
        {
            THUOC thuoc = new THUOC
            {
                MaThuoc = TestCommon.LEN_10,
                TenThuoc = TestCommon.LEN_50 + "11",
                ChiDinh = TestCommon.LEN_250 + "11",
                ChongChiDinh = TestCommon.LEN_250 + "11"
            };
            ThuocDAO dao = new ThuocDAO();
            string actual = dao.Save(db, thuoc);
            string expected = "1111";
            Assert.AreEqual(expected, actual);
        }

        // Test update data sucesses
        [TestMethod]
        public void Update_TestCase4()
        {
            // Khởi tạo dao
            ThuocDAO dao = new ThuocDAO();
            // Insert một thuốc mới
            THUOC thuoc = new THUOC
            {
                MaThuoc = TestCommon.LEN_10,
                TenThuoc = "TEST UT"
            };
            dao.Save(db, thuoc);
            // Update thuốc 
            THUOC thuocUpdate = new THUOC
            {
                MaThuoc = TestCommon.LEN_10,
                TenThuoc = "TEST UT UPDATE"
            };
            // Tạo biến lưu thông tin thuốc update
            string actual = dao.Save(db, thuocUpdate);
            // Biến kết quả
            string expected = "0000";
            // Test 
            Assert.AreEqual(expected, actual);
        }

        // Test update without TenThuoc
        [TestMethod]
        public void Update_TestCase5()
        {
            // Khởi tạo dao
            ThuocDAO dao = new ThuocDAO();
            // Insert một thuốc mới
            THUOC thuoc = new THUOC
            {
                MaThuoc = TestCommon.LEN_10,
                TenThuoc = "TEST UT"
            };
            dao.Save(db, thuoc);
            // Update thuốc 
            THUOC thuocUpdate = new THUOC
            {
                MaThuoc = TestCommon.LEN_10,
            };
            // Tạo biến lưu thông tin thuốc update
            string actual = dao.Save(db, thuocUpdate);
            string expected = "0000";
            Assert.AreEqual(expected, actual);
        }

        // Test update max length
        [TestMethod]
        public void Update_TestCase6()
        {
            ThuocDAO dao = new ThuocDAO();
            THUOC thuoc = new THUOC
            {
                MaThuoc = TestCommon.LEN_10,
                TenThuoc = "TEST UT"
            };
            dao.Save(db, thuoc);
            THUOC thuocUpdate = new THUOC
            {
                MaThuoc = TestCommon.LEN_10,
                TenThuoc = TestCommon.LEN_50 + "1",
                ChiDinh = TestCommon.LEN_50 + "1",
                ChongChiDinh = TestCommon.LEN_50 + "1"

            };
            string actual = dao.Save(db, thuocUpdate);
            string expected = "1111";
            Assert.AreEqual(expected, actual);
        }
        

        // Test delete sucesses
        [TestMethod]
        public void Delete_TestCase7()
        {
            ThuocDAO dao = new ThuocDAO();
            THUOC thuoc = new THUOC
            {
                MaThuoc = TestCommon.LEN_10,
                TenThuoc = TestCommon.LEN_50
            };
            dao.Save(db, thuoc);
            string actual = dao.Delete(db, thuoc);
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
