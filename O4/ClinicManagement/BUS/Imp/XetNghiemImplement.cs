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
using BUS.Com;
using DAO.Imp;
namespace BUS.Imp
{
    class XetNghiemImplement : IXetNghiemService
    {
        // LẤY DANH SÁCH CÁC XÉT NGHIỆM
        public string GetListXetNghiem(out List<XetNghiemEnity> ListXetNghiem, ref List<MessageError> Messages)
        {
            string ProgramName = "XetNghiemImplement-GetListXetNghiem";
            // khởi tạo đối tượng XetNghiem
            ListXetNghiem = new List<XetNghiemEnity>();
            // Khởi tạo danh sách XetNghiemDAO trả về 
            List<XETNGHIEM> ListXetNghiemDAO = null;
            // Biến đón kết quả từ dao
            string IdResult;
            // Khởi tạo DB
            using (var db = new QLPHONGKHAMEntities())
            {
                // Tạo đối tượng DAO
                BaseDAO dao = new BaseDAO();
                // thực hiện lệnh select
                IdResult = dao.Select(db, out ListXetNghiemDAO, ref Messages);
            }
            // trường hợp select fail
            if (IdResult.Equals(Constant.RES_FAI))
            {
                // thêm Message Error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi xãy ra khi select dữ liệu từ Table XETNGHIEM - {0}", ProgramName)
                });
                // return fail;
                return Constant.RES_FAI;
            }
            // trường hợp data rỗng
            if (ListXetNghiemDAO.Count == 0)
            {
                // thêm Message Error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi empty dữ liệu từ Table XETNGHIEM - {0}", ProgramName)
                });
                // return fail;
                return Constant.RES_FAI;
            }
            // duyệt qua danh sách xét nghiệm
            foreach (var xetnghiem in ListXetNghiemDAO)
            {
                // tạo đối tượng entity
                XetNghiemEnity xetNghiemEntity = new XetNghiemEnity();
                // copy property
                Utils.CopyPropertiesFrom(xetnghiem, xetNghiemEntity);
                // add vào list ouput
                ListXetNghiem.Add(xetNghiemEntity);
            }
            return Constant.RES_SUC;
        }

        // LẤY THÔNG TIN CHI TIẾT CỦA 1 XÉT NGHIỆM
        public string GetInfomationXetNghiem(string MaXetNghiem, out XetNghiemEnity XetNghiemEntity, ref List<MessageError> Messages)
        {
            string ProgramName = "XetNghiemImplement-GetInfomationXetNghiem";
            // khởi tạo đối tượng XetNghiem
            XetNghiemEntity = new XetNghiemEnity();
            // Khởi tạo danh sách XetNghiemDAO trả về 
            List<XETNGHIEM> ListXetNghiemDAO = null;
            // Biến đón kết quả từ dao
            string IdResult;
            // Khởi tạo DB
            using (var db = new QLPHONGKHAMEntities())
            {
                // Tạo đối tượng DAO
                BaseDAO dao = new BaseDAO();
                // thực hiện lệnh select
                IdResult = dao.Select(db, xn => xn.MaXetNghiem == MaXetNghiem, out ListXetNghiemDAO, ref Messages);
            }
            // trường hợp select fail
            if (IdResult.Equals(Constant.RES_FAI))
            {
                // thêm Message Error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi xãy ra khi select dữ liệu từ Table XETNGHIEM - {0}", ProgramName)
                });
                // return fail;
                return Constant.RES_FAI;
            }
            // trường hợp data rỗng
            if (ListXetNghiemDAO.Count == 0)
            {
                // thêm Message Error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi empty dữ liệu từ Table XETNGHIEM - {0}", ProgramName)
                });
                // return fail;
                return Constant.RES_FAI;
            }
            // trường hợp data trả về nhiều hơn 1 record
            if (ListXetNghiemDAO.Count > 1)
            {
                // thêm Message Error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi select trên key nhiều hơn 1 record dữ liệu từ Table XETNGHIEM - {0}", ProgramName)
                });
                // return fail;
                return Constant.RES_FAI;
            }
            // copy property
            Utils.CopyPropertiesFrom(ListXetNghiemDAO.ElementAt(0), XetNghiemEntity);
            // return success
            return Constant.RES_SUC;
        }
    }
}
