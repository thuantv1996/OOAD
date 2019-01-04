using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DAO.Implement;
using System.Data.Entity;

namespace UnitTest.DAO
{
    [TestClass]
    public class TestDonThuocDAO
    {
        private static QLPHONGKHAMEntities db;
        private static DbContextTransaction trans;
        // INIT METHOD
        [TestInitialize]
        public void Init()
        {
            db = new QLPHONGKHAMEntities();
            trans = db.Database.BeginTransaction();

            db.HOSOBENHANs.Add(new HOSOBENHAN { MaHoSo = TestCommon.LEN_10 });
        }

        /* BEGIN TEST METHOD */
        [TestMethod]
        // Test insert DonThuoc sucesses
        public void Insert_TestCase1()
        {
            DONTHUOC donThuoc = new DONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                NgayLap = TestCommon.LEN_8,
                GhiChu = TestCommon.LEN_250
            };
            DonThuocDAO dao = new DonThuocDAO();
            string actual = dao.Save(db, donThuoc);
            string expected = "0000";
            Assert.Equals(expected, actual);
        }

        [TestMethod]
        // Test insert without MaDonThuoc or MaHoSo
        public void Insert_TestCase2()
        {
            DONTHUOC donThuoc = new DONTHUOC
            {
                NgayLap = TestCommon.LEN_8,
                GhiChu = TestCommon.LEN_250
            };
            DonThuocDAO dao = new DonThuocDAO();
            string actual = dao.Save(db, donThuoc);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test insert MaHoSo not found in table HOSOBENHAN
        [TestMethod]
        public void Insert_TestCase3()
        {
            DONTHUOC donThuoc = new DONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaHoSo = "123",
            };
            DonThuocDAO dao = new DonThuocDAO();
            string actual = dao.Save(db, donThuoc);
            string expected = "1111";
            // Test
            Assert.Equals(expected, actual);
        }


        // Test insert max length
        [TestMethod]
        public void Insert_TestCase4()
        {
            DONTHUOC donThuoc = new DONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                NgayLap = TestCommon.LEN_8 + "1",
                GhiChu = TestCommon.LEN_250 + "1"
            };
            DonThuocDAO dao = new DonThuocDAO();
            string actual = dao.Save(db, donThuoc);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }


        // Test update sucesses
        [TestMethod]
        public void Update_TestCase5()
        {
            // Khởi tạo dao
            DonThuocDAO dao = new DonThuocDAO();
            DONTHUOC donThuoc = new DONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaHoSo = "123",
            };
            dao.Save(db, donThuoc);
            DONTHUOC donThuocUpdate = new DONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaHoSo = "TEST UPDATE",
            };
            // Tạo biến lưu thông tin nhân viên update
            string actual = dao.Save(db, donThuocUpdate);
            // Biến kết quả
            string expected = "0000";
            // Test 
            Assert.Equals(expected, actual);
        }

        // Test update with MaHoSo is null
        [TestMethod]
        public void Update_TestCase6()
        {
            DonThuocDAO dao = new DonThuocDAO();
            DONTHUOC donThuoc = new DONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
            };
            dao.Save(db, donThuoc);
            DONTHUOC donThuocUpdate = new DONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
            };
            // Tạo biến lưu thông tin nhân viên update
            string actual = dao.Save(db, donThuocUpdate);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test update with MaHoSo doesn't exist in table HOSOBENHAN
        [TestMethod]
        public void Update_TestCase7()
        {
            DonThuocDAO dao = new DonThuocDAO();
            DONTHUOC donThuoc = new DONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
            };
            dao.Save(db, donThuoc);
            DONTHUOC donThuocUpdate = new DONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaHoSo = "123",
            };
            // Tạo biến lưu thông tin nhân viên update
            string actual = dao.Save(db, donThuocUpdate);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test update max length
        [TestMethod]
        public void Update_TestCase8()
        {
            DonThuocDAO dao = new DonThuocDAO();
            DONTHUOC donThuoc = new DONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                NgayLap = TestCommon.LEN_8,
                GhiChu = TestCommon.LEN_250
            };
            dao.Save(db, donThuoc);
            DONTHUOC donThuocUpdate = new DONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                NgayLap = TestCommon.LEN_8 + "1",
                GhiChu = TestCommon.LEN_250 + "1"
            };
            string actual = dao.Save(db, donThuocUpdate);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }


        [TestMethod]
        // Test delete
        public void Delete_TestCase9()
        {
            DONTHUOC donThuoc = new DONTHUOC
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
            };
            DonThuocDAO dao = new DonThuocDAO();
            dao.Save(db, donThuoc);
            string actual = dao.Delete(db, donThuoc);
            string expected = "0000";
            Assert.AreEqual(expected, actual);
        }

        /* END TEST METHOD */

        // CLEAN METHOD
        [TestCleanup]
        public void Clean()
        {
            trans.Rollback();
            trans.Dispose();
            db.Dispose();
        }
    }
}
