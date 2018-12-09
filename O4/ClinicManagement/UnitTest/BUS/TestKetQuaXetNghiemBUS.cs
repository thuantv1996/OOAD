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
    public class TestKetQuaXetNghiemBUS
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
        public void Add_TestCase1()
        {
            KetQuaXetNghiemDTO ketQuaXetNghiemDTO = new KetQuaXetNghiemDTO {
                MaHoSo = TestCommon.LEN_10,
                MaXetNghiem = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
                NgayXetNghiem = TestCommon.LEN_8,
                KetQua = "abc",
                ThanhToan = true,
                TongChiPhi = 1000
            };
            KetQuaXetNghiemBUS ketQuaXetNghiemBUS = new KetQuaXetNghiemBUS();

            string actual = ketQuaXetNghiemBUS.AddKetQuaXetNghiem(db, ketQuaXetNghiemDTO) ;
            string expected = "0000";
            Assert.Equals(expected, actual);

        }
        // Test insert max length
        [TestMethod]
        public void Add_TestCase2()
        {
            KetQuaXetNghiemDTO ketQuaXetNghiemDTO = new KetQuaXetNghiemDTO
            {
                MaHoSo = TestCommon.LEN_10 + "1",
                MaXetNghiem = TestCommon.LEN_10 + "1",
                MaBacSi = TestCommon.LEN_10 + "1",
                NgayXetNghiem = TestCommon.LEN_8 + "1",
                KetQua = "abc",
                ThanhToan = true,
                TongChiPhi = 1000000000000
            };
            KetQuaXetNghiemBUS ketQuaXetNghiemBUS = new KetQuaXetNghiemBUS();

            string actual = ketQuaXetNghiemBUS.AddKetQuaXetNghiem(db, ketQuaXetNghiemDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test insert with MaHoSo & MaXetNghiem is null
        [TestMethod]
        public void Add_TestCase3()
        {
            KetQuaXetNghiemDTO ketQuaXetNghiemDTO = new KetQuaXetNghiemDTO
            {
                MaBacSi = TestCommon.LEN_10,
                NgayXetNghiem = TestCommon.LEN_8,
                KetQua = "abc",
                ThanhToan = true,
                TongChiPhi = 1000
            };
            KetQuaXetNghiemBUS ketQuaXetNghiemBUS = new KetQuaXetNghiemBUS();

            string actual = ketQuaXetNghiemBUS.AddKetQuaXetNghiem(db, ketQuaXetNghiemDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test insert with MaHoSo or MaXetNghiem doesn't exist in table HOSOBENHAN, XETNGHIEM
        [TestMethod]
        public void Add_TestCase4()
        {
            KetQuaXetNghiemDTO ketQuaXetNghiemDTO = new KetQuaXetNghiemDTO
            {
                MaHoSo = "123",
                MaXetNghiem = "123",
                MaBacSi = TestCommon.LEN_10,
                NgayXetNghiem = TestCommon.LEN_8,
                KetQua = "abc",
                ThanhToan = true,
                TongChiPhi = 1000
            };
            KetQuaXetNghiemBUS ketQuaXetNghiemBUS = new KetQuaXetNghiemBUS();

            string actual = ketQuaXetNghiemBUS.AddKetQuaXetNghiem(db, ketQuaXetNghiemDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test update success
        [TestMethod]
        public void Update_TestCase1()
        {
            KetQuaXetNghiemDTO ketQuaXetNghiemDTO = new KetQuaXetNghiemDTO
            {
                MaHoSo = TestCommon.LEN_10,
                MaXetNghiem = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
                NgayXetNghiem = TestCommon.LEN_8,
                KetQua = "abc",
                ThanhToan = false,
                TongChiPhi = 1000
            };
            KetQuaXetNghiemBUS ketQuaXetNghiemBUS = new KetQuaXetNghiemBUS();

            ketQuaXetNghiemBUS.AddKetQuaXetNghiem(db, ketQuaXetNghiemDTO);

            KetQuaXetNghiemDTO ketQuaXetNghiemUpdate = new KetQuaXetNghiemDTO
            {
                MaHoSo = TestCommon.LEN_10,
                MaXetNghiem = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
                NgayXetNghiem = TestCommon.LEN_8,
                KetQua = "TEST UPDATE",
                ThanhToan = true,
                TongChiPhi = 1000
            };


            string actual = ketQuaXetNghiemBUS.UpdateKetQuaXetNghiem(db, ketQuaXetNghiemDTO);
            string expected = "0000";
            Assert.Equals(expected, actual);
        }
        // Test update max length
        [TestMethod]
        public void Update_TestCase2()
        {
            KetQuaXetNghiemDTO ketQuaXetNghiemDTO = new KetQuaXetNghiemDTO
            {
                MaHoSo = TestCommon.LEN_10,
                MaXetNghiem = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
                NgayXetNghiem = TestCommon.LEN_8,
                KetQua = "abc",
                ThanhToan = false,
                TongChiPhi = 1000
            };
            KetQuaXetNghiemBUS ketQuaXetNghiemBUS = new KetQuaXetNghiemBUS();

            ketQuaXetNghiemBUS.AddKetQuaXetNghiem(db, ketQuaXetNghiemDTO);

            KetQuaXetNghiemDTO ketQuaXetNghiemUpdate = new KetQuaXetNghiemDTO
            {
                MaHoSo = TestCommon.LEN_10 + "1",
                MaXetNghiem = TestCommon.LEN_10 + "1",
                MaBacSi = TestCommon.LEN_10 + "1",
                NgayXetNghiem = TestCommon.LEN_8 + "1",
                KetQua = "TEST UPDATE",
                ThanhToan = true,
                TongChiPhi = 10000000000000
            };


            string actual = ketQuaXetNghiemBUS.UpdateKetQuaXetNghiem(db, ketQuaXetNghiemDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test update with MaHoSo & MaXetNghiem is null
        [TestMethod]
        public void Update_TestCase3()
        {
            KetQuaXetNghiemDTO ketQuaXetNghiemDTO = new KetQuaXetNghiemDTO
            {
                MaHoSo = TestCommon.LEN_10,
                MaXetNghiem = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
            };
            KetQuaXetNghiemBUS ketQuaXetNghiemBUS = new KetQuaXetNghiemBUS();

            ketQuaXetNghiemBUS.AddKetQuaXetNghiem(db, ketQuaXetNghiemDTO);

            KetQuaXetNghiemDTO ketQuaXetNghiemUpdate = new KetQuaXetNghiemDTO
            {
                MaBacSi = TestCommon.LEN_10
            };


            string actual = ketQuaXetNghiemBUS.UpdateKetQuaXetNghiem(db, ketQuaXetNghiemDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test update with MaHoSo or MaXetNghiem doesn't exist in table HOSOBENHAN, XETNGHIEM
        [TestMethod]
        public void Update_TestCase4()
        {
            KetQuaXetNghiemDTO ketQuaXetNghiemDTO = new KetQuaXetNghiemDTO
            {
                MaHoSo = TestCommon.LEN_10,
                MaXetNghiem = TestCommon.LEN_10,
                MaBacSi = TestCommon.LEN_10,
                NgayXetNghiem = TestCommon.LEN_8,
                KetQua = "abc",
                ThanhToan = false,
                TongChiPhi = 1000
            };
            KetQuaXetNghiemBUS ketQuaXetNghiemBUS = new KetQuaXetNghiemBUS();

            ketQuaXetNghiemBUS.AddKetQuaXetNghiem(db, ketQuaXetNghiemDTO);

            KetQuaXetNghiemDTO ketQuaXetNghiemUpdate = new KetQuaXetNghiemDTO
            {
                MaHoSo = "123",
                MaXetNghiem = "123",
                MaBacSi = TestCommon.LEN_10,
                NgayXetNghiem = TestCommon.LEN_8,
                KetQua = "TEST UPDATE",
                ThanhToan = true,
                TongChiPhi = 1000
            };


            string actual = ketQuaXetNghiemBUS.UpdateKetQuaXetNghiem(db, ketQuaXetNghiemDTO);
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
