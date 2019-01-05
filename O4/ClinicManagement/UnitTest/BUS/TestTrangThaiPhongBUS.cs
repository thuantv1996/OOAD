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
    public class TestTrangThaiPhongBUS
    {
        private static QLPHONGKHAMEntities db;
        private static DbContextTransaction trans;
        // init method
        [TestInitialize]
        public void Init()
        {
            db = new QLPHONGKHAMEntities();
            trans = db.Database.BeginTransaction();
            db.PHONGs.Add(new PHONG { MaPhong = TestCommon.LEN_10 });
        }
        /* BEGIN TEST METHOD */
        // Test update success
        [TestMethod]
        public void Update_TestCase1()
        {
            
            TrangThaiPhongDTO trangThaiPhongDTO = new TrangThaiPhongDTO
            {
                MaPhong = TestCommon.LEN_10,
                NgayKham = TestCommon.LEN_8,
                SttCaoNhat = 1,
            };
            TrangThaiPhongBUS trangThaiPhongBUS = new TrangThaiPhongBUS();
            trangThaiPhongBUS.UpdateTrangThaiPhong(db, trangThaiPhongDTO);

            TrangThaiPhongDTO trangThaiPhongUpdate = new TrangThaiPhongDTO
            {
                MaPhong = TestCommon.LEN_10,
                NgayKham = TestCommon.LEN_8,
                SttCaoNhat = 2,
            };
            string actual = trangThaiPhongBUS.UpdateTrangThaiPhong(db, trangThaiPhongUpdate);
            // Biến kết quả
            string expected = "0000";
            // Test 
            Assert.Equals(expected, actual);
        }

        // Test update NgayKham or MaPhong is null
        [TestMethod]
        public void Update_TestCase2()
        {
            TrangThaiPhongDTO trangThaiPhongDTO = new TrangThaiPhongDTO
            {
                MaPhong = TestCommon.LEN_10,
                NgayKham = TestCommon.LEN_8,
                SttCaoNhat = 1,
            };
            TrangThaiPhongBUS trangThaiPhongBUS = new TrangThaiPhongBUS();
            trangThaiPhongBUS.UpdateTrangThaiPhong(db, trangThaiPhongDTO);

            TrangThaiPhongDTO trangThaiPhongUpdate = new TrangThaiPhongDTO
            {
                SttCaoNhat = 2,
            };
            string actual = trangThaiPhongBUS.UpdateTrangThaiPhong(db, trangThaiPhongUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }
        // Test update max lenght string
        [TestMethod]
        public void Update_TestCase3()
        {
            TrangThaiPhongDTO trangThaiPhongDTO = new TrangThaiPhongDTO
            {
                MaPhong = TestCommon.LEN_10,
                NgayKham = TestCommon.LEN_8,
                SttCaoNhat = 1,
            };
            TrangThaiPhongBUS trangThaiPhongBUS = new TrangThaiPhongBUS();
            trangThaiPhongBUS.UpdateTrangThaiPhong(db, trangThaiPhongDTO);

            TrangThaiPhongDTO trangThaiPhongUpdate = new TrangThaiPhongDTO
            {
                MaPhong = TestCommon.LEN_10 + "1",
                NgayKham = TestCommon.LEN_8 + "1",
                SttCaoNhat = 2,
            };
            string actual = trangThaiPhongBUS.UpdateTrangThaiPhong(db, trangThaiPhongUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }
        // Test update MaPhong doesn't exist in table PHONG
        [TestMethod]
        public void Update_TestCase4()
        {
            TrangThaiPhongDTO trangThaiPhongDTO = new TrangThaiPhongDTO
            {
                MaPhong = TestCommon.LEN_10,
                NgayKham = TestCommon.LEN_8,
                SttCaoNhat = 1,
            };
            TrangThaiPhongBUS trangThaiPhongBUS = new TrangThaiPhongBUS();
            trangThaiPhongBUS.UpdateTrangThaiPhong(db, trangThaiPhongDTO);

            TrangThaiPhongDTO trangThaiPhongUpdate = new TrangThaiPhongDTO
            {
                MaPhong = "1234",
                NgayKham = TestCommon.LEN_8,
                SttCaoNhat = 2,
            };
            string actual = trangThaiPhongBUS.UpdateTrangThaiPhong(db, trangThaiPhongUpdate);
            // Biến kết quả
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }

        //Test get trang thai phong success
        [TestMethod]
        public void GetTrangThaiPhong_TestCase1()
        {
            // create data search
            db.TRANGTHAIPHONGs.Add(new TRANGTHAIPHONG{ MaPhong = "1234567890", NgayKham = "10122018" });
            db.TRANGTHAIPHONGs.Add(new TRANGTHAIPHONG { MaPhong = "1234567891", NgayKham = "11122018" });
            db.TRANGTHAIPHONGs.Add(new TRANGTHAIPHONG { MaPhong = "1234567892", NgayKham = "12122018" });

            TrangThaiPhongDTO trangThaiPhongDTO = null;

            TrangThaiPhongBUS trangThaiPhongBUS = new TrangThaiPhongBUS();

            string actual = trangThaiPhongBUS.GetTrangThaiPhong(db, "1234567890", "10122018", out trangThaiPhongDTO);
            string expected = "0000";
            Assert.Equals(actual, expected);

        }

        [TestMethod]
        public void GetTrangThaiPhong_TestCase2()
        {
            TrangThaiPhongDTO trangThaiPhongDTO = null;

            TrangThaiPhongBUS trangThaiPhongBUS = new TrangThaiPhongBUS();

            string actual = trangThaiPhongBUS.GetTrangThaiPhong(db, "1234567890", "10122018",out trangThaiPhongDTO);
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
