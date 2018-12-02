using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BUS;
using DTO;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using DAO.Implement;
using DAO;
using BUS.Imp;

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
            BenhNhanDTO benhNhanDTO = new BenhNhanDTO  { MaBenhNhan = "1234567890",
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
        public void Insert_TestCase2()
        {
            BenhNhanDTO benhNhanDTO = new BenhNhanDTO  { MaBenhNhan = "1234567890000"  };
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            string actual = benhNhanBUS.InsertBenhNhan(db, benhNhanDTO);
            string expected = "1111";
            Assert.Equals(actual, expected);

        }

        public void Insert_TestCase3()
        {
            BenhNhanDTO benhNhanDTO = new BenhNhanDTO { MaBenhNhan = "1234567890000",
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

        public void Search_TestCase1()
        {
            BenhNhanDTO benhNhanDTO = new BenhNhanDTO
            {
                MaBenhNhan = "1234567890",
                HoTen = "Nguyen Van A",
                CMND = "2000900"
            };
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            string actual = benhNhanBUS.InsertBenhNhan(db, benhNhanDTO);
            string expected = "0000";
            Assert.Equals(actual, expected);
        }

        public void Search_TestCase2()
        {
            BenhNhanDTO benhNhanDTO = new BenhNhanDTO  {MaBenhNhan = "1234567890000",
                                                        HoTen = "12345678901234567890123456789012345678901234567890",
                                                        CMND ="2000900000000"};
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            string actual = benhNhanBUS.InsertBenhNhan(db, benhNhanDTO);
            string expected = "1111";
            Assert.Equals(actual, expected);
        }

         public void Update_TestCase1()
        {
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            // Insert benh nhan mới
           BenhNhanDTO benhNhanDTO = new BenhNhanDTO { MaBenhNhan = "1234567899",
                                                       HoTen = "Nguyen Van B" };

            benhNhanBUS.InsertBenhNhan(db, benhNhanDTO);
            // Update benh nhan
            BenhNhanDTO benhNhanUpdate = new BenhNhanDTO { MaBenhNhan = "1234567899",
                                                           HoTen = "Nguyen Van B"};


            string actual = benhNhanBUS.InsertBenhNhan(db, benhNhanUpdate);
            string expected = "0000";
            // Test 
            Assert.Equals(expected, actual);
        }
         public void Update_TestCase2()
        {
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            // Insert benh nhan mới
           BenhNhanDTO benhNhanDTO = new BenhNhanDTO { MaBenhNhan = "",
                                                       HoTen = "" };

            benhNhanBUS.InsertBenhNhan(db, benhNhanDTO);
            // Update benh nhan
            BenhNhanDTO benhNhanUpdate = new BenhNhanDTO { MaBenhNhan = "",
                                                           HoTen = ""};


            string actual = benhNhanBUS.InsertBenhNhan(db, benhNhanUpdate);
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }

         public void Update_TestCase3()
        {
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            // Insert benh nhan mới
           BenhNhanDTO benhNhanDTO = new BenhNhanDTO { MaBenhNhan = "1234567890000",
                                                        HoTen = "12345678901234567890123456789012345678901234567890" };

            benhNhanBUS.InsertBenhNhan(db, benhNhanDTO);
            // Update benh nhan
            BenhNhanDTO benhNhanUpdate = new BenhNhanDTO { MaBenhNhan = "1234567890000",
                                                        HoTen = "12345678901234567890123456789012345678901234567890"};


            string actual = benhNhanBUS.InsertBenhNhan(db, benhNhanUpdate);
            string expected = "1111";
            // Test 
            Assert.Equals(expected, actual);
        }





        public void GetInformation_TestCase1()
        {
            BenhNhanDTO benhNhanDTO = new BenhNhanDTO { MaBenhNhan = "1234567890" };
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            string actual = benhNhanBUS.InsertBenhNhan(db, benhNhanDTO);
            string expected = "0000";
            Assert.Equals(actual, expected);

        }
        public void GetInformation_TestCase2()
        {
            BenhNhanDTO benhNhanDTO = new BenhNhanDTO { MaBenhNhan = "" };
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            string actual = benhNhanBUS.InsertBenhNhan(db, benhNhanDTO);
            string expected = "1111";
            Assert.Equals(actual, expected);

        }

        public void GetInformation_TestCase3()
        {
            BenhNhanDTO benhNhanDTO = new BenhNhanDTO { MaBenhNhan = "1234567890000" };
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            string actual = benhNhanBUS.InsertBenhNhan(db, benhNhanDTO);
            string expected = "1111";
            Assert.Equals(actual, expected);

        }

        public void GetList_TestCase1()
        {
            BenhNhanDTO benhNhanDTO = new BenhNhanDTO  { MaBenhNhan = "1234567890",
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
        public void GetList_TestCase2()
        {
            BenhNhanDTO benhNhanDTO = new BenhNhanDTO { MaBenhNhan = "1234567890000",
                                                        HoTen = "",
                                                         CMND ="",
                                                         NgaySinh ="",
                                                         GioiTinh = true,
                                                         SoDienThoai="",
                                                         DiaChi = "",
                                                         GhiChu = ""};
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            string actual = benhNhanBUS.InsertBenhNhan(db, benhNhanDTO);
            string expected = "1111";
            Assert.Equals(actual, expected);

        }
        public void GetList_TestCase3()
        {
            BenhNhanDTO benhNhanDTO = new BenhNhanDTO { MaBenhNhan = "1234567890000",
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
