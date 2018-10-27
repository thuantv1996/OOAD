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

        public string GetInformationBenhNhan(string MaBenhNhan, out BENHNHAN InformationBenhNhan, out List<string> MessangeError)
        {
            throw new NotImplementedException();
        }

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
                    string sql = "select * "
                        + "from BENHNHAN "
                        + "where ";
                    if(BenhNhanSearchEntity.MaBenhNhan != "")
                    {
                        sql = sql + "MaBenhNhan like '%{0}%' ";
                    }
                    if(BenhNhanSearchEntity.TenBenhNhan != "")
                    {
                        sql = sql + "and TenBenhNhan like '%{1}%' ";
                    }
                    if (BenhNhanSearchEntity.CMND != "")
                    {
                        sql = sql + "and CMND like '%{2}%'";
                    }

                    IdResult = Dao.Select(db, out LstResult, out MessageError);
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
