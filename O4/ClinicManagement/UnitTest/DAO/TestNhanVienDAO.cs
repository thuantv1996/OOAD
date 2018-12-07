using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DAO.Implement;
using System.Data.Entity;

namespace UnitTest.DAO
{
    [TestClass]
    public class TestNhanVienDAO
    {
        private static QLPHONGKHAMEntities db;
        private static DbContextTransaction trans;
        // init method
        [TestInitialize]
        public void Init()
        {
            db = new QLPHONGKHAMEntities();
            trans = db.Database.BeginTransaction();
            db.LOAINHANVIENs.Add(new LOAINHANVIEN { MaLoaiNV = TestCommon.LEN_10 });
            db.PHONGs.Add(new PHONG { MaPhong = TestCommon.LEN_10 });
        }

        /* BEGIN TEST METHOD */
        [TestMethod]
        // Test insert data sucesses
        public void Insert_TestCase1()
        {
            NHANVIEN nhanVien = new NHANVIEN
            {   MaNV = TestCommon.LEN_10,
                HoTenNV = "abc",
                NgaySinh = "1996",
                CMND = "123",
                DiaChi = "123",
                SoDienThoai = "123",
                Email = "123",
                MaSoThue = "123",
                SoTaiKhoan = "123",
                MaLoaiNV = TestCommon.LEN_10,
                MaPhong = TestCommon.LEN_10
            };
            NhanVienDAO dao = new NhanVienDAO();
            string actual = dao.Save(db, nhanVien);
            string expected = "0000";
            Assert.Equals(expected, actual);
        }

        // Test insert null
        [TestMethod]
        public void Insert_TestCase2()
        {
            NHANVIEN nhanVien = new NHANVIEN { MaNV = TestCommon.LEN_10 };
            NhanVienDAO dao = new NhanVienDAO();
            string actual = dao.Save(db, nhanVien);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test insert max - length string
        [TestMethod]
        public void Insert_TestCase3()
        {
            NHANVIEN nhanVien = new NHANVIEN
            {
                MaNV = TestCommon.LEN_10,
                HoTenNV = TestCommon.LEN_50 + "1",
                NgaySinh = TestCommon.LEN_8 + "1",
                CMND = TestCommon.LEN_10 + "123",
                DiaChi = TestCommon.LEN_250 + "1",
                SoDienThoai = TestCommon.LEN_10 + "12",
                Email = TestCommon.LEN_250 + "1",
                MaSoThue = TestCommon.LEN_10 + "1234",
                SoTaiKhoan = TestCommon.LEN_10 + "123455",
                MaLoaiNV = TestCommon.LEN_10 + "1",
                MaPhong = TestCommon.LEN_10 + "1"
            };
            NhanVienDAO dao = new NhanVienDAO();
            string actual = dao.Save(db, nhanVien);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test insert MaLoaiNV, MaPhong not found in table MALOAINHANVIEN, MAPHONG
        [TestMethod]
        public void Insert_TestCase4()
        {
            NHANVIEN nhanVien = new NHANVIEN
            {   MaNV = TestCommon.LEN_10,
                HoTenNV = TestCommon.LEN_50,
                MaLoaiNV = "0987654321",
                MaPhong = "0987654321"
            };
            NhanVienDAO dao = new NhanVienDAO();
            string actual = dao.Save(db, nhanVien);
            string expected = "1111";
            // Test
            Assert.Equals(expected, actual);
        }

        // Test update data sucesses
        [TestMethod]
        public void Update_TestCase5()
        {
            // Khởi tạo dao
            NhanVienDAO dao = new NhanVienDAO();
            // Insert một nhân viên mới
            NHANVIEN nhanVien = new NHANVIEN
            {
                MaNV = TestCommon.LEN_10,
                HoTenNV = "TEST UT"
            };
            dao.Save(db, nhanVien);
            // Update nhân viên 
            NHANVIEN nhanVienUpdate = new NHANVIEN
            {
                MaNV = TestCommon.LEN_10,
                HoTenNV = "TEST UT UPDATE"
            };
            // Tạo biến lưu thông tin nhân viên update
            string actual = dao.Save(db, nhanVienUpdate);
            // Biến kết quả
            string expected = "0000";
            // Test 
            Assert.Equals(expected, actual);
        }

        // Test update without TenNhanVien
        [TestMethod]
        public void Update_TestCase6()
        {
            NhanVienDAO dao = new NhanVienDAO();
            NHANVIEN nhanVien = new NHANVIEN
            {
                MaNV = TestCommon.LEN_10,
                HoTenNV = "TEST UT"
            };
            dao.Save(db, nhanVien);
            NHANVIEN nhanVienUpdate = new NHANVIEN
            {
                MaNV = TestCommon.LEN_10,
            };
            string actual = dao.Save(db, nhanVienUpdate);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test update max length
        [TestMethod]
        public void Update_TestCase7()
        {
            NhanVienDAO dao = new NhanVienDAO();
            NHANVIEN nhanVien = new NHANVIEN
            {
                MaNV = TestCommon.LEN_10,
                HoTenNV = "TEST UT"
            };
            dao.Save(db, nhanVien);
            NHANVIEN nhanVienUpdate = new NHANVIEN
            {
                MaNV = TestCommon.LEN_10,
                HoTenNV = TestCommon.LEN_50 + "1",
                NgaySinh = TestCommon.LEN_8 + "1",
                CMND = TestCommon.LEN_10 + "123",
                DiaChi = TestCommon.LEN_250 + "1",
                SoDienThoai = TestCommon.LEN_10 + "12",
                Email = TestCommon.LEN_250 + "1",
                MaSoThue = TestCommon.LEN_10 + "1234",
                SoTaiKhoan = TestCommon.LEN_10 + "123455",
                MaLoaiNV = TestCommon.LEN_10 + "1",
                MaPhong = TestCommon.LEN_10 + "1"

            };
            string actual = dao.Save(db, nhanVienUpdate);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test update data with MaloaiNV or MaPhong doesn't exist in table
        [TestMethod]
        public void Update_TestCase8()
        {
            // Khởi tạo dao
            NhanVienDAO dao = new NhanVienDAO();
            // Insert một nhân viên mới
            NHANVIEN nhanVien = new NHANVIEN
            {
                MaNV = TestCommon.LEN_10,
                HoTenNV = TestCommon.LEN_50,
                MaLoaiNV = TestCommon.LEN_10,
                MaPhong = TestCommon.LEN_10

            };
            dao.Save(db, nhanVien);
            // Update nhân viên 
            NHANVIEN nhanVienUpdate = new NHANVIEN
            {
                MaNV = TestCommon.LEN_10,
                HoTenNV = TestCommon.LEN_50,
                MaLoaiNV = "TESTUP0001",
                MaPhong = "TESTUP0001"
            };
            // Tạo biến lưu thông tin nhân viên update
            string actual = dao.Save(db, nhanVienUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }

        // Test delete sucesses
        [TestMethod]
        public void Delete_TestCase9()
        {
            NHANVIEN nhanVien = new NHANVIEN
            {
                MaNV = TestCommon.LEN_10,
                HoTenNV = "abc",
                MaLoaiNV = TestCommon.LEN_10,
                MaPhong = TestCommon.LEN_10
            };
            NhanVienDAO dao = new NhanVienDAO();
            string actual = dao.Save(db, nhanVien);
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
