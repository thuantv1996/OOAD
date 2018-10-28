using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace UnitTest
{
    /// <summary>
    /// Test Layer DAO 
    /// Test on table LOAINHANVIEN
    /// </summary>
    [TestClass]
    public class TestDAO
    {
        private static QLPHONGKHAMEntities db;
        private static DbContextTransaction trans;
        [TestInitialize]
        public void Init()
        {
            db = new QLPHONGKHAMEntities();
            trans = db.Database.BeginTransaction();
            // Clear data
            // delate data of Table LOAINHANVIEN
            db.LOAINHANVIENs.SqlQuery("Delete from LOAINHANVIEN", new object[0]);
            //
        }

        // Test Module DAO trường hợp Success all funtion 
        [TestMethod]
        public void TestCase1()
        {
            List<string> LstResultExecute = new List<string>();
            List<string> LstResultDesire = new List<string>();
            // Chuẩn bị các thành phần 
            List<LOAINHANVIEN> ListLoaiNhanVien = null;
            List<string> MessageError = null;
            DAO.Imp.BaseDAO dao = new DAO.Imp.BaseDAO();
            LOAINHANVIEN lnv = new LOAINHANVIEN { MaLoaiNV = "LNV0000004", TenLoaiNV = "TEST UT" };

            //
            // Chạy function
            // 
            // execute function Insert 
            LstResultExecute.Add(dao.Insert(lnv, db, out MessageError));
            // execute function Select 
            LstResultExecute.Add(dao.Select(db, out ListLoaiNhanVien, out MessageError));
            LstResultExecute.Add(dao.Select(db, l=>l.MaLoaiNV.Equals("LNV0000004"), out ListLoaiNhanVien, out MessageError));
            LstResultExecute.Add(dao.Select(db, "Select * From LOAINHANVIEN", new object[0],out ListLoaiNhanVien, out MessageError));
            // execute function Update
            lnv = new LOAINHANVIEN { MaLoaiNV = "LNV0000004", TenLoaiNV = "TEST UT Update" };
            LstResultExecute.Add(dao.Update(lnv, db, out MessageError));
            // execute function Delete
            LstResultExecute.Add(dao.Delete(lnv, db, out MessageError));

            //
            // Setup kết quả dự tưởng
            //
            for(int i = 0; i < 6; i++)
            {
                LstResultDesire.Add(DAO.Com.DAOConstant.RES_SUC);
            }


            CollectionAssert.AreEqual(LstResultExecute, LstResultDesire);
        }

        // test Insert data
        [TestMethod]
        public void TestCase2()
        {
            List<string> LstResultExecute = new List<string>();
            List<string> LstResultDesire = new List<string>();
            // Chuẩn bị các thành phần 
            List<LOAINHANVIEN> ListLoaiNhanVien = null;
            List<string> MessageError = null;
            DAO.Imp.BaseDAO dao = new DAO.Imp.BaseDAO();
            LOAINHANVIEN lnv = new LOAINHANVIEN { MaLoaiNV = "LNV0000004", TenLoaiNV = "TEST UT" };
            //
            // Chạy function
            // 
            // execute function Insert 
            LstResultExecute.Add(dao.Insert(lnv, db, out MessageError));
            // Test 
            Assert.AreEqual(lnv, db.LOAINHANVIENs.Find("LNV0000004"));
        }

        // test Update data
        [TestMethod]
        public void TestCase3()
        {
            List<string> LstResultExecute = new List<string>();
            List<string> LstResultDesire = new List<string>();
            // Chuẩn bị các thành phần 
            List<LOAINHANVIEN> ListLoaiNhanVien = null;
            List<string> MessageError = null;
            DAO.Imp.BaseDAO dao = new DAO.Imp.BaseDAO();
            LOAINHANVIEN lnv = new LOAINHANVIEN { MaLoaiNV = "LNV0000005", TenLoaiNV = "TEST UT" };
            db.LOAINHANVIENs.Add(lnv);
            LOAINHANVIEN expected = new LOAINHANVIEN { MaLoaiNV = "LNV0000005", TenLoaiNV = "TEST UT Update" };
            //
            // Chạy function
            // 
            // execute function Insert 
            LstResultExecute.Add(dao.Update(expected, db, out MessageError));
            LOAINHANVIEN actual = db.LOAINHANVIENs.Find("LNV0000005");
            // Test 
            Assert.AreEqual(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
        }

        // test delete
        [TestMethod]
        public void TestCase4()
        {
            List<string> LstResultExecute = new List<string>();
            List<string> LstResultDesire = new List<string>();
            // Chuẩn bị các thành phần 
            List<LOAINHANVIEN> ListLoaiNhanVien = null;
            List<string> MessageError = null;
            DAO.Imp.BaseDAO dao = new DAO.Imp.BaseDAO();
            LOAINHANVIEN lnv = new LOAINHANVIEN { MaLoaiNV = "LNV0000005", TenLoaiNV = "TEST UT" };
            db.LOAINHANVIENs.Add(lnv);
            // Chạy function
            // 
            // execute function Insert 
            LstResultExecute.Add(dao.Delete(lnv, db, out MessageError));
            LOAINHANVIEN actual = db.LOAINHANVIENs.Find("LNV0000005");
            // Test 
            Assert.AreEqual(null, actual);
        }

        [TestCleanup]
        public void Clear()
        {
            // Rollback data
            trans.Rollback();
            trans.Dispose();
            db.Dispose();
        }

        private List<LOAINHANVIEN> GetListLoaiNhanVien()
        {
            List<LOAINHANVIEN> Result = new List<LOAINHANVIEN>();
            LOAINHANVIEN NhanVien = new LOAINHANVIEN { MaLoaiNV = "LNV0000001", TenLoaiNV = "Tiếp nhận" };
            Result.Add(NhanVien);
            NhanVien = new LOAINHANVIEN { MaLoaiNV = "LNV0000002", TenLoaiNV = "Bác sĩ khám" };
            Result.Add(NhanVien);
            NhanVien = new LOAINHANVIEN { MaLoaiNV = "LNV0000003", TenLoaiNV = "Bác sĩ xét nghiệm" };
            Result.Add(NhanVien);
            return Result;
        }
        
    }
}
