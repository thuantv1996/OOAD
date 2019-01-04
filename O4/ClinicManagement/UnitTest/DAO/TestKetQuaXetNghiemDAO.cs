using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DAO.Implement;
using System.Data.Entity;

namespace UnitTest.DAO
{
    [TestClass]
    public class TestKetQuaXetNghiemDAO
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
            db.XETNGHIEMs.Add(new XETNGHIEM { MaXetNghiem = TestCommon.LEN_10 });
        }

        /* BEGIN TEST METHOD */

        // Test insert data sucesses
        [TestMethod]
        public void Insert_TestCase1()
        {
            KETQUAXETNGHIEM ketQuaXetNghiem = new KETQUAXETNGHIEM
            {
                MaHoSo = TestCommon.LEN_10,
                MaXetNghiem = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
                NgayXetNghiem = TestCommon.LEN_8,
                KetQua = "abc",
                ThanhToan = true,
                TongChiPhi = 1000
            };
            KetQuaXetNghiemDAO dao = new KetQuaXetNghiemDAO();
            string actual = dao.Save(db, ketQuaXetNghiem);
            string expected = "0000";
            Assert.Equals(expected, actual);
        }


        // Test insert max length
        [TestMethod]
        public void Insert_TestCase2()
        {
            KETQUAXETNGHIEM ketQuaXetNghiem = new KETQUAXETNGHIEM
            {
                MaHoSo = TestCommon.LEN_10 + "1",
                MaXetNghiem = TestCommon.LEN_10 + "1",
                MaBacSi = TestCommon.LEN_10 + "1",
                NgayXetNghiem = TestCommon.LEN_8 + "1",
                KetQua = "abc",
                ThanhToan = true,
                TongChiPhi = 1000000000000
            };
            KetQuaXetNghiemDAO dao = new KetQuaXetNghiemDAO();
            string actual = dao.Save(db, ketQuaXetNghiem);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }


        // Test insert with MaHoSo & MaXetNghiem is null
        [TestMethod]
        public void Insert_TestCase3()
        {
            KETQUAXETNGHIEM ketQuaXetNghiem = new KETQUAXETNGHIEM
            {
                MaBacSi = TestCommon.LEN_10,
                NgayXetNghiem = TestCommon.LEN_8,
                KetQua = "abc",
                ThanhToan = true,
                TongChiPhi = 1000
            };
            KetQuaXetNghiemDAO dao = new KetQuaXetNghiemDAO();
            string actual = dao.Save(db, ketQuaXetNghiem);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }


        // Test insert with MaHoSo or MaXetNghiem doesn't exist in table HOSOBENHAN, XETNGHIEM
        [TestMethod]
        public void Insert_TestCase4()
        {
            KETQUAXETNGHIEM ketQuaXetNghiem = new KETQUAXETNGHIEM
            {
                MaHoSo = "123",
                MaXetNghiem = "123",
                MaBacSi = TestCommon.LEN_10,
                NgayXetNghiem = TestCommon.LEN_8,
                KetQua = "abc",
                ThanhToan = true,
                TongChiPhi = 1000
            };
            KetQuaXetNghiemDAO dao = new KetQuaXetNghiemDAO();
            string actual = dao.Save(db, ketQuaXetNghiem);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }


        // Test update success
        [TestMethod]
        public void Update_TestCase5()
        {
            KetQuaXetNghiemDAO dao = new KetQuaXetNghiemDAO();
            KETQUAXETNGHIEM ketQuaXetNghiem = new KETQUAXETNGHIEM
            {
                MaHoSo = TestCommon.LEN_10,
                MaXetNghiem = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
                NgayXetNghiem = TestCommon.LEN_8,
                KetQua = "abc",
                ThanhToan = false,
                TongChiPhi = 1000
            };
            dao.Save(db, ketQuaXetNghiem);
            KETQUAXETNGHIEM ketQuaXetNghiemUpdate = new KETQUAXETNGHIEM
            {
                MaHoSo = TestCommon.LEN_10,
                MaXetNghiem = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
                NgayXetNghiem = TestCommon.LEN_8,
                KetQua = "TEST UPDATE",
                ThanhToan = true,
                TongChiPhi = 1000
            };
            string actual = dao.Save(db, ketQuaXetNghiemUpdate);
            // Biến kết quả
            string expected = "0000";
            // Test 
            Assert.Equals(expected, actual);
        }

        // Test update max length
        [TestMethod]
        public void Update_TestCase6()
        {
            KetQuaXetNghiemDAO dao = new KetQuaXetNghiemDAO();
            KETQUAXETNGHIEM ketQuaXetNghiem = new KETQUAXETNGHIEM
            {
                MaHoSo = TestCommon.LEN_10,
                MaXetNghiem = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
                NgayXetNghiem = TestCommon.LEN_8,
                KetQua = "abc",
                ThanhToan = false,
                TongChiPhi = 1000
            };
            dao.Save(db, ketQuaXetNghiem);
            KETQUAXETNGHIEM ketQuaXetNghiemUpdate = new KETQUAXETNGHIEM
            {
                MaHoSo = TestCommon.LEN_10 + "1",
                MaXetNghiem = TestCommon.LEN_10 + "1",
                MaBacSi = TestCommon.LEN_10 + "1",
                NgayXetNghiem = TestCommon.LEN_8 + "1",
                KetQua = "TEST UPDATE",
                ThanhToan = true,
                TongChiPhi = 10000000000000
            };
            string actual = dao.Save(db, ketQuaXetNghiemUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }


        // Test update with MaHoSo & MaXetNghiem is null
        [TestMethod]
        public void Update_TestCase7()
        {
            KetQuaXetNghiemDAO dao = new KetQuaXetNghiemDAO();
            KETQUAXETNGHIEM ketQuaXetNghiem = new KETQUAXETNGHIEM
            {
                MaHoSo = TestCommon.LEN_10,
                MaXetNghiem = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
            };
            dao.Save(db, ketQuaXetNghiem);
            KETQUAXETNGHIEM ketQuaXetNghiemUpdate = new KETQUAXETNGHIEM
            {
                MaBacSi = TestCommon.LEN_10
            };
            string actual = dao.Save(db, ketQuaXetNghiemUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }

        // Test update with MaHoSo or MaXetNghiem doesn't exist in table HOSOBENHAN, XETNGHIEM
        [TestMethod]
        public void Update_TestCase8()
        {
            KetQuaXetNghiemDAO dao = new KetQuaXetNghiemDAO();
            KETQUAXETNGHIEM ketQuaXetNghiem = new KETQUAXETNGHIEM
            {
                MaHoSo = TestCommon.LEN_10,
                MaXetNghiem = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
                NgayXetNghiem = TestCommon.LEN_8,
                KetQua = "abc",
                ThanhToan = false,
                TongChiPhi = 1000
            };
            dao.Save(db, ketQuaXetNghiem);
            KETQUAXETNGHIEM ketQuaXetNghiemUpdate = new KETQUAXETNGHIEM
            {
                MaHoSo = "123",
                MaXetNghiem = "123",
                MaBacSi = TestCommon.LEN_10,
                NgayXetNghiem = TestCommon.LEN_8,
                KetQua = "TEST UPDATE",
                ThanhToan = true,
                TongChiPhi = 1000
            };
            string actual = dao.Save(db, ketQuaXetNghiemUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }


        // Test delete sucesses
        [TestMethod]
        public void Delete_TestCase9()
        {
            KETQUAXETNGHIEM ketQuaXetNghiem = new KETQUAXETNGHIEM
            {
                MaHoSo = TestCommon.LEN_10,
                MaXetNghiem = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
            };
            KetQuaXetNghiemDAO dao = new KetQuaXetNghiemDAO();
            dao.Save(db, ketQuaXetNghiem);
            string actual = dao.Delete(db, ketQuaXetNghiem);
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
