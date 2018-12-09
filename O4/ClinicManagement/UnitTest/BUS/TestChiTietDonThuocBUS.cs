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
    public class TestChiTietDonThuocBUS
    {
        private static QLPHONGKHAMEntities db;
        private static DbContextTransaction trans;
        //init method
        [TestInitialize]
        public void Init()
        {
            db = new QLPHONGKHAMEntities();
            trans = db.Database.BeginTransaction();
            db.DONTHUOCs.Add(new DONTHUOC { MaDonThuoc = TestCommon.LEN_10 });
            db.THUOCs.Add(new THUOC { MaThuoc = TestCommon.LEN_10 });
        }

        // Test insert data sucesses
        [TestMethod]
        public void Save_TestCase1()
        {
            ChiTietDonThuocDTO chiTietDonThuocDTO = new ChiTietDonThuocDTO
            {
                MaDonThuoc = TestCommon.LEN_10,
                MaThuoc = TestCommon.LEN_50,
                SoLuong = 10,
                GhiChu = TestCommon.LEN_250
            };

            ChiTietDonThuocBUS chiTietDonThuocBUS = new ChiTietDonThuocBUS();
            
            

            // execute
            string actual = chiTietDonThuocBUS.SaveChiTietDonThuoc(db, chiTietDonThuocDTO);
            string expected = "0000";

            // compare
            Assert.Equals(actual, expected);


        }

        [TestMethod]
        public void Save_TestCase2()
        {

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
