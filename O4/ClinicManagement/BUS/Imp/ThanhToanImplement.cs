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
            THANHTOAN ThanhToanDAO = new THANHTOAN();

            // Convert đối tượng từ DTO sang DAO
            BUS.Com.Utils.CopyPropertiesFrom(ThanhToan, ThanhToanDAO);

            // Khởi tạo lớp DAO
            DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
            // Thực hiện lệnh INSERT
            IdResult = Dao.Insert(ThanhToanDAO, db, ref Messages);
            // Nếu hàm INSERT báo lỗi
            if (IdResult == Constant.RES_FAI)
            {
                // Thêm thông báo lỗi
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = string.Format("Lỗi khi Insert vao Table THANHTOAN - {0}", ProgramName)
                });
                // Return faild
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }

        public string CreateIdThanhToan(out string Id, ref List<MessageError> Messages)
        {
            string ProgramName = "ThanhToanImplement-CreateIdThanhToan";
            List<THANHTOAN> ListThanhToanDAO = new List<THANHTOAN>();
            Id = "TT00000001";
            using (var db = new QLPHONGKHAMEntities())
            {
                ListThanhToanDAO = (from tt in db.THANHTOANs
                               orderby tt.MaThanhToan descending
                               select tt).ToList();
            }
            if (ListThanhToanDAO.Count > 0)
            {
                string curId = ListThanhToanDAO.ElementAt(0).MaThanhToan;
                try
                {
                    int curNumId = Int32.Parse(curId.Substring(2, 8));
                    curNumId += 1;
                    Id = "TT";
                    for (int i = 0; i < (8 - curNumId.ToString().Length); i++)
                    {
                        Id += "0";
                    }
                    Id += curNumId.ToString();
                }
                catch
                {
                    // thêm Message Error
                    Messages.Add(new MessageError
                    {
                        IdError = Constant.MES_SYS,
                        Message = String.Format("Lỗi xãy ra khi Parse một chuổi sang Int32 - {0}", ProgramName)
                    });
                    // return fail;
                    return Constant.RES_FAI;
                }
            }
            return Constant.RES_SUC;
        }

        public string UpdateThanhToan(QLPHONGKHAMEntities db, ThanhToanEntity ThanhToan, ref List<MessageError> Messages)
        {
            string ProgramName = "ThanhToanImplement-UpdateThanhToan";
            string IdResult;
            // Tạo đối tượng THANHTOAN kết quả
            THANHTOAN ThanhToanDAO = new THANHTOAN();
            // Convert đối tượng từ DTO sang DAO
            BUS.Com.Utils.CopyPropertiesFrom(ThanhToan, ThanhToanDAO);
            // Khởi tạo lớp DAO
            DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
            // Thực hiện lệnh Update
            IdResult = Dao.Update(ThanhToanDAO, db, ref Messages);
            // Nếu hàm INSERT báo lỗi
            if (IdResult == Constant.RES_FAI)
            {
                // Thêm thông báo lỗi
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = string.Format("Lỗi khi Update vao Table THANHTOAN - {0}", ProgramName)
                });
                // Return faild
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }
    }

}
