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
    public class TestBenhNhanBUS
    {
        private static QLPHONGKHAMEntities db;
        private static DbContextTransaction trans;
        //init method
        [TestInitialize]
        public void Init()
        {
            db = new QLPHONGKHAMEntities();
            trans = db.Database.BeginTransaction(); 
        }
        [TestMethod]
        public void Insert_TestCase1()
        {
            BenhNhanDTO benhNhanDTO = new BenhNhanDTO  { MaBenhNhan = "1234567899",
                                                         HoTen = "Nguyen Van A",
                                                         CMND ="2000900",
                                                         NgaySinh ="18091997",
                                                         GioiTinh = true,
                                                         SoDienThoai="0913857555",
                                                         DiaChi = "Ho Chi Minh",
                                                         GhiChu = "Khong co"};
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            string actual = benhNhanBUS.InsertBenhNhan(db, benhNhanDTO);
            string expected = "0000";
            Assert.Equals(actual, expected);
        }
        [TestMethod]
        public void Insert_TestCase2()
        {
            BenhNhanDTO benhNhanDTO = new BenhNhanDTO  { MaBenhNhan = "1234567899"  };
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            string actual = benhNhanBUS.InsertBenhNhan(db, benhNhanDTO);
            string expected = "1111";
            Assert.Equals(actual, expected);
        }
        [TestMethod]
        public void Insert_TestCase3()
        {
            BenhNhanDTO benhNhanDTO = new BenhNhanDTO { MaBenhNhan = "1234567899",
                                                        HoTen = "12345678901234567890123456789012345678901234567890",
                                                        CMND ="2000900000000",
                                                        NgaySinh ="180919979",
                                                        GioiTinh = true,
                                                        SoDienThoai="091385755555",
                                                        DiaChi = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890",
                                                        GhiChu = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890"
            };
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            string actual = benhNhanBUS.InsertBenhNhan(db, benhNhanDTO);
            string expected = "1111";
            Assert.Equals(actual, expected);
        }
        [TestMethod]
        public void Search_TestCase1()
        {
            // create data search
            db.BENHNHANs.Add(new BENHNHAN { MaBenhNhan = "1234567890", HoTen = "aaaaaaaaaa" });
            db.BENHNHANs.Add(new BENHNHAN { MaBenhNhan = "1234567891", HoTen = "bbbbbbbbbb" });
            db.BENHNHANs.Add(new BENHNHAN { MaBenhNhan = "1234567892", HoTen = "cccccccccc" });
            // create object search
            BenhNhanSearchEntity benhNhanSearch = new BenhNhanSearchEntity
            {
                MaBenhNhan = "12345678",
                TenBenhNhan = "",
                CMND = ""
            };
            List<BenhNhanDTO> listResult = null;
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            // execute
            string actual = benhNhanBUS.SearchBenhNhan(db, benhNhanSearch, out listResult);
            string expected = "0000";
            // compare
            Assert.Equals(actual, expected);
        }
        [TestMethod]
        public void Search_TestCase2()
        {
            // create object search
            BenhNhanSearchEntity benhNhanSearch = new BenhNhanSearchEntity
            {
                MaBenhNhan = "12345678",
                TenBenhNhan = "",
                CMND = ""
            };
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            List<BenhNhanDTO> listResult = null;
            string actual = benhNhanBUS.SearchBenhNhan(db, benhNhanSearch, out listResult);
            string expected = "0000";
            Assert.Equals(actual, expected);
        }
        [TestMethod]
        public void Update_TestCase1()
        {
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            // Insert benh nhan mới
            BenhNhanDTO benhNhanDTO = new BenhNhanDTO { MaBenhNhan = "1234567899",
                                                       HoTen = "Nguyen Van B" };

            benhNhanBUS.InsertBenhNhan(db, benhNhanDTO);
            // Update benh nhan
            BenhNhanDTO benhNhanUpdate = new BenhNhanDTO { MaBenhNhan = "1234567899",
                                                           HoTen = "Nguyen Van A"};


            string actual = benhNhanBUS.UpdateBenhNhan(db, benhNhanUpdate);
            string expected = "0000";
            // Test 
            Assert.Equals(expected, actual);
        }
        [TestMethod]
        public void Update_TestCase2()
        {
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            // Insert benh nhan mới
            BenhNhanDTO benhNhanDTO = new BenhNhanDTO { MaBenhNhan = "1234567899",
                                                       HoTen = "Nguyen Van A" };
            benhNhanBUS.InsertBenhNhan(db, benhNhanDTO);
            // Update benh nhan
            BenhNhanDTO benhNhanUpdate = new BenhNhanDTO { MaBenhNhan = "1234567899",
                                                           HoTen = ""};
            string actual = benhNhanBUS.UpdateBenhNhan(db, benhNhanUpdate);
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }
        [TestMethod]
        public void Update_TestCase3()
        {
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            // Insert benh nhan mới
            BenhNhanDTO benhNhanDTO = new BenhNhanDTO { MaBenhNhan = "1234567899",
                                                        HoTen = "Nguyen Van A" };
            benhNhanBUS.InsertBenhNhan(db, benhNhanDTO);
            // Update benh nhan
            BenhNhanDTO benhNhanUpdate = new BenhNhanDTO { MaBenhNhan = "1234567899",
                                                        HoTen = "12345678901234567890123456789012345678901234567890"};
            string actual = benhNhanBUS.InsertBenhNhan(db, benhNhanUpdate);
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }
        [TestMethod]
        public void GetInformation_TestCase1()
        {
            // create data search
            db.BENHNHANs.Add(new BENHNHAN { MaBenhNhan = "1234567890", HoTen = "aaaaaaaaaa" });
            db.BENHNHANs.Add(new BENHNHAN { MaBenhNhan = "1234567891", HoTen = "bbbbbbbbbb" });
            db.BENHNHANs.Add(new BENHNHAN { MaBenhNhan = "1234567892", HoTen = "cccccccccc" });
            BenhNhanDTO benhNhanDTO = null;
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            string actual = benhNhanBUS.GetInformationBenhNhan(db, "1234567890", out benhNhanDTO);
            string expected = "0000";
            Assert.Equals(actual, expected);
        }
        [TestMethod]
        public void GetInformation_TestCase2()
        {
            BenhNhanDTO benhNhanDTO = null;
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            string actual = benhNhanBUS.GetInformationBenhNhan(db, "1234567890", out benhNhanDTO);
            string expected = "1111";
            Assert.Equals(actual, expected);

        }
        [TestMethod]
        public void GetList_TestCase1()
        {
            // create data search
            db.BENHNHANs.Add(new BENHNHAN { MaBenhNhan = "1234567890", HoTen = "aaaaaaaaaa" });
            db.BENHNHANs.Add(new BENHNHAN { MaBenhNhan = "1234567891", HoTen = "bbbbbbbbbb" });
            db.BENHNHANs.Add(new BENHNHAN { MaBenhNhan = "1234567892", HoTen = "cccccccccc" });
            List<BenhNhanDTO> listBenhNhan = null;
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            string actual = benhNhanBUS.GetListBenhNhan(db, out listBenhNhan);
            string expected = "0000";
            Assert.Equals(actual, expected);

        }
        [TestMethod]
        public void GetList_TestCase2()
        {
            List<BenhNhanDTO> listBenhNhan = null;
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            string actual = benhNhanBUS.GetListBenhNhan(db, out listBenhNhan);
            string expected = "1111";
            Assert.Equals(actual, expected);

        }
        //clean method
        [TestCleanup]
        public void Clear()
        {
            trans.Rollback();
            trans.Dispose();
            db.Dispose();
        }
    }
}
