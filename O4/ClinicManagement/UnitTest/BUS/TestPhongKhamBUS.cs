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
    public class TestPhongKhamBUS
    {
        private static QLPHONGKHAMEntities db;
        private static DbContextTransaction trans;
        // init method
        [TestInitialize]
        public void Init()
        {
            db = new QLPHONGKHAMEntities();
            trans = db.Database.BeginTransaction();
        }

        /*Begin test method*/

        //Test success
        [TestMethod]
        public void GetInformation_TestCase1()
        {
            // create data search
            db.PHONGs.Add(new PHONG { MaPhong = "1234567890" });
            db.PHONGs.Add(new PHONG { MaPhong = "1234567891" });
            db.PHONGs.Add(new PHONG { MaPhong = "1234567892" });

            PhongKhamDTO phongKhamDTO = null;

            PhongKhamBUS phongKhamBUS = new PhongKhamBUS();

           

            string actual = phongKhamBUS.GetInformationPhongKham(db, "1234567890", out phongKhamDTO);
            string expected = "0000";

            Assert.Equals(actual, expected);


        }
        [TestMethod]
        public void GetInformation_TestCase2()
        {


            PhongKhamDTO phongKhamDTO = null;

            PhongKhamBUS phongKhamBUS = new PhongKhamBUS();



            string actual = phongKhamBUS.GetInformationPhongKham(db, "1234567890", out phongKhamDTO);
            string expected = "1111";

            Assert.Equals(actual, expected);
        }

        [TestMethod]
        public void GetList_TestCase1()
        {
            // create data search
            db.PHONGs.Add(new PHONG { MaPhong = "1234567890" });
            db.PHONGs.Add(new PHONG { MaPhong = "1234567891" });
            db.PHONGs.Add(new PHONG { MaPhong = "1234567892" });

            List<PHONG> listPhongKham = null;

            PhongKhamBUS phongKhamBUS = new PhongKhamBUS();



            string actual = phongKhamBUS.GetListPhongKham(db,  out listPhongKham);
            string expected = "0000";

            Assert.Equals(actual, expected);
        }
        [TestMethod]
        public void GetList_TestCase2()
        {

            List<PHONG> listPhongKham = null;

            PhongKhamBUS phongKhamBUS = new PhongKhamBUS();

            string actual = phongKhamBUS.GetListPhongKham(db, out listPhongKham);
            string expected = "0000";

            Assert.Equals(actual, expected);
        }
        /* END TEST METHOD */

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
