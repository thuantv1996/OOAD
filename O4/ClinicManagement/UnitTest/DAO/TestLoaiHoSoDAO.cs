using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DAO.Implement;
using System.Data.Entity;

namespace UnitTest.DAO
{
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
        public void Save_TestCase1()
        {
            LOAIHOSO loaiHoSo = new LOAIHOSO
            {
                MaLoaiHoSo = TestCommon.LEN_10,
                TenLoaiHoSo = TestCommon.LEN_50
            };
            LoaiHoSoDAO dao = new LoaiHoSoDAO();
            string actual = dao.Save(db, loaiHoSo);
            string expected = "0000";
            Assert.Equals(expected, actual);
        }

        [TestMethod]
        // Test insert without MaLoaiHoSo or TenLoaiHoSo
        public void Save_TestCase2()
        {
            LOAIHOSO loaiHoSo = new LOAIHOSO { };
            LoaiHoSoDAO dao = new LoaiHoSoDAO();
            string actual = dao.Save(db, loaiHoSo);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test full - length string
        [TestMethod]
        public void Insert_TestCase3()
        {
            LOAIHOSO loaiHoSo = new LOAIHOSO
            {
                MaLoaiHoSo = TestCommon.LEN_10,
                TenLoaiHoSo = TestCommon.LEN_50
            };
            LoaiHoSoDAO dao = new LoaiHoSoDAO();
            string actual = dao.Save(db, loaiHoSo);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test max - length string
        [TestMethod]
        public void Insert_TestCase4()
        {
            LOAIHOSO loaiHoSo = new LOAIHOSO
            {
                MaLoaiHoSo = TestCommon.LEN_10 + "1",
                TenLoaiHoSo = TestCommon.LEN_50 + "1"
            };
            LoaiHoSoDAO dao = new LoaiHoSoDAO();
            string actual = dao.Save(db, loaiHoSo);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        [TestMethod]
        // Test update
        public void Save_TestCase5()
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
            Assert.Equals(expected, actual);
        }

        [TestMethod]
        // Test Delete
        public void Save_TestCase6()
        {
            LOAIHOSO loaiHoSo = new LOAIHOSO
            {
                MaLoaiHoSo = TestCommon.LEN_10,
                TenLoaiHoSo = TestCommon.LEN_50
            };
            LoaiHoSoDAO dao = new LoaiHoSoDAO();
            string actual = dao.Save(db, loaiHoSo);
            Assert.Equals(null, actual);
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
