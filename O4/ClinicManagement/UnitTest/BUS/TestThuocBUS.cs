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
    public class TestThuocBUS
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
        /* BEGIN TEST METHOD */
        //Test get list thuoc success
        [TestMethod]
        public void GetListThuoc_Testcase1()
        {
            // create data search
            db.THUOCs.Add(new THUOC { MaThuoc = "1234567890", TenThuoc = "aaaaaaaaaa" });
            db.THUOCs.Add(new THUOC { MaThuoc = "1234567891", TenThuoc = "bbbbbbbbbb" });
            db.THUOCs.Add(new THUOC { MaThuoc = "1234567892", TenThuoc = "cccccccccc" });
           
            List<ThuocDTO> listThuoc = null;

            ThuocBUS thuocBUS = new ThuocBUS();

            string actual = thuocBUS.GetListThuoc(db, out listThuoc);
            string expected = "0000";
            Assert.Equals(actual, expected);

        }

        [TestMethod]
        public void GetListThuoc_Testcase2()
        {
            List<ThuocDTO> listThuoc = null;

            ThuocBUS thuocBUS = new ThuocBUS();

            string actual = thuocBUS.GetListThuoc(db, out listThuoc);
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
