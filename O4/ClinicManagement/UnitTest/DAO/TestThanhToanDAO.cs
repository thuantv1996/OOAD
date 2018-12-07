using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DAO.Implement;
using System.Data.Entity;

namespace UnitTest.DAO
{
    [TestClass]
    public class TestThanhToanDAO
    {
        private static QLPHONGKHAMEntities db;
        private static DbContextTransaction trans;
        // init method
        [TestInitialize]
        public void Init()
        {
            db = new QLPHONGKHAMEntities();
            trans = db.Database.BeginTransaction();
            db.HOSOBENHANs.Add(new HOSOBENHAN { MaHoSo = TestCommon.LEN_10 });
        }

        /* BEGIN TEST METHOD */

        // Test insert data sucesses
        [TestMethod]
        public void Insert_TestCase1()
        {
            THANHTOAN thanhToan = new THANHTOAN
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                ChiPhiKham = 100000000000,
                ChiPhiXetNghiem = 100000000000,
                TongChiPhi = 200000000000,
                NhanVienThu = TestCommon.LEN_10,
                NgayThu = TestCommon.LEN_8
            };
            ThanhToanDAO dao = new ThanhToanDAO();
            string actual = dao.Save(db, thanhToan);
            string expected = "0000";
            Assert.Equals(expected, actual);
        }

        // Test insert MaHoSo is null
        [TestMethod]
        public void Insert_TestCase2()
        {
            THANHTOAN thanhToan = new THANHTOAN
            {
                MaThanhToan = TestCommon.LEN_10,
            };
            ThanhToanDAO dao = new ThanhToanDAO();
            string actual = dao.Save(db, thanhToan);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test insert ChiPhi is negative
        [TestMethod]
        public void Insert_TestCase3()
        {
            THANHTOAN thanhToan = new THANHTOAN
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                ChiPhiKham = -100000000000,
                ChiPhiXetNghiem = -100000000000,
                TongChiPhi = -200000000000,
            };
            ThanhToanDAO dao = new ThanhToanDAO();
            string actual = dao.Save(db, thanhToan);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test insert max length
        [TestMethod]
        public void Insert_TestCase4()
        {
            THANHTOAN thanhToan = new THANHTOAN
            {
                MaThanhToan = TestCommon.LEN_10 + "1",
                MaHoSo = TestCommon.LEN_10 + "1",
                ChiPhiKham = 1000000000001,
                ChiPhiXetNghiem = 1000000000001,
                TongChiPhi = 2000000000002,
                NhanVienThu = TestCommon.LEN_10 + "1",
                NgayThu = TestCommon.LEN_8 + "1"
            };
            ThanhToanDAO dao = new ThanhToanDAO();
            string actual = dao.Save(db, thanhToan);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test insert with MaHoSo doesn't exist in table HOSOBENHAN
        [TestMethod]
        public void Insert_TestCase5()
        {
            THANHTOAN thanhToan = new THANHTOAN
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = "123",
            };
            ThanhToanDAO dao = new ThanhToanDAO();
            string actual = dao.Save(db, thanhToan);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test update success
        [TestMethod]
        public void Update_TestCase6()
        {
            ThanhToanDAO dao = new ThanhToanDAO();
            THANHTOAN thanhToan = new THANHTOAN
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                ChiPhiKham = 1,
                ChiPhiXetNghiem = 1,
                TongChiPhi = 2,
                NhanVienThu = TestCommon.LEN_10,
                NgayThu = TestCommon.LEN_8

            };
            dao.Save(db, thanhToan);
            THANHTOAN thanhToanUpdate = new THANHTOAN
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                ChiPhiKham = 1,
                ChiPhiXetNghiem = 1,
                TongChiPhi = 2,
                NhanVienThu = "1234",
                NgayThu = TestCommon.LEN_8
            };
            string actual = dao.Save(db, thanhToanUpdate);
            // Biến kết quả
            string expected = "0000";
            // Test 
            Assert.Equals(expected, actual);
        }

        // Test update MaHoSo is null
        [TestMethod]
        public void Update_TestCase7()
        {
            ThanhToanDAO dao = new ThanhToanDAO();
            THANHTOAN thanhToan = new THANHTOAN
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,

            };
            dao.Save(db, thanhToan);
            THANHTOAN thanhToanUpdate = new THANHTOAN
            {
                MaThanhToan = TestCommon.LEN_10,
            };
            string actual = dao.Save(db, thanhToanUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }


        // Test update ChiPhi is negative
        [TestMethod]
        public void Update_TestCase8()
        {
            ThanhToanDAO dao = new ThanhToanDAO();
            THANHTOAN thanhToan = new THANHTOAN
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                ChiPhiKham = 1,
                ChiPhiXetNghiem = 1,
                TongChiPhi = 2,

            };
            dao.Save(db, thanhToan);
            THANHTOAN thanhToanUpdate = new THANHTOAN
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                ChiPhiKham = -1,
                ChiPhiXetNghiem = -1,
                TongChiPhi = -2,
            };
            string actual = dao.Save(db, thanhToanUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }


        // Test update max lenght
        [TestMethod]
        public void Update_TestCase9()
        {
            ThanhToanDAO dao = new ThanhToanDAO();
            THANHTOAN thanhToan = new THANHTOAN
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                ChiPhiKham = 1,
                ChiPhiXetNghiem = 1,
                TongChiPhi = 2,
                NhanVienThu = TestCommon.LEN_10,
                NgayThu = TestCommon.LEN_8

            };
            dao.Save(db, thanhToan);
            THANHTOAN thanhToanUpdate = new THANHTOAN
            {
                MaThanhToan = TestCommon.LEN_10 + "1",
                MaHoSo = TestCommon.LEN_10 + "1",
                ChiPhiKham = 1111111111111,
                ChiPhiXetNghiem = 1111111111111,
                TongChiPhi = 22222222222222,
                NhanVienThu = TestCommon.LEN_10 + "1",
                NgayThu = TestCommon.LEN_8 + "1"
            };
            string actual = dao.Save(db, thanhToanUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }


        // Test update with MaHoSo doesn't exist in table HOSOBENHAN
        [TestMethod]
        public void Update_TestCase10()
        {
            ThanhToanDAO dao = new ThanhToanDAO();
            THANHTOAN thanhToan = new THANHTOAN
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,

            };
            dao.Save(db, thanhToan);
            THANHTOAN thanhToanUpdate = new THANHTOAN
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = "123"
            };
            string actual = dao.Save(db, thanhToanUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }

        // Test delete sucesses
        [TestMethod]
        public void Delete_TestCase9()
        {
            THANHTOAN thanhToan = new THANHTOAN
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10
            };
            ThanhToanDAO dao = new ThanhToanDAO();
            string actual = dao.Save(db, thanhToan);
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
