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
    public class TestXetNghiemBUS
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
        [TestMethod]
        public void GetInformation_TestCase1()
        {
            // create data search
            db.XETNGHIEMs.Add(new XETNGHIEM { MaXetNghiem = "1234567890" });
            db.XETNGHIEMs.Add(new XETNGHIEM { MaXetNghiem = "1234567891" });
            db.XETNGHIEMs.Add(new XETNGHIEM { MaXetNghiem = "1234567892" });

            XetNghiemDTO xetNghiemDTO = null;
            XetNghiemBUS xetNghiemBUS = new XetNghiemBUS();

            string actual = xetNghiemBUS.GetInfomationXetNghiem(db, "1234567890", out xetNghiemDTO);
            string expected = "0000";
            Assert.Equals(actual, expected);
        }
        [TestMethod]
        public void GetInformation_TestCase2()
        {
            XetNghiemDTO xetNghiemDTO = null;
            XetNghiemBUS xetNghiemBUS = new XetNghiemBUS();

            string actual = xetNghiemBUS.GetInfomationXetNghiem(db, "1234567890", out xetNghiemDTO);
            string expected = "1111";
            Assert.Equals(actual, expected);
        }

        [TestMethod]
        public void GetList_TestCase1()
        {
            // create data search
            db.XETNGHIEMs.Add(new XETNGHIEM { MaXetNghiem = "1234567890" });
            db.XETNGHIEMs.Add(new XETNGHIEM { MaXetNghiem = "1234567891" });
            db.XETNGHIEMs.Add(new XETNGHIEM { MaXetNghiem = "1234567892" });

            List<XetNghiemDTO> xetNghiemDTO = null;
            XetNghiemBUS xetNghiemBUS = new XetNghiemBUS();

            string actual = xetNghiemBUS.GetListXetNghiem(db,  out xetNghiemDTO);
            string expected = "0000";
            Assert.Equals(actual, expected);
        }
        [TestMethod]
        public void GetList_TestCase2()
        {
            List<XetNghiemDTO> xetNghiemDTO = null;
            XetNghiemBUS xetNghiemBUS = new XetNghiemBUS();

            string actual = xetNghiemBUS.GetListXetNghiem(db, out xetNghiemDTO);
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
