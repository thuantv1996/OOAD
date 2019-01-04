using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DAO.Implement;
using System.Data.Entity;

namespace UnitTest.DAO
{
    [TestClass]
    public class TestLoaiHoSoDAO
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
        [TestMethod]
        // Test insert data sucesses
        public void Insert_TestCase1()
        {
            LOAIHOSO loaiHoSo = new LOAIHOSO
            {
                MaLoaiHoSo = TestCommon.LEN_10,
                TenLoaiHoSo = TestCommon.LEN_50
            };
            LoaiHoSoDAO dao = new LoaiHoSoDAO();
            string actual = dao.Save(db, loaiHoSo);
            string expected = "0000";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        // Test insert without MaLoaiHoSo or TenLoaiHoSo
        public void Insert_TestCase2()
        {
            LOAIHOSO loaiHoSo = new LOAIHOSO { };
            LoaiHoSoDAO dao = new LoaiHoSoDAO();
            string actual = dao.Save(db, loaiHoSo);
            string expected = "1111";
            Assert.AreEqual(expected, actual);
        }

        // Test max - length string
        [TestMethod]
        public void Insert_TestCase3()
        {
            LOAIHOSO loaiHoSo = new LOAIHOSO
            {
                MaLoaiHoSo = TestCommon.LEN_10 + "1",
                TenLoaiHoSo = TestCommon.LEN_50 + "1"
            };
            LoaiHoSoDAO dao = new LoaiHoSoDAO();
            string actual = dao.Save(db, loaiHoSo);
            string expected = "1111";
            Assert.AreEqual(expected, actual);
        }


        // Test update sucesses
        [TestMethod]
        public void Update_TestCase4()
        {
            // Khởi tạo dao
            LoaiHoSoDAO dao = new LoaiHoSoDAO();
            // Insert một loại nhân viên mới
            LOAIHOSO loaiHoSo = new LOAIHOSO
            {
                MaLoaiHoSo = TestCommon.LEN_10,
                TenLoaiHoSo = TestCommon.LEN_50
            };
            dao.Save(db, loaiHoSo);
            // Update loại nhân viên 
            LOAIHOSO loaiHoSoUpdate = new LOAIHOSO
            {
                MaLoaiHoSo = TestCommon.LEN_10,
                TenLoaiHoSo = "TEST LOAI HO SO"
            };
            // Tạo biến lưu thông tin loaiNhanVienUpdate
            string actual = dao.Save(db, loaiHoSoUpdate);
            // Biến kết quả
            string expected = "0000";
            // Test 
            Assert.AreEqual(expected, actual);
        }

        // Test update without TenLoaiHoSo
        [TestMethod]
        public void Update_TestCase5()
        {
            LoaiHoSoDAO dao = new LoaiHoSoDAO();
            LOAIHOSO loaiHoSo = new LOAIHOSO
            {
                MaLoaiHoSo = TestCommon.LEN_10,
                TenLoaiHoSo = TestCommon.LEN_50
            };
            dao.Save(db, loaiHoSo);
            LOAIHOSO loaiHoSoUpdate = new LOAIHOSO
            {
                MaLoaiHoSo = TestCommon.LEN_10
            };
            string actual = dao.Save(db, loaiHoSoUpdate);
            string expected = "0000";
            Assert.AreEqual(expected, actual);
        }

        // Test update max-length
        public void Update_TestCase6()
        {
            LoaiHoSoDAO dao = new LoaiHoSoDAO();
            LOAIHOSO loaiHoSo = new LOAIHOSO
            {
                MaLoaiHoSo = TestCommon.LEN_10,
                TenLoaiHoSo = TestCommon.LEN_50
            };
            dao.Save(db, loaiHoSo);
            LOAIHOSO loaiHoSoUpdate = new LOAIHOSO
            {
                MaLoaiHoSo = TestCommon.LEN_10,
                TenLoaiHoSo = TestCommon.LEN_50 + "12"
            };
            string actual = dao.Save(db, loaiHoSoUpdate);
            string expected = "1111";
            Assert.AreEqual(expected, actual);
        }

        // Test Delete sucesses
        [TestMethod]
        public void Save_TestCase7()
        {
            LOAIHOSO loaiHoSo = new LOAIHOSO
            {
                MaLoaiHoSo = TestCommon.LEN_10,
                TenLoaiHoSo = TestCommon.LEN_50
            };
            LoaiHoSoDAO dao = new LoaiHoSoDAO();
            dao.Save(db, loaiHoSo);
            string actual = dao.Delete(db, loaiHoSo);
            string expected = "0000";
            Assert.AreEqual(expected, actual);
        }
        /*End test method*/

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
