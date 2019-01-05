using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO;
using System.Data.Entity;
using DAO;
using BUS.Imp;
using BUS.Entities;
using System.Collections.Generic;

namespace UnitTest.BUS
{
    public class TestDonThuocBUS
    {
        private static QLPHONGKHAMEntities db;
        private static DbContextTransaction trans;
        //init method
        [TestInitialize]
        public void Init()
        {
            db = new QLPHONGKHAMEntities();
            trans = db.Database.BeginTransaction();
            db.HOSOBENHANs.Add(new HOSOBENHAN { MaHoSo = TestCommon.LEN_10 });
        }
        /* BEGIN TEST METHOD */

        [TestMethod]
        public void GetInformation_TestCase1()
        {
            // create data search
            db.DONTHUOCs.Add(new DONTHUOC { MaHoSo = "1234567890" });
            db.DONTHUOCs.Add(new DONTHUOC { MaHoSo = "1234567891" });
            db.DONTHUOCs.Add(new DONTHUOC { MaHoSo = "1234567892" });

            DonThuocDTO donThuocDTO = null;
            DonThuocBUS donThuocBUS = new DonThuocBUS();

            string actual = donThuocBUS.GetInformationDonThuocWithId(db, "1234567890", out donThuocDTO);

            string expected = "0000";
            Assert.Equals(actual, expected);
        }

        [TestMethod]
        public void GetInformation_TestCase2()
        {
            DonThuocDTO donThuocDTO = null;
            DonThuocBUS donThuocBUS = new DonThuocBUS();
            string actual = donThuocBUS.GetInformationDonThuocWithId(db, "1234567890", out donThuocDTO);

            string expected = "0000";
            Assert.Equals(actual, expected);

        }

        [TestMethod]
        // Test insert DonThuoc sucesses
        public void Save_TestCase1()
        {
            DonThuocDTO donThuocDTO = new DonThuocDTO {
                MaDonThuoc = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                NgayLap = TestCommon.LEN_8,
                GhiChu = TestCommon.LEN_250
            };
            DonThuocBUS donThuocBUS = new DonThuocBUS();
            // execute
            string actual = donThuocBUS.SaveDonThuoc(db, donThuocDTO);
            string expected = "0000";

            // compare
            Assert.Equals(actual, expected);

        }

        [TestMethod]
        // Test insert without MaDonThuoc or MaHoSo
        public void Save_TestCase2()
        {
            DonThuocDTO donThuocDTO = new DonThuocDTO
            {
                NgayLap = TestCommon.LEN_8,
                GhiChu = TestCommon.LEN_250
            };
            DonThuocBUS donThuocBUS = new DonThuocBUS();
            // execute
            string actual = donThuocBUS.SaveDonThuoc(db, donThuocDTO);
            string expected = "1111";

            // compare
            Assert.Equals(actual, expected);
        }
        // Test insert MaHoSo not found in table HOSOBENHAN
        [TestMethod]
        public void Save_TestCase3()
        {
            DonThuocDTO donThuocDTO = new DonThuocDTO
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaHoSo = "123",
            };
            DonThuocBUS donThuocBUS = new DonThuocBUS();
            // execute
            string actual = donThuocBUS.SaveDonThuoc(db, donThuocDTO);
            string expected = "1111";

            // compare
            Assert.Equals(actual, expected);

        }
        // Test insert max length
        [TestMethod]
        public void Save_TestCase4()
        {
            DonThuocDTO donThuocDTO = new DonThuocDTO
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaHoSo = TestCommon.LEN_10,
                NgayLap = TestCommon.LEN_8 + "1",
                GhiChu = TestCommon.LEN_250 + "1"
            };
            DonThuocBUS donThuocBUS = new DonThuocBUS();
            // execute
            string actual = donThuocBUS.SaveDonThuoc(db, donThuocDTO);
            string expected = "1111";

            // compare
            Assert.Equals(actual, expected);

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
