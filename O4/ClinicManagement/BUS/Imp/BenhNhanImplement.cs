using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.Enities;
using BUS.Service;
using DAO;
using DTO;

namespace BUS.Imp
{
    public class BenhNhanImplement : IBenhNhanService
    {
        public string AddBenhNhan(BenhNhanEnity BenhNhan, out List<string> MessangeError)
        {
            throw new NotImplementedException();
        }

        // HÀM LẤY THÔNG TIN BỆNH NHÂN 
        public string GetInformationBenhNhan(string MaBenhNhan, out BENHNHAN InformationBenhNhan, out List<string> MessangeError)
        {
            InformationBenhNhan = new BENHNHAN();
            List<BENHNHAN> LstResult = null;
            string IdResult = "";
            // Khởi tạo Database
            using (var db = new QLPHONGKHAMEntities())
            {
                //Khởi tạo transaction
                using (var trans = db.Database.BeginTransaction())
                {
                    // Khởi tạo lớp DAO
                    DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                    // Thực hiện lệnh SELECT
                    IdResult = Dao.Select(db, bn => bn.MaBenhNhan.Equals(MaBenhNhan), out LstResult, out MessangeError);
                    // Nếu không thực hiện được lệnh SELECT
                    if (IdResult == BUS.Com.BusConstant.RES_FAI)
                    {
                        if (MessangeError == null)
                        {
                            MessangeError = new List<string>();
                        }
                        // Thêm thông báo lỗi
                        MessangeError.Insert(0, "Lỗi Database trong truy vấn select table BENHNHAN");
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                    }
                    // Nếu không tìm thấy trường
                    if (LstResult.Count == 0)
                    {
                        if (MessangeError == null)
                        {
                            MessangeError = new List<string>();
                        }
                        MessangeError.Insert(0, "Không select được dữ liệu (Data is empty)");
                        trans.Rollback();
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                    }
                }
            }
            return IdResult;
        }

        // HÀM LẤY DANH SÁCH BỆNH NHÂN
        public string GetListBenhNhan(out List<BenhNhanEnity> ListBenhNhan, out List<string> MessageError)
        {
            ListBenhNhan = new List<BenhNhanEnity>();
            List<BENHNHAN> LstResult = null;
            string IdResult = "";
            // Khởi tạo Database
            using (var db = new QLPHONGKHAMEntities())
            {
                // Khởi tạo Transaction
                using (var trans = db.Database.BeginTransaction())
                {
                    // Khởi tạo lớp DAO
                    DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();   
                    // Thực hiện lệnh SELECT
                    IdResult = Dao.Select(db, out LstResult, out MessageError);
                    // Nếu không thực hiện được lệnh SELECT
                    if(IdResult == BUS.Com.BusConstant.RES_FAI)
                    {
                        if(MessageError == null)
                        {
                            MessageError = new List<string>();
                        }
                        // Thêm thông báo lỗi
                        MessageError.Insert(0, "Lỗi Database trong truy vấn select table BENHNHAN");
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                    }
                    // Nếu không tìm thấy trường
                    if(LstResult.Count == 0)
                    {
                        if (MessageError == null)
                        {
                            MessageError = new List<string>();
                        }
                        MessageError.Insert(0, "Không select được dữ liệu (Data is empty)");
                        trans.Rollback();
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                    }                    
                }   
            }
            // Sau khi lấy được danh sách, convert đối tượng BenhNhan sang BenhNhanEnity
            foreach (BENHNHAN BenhNhan in LstResult)
            {
                BenhNhanEnity temp = new BenhNhanEnity();
                BUS.Com.Utils.CopyPropertiesFrom(BenhNhan, temp);
                ListBenhNhan.Add(temp);
            } 
            return IdResult;
        }

        // HÀM TÌM KIẾM THÔNG TIN BỆNH NHÂN
        public string SearchBenhNhan(BenhNhanSearchEntity BenhNhanSearchEntity, out List<BenhNhanEnity> ListBenhNhan, out List<string> MessageError)
        {
            ListBenhNhan = new List<BenhNhanEnity>();
            List<BENHNHAN> LstResult = null;
            string IdResult = "";
            // Khởi tạo Database
            using (var db = new QLPHONGKHAMEntities())
            {
                // Khởi tạo Transaction
                using (var trans = db.Database.BeginTransaction())
                {
                    // Khởi tạo lớp DAO
                    DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                    // Thực hiện lệnh SELECT
                    string sql = "SELECT * "
                        + "FROM BENHNHAN "
                        + "WHERE ";
                    bool HasPrevCondition = false;
                    if (BenhNhanSearchEntity.MaBenhNhan != "")
                    {
                        sql = sql + "MaBenhNhan LIKE '%{0}%' ";
                    }
                    if(BenhNhanSearchEntity.TenBenhNhan != "")
                    {
                        if(HasPrevCondition)
                        {
                            sql += "AND ";
                        }
                        sql = sql + "TenBenhNhan LIKE '%{1}%' ";
                        HasPrevCondition = true;
                    }
                    if (BenhNhanSearchEntity.CMND != "")
                    {
                        if (HasPrevCondition)
                        {
                            sql += "AND ";
                        }
                        sql = sql + "TenBenhNhan LIKE '%{2}%' ";
                        HasPrevCondition = true;
                    }
                    object[] param = { BenhNhanSearchEntity.MaBenhNhan, BenhNhanSearchEntity.TenBenhNhan, BenhNhanSearchEntity.CMND };
                    IdResult = Dao.Select(db, sql, param,out LstResult, out MessageError);
                    // Nếu không thực hiện được lệnh SELECT
                    if (IdResult == BUS.Com.BusConstant.RES_FAI)
                    {
                        if (MessageError == null)
                        {
                            MessageError = new List<string>();
                        }
                        MessageError.Insert(0, "Lỗi Database trong truy vấn select table BENHNHAN");
                        trans.Rollback();
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                    }
                    // Nếu không tìm thấy trường
                    if (LstResult.Count == 0)
                    {
                        if (MessageError == null)
                        {
                            MessageError = new List<string>();
                        }
                        MessageError.Insert(0, "Không select được dữ liệu (Data is empty)");
                        trans.Rollback();
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                    }
                }
               
            }
            //
            foreach (BENHNHAN BenhNhan in LstResult)
            {
                BenhNhanEnity temp = new BenhNhanEnity();
                BenhNhanSearchEntity temp2 = new BenhNhanSearchEntity();

                ListBenhNhan.Add(temp);

            }
            return "0000";
        }
    }
}
