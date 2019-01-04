using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DAO.Implement;
using System.Data.Entity;


namespace UnitTest.DAO
{
    [TestClass]
    public class TestLuonCongViecDAO
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
            LUONCONGVIEC luonCongViec = new LUONCONGVIEC
            {
                MaHoSo = TestCommon.LEN_10,
                NodeHienTai = "12345",
                TiepNhan = true,
                KhamBenh = true,
                XetNghiem = true
            };
            LuonCongViecDAO dao = new LuonCongViecDAO();
            string actual = dao.Save(db, luonCongViec);
            string expected = "0000";
            Assert.AreEqual(expected, actual);
        }

        // Test insert MaHoSo is null
        [TestMethod]
        public void Insert_TestCase2()
        {
            LUONCONGVIEC luonCongViec = new LUONCONGVIEC
            {
                NodeHienTai = "12345",
                TiepNhan = true,
                KhamBenh = true,
                XetNghiem = true
            };
            LuonCongViecDAO dao = new LuonCongViecDAO();
            string actual = dao.Save(db, luonCongViec);
            string expected = "1111";
            Assert.AreEqual(expected, actual);
        }


        // Test insert MaHoSo doesn't exist in table HOSOBENHAN
        [TestMethod]
        public void Insert_TestCase3()
        {
            LUONCONGVIEC luonCongViec = new LUONCONGVIEC
            {
                MaHoSo = "123",
                NodeHienTai = "12345",
                TiepNhan = true,
                KhamBenh = true,
                XetNghiem = true
            };
            LuonCongViecDAO dao = new LuonCongViecDAO();
            string actual = dao.Save(db, luonCongViec);
            string expected = "1111";
            Assert.AreEqual(expected, actual);
        }


        // Test insert max length 
        [TestMethod]
        public void Insert_TestCase4()
        {
            LUONCONGVIEC luonCongViec = new LUONCONGVIEC
            {
                MaHoSo = TestCommon.LEN_10 + "1",
                NodeHienTai = "123456",
                TiepNhan = true,
                KhamBenh = true,
                XetNghiem = true
            };
            LuonCongViecDAO dao = new LuonCongViecDAO();
            string actual = dao.Save(db, luonCongViec);
            string expected = "1111";
            Assert.AreEqual(expected, actual);
        }


        // Test insert TiepNhan is false but KhamBenh &  XetNghiem is true
        [TestMethod]
        public void Insert_TestCase5()
        {
            LUONCONGVIEC luonCongViec = new LUONCONGVIEC
            {
                MaHoSo = TestCommon.LEN_10,
                NodeHienTai = "12345",
                TiepNhan = false,
                KhamBenh = true,
                XetNghiem = true
            };
            LuonCongViecDAO dao = new LuonCongViecDAO();
            string actual = dao.Save(db, luonCongViec);
            string expected = "0000";
            Assert.AreEqual(expected, actual);
        }

        // Test update successes
        [TestMethod]
        public void Update_TestCase6()
        {
            LuonCongViecDAO dao = new LuonCongViecDAO();
            LUONCONGVIEC luonCongViec = new LUONCONGVIEC
            {
                MaHoSo = TestCommon.LEN_10,
                NodeHienTai = "12345",
                TiepNhan = false,
                KhamBenh = false,
                XetNghiem = false
            };
            dao.Save(db, luonCongViec);
            LUONCONGVIEC luonCongViecUpdate = new LUONCONGVIEC
            {
                MaHoSo = TestCommon.LEN_10,
                NodeHienTai = "12345",
                TiepNhan = true,
                KhamBenh = false,
                XetNghiem = false
            };
            string actual = dao.Save(db, luonCongViecUpdate);
            // Biến kết quả
            string expected = "0000";
            // Test 
            Assert.AreEqual(expected, actual);
        }


        // Test update MaHoSo doesn't exist in table HOSOBENHAN
        [TestMethod]
        public void Update_TestCase7()
        {
            LuonCongViecDAO dao = new LuonCongViecDAO();
            LUONCONGVIEC luonCongViec = new LUONCONGVIEC
            {
                MaHoSo = TestCommon.LEN_10,
                NodeHienTai = "12345",
                TiepNhan = false,
                KhamBenh = false,
                XetNghiem = false
            };
            dao.Save(db, luonCongViec);
            LUONCONGVIEC luonCongViecUpdate = new LUONCONGVIEC
            {
                MaHoSo = "1234",
                NodeHienTai = "12345",
                TiepNhan = false,
                KhamBenh = false,
                XetNghiem = false
            };
            string actual = dao.Save(db, luonCongViecUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.AreEqual(expected, actual);
        }


        // Test update max length 
        [TestMethod]
        public void Update_TestCase8()
        {
            LuonCongViecDAO dao = new LuonCongViecDAO();
            LUONCONGVIEC luonCongViec = new LUONCONGVIEC
            {
                MaHoSo = TestCommon.LEN_10,
                NodeHienTai = "12345",
            };
            dao.Save(db, luonCongViec);
            LUONCONGVIEC luonCongViecUpdate = new LUONCONGVIEC
            {
                MaHoSo = TestCommon.LEN_10 + "1",
                NodeHienTai = "123456",
            };
            string actual = dao.Save(db, luonCongViecUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.AreEqual(expected, actual);
        }


        // Test update TiepNhan is false but KhamBenh &  XetNghiem is true
        [TestMethod]
        public void Update_TestCase9()
        {
            LuonCongViecDAO dao = new LuonCongViecDAO();
            LUONCONGVIEC luonCongViec = new LUONCONGVIEC
            {
                MaHoSo = TestCommon.LEN_10,
                NodeHienTai = "12345",
                TiepNhan = false,
                KhamBenh = false,
                XetNghiem = false
            };
            dao.Save(db, luonCongViec);
            LUONCONGVIEC luonCongViecUpdate = new LUONCONGVIEC
            {
                MaHoSo = "1234",
                NodeHienTai = "12345",
                TiepNhan = false,
                KhamBenh = true,
                XetNghiem = true
            };
            string actual = dao.Save(db, luonCongViecUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.AreEqual(expected, actual);
        }


        // Test delete
        [TestMethod]
        public void Delete_TestCase10()
        {
            LUONCONGVIEC luonCongViec = new LUONCONGVIEC
            {
                MaHoSo = TestCommon.LEN_10,
                NodeHienTai = "12345",
                TiepNhan = true,
                KhamBenh = true,
                XetNghiem = true
            };
            LuonCongViecDAO dao = new LuonCongViecDAO();
            dao.Save(db, luonCongViec);
            string actual = dao.Delete(db, luonCongViec);
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
