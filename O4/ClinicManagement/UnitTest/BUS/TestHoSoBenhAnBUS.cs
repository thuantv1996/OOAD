using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO;
using System.Data.Entity;
using DAO;
using BUS.Imp;
using BUS.Entities;
using System.Collections.Generic;

namespace UnitTest.BUS
{
    public class TestHoSoBenhAnBUS
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
        public void Add_TestCase1()
        {
            HoSoBenhAnDTO hoSoBenhAnDTO = new HoSoBenhAnDTO {
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
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();

            string actual = hoSoBenhAnBUS.AddHoSoBenhAn(db, hoSoBenhAnDTO);
            string expected = "0000";
            Assert.Equals(expected, actual);

        }
        // Test insert max length
        [TestMethod]
        public void Add_TestCase2()
        {
            HoSoBenhAnDTO hoSoBenhAnDTO = new HoSoBenhAnDTO
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
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();

            string actual = hoSoBenhAnBUS.AddHoSoBenhAn(db, hoSoBenhAnDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test insert with MaLoaiHoSo, MaBenhNhan, MaNguoiTN is null
        [TestMethod]
        public void Add_TestCase3()
        {
            HoSoBenhAnDTO hoSoBenhAnDTO = new HoSoBenhAnDTO
            {
                MaHoSo = TestCommon.LEN_10,
            };
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();

            string actual = hoSoBenhAnBUS.AddHoSoBenhAn(db, hoSoBenhAnDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test insert with MaLoaiHoSo, MaBenhNhan, MaNguoiTN, MaPhongKham, MaBacSi doesn't exist in table
        [TestMethod]
        public void Add_TestCase4()
        {
            HoSoBenhAnDTO hoSoBenhAnDTO = new HoSoBenhAnDTO
            {
                MaHoSo = TestCommon.LEN_10,
                MaLoaiHoSo = "1234",
                MaBenhNhan = "1234",
                MaNguoiTN = "1234",
                MaPhongKham = "1234",
                MaBacSi = "1234",
            };
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();

            string actual = hoSoBenhAnBUS.AddHoSoBenhAn(db, hoSoBenhAnDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test insert with SoThuTu is negative
        [TestMethod]
        public void Add_TestCase5()
        {
            HoSoBenhAnDTO hoSoBenhAnDTO = new HoSoBenhAnDTO
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
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();

            string actual = hoSoBenhAnBUS.AddHoSoBenhAn(db, hoSoBenhAnDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test search success
        [TestMethod]
        public void Search_TestCase1()
        {
            // create data search
            db.HOSOBENHANs.Add(new HOSOBENHAN { MaHoSo = "1234567890", NgayKham = "12122010" });
            db.HOSOBENHANs.Add(new HOSOBENHAN { MaHoSo = "1234567891", NgayKham = "12122011" });
            db.HOSOBENHANs.Add(new HOSOBENHAN { MaHoSo = "1234567892", NgayKham = "12122012" });
            

            // create object search
            HoSoSearchEntity hoSoSearchEntity = new HoSoSearchEntity
            {
                MaHoSo = "12345678",
                TenBenhNhan = "",
                NgayKham = ""
            };
            List<HoSoBenhAnDTO> listResult = null;
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();

           
            // execute
            string actual = hoSoBenhAnBUS.SearchHoSo(db, hoSoSearchEntity, out listResult);
            string expected = "0000";
            // compare
            Assert.Equals(actual, expected);
        }
        // Test seatch with data null
        [TestMethod]
        public void Search_TestCase2()
        {
            
            // create object search
            HoSoSearchEntity hoSoSearchEntity = new HoSoSearchEntity
            {
                MaHoSo = "12345678",
                TenBenhNhan = "",
                NgayKham = ""
            };
            List<HoSoBenhAnDTO> listResult = null;
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();


            // execute
            string actual = hoSoBenhAnBUS.SearchHoSo(db, hoSoSearchEntity, out listResult);
            string expected = "1111";
            // compare
            Assert.Equals(actual, expected);
        }
        // Test update success
        [TestMethod]
        public void Update_TestCase1()
        {
            HoSoBenhAnDTO hoSoBenhAnDTO = new HoSoBenhAnDTO
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

            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            hoSoBenhAnBUS.AddHoSoBenhAn(db, hoSoBenhAnDTO);

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
            string actual = hoSoBenhAnBUS.UpdateHoSoBenhAn(db, hoSoBenhAnDTO);
            string expected = "0000";
            Assert.Equals(expected, actual);

        }
        // Test update max length
        [TestMethod]
        public void Update_TestCase2()
        {
            HoSoBenhAnDTO hoSoBenhAnDTO = new HoSoBenhAnDTO
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

            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            hoSoBenhAnBUS.AddHoSoBenhAn(db, hoSoBenhAnDTO);

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
            string actual = hoSoBenhAnBUS.UpdateHoSoBenhAn(db, hoSoBenhAnDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }

        // Test update with MaLoaiHoSo, MaBenhNhan, MaNguoiTN is null
        [TestMethod]
        public void Update_TestCase3()
        {
            HoSoBenhAnDTO hoSoBenhAnDTO = new HoSoBenhAnDTO
            {
                MaHoSo = TestCommon.LEN_10,
                MaLoaiHoSo = TestCommon.LEN_10,
                MaBenhNhan = TestCommon.LEN_10,
            };

            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            hoSoBenhAnBUS.AddHoSoBenhAn(db, hoSoBenhAnDTO);

            HOSOBENHAN hoSoBenhAnUpdate = new HOSOBENHAN
            {
                MaHoSo = TestCommon.LEN_10,
            };
            string actual = hoSoBenhAnBUS.UpdateHoSoBenhAn(db, hoSoBenhAnDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test update with MaLoaiHoSo, MaBenhNhan, MaNguoiTN, MaPhongKham, MaBacSi doesn't exist in table
        [TestMethod]
        public void Update_TestCase4()
        {
            HoSoBenhAnDTO hoSoBenhAnDTO = new HoSoBenhAnDTO
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

            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            hoSoBenhAnBUS.AddHoSoBenhAn(db, hoSoBenhAnDTO);

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
            string actual = hoSoBenhAnBUS.UpdateHoSoBenhAn(db, hoSoBenhAnDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test update with SoThuTu is negative
        [TestMethod]
        public void Update_TestCase5()
        {
            HoSoBenhAnDTO hoSoBenhAnDTO = new HoSoBenhAnDTO
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

            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            hoSoBenhAnBUS.AddHoSoBenhAn(db, hoSoBenhAnDTO);

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
            string actual = hoSoBenhAnBUS.UpdateHoSoBenhAn(db, hoSoBenhAnDTO);
            string expected = "1111";
            Assert.Equals(expected, actual);
        }
        // Test delete sucesses
        [TestMethod]
        public void Delete_TestCase1()
        {

            HoSoBenhAnDTO hoSoBenhAnDTO = new HoSoBenhAnDTO
            {
                MaHoSo = TestCommon.LEN_10,
                MaHoSoTruoc = TestCommon.LEN_10,
                MaHoSoGoc = TestCommon.LEN_10,
                MaLoaiHoSo = TestCommon.LEN_10,
                MaBenhNhan = TestCommon.LEN_10,
                MaNguoiTN = TestCommon.LEN_10,
            };
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            string actual = hoSoBenhAnBUS.AddHoSoBenhAn(db, hoSoBenhAnDTO );
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
