using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DAO.Implement;
using System.Data.Entity;

namespace UnitTest.DAO
{
    [TestClass]
    public class TestHoSoBenhAnDAO
    {
        private static QLPHONGKHAMEntities db;
        private static DbContextTransaction trans;
        // init method
        [TestInitialize]
        public void Init()
        {
            db = new QLPHONGKHAMEntities();
            trans = db.Database.BeginTransaction();
            db.LOAIHOSOes.Add(new LOAIHOSO { MaLoaiHoSo = TestCommon.LEN_10 });
            db.BENHNHANs.Add(new BENHNHAN { MaBenhNhan = TestCommon.LEN_10 });
            db.NHANVIENs.Add(new NHANVIEN { MaNV = TestCommon.LEN_10 });
            db.PHONGs.Add(new PHONG { MaPhong = TestCommon.LEN_10 });
            
        }

        /* BEGIN TEST METHOD */

        // Test insert data sucesses
        [TestMethod]
        public void Insert_TestCase1()
        {
            HOSOBENHAN hoSoBenhAn = new HOSOBENHAN
            {
                MaHoSo = TestCommon.LEN_10,
                MaHoSoTruoc = TestCommon.LEN_10,
                MaHoSoGoc = TestCommon.LEN_10,
                MaLoaiHoSo = TestCommon.LEN_10,
                MaBenhNhan = TestCommon.LEN_10,
                MaNguoiTN = TestCommon.LEN_10,
                NgayTiepNhan = TestCommon.LEN_8,
                YeuCauKham = TestCommon.LEN_250,
                TrieuChung = TestCommon.LEN_250,
                NgayKham = TestCommon.LEN_8,
                SoThuTu = 1,
                MaPhongKham = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
                ChuanDoan = "abc",
                CoKeDon = true,
            };
            HoSoBenhAnDAO dao = new HoSoBenhAnDAO();
            string actual = dao.Save(db, hoSoBenhAn);
            string expected = "0000";
            Assert.Equals(expected, actual);
        }

        // Test insert max length
        [TestMethod]
        public void Insert_TestCase2()
        {
            HOSOBENHAN hoSoBenhAn = new HOSOBENHAN
            {
                MaHoSo = TestCommon.LEN_10 + "1",
                MaHoSoTruoc = TestCommon.LEN_10 + "1",
                MaHoSoGoc = TestCommon.LEN_10 + "1",
                MaLoaiHoSo = TestCommon.LEN_10 + "1",
                MaBenhNhan = TestCommon.LEN_10 + "1",
                MaNguoiTN = TestCommon.LEN_10 + "1",
                NgayTiepNhan = TestCommon.LEN_8 + "1",
                YeuCauKham = TestCommon.LEN_250 + "1",
                TrieuChung = TestCommon.LEN_250 + "1",
                NgayKham = TestCommon.LEN_8 + "1",
                SoThuTu = 1,
                MaPhongKham = TestCommon.LEN_10 + "1",
                MaBacSi = TestCommon.LEN_10 + "1",
                ChuanDoan = "abc",
                CoKeDon = true,
            };
            HoSoBenhAnDAO dao = new HoSoBenhAnDAO();
            string actual = dao.Save(db, hoSoBenhAn);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }


        // Test insert with MaLoaiHoSo, MaBenhNhan, MaNguoiTN is null
        [TestMethod]
        public void Insert_TestCase3()
        {
            HOSOBENHAN hoSoBenhAn = new HOSOBENHAN
            {
                MaHoSo = TestCommon.LEN_10,
            };
            HoSoBenhAnDAO dao = new HoSoBenhAnDAO();
            string actual = dao.Save(db, hoSoBenhAn);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }


