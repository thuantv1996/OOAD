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
    public class TestLuonCongViecBUS
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
        public void Add_TestCase1()
        {
            LuonCongViecDTO luonCongViecDTO = new LuonCongViecDTO 
            {
                MaHoSo = TestCommon.LEN_10,
                NodeHienTai = "12345",
                TiepNhan = true,
                KhamBenh = true,
                XetNghiem = true
            };
            LuonCongViecBUS luonCongViecBUS = new LuonCongViecBUS();
            string actual = luonCongViecBUS.AddLuonCongViec(db, luonCongViecDTO);
            string expected = "0000";
            Assert.Equals(expected, actual);
        }
        // Test insert MaHoSo is null
        [TestMethod]
        public void Add_TestCase2()
        {
            LuonCongViecDTO luonCongViecDTO = new LuonCongViecDTO
            {
                NodeHienTai = "12345",
                TiepNhan = true,
                KhamBenh = true,
                XetNghiem = true
            };
            LuonCongViecBUS luonCongViecBUS = new LuonCongViecBUS();
            string actual = luonCongViecBUS.AddLuonCongViec(db, luonCongViecDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test insert MaHoSo doesn't exist in table HOSOBENHAN
        [TestMethod]
        public void Add_TestCase3()
        {
            LuonCongViecDTO luonCongViecDTO = new LuonCongViecDTO
            {
                MaHoSo = "123",
                NodeHienTai = "12345",
                TiepNhan = true,
                KhamBenh = true,
                XetNghiem = true
            };
            LuonCongViecBUS luonCongViecBUS = new LuonCongViecBUS();
            string actual = luonCongViecBUS.AddLuonCongViec(db, luonCongViecDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test insert max length 
        [TestMethod]
        public void Add_TestCase4()
        {
            LuonCongViecDTO luonCongViecDTO = new LuonCongViecDTO
            {
                MaHoSo = TestCommon.LEN_10 + "1",
                NodeHienTai = "123456",
                TiepNhan = true,
                KhamBenh = true,
                XetNghiem = true
            };
            LuonCongViecBUS luonCongViecBUS = new LuonCongViecBUS();
            string actual = luonCongViecBUS.AddLuonCongViec(db, luonCongViecDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test insert TiepNhan is false but KhamBenh &  XetNghiem is true
        [TestMethod]
        public void Add_TestCase5()
        {
            LuonCongViecDTO luonCongViecDTO = new LuonCongViecDTO
            {
                MaHoSo = TestCommon.LEN_10,
                NodeHienTai = "12345",
                TiepNhan = false,
                KhamBenh = true,
                XetNghiem = true
            };
            LuonCongViecBUS luonCongViecBUS = new LuonCongViecBUS();
            string actual = luonCongViecBUS.AddLuonCongViec(db, luonCongViecDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test update successes
        [TestMethod]
        public void Update_TestCase1()
        {
            LuonCongViecDTO luonCongViecDTO = new LuonCongViecDTO
            {
                MaHoSo = TestCommon.LEN_10,
                NodeHienTai = "12345",
                TiepNhan = false,
                KhamBenh = false,
                XetNghiem = false
            };
            LuonCongViecBUS luonCongViecBUS = new LuonCongViecBUS();

            LuonCongViecDTO luonCongViecUpdate = new LuonCongViecDTO {
                MaHoSo = TestCommon.LEN_10,
                NodeHienTai = "12345",
                TiepNhan = true,
                KhamBenh = false,
                XetNghiem = false
            };

            string actual = luonCongViecBUS.UpdateLuonCongViec(db, luonCongViecDTO);
            string expected = "0000";
            Assert.Equals(expected, actual);
        }
        // Test update MaHoSo doesn't exist in table HOSOBENHAN
        [TestMethod]
        public void Update_TestCase2()
        {
            LuonCongViecDTO luonCongViecDTO = new LuonCongViecDTO
            {
                MaHoSo = TestCommon.LEN_10,
                NodeHienTai = "12345",
                TiepNhan = false,
                KhamBenh = false,
                XetNghiem = false
            };
            LuonCongViecBUS luonCongViecBUS = new LuonCongViecBUS();

            LuonCongViecDTO luonCongViecUpdate = new LuonCongViecDTO
            {
                MaHoSo = "1234",
                NodeHienTai = "12345",
                TiepNhan = false,
                KhamBenh = false,
                XetNghiem = false
            };

            string actual = luonCongViecBUS.UpdateLuonCongViec(db, luonCongViecDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test update max length 
        [TestMethod]
        public void Update_TestCase3()
        {
            LuonCongViecDTO luonCongViecDTO = new LuonCongViecDTO
            {

                MaHoSo = TestCommon.LEN_10,
                NodeHienTai = "12345",
            };
            LuonCongViecBUS luonCongViecBUS = new LuonCongViecBUS();

            LuonCongViecDTO luonCongViecUpdate = new LuonCongViecDTO
            {
                MaHoSo = TestCommon.LEN_10 + "1",
                NodeHienTai = "123456",
            };

            string actual = luonCongViecBUS.UpdateLuonCongViec(db, luonCongViecDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test update TiepNhan is false but KhamBenh &  XetNghiem is true
        [TestMethod]
        public void Update_TestCase4()
        {
            LuonCongViecDTO luonCongViecDTO = new LuonCongViecDTO
            {
                MaHoSo = TestCommon.LEN_10,
                NodeHienTai = "12345",
                TiepNhan = false,
                KhamBenh = false,
                XetNghiem = false
            };
            LuonCongViecBUS luonCongViecBUS = new LuonCongViecBUS();

            LuonCongViecDTO luonCongViecUpdate = new LuonCongViecDTO
            {
                MaHoSo = "1234",
                NodeHienTai = "12345",
                TiepNhan = false,
                KhamBenh = true,
                XetNghiem = true
            };

            string actual = luonCongViecBUS.UpdateLuonCongViec(db, luonCongViecDTO);
            string expected = "1111";
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
