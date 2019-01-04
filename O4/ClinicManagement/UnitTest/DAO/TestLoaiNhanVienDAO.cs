using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DAO.Implement;
using System.Data.Entity;

namespace UnitTest.DAO
{
    [TestClass]
    public class TestLoaiNhanVienDAO
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
            LOAINHANVIEN loaiNhanVien = new LOAINHANVIEN
            {
                MaLoaiNV = TestCommon.LEN_10,
                TenLoaiNV = TestCommon.LEN_50
            };
            LoaiNhanVienDAO dao = new LoaiNhanVienDAO();
            string actual = dao.Save(db, loaiNhanVien);
            string expected = "0000";
            Assert.AreEqual(expected, actual);
        }
       
        // Test insert without MaLoaiNV or TenLoaiNV
        [TestMethod]
        public void Insert_TestCase2()
        {
            LOAINHANVIEN loaiNhanVien = new LOAINHANVIEN {  };
            LoaiNhanVienDAO dao = new LoaiNhanVienDAO();
            string actual = dao.Save(db, loaiNhanVien);
            string expected = "1111";
            Assert.AreEqual(expected, actual);
        }

        // Test insert max - length string
        [TestMethod]
        public void Insert_TestCase3()
        {
            LOAINHANVIEN loaiNhanVien = new LOAINHANVIEN
            {
                MaLoaiNV = TestCommon.LEN_10 + "1",
                TenLoaiNV = TestCommon.LEN_50 + "1",
            };
            LoaiNhanVienDAO dao = new LoaiNhanVienDAO();
            string actual = dao.Save(db, loaiNhanVien);
            string expected = "1111";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        // Test update sucesses
        public void Update_TestCase4()
        {
            // Khởi tạo dao
            LoaiNhanVienDAO dao = new LoaiNhanVienDAO();
            // Insert một loại nhân viên mới
            LOAINHANVIEN loaiNhanVien = new LOAINHANVIEN
            {
                MaLoaiNV = TestCommon.LEN_10,
                TenLoaiNV = TestCommon.LEN_50
            };
            dao.Save(db, loaiNhanVien);
            // Update loại nhân viên 
            LOAINHANVIEN loaiNhanVienUpdate = new LOAINHANVIEN
            {
                MaLoaiNV = TestCommon.LEN_10,
                TenLoaiNV = "TEST LOAI NHAN VIEN"
            };
            // Tạo biến lưu thông tin loaiNhanVienUpdate
            string actual = dao.Save(db, loaiNhanVienUpdate);
            // Biến kết quả
            string expected = "0000";
            // Test 
            Assert.AreEqual(expected, actual);
        }

        // Test update without TenLoaiNhanVien
        [TestMethod]
        public void Update_TestCase5()
        {
            LoaiNhanVienDAO dao = new LoaiNhanVienDAO();
            LOAINHANVIEN loaiNhanVien = new LOAINHANVIEN
            {
                MaLoaiNV = TestCommon.LEN_10,
                TenLoaiNV = TestCommon.LEN_50
            };
            dao.Save(db, loaiNhanVien);
            LOAINHANVIEN loaiNhanVienUpdate = new LOAINHANVIEN
            {
                MaLoaiNV = TestCommon.LEN_10,
                TenLoaiNV = TestCommon.LEN_250
            };
            string actual = dao.Save(db, loaiNhanVienUpdate);
            string expected = "0000";
            Assert.AreEqual(expected, actual);
        }

        // Test update max length
        [TestMethod]
        public void Update_TestCase6()
        {
            LoaiNhanVienDAO dao = new LoaiNhanVienDAO();
            LOAINHANVIEN loaiNhanVien = new LOAINHANVIEN
            {
                MaLoaiNV = TestCommon.LEN_10,
                TenLoaiNV = TestCommon.LEN_50
            };
            dao.Save(db, loaiNhanVien);
            LOAINHANVIEN loaiNhanVienUpdate = new LOAINHANVIEN
            {
                MaLoaiNV = TestCommon.LEN_10,
                TenLoaiNV = TestCommon.LEN_250 + "12"
            };
            string actual = dao.Save(db, loaiNhanVienUpdate);
            string expected = "1111";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        // Test Delete sucesses
        public void Delete_TestCase7()
        {
            LOAINHANVIEN loaiNhanVien = new LOAINHANVIEN
            {
                MaLoaiNV = TestCommon.LEN_10,
                TenLoaiNV = TestCommon.LEN_50
            };
            LoaiNhanVienDAO dao = new LoaiNhanVienDAO();
            dao.Save(db, loaiNhanVien);
            string actual = dao.Delete(db, loaiNhanVien);
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
