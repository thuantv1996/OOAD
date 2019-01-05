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
    public class TestLoaiHoSoBUS
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
        [TestMethod]
        // Test getlist data sucesses
        public void GetList_TestCase1()
        {
            // create data search
            db.LOAIHOSOes.Add(new LOAIHOSO { MaLoaiHoSo = "1234567890", TenLoaiHoSo = "aaaaaaaaaa" });
            db.LOAIHOSOes.Add(new LOAIHOSO { MaLoaiHoSo = "1234567891", TenLoaiHoSo = "bbbbbbbbbb" });
            db.LOAIHOSOes.Add(new LOAIHOSO { MaLoaiHoSo = "1234567892", TenLoaiHoSo = "cccccccccc" });
            List<LoaiHoSoDTO> listHoSo = null;
            LoaiHoSoBUS loaiHoSoBUS = new LoaiHoSoBUS();
            string actual = loaiHoSoBUS.GetListLoaiHoSo(db, out listHoSo);
            string expected = "0000";
            Assert.Equals(actual, expected);

        }
        //// test null data
        [TestMethod]
        public void GetList_TestCase2()
        {
           
            List<LoaiHoSoDTO> listHoSo = null;
            LoaiHoSoBUS loaiHoSoBUS = new LoaiHoSoBUS();
            string actual = loaiHoSoBUS.GetListLoaiHoSo(db, out listHoSo);
            string expected = "1111";
            Assert.Equals(actual, expected);
        }
        // Test get information data sucesses
        [TestMethod]
        public void GetInformation_TestCase1()
        {
            // create data search
            db.LOAIHOSOes.Add(new LOAIHOSO { MaLoaiHoSo = "1234567890", TenLoaiHoSo = "aaaaaaaaaa" });
            db.LOAIHOSOes.Add(new LOAIHOSO { MaLoaiHoSo = "1234567891", TenLoaiHoSo = "bbbbbbbbbb" });
            db.LOAIHOSOes.Add(new LOAIHOSO { MaLoaiHoSo = "1234567892", TenLoaiHoSo = "cccccccccc" });
            LoaiHoSoDTO loaiHoSoDTO = null;
            LoaiHoSoBUS loaiHoSoBUS = new LoaiHoSoBUS();
            string actual = loaiHoSoBUS.GetInformationLoaiHoSo(db, "1234567890",  out loaiHoSoDTO);
            string expected = "0000";
            Assert.Equals(actual, expected);
        }
        // test null data
        [TestMethod]
        public void GetInformation_TestCase2()
        {
            
            LoaiHoSoDTO loaiHoSoDTO = null;
            LoaiHoSoBUS loaiHoSoBUS = new LoaiHoSoBUS();
            string actual = loaiHoSoBUS.GetInformationLoaiHoSo(db, "1234567890", out loaiHoSoDTO);
            string expected = "1111";
            Assert.Equals(actual, expected);
        }
        /*End test method*/

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
