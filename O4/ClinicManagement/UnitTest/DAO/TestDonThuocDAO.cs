using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DAO.Implement;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.DAO
{
    public class TestDonThuocDAO
    {
        private static QLPHONGKHAMEntities db;
        private static DbContextTransaction trans;
        // INIT METHOD
        [TestInitialize]
        public void Init()
        {
            db = new QLPHONGKHAMEntities();
            trans = db.Database.BeginTransaction();
        }

        /* BEGIN TEST METHOD */
        [TestMethod]
        // Test insert DonThuoc sucesses
        public void Insert_TestCase1()
        {

        }

        [TestMethod]
        // Test insert without MaDonThuoc or MaHoSo
        public void Insert_TestCase2()
        {

        }

        [TestMethod]
        // Test insert full length
        public void Insert_TestCase3()
        {

        }

        [TestMethod]
        // Test insert max length
        public void Insert_TestCase4()
        {

        }

        [TestMethod]
        // Test update sucesses
        public void Update_TestCase5()
        {

        }

        [TestMethod]
        // Test delete
        public void Delete_TestCase6()
        {

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
