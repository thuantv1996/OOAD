using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DAO.Implement;
using System.Data.Entity;

namespace UnitTest.DAO
{
    public class TestLoaiNhanVien
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
            Assert.Equals(expected, actual);
        }

        [TestMethod]
        // Test insert without MaLoaiNV or TenLoaiNV
        public void Insert_TestCase2()
        {
            LOAINHANVIEN loaiNhanVien = new LOAINHANVIEN {  };
            LoaiNhanVienDAO dao = new LoaiNhanVienDAO();
            string actual = dao.Save(db, loaiNhanVien);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test full - length string
        [TestMethod]
        public void Insert_TestCase3()
        {
            LOAINHANVIEN loaiNhanVien = new LOAINHANVIEN
            {
                MaLoaiNV = TestCommon.LEN_10,
                TenLoaiNV = TestCommon.LEN_50
            };
            LoaiNhanVienDAO dao = new LoaiNhanVienDAO();
            string actual = dao.Save(db, loaiNhanVien);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test max - length string
        [TestMethod]
        public void Insert_TestCase4()
        {
            LOAINHANVIEN loaiNhanVien = new LOAINHANVIEN
            {
                MaLoaiNV = TestCommon.LEN_10 + "1",
                TenLoaiNV = TestCommon.LEN_50 + "1",
            };
            LoaiNhanVienDAO dao = new LoaiNhanVienDAO();
            string actual = dao.Save(db, loaiNhanVien);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        [TestMethod]
        // Test update
        public void Update_TestCase5()
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
            Assert.Equals(expected, actual);
        }

        [TestMethod]
        // Test Delete
        public void Delete_TestCase6()
        {
            LOAINHANVIEN loaiNhanVien = new LOAINHANVIEN
            {
                MaLoaiNV = TestCommon.LEN_10,
                TenLoaiNV = TestCommon.LEN_50
            };
            LoaiNhanVienDAO dao = new LoaiNhanVienDAO();
            string actual = dao.Save(db, loaiNhanVien);
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
