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
        public string InsertBenhNhan(BenhNhanEnity BenhNhan, out List<string> MessangeError)
        {
            // Kết quả trả về
            string IdResult = "";
            // Tạo đối tượng BENHNHAN kết quả
            BENHNHAN BenhNhanResult = new BENHNHAN();
            // Convert đối tượng từ DTO sang DAO
            BUS.Com.Utils.CopyPropertiesFrom(BenhNhan, BenhNhanResult);
            // Khởi tạo Database
            using (var db = new QLPHONGKHAMEntities())
            {
                // Khởi tạo transaction 
                using (var trans = db.Database.BeginTransaction())
                {
                    // Khởi tạo lớp DAO
                    DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                    // Thực hiện lệnh INSERT
                    IdResult = Dao.Insert(BenhNhanResult, db, out MessangeError);
                    // Nếu hàm INSERT báo lỗi
                    if(IdResult == BUS.Com.BusConstant.RES_FAI)
                    {
                        if(MessangeError == null)
                        {
                            MessangeError = new List<string>();
                        }
                        // Thêm thông báo lỗi
                        MessangeError.Insert(0, "Lỗi truy vấn insert table BENHNHAN");
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                        // return 
                        return IdResult;
                    }
                }
            }
                return IdResult;
        }
     
        public string GetInformationBenhNhan(string MaBenhNhan, out BenhNhanEnity InformationBenhNhan, out List<string> MessangeError)
        {
            // khởi tạo đối tượng Bệnh Nhân (DTO) trả về
            InformationBenhNhan = new BenhNhanEnity();
            // Khai báo danh sách đối tượng Bệnh Nhân (DAO) đón nhận data từ function select 
            List<BENHNHAN> LstResult = null;
            // Kết quả trả về
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
                    // Nếu hàm select báo lỗi
                    if (IdResult == BUS.Com.BusConstant.RES_FAI)
                    {
                        if (MessangeError == null)
                        {
                            MessangeError = new List<string>();
                        }
                        // Thêm thông báo lỗi
                        MessangeError.Insert(0, "Lỗi truy vấn select table BENHNHAN");
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                        // return 
                        return IdResult;
                    }
                    // Nếu hàm select không trả về bất kỳ record nào
                    if (LstResult.Count == 0)
                    {
                        if (MessangeError == null)
                        {
                            MessangeError = new List<string>();
                        }
                        // Thêm thông báo lỗi
                        MessangeError.Insert(0, "Không select được dữ liệu (Data is empty)");
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                        // return 
                        return IdResult;
                    }
                }
            }
            // Vì search trên Key nên chỉ trả về nhiều nhất 1 record 
            // Lấy record trả về
            BENHNHAN SearchResult = LstResult.ToList().ElementAt(0);
            // Vì BENHNHAN là kiểu dữ liệu của DAO nên không thể gửi lên GUI
            // => cần chuyển đối tượng DAO sang DTO vì GUI có thể sử dụng DTO
            // convert SearchResult từ DAO sang DTO
            BUS.Com.Utils.CopyPropertiesFrom(SearchResult, InformationBenhNhan);
            // return 
            return IdResult;
        }

        public string GetListBenhNhan(out List<BenhNhanEnity> ListBenhNhan, out List<string> MessageError)
        {
            // Danh sách bệnh nhân (DTO) trả về
            ListBenhNhan = new List<BenhNhanEnity>();
            // Danh sách Bệnh Nhân (DAO) Nhận được từ function select
            List<BENHNHAN> LstResult = null;
            // Result code
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
                        // return 
                        return IdResult;
                    }
                    // Nếu không tìm thấy trường
                    if(LstResult.Count == 0)
                    {
                        if (MessageError == null)
                        {
                            MessageError = new List<string>();
                        }
                        // Thêm thông báo lỗi
                        MessageError.Insert(0, "Không select được dữ liệu (Data is empty)");
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                        // return 
                        return IdResult;
                    }                    
                }   
            }
            // Sau khi lấy được danh sách, convert đối tượng BenhNhan (DAO) sang BenhNhanEnity(DTO)
            foreach (BENHNHAN BenhNhan in LstResult)
            {
                BenhNhanEnity temp = new BenhNhanEnity();
                BUS.Com.Utils.CopyPropertiesFrom(BenhNhan, temp);
                ListBenhNhan.Add(temp);
            }
            // return 
            return IdResult;

        }
        
        public string SearchBenhNhan(BenhNhanSearchEntity BenhNhanSearchEntity, out List<BenhNhanEnity> ListBenhNhan, out List<string> MessageError)
        {
            // Danh sách bệnh nhân (DTO) trả về
            ListBenhNhan = new List<BenhNhanEnity>();
            // Danh sách Bệnh Nhân (DAO) Nhận được từ function select
            List<BENHNHAN> LstResult = null;
            // Result code
            string IdResult = "";
            // Khởi tạo Database
            using (var db = new QLPHONGKHAMEntities())
            {
                // Khởi tạo Transaction
                using (var trans = db.Database.BeginTransaction())
                {
                    // Khởi tạo lớp DAO
                    DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                    // Tạo Paramester search
                    object[] param = { BenhNhanSearchEntity.MaBenhNhan, BenhNhanSearchEntity.TenBenhNhan, BenhNhanSearchEntity.CMND };
                    // Lấy câu truy vấn sql từ function Com.BUSSql.SqlSearchBenhNhan(param)
                    string sql = BUS.Com.BUSSql.SqlSearchBenhNhan(param);
                    // thực thi hàm select 
                    IdResult = Dao.Select(db, sql, param,out LstResult, out MessageError);
                    // Nếu không thực hiện được lệnh SELECT
                    if (IdResult == BUS.Com.BusConstant.RES_FAI)
                    {
                        if (MessageError == null)
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
                    if (LstResult.Count == 0)
                    {
                        if (MessageError == null)
                        {
                            MessageError = new List<string>();
                        }
                        // Thêm thông báo lỗi
                        MessageError.Insert(0, "Không select được dữ liệu (Data is empty)");
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                    }
                }
               
            }
            // Sau khi lấy được danh sách, convert đối tượng BenhNhan (DAO) sang BenhNhanEnity(DTO)
            foreach (BENHNHAN BenhNhan in LstResult)
            {
                BenhNhanEnity temp = new BenhNhanEnity();
                BUS.Com.Utils.CopyPropertiesFrom(BenhNhan, temp);
                ListBenhNhan.Add(temp);
            }
            // return 
            return IdResult;
        }

        public string UpdateBenhNhan(BenhNhanEnity BenhNhan, out List<string> MessageError)
        {
            // Kết quả trả về
            string IdResult = "";
            // Tạo đối tượng BENHNHAN kết quả
            BENHNHAN BenhNhanResult = new BENHNHAN();
            // Convert đối tượng từ DTO sang DAO
            BUS.Com.Utils.CopyPropertiesFrom(BenhNhan, BenhNhanResult);
            // Khởi tạo Database
            using (var db = new QLPHONGKHAMEntities())
            {
                // Khởi tạo transaction 
                using (var trans = db.Database.BeginTransaction())
                {
                    // Khởi tạo lớp DAO
                    DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                    // Thực hiện lệnh INSERT
                    IdResult = Dao.Update(BenhNhanResult, db, out MessageError);
                    // Nếu hàm INSERT báo lỗi
                    if (IdResult == BUS.Com.BusConstant.RES_FAI)
                    {
                        if (MessageError == null)
                        {
                            MessageError = new List<string>();
                        }
                        // Thêm thông báo lỗi
                        MessageError.Insert(0, "Lỗi truy vấn update table BENHNHAN");
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = BUS.Com.BusConstant.RES_FAI;
                        // return 
                        return IdResult;
                    }
                }
            }
            return IdResult;
        }
    }
}
