using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO;
using System.Data.Entity;
using DAO;
using BUS.Imp;
using BUS.Entities;
using System.Collections.Generic;
namespace UnitTest.BUS
{
    [TestClass]
    public class TestThanhToanBUS
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
            ThanhToanDTO thanhToanDTO = new ThanhToanDTO
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                ChiPhiKham = 100000000000,
                ChiPhiXetNghiem = 100000000000,
                TongChiPhi = 200000000000,
                NhanVienThu = TestCommon.LEN_10,
                NgayThu = TestCommon.LEN_8
            };

            ThanhToanBUS thanhToanBUS = new ThanhToanBUS();
            string actual = thanhToanBUS.InsertThanhToan(db, thanhToanDTO);
            string expected = "0000";
            Assert.Equals(expected, actual);
        }
        // Test insert MaHoSo is null
        [TestMethod]
        public void Insert_TestCase2()
        {
            ThanhToanDTO thanhToanDTO = new ThanhToanDTO
            {
                MaThanhToan = TestCommon.LEN_10,
            };

            ThanhToanBUS thanhToanBUS = new ThanhToanBUS();
            string actual = thanhToanBUS.InsertThanhToan(db, thanhToanDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test insert ChiPhi is negative
        [TestMethod]
        public void Insert_TestCase3()
        {
            ThanhToanDTO thanhToanDTO = new ThanhToanDTO
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                ChiPhiKham = -100000000000,
                ChiPhiXetNghiem = -100000000000,
                TongChiPhi = -200000000000,
            };

            ThanhToanBUS thanhToanBUS = new ThanhToanBUS();
            string actual = thanhToanBUS.InsertThanhToan(db, thanhToanDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test insert max length
        [TestMethod]
        public void Insert_TestCase4()
        {
            ThanhToanDTO thanhToanDTO = new ThanhToanDTO
            {
                MaThanhToan = TestCommon.LEN_10 + "1",
                MaHoSo = TestCommon.LEN_10 + "1",
                ChiPhiKham = 1000000000001,
                ChiPhiXetNghiem = 1000000000001,
                TongChiPhi = 2000000000002,
                NhanVienThu = TestCommon.LEN_10 + "1",
                NgayThu = TestCommon.LEN_8 + "1"
            };

            ThanhToanBUS thanhToanBUS = new ThanhToanBUS();
            string actual = thanhToanBUS.InsertThanhToan(db, thanhToanDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test insert with MaHoSo doesn't exist in table HOSOBENHAN
        [TestMethod]
        public void Insert_TestCase5()
        {
            ThanhToanDTO thanhToanDTO = new ThanhToanDTO
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = "123",
            };

            ThanhToanBUS thanhToanBUS = new ThanhToanBUS();
            string actual = thanhToanBUS.InsertThanhToan(db, thanhToanDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test update success
        [TestMethod]
        public void Update_TestCase1()
        {
            ThanhToanDTO thanhToanDTO = new ThanhToanDTO
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                ChiPhiKham = 1,
                ChiPhiXetNghiem = 1,
                TongChiPhi = 2,
                NhanVienThu = TestCommon.LEN_10,
                NgayThu = TestCommon.LEN_8
            };

            ThanhToanBUS thanhToanBUS = new ThanhToanBUS();

            thanhToanBUS.InsertThanhToan(db, thanhToanDTO);

            ThanhToanDTO thanhtoanUpdate = new ThanhToanDTO
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                ChiPhiKham = 1,
                ChiPhiXetNghiem = 1,
                TongChiPhi = 2,
                NhanVienThu = "1234",
                NgayThu = TestCommon.LEN_8
            };

            string actual = thanhToanBUS.UpdateThanhToan(db, thanhtoanUpdate);
            string expected = "0000";
            Assert.Equals(expected, actual);
        }

        // Test update MaHoSo is null
        [TestMethod]
        public void Update_TestCase2()
        {
            ThanhToanDTO thanhToanDTO = new ThanhToanDTO
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
            };

            ThanhToanBUS thanhToanBUS = new ThanhToanBUS();

            thanhToanBUS.InsertThanhToan(db, thanhToanDTO);

            ThanhToanDTO thanhtoanUpdate = new ThanhToanDTO
            {
                MaThanhToan = TestCommon.LEN_10,
            };

            string actual = thanhToanBUS.UpdateThanhToan(db, thanhtoanUpdate);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test update ChiPhi is negative
        [TestMethod]
        public void Update_TestCase3()
        {
            ThanhToanDTO thanhToanDTO = new ThanhToanDTO
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                ChiPhiKham = 1,
                ChiPhiXetNghiem = 1,
                TongChiPhi = 2,
            };

            ThanhToanBUS thanhToanBUS = new ThanhToanBUS();

            thanhToanBUS.InsertThanhToan(db, thanhToanDTO);

            ThanhToanDTO thanhtoanUpdate = new ThanhToanDTO
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                ChiPhiKham = -1,
                ChiPhiXetNghiem = -1,
                TongChiPhi = -2,
            };

            string actual = thanhToanBUS.UpdateThanhToan(db, thanhtoanUpdate);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test update max lenght
        [TestMethod]
        public void Update_TestCase4()
        {
            ThanhToanDTO thanhToanDTO = new ThanhToanDTO
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                ChiPhiKham = 1,
                ChiPhiXetNghiem = 1,
                TongChiPhi = 2,
                NhanVienThu = TestCommon.LEN_10,
                NgayThu = TestCommon.LEN_8
            };

            ThanhToanBUS thanhToanBUS = new ThanhToanBUS();

            thanhToanBUS.InsertThanhToan(db, thanhToanDTO);

            ThanhToanDTO thanhtoanUpdate = new ThanhToanDTO
            {
                MaThanhToan = TestCommon.LEN_10 + "1",
                MaHoSo = TestCommon.LEN_10 + "1",
                ChiPhiKham = 1111111111111,
                ChiPhiXetNghiem = 1111111111111,
                TongChiPhi = 22222222222222,
                NhanVienThu = TestCommon.LEN_10 + "1",
                NgayThu = TestCommon.LEN_8 + "1"
            };

            string actual = thanhToanBUS.UpdateThanhToan(db, thanhtoanUpdate);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test update with MaHoSo doesn't exist in table HOSOBENHAN
        [TestMethod]
        public void Update_TestCase5()
        {
            ThanhToanDTO thanhToanDTO = new ThanhToanDTO
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
            };

            ThanhToanBUS thanhToanBUS = new ThanhToanBUS();

            thanhToanBUS.InsertThanhToan(db, thanhToanDTO);

            ThanhToanDTO thanhtoanUpdate = new ThanhToanDTO
            {
                MaThanhToan = TestCommon.LEN_10,
                MaHoSo = "123"
            };

            string actual = thanhToanBUS.UpdateThanhToan(db, thanhtoanUpdate);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        //get thanh toan success
        [TestMethod]
        public void GetThanhToan_TestCase1()
        {
            // create data search
            db.THANHTOANs.Add(new THANHTOAN { MaHoSo = "1234567890" });
            db.THANHTOANs.Add(new THANHTOAN { MaHoSo = "1234567891" });
            db.THANHTOANs.Add(new THANHTOAN { MaHoSo = "1234567892" });

            ThanhToanDTO thanhToanDTO = null;

            ThanhToanBUS thanhToanBUS = new ThanhToanBUS();

            string actual = thanhToanBUS.GetThanhToan(db, "1234567890", out thanhToanDTO);
            string expected = "0000";
            Assert.Equals(actual, expected);

        }
        [TestMethod]
        public void GetThanhToan_TestCase2()
        {
            ThanhToanDTO thanhToanDTO = null;

            ThanhToanBUS thanhToanBUS = new ThanhToanBUS();

            string actual = thanhToanBUS.GetThanhToan(db, "1234567890", out thanhToanDTO);
            string expected = "1111";
            Assert.Equals(actual, expected);
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