        // Test insert with MaLoaiHoSo, MaBenhNhan, MaNguoiTN, MaPhongKham, MaBacSi doesn't exist in table
        [TestMethod]
        public void Insert_TestCase4()
        {
            HOSOBENHAN hoSoBenhAn = new HOSOBENHAN
            {
                MaHoSo = TestCommon.LEN_10,
                MaLoaiHoSo = "1234",
                MaBenhNhan = "1234",
                MaNguoiTN = "1234",
                MaPhongKham = "1234",
                MaBacSi = "1234",
            };
            HoSoBenhAnDAO dao = new HoSoBenhAnDAO();
            string actual = dao.Save(db, hoSoBenhAn);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test insert with SoThuTu is negative
        [TestMethod]
        public void Insert_TestCase5()
        {
            HOSOBENHAN hoSoBenhAn = new HOSOBENHAN
            {
                MaHoSo = TestCommon.LEN_10,
                MaHoSoTruoc = TestCommon.LEN_10,
                MaHoSoGoc = TestCommon.LEN_10,
                MaLoaiHoSo = TestCommon.LEN_10,
                MaBenhNhan = TestCommon.LEN_10,
                MaNguoiTN = TestCommon.LEN_10,
                NgayTiepNhan = TestCommon.LEN_8,
                YeuCauKham = TestCommon.LEN_250,
                TrieuChung = TestCommon.LEN_250,
                NgayKham = TestCommon.LEN_8,
                SoThuTu = -1,
                MaPhongKham = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
                ChuanDoan = "abc",
                CoKeDon = true,
            };
            HoSoBenhAnDAO dao = new HoSoBenhAnDAO();
            string actual = dao.Save(db, hoSoBenhAn);
            string expected = "0000";
            Assert.Equals(expected, actual);
        }

        // Test update success
        [TestMethod]
        public void Update_TestCase6()
        {
            HoSoBenhAnDAO dao = new HoSoBenhAnDAO();
            HOSOBENHAN hoSoBenhAn = new HOSOBENHAN
            {
                MaHoSo = TestCommon.LEN_10,
                MaHoSoTruoc = TestCommon.LEN_10,
                MaHoSoGoc = TestCommon.LEN_10,
                MaLoaiHoSo = TestCommon.LEN_10,
                MaBenhNhan = TestCommon.LEN_10,
                MaNguoiTN = TestCommon.LEN_10,
                NgayTiepNhan = TestCommon.LEN_8,
                YeuCauKham = TestCommon.LEN_250,
                TrieuChung = TestCommon.LEN_250,
                NgayKham = TestCommon.LEN_8,
                SoThuTu = 1,
                MaPhongKham = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
                ChuanDoan = "abc",
                CoKeDon = true,
            };
            dao.Save(db, hoSoBenhAn);
            HOSOBENHAN hoSoBenhAnUpdate = new HOSOBENHAN
            {
                MaHoSo = TestCommon.LEN_10,
                MaHoSoTruoc = TestCommon.LEN_10,
                MaHoSoGoc = TestCommon.LEN_10,
                MaLoaiHoSo = TestCommon.LEN_10,
                MaBenhNhan = TestCommon.LEN_10,
                MaNguoiTN = TestCommon.LEN_10,
                NgayTiepNhan = TestCommon.LEN_8,
                YeuCauKham = TestCommon.LEN_250,
                TrieuChung = TestCommon.LEN_250,
                NgayKham = TestCommon.LEN_8,
                SoThuTu = 1,
                MaPhongKham = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
                ChuanDoan = "TEST UPDATE",
                CoKeDon = true,
            };
            string actual = dao.Save(db, hoSoBenhAnUpdate);
            // Biến kết quả
            string expected = "0000";
            // Test 
            Assert.Equals(expected, actual);
        }

        // Test update max length
        [TestMethod]
        public void Update_TestCase7()
        {
            HoSoBenhAnDAO dao = new HoSoBenhAnDAO();
            HOSOBENHAN hoSoBenhAn = new HOSOBENHAN
            {
                MaHoSo = TestCommon.LEN_10,
                MaHoSoTruoc = TestCommon.LEN_10,
                MaHoSoGoc = TestCommon.LEN_10,
                MaLoaiHoSo = TestCommon.LEN_10,
                MaBenhNhan = TestCommon.LEN_10,
                MaNguoiTN = TestCommon.LEN_10,
                NgayTiepNhan = TestCommon.LEN_8,
                YeuCauKham = TestCommon.LEN_250,
                TrieuChung = TestCommon.LEN_250,
                NgayKham = TestCommon.LEN_8,
                SoThuTu = 1,
                MaPhongKham = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
                ChuanDoan = "abc",
                CoKeDon = true,
            };
            dao.Save(db, hoSoBenhAn);
            HOSOBENHAN hoSoBenhAnUpdate = new HOSOBENHAN
            {
                MaHoSo = TestCommon.LEN_10 + "1",
                MaHoSoTruoc = TestCommon.LEN_10 + "1",
                MaHoSoGoc = TestCommon.LEN_10 + "1",
                MaLoaiHoSo = TestCommon.LEN_10 + "1",
                MaBenhNhan = TestCommon.LEN_10 + "1",
                MaNguoiTN = TestCommon.LEN_10 + "1",
                NgayTiepNhan = TestCommon.LEN_8 + "1",
                YeuCauKham = TestCommon.LEN_250 + "1",
                TrieuChung = TestCommon.LEN_250 + "1",
                NgayKham = TestCommon.LEN_8 + "1",
                SoThuTu = 1,
                MaPhongKham = TestCommon.LEN_10 + "1",
                MaBacSi = TestCommon.LEN_10 + "1",
                ChuanDoan = "abc",
                CoKeDon = true,
            };
            string actual = dao.Save(db, hoSoBenhAnUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }


        // Test update with MaLoaiHoSo, MaBenhNhan, MaNguoiTN is null
        [TestMethod]
        public void Update_TestCase8()
        {
            HoSoBenhAnDAO dao = new HoSoBenhAnDAO();
            HOSOBENHAN hoSoBenhAn = new HOSOBENHAN
            {
                MaHoSo = TestCommon.LEN_10,
                MaLoaiHoSo = TestCommon.LEN_10,
                MaBenhNhan = TestCommon.LEN_10,
            };
            dao.Save(db, hoSoBenhAn);
            HOSOBENHAN hoSoBenhAnUpdate = new HOSOBENHAN
            {
                MaHoSo = TestCommon.LEN_10,
            };
            string actual = dao.Save(db, hoSoBenhAnUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }


        // Test update with MaLoaiHoSo, MaBenhNhan, MaNguoiTN, MaPhongKham, MaBacSi doesn't exist in table
        [TestMethod]
        public void Update_TestCase9()
        {
            HoSoBenhAnDAO dao = new HoSoBenhAnDAO();
            HOSOBENHAN hoSoBenhAn = new HOSOBENHAN
            {
                MaHoSo = TestCommon.LEN_10,
                MaLoaiHoSo = TestCommon.LEN_10,
                MaBenhNhan = TestCommon.LEN_10,
                MaNguoiTN = TestCommon.LEN_10,
                NgayTiepNhan = TestCommon.LEN_8,
                YeuCauKham = TestCommon.LEN_250,
                TrieuChung = TestCommon.LEN_250,
                NgayKham = TestCommon.LEN_8,
                SoThuTu = 1,
                MaPhongKham = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
            };
            dao.Save(db, hoSoBenhAn);
            HOSOBENHAN hoSoBenhAnUpdate = new HOSOBENHAN
            {
                MaHoSo = TestCommon.LEN_10,
                MaLoaiHoSo = "12345",
                MaBenhNhan = "12345",
                MaNguoiTN = "12345",
                NgayTiepNhan = TestCommon.LEN_8,
                YeuCauKham = TestCommon.LEN_250,
                TrieuChung = TestCommon.LEN_250,
                NgayKham = TestCommon.LEN_8,
                SoThuTu = 1,
                MaPhongKham = "12345",
                MaBacSi = "12345",
            };
            string actual = dao.Save(db, hoSoBenhAnUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }

        // Test update with SoThuTu is negative
        [TestMethod]
        public void Update_TestCase10()
        {
            HoSoBenhAnDAO dao = new HoSoBenhAnDAO();
            HOSOBENHAN hoSoBenhAn = new HOSOBENHAN
            {
                MaHoSo = TestCommon.LEN_10,
                MaLoaiHoSo = TestCommon.LEN_10,
                MaBenhNhan = TestCommon.LEN_10,
                MaNguoiTN = TestCommon.LEN_10,
                NgayTiepNhan = TestCommon.LEN_8,
                YeuCauKham = TestCommon.LEN_250,
                TrieuChung = TestCommon.LEN_250,
                NgayKham = TestCommon.LEN_8,
                SoThuTu = 1,
                MaPhongKham = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
            };
            dao.Save(db, hoSoBenhAn);
            HOSOBENHAN hoSoBenhAnUpdate = new HOSOBENHAN
            {
                MaHoSo = TestCommon.LEN_10,
                MaLoaiHoSo = TestCommon.LEN_10,
                MaBenhNhan = TestCommon.LEN_10,
                MaNguoiTN = TestCommon.LEN_10,
                NgayTiepNhan = TestCommon.LEN_8,
                YeuCauKham = TestCommon.LEN_250,
                TrieuChung = TestCommon.LEN_250,
                NgayKham = TestCommon.LEN_8,
                SoThuTu = -1,
                MaPhongKham = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10
            };
        }

        // Test delete sucesses
        [TestMethod]
        public void Delete_TestCase11()
        {
            HOSOBENHAN hoSoBenhAnDelete = new HOSOBENHAN
            {
                MaHoSo = TestCommon.LEN_10,
                MaHoSoTruoc = TestCommon.LEN_10,
                MaHoSoGoc = TestCommon.LEN_10,
                MaLoaiHoSo = TestCommon.LEN_10,
                MaBenhNhan = TestCommon.LEN_10,
                MaNguoiTN = TestCommon.LEN_10,
            };
            HoSoBenhAnDAO dao = new HoSoBenhAnDAO();
            dao.Save(db, hoSoBenhAnDelete);
            string actual = dao.Delete(db, hoSoBenhAnDelete);
            string expected = "0000";
            Assert.Equals(expected, actual);
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
