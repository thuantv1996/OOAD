using System.Collections.Generic;
using System.Linq;
using BUS.Service;
using DAO;
using DTO;
using COM;
using BUS.Entities;

namespace BUS.Imp
{
    public class BenhNhanImplement : IBenhNhanService
    {
        public string InsertBenhNhan(BenhNhanEnity BenhNhan, ref List<MessageError> Messages)
        {
            string ProgramName = "BenhNhanImplement_InsertBenhNhan";
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
                    IdResult = Dao.Insert(BenhNhanResult, db, ref Messages);
                    // Nếu hàm INSERT báo lỗi
                    if(IdResult == Constant.RES_FAI)
                    {
                        // Thêm thông báo lỗi
                        Messages.Add(new MessageError
                        {
                            IdError = Constant.MES_DB,
                            Message = string.Format("Lỗi khi Insert vao Table BENHNHAN - {0}", ProgramName)
                        });
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = Constant.RES_FAI;
                        // return 
                        return IdResult;
                    }
                }
            }
                return IdResult;
        }
     
        public string GetInformationBenhNhan(string MaBenhNhan, out BenhNhanEnity InformationBenhNhan, ref List<MessageError> Messages)
        {
            string ProgramName = "BenhNhanImplement_GetInformationBenhNhan";
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
                    IdResult = Dao.Select(db, bn => bn.MaBenhNhan.Equals(MaBenhNhan), out LstResult, ref Messages);
                    // Nếu hàm select báo lỗi
                    if (IdResult == Constant.RES_FAI)
                    {
                        
                        // Thêm thông báo lỗi
                        Messages.Add(new MessageError
                        {
                            IdError = Constant.MES_DB,
                            Message = string.Format("Lỗi truy vấn select table BENHNHAN - {0}", ProgramName)
                        });
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = Constant.RES_FAI;
                        // return 
                        return IdResult;
                    }
                    // Nếu hàm select không trả về bất kỳ record nào
                    if (LstResult.Count == 0)
                    {
                        Messages.Add(new MessageError
                        {
                            IdError = Constant.MES_DB,
                            Message = string.Format("Không select được dữ liệu (Data is empty) - {0}", ProgramName)
                        });
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = Constant.RES_FAI;
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

        public string GetListBenhNhan(out List<BenhNhanEnity> ListBenhNhan, ref List<MessageError> Messages)
        {
            string ProgramName = "BenhNhanImplement_GetListBenhNhan";
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
                    IdResult = Dao.Select(db, out LstResult, ref Messages);
                    // Nếu không thực hiện được lệnh SELECT
                    if(IdResult == Constant.RES_FAI)
                    {
                        Messages.Add(new MessageError
                        {
                            IdError = Constant.MES_DB,
                            Message = string.Format("Lỗi Database trong truy vấn select table BENHNHAN - {0}", ProgramName)
                        });
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = Constant.RES_FAI;
                        // return 
                        return IdResult;
                    }
                    // Nếu không tìm thấy trường
                    if(LstResult.Count == 0)
                    {
                        Messages.Add(new MessageError
                        {
                            IdError = Constant.MES_DB,
                            Message = string.Format("Không select được dữ liệu (Data is empty) - {0}", ProgramName)
                        });
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = Constant.RES_FAI;
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
        
        public string SearchBenhNhan(BenhNhanSearchEntity BenhNhanSearchEntity, out List<BenhNhanEnity> ListBenhNhan, ref List<MessageError> Messages)
        {
            string ProgramName = "BenhNhanImplement_SearchBenhNhan";
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
                    IdResult = Dao.Select(db, sql, param,out LstResult, ref Messages);
                    // Nếu không thực hiện được lệnh SELECT
                    if (IdResult == Constant.RES_FAI)
                    {
                        Messages.Add(new MessageError
                        {
                            IdError = Constant.MES_DB,
                            Message = string.Format("Lỗi Database trong truy vấn select table BENHNHAN - {0}", ProgramName)
                        });
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = Constant.RES_FAI;
                    }
                    // Nếu không tìm thấy trường
                    if (LstResult.Count == 0)
                    {
                        Messages.Add(new MessageError
                        {
                            IdError = Constant.MES_DB,
                            Message = string.Format("Không select được dữ liệu (Data is empty) - {0}", ProgramName)
                        });
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = Constant.RES_FAI;
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

        public string UpdateBenhNhan(BenhNhanEnity BenhNhan, ref List<MessageError> Messages)
        {
            string ProgramName = "BenhNhanImplement_UpdateBenhNhan";
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
                    IdResult = Dao.Update(BenhNhanResult, db, ref Messages);
                    // Nếu hàm INSERT báo lỗi
                    if (IdResult == Constant.RES_FAI)
                    {
                        // Thêm thông báo lỗi
                        Messages.Add(new MessageError
                        {
                            IdError = Constant.MES_DB,
                            Message = string.Format("Lỗi khi Update vao Table BENHNHAN - {0}", ProgramName)
                        });
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = Constant.RES_FAI;
                        // return 
                        return IdResult;
                    }
                }
            }
            return IdResult;
        }

    }
}
