using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.Entities;
using BUS.Service;
using DTO;
using DAO;
using COM;

namespace BUS.Imp
{
    class ThanhToanImplement : IThanhToanService
    {
        public string AddThanhToan(QLPHONGKHAMEntities db, ThanhToanEntity ThanhToan, ref List<MessageError> Messages)
        {
            string ProgramName = "ThanhToanImplement-AddThanhToan";
            string IdResult;
            // Tạo đối tượng THANHTOAN kết quả
            THANHTOAN ThanhToanResult = new THANHTOAN();
            
            // Convert đối tượng từ DTO sang DAO
            BUS.Com.Utils.CopyPropertiesFrom(ThanhToan, ThanhToanResult);
            // Khởi tạo Database
            using (db = new QLPHONGKHAMEntities())
            {
                // Khởi tạo transaction 
                using (var trans = db.Database.BeginTransaction())
                {
                    // Khởi tạo lớp DAO
                    DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                    // Thực hiện lệnh INSERT
                    IdResult = Dao.Insert(ThanhToanResult ,db, ref Messages);
                    // Nếu hàm INSERT báo lỗi
                    if (IdResult == Constant.RES_FAI)
                    {
                        // Thêm thông báo lỗi
                        Messages.Add(new MessageError
                        {
                            IdError = Constant.MES_DB,
                            Message = string.Format("Lỗi khi Update vao Table THANHTOAN - {0}", ProgramName)
                        });
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = Constant.RES_FAI;
                        // return 
                        return IdResult;
                    }
                    else
                    {
                        trans.Commit();
                    }
                }
            }
            return Constant.RES_SUC;
        }


        public string UpdateThanhToan(QLPHONGKHAMEntities db, ThanhToanEntity ThanhToan, ref List<MessageError> Messages)
        {
            string ProgramName = "ThanhToanImplement-UpdateThanhToan";
            string IdResult;
            // Tạo đối tượng THANHTOAN kết quả
            THANHTOAN ThanhToanResult = new THANHTOAN();
            // Convert đối tượng từ DTO sang DAO
            BUS.Com.Utils.CopyPropertiesFrom(ThanhToan, ThanhToanResult);
            // Khởi tạo Database
            using (db = new QLPHONGKHAMEntities())
            {
                // Khởi tạo transaction 
                using (var trans = db.Database.BeginTransaction())
                {
                    // Khởi tạo lớp DAO
                    DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                    // Thực hiện lệnh Update
                    IdResult = Dao.Update(ThanhToanResult, db, ref Messages);
                    // Nếu hàm INSERT báo lỗi
                    if (IdResult == Constant.RES_FAI)
                    {
                        // Thêm thông báo lỗi
                        Messages.Add(new MessageError
                        {
                            IdError = Constant.MES_DB,
                            Message = string.Format("Lỗi khi Update vao Table THANHTOAN - {0}", ProgramName)
                        });
                        // Rollback dữ liệu
                        trans.Rollback();
                        // Return faild
                        IdResult = Constant.RES_FAI;
                        // return 
                        return IdResult;
                    }
                    else
                    {
                        trans.Commit();
                    }
                }
            }
            return Constant.RES_SUC;
        }

    }
            
}
