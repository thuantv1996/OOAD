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
    class LoaiHoSoImplement : ILoaiHoSoService
    {
        public string GetListLoaiHoSo(out List<LoaiHoSoEnity> ListLoaiHoSo, ref List<MessageError> Messages)
        {
            string ProgramName = "LoaiHoSoImplement_GetListLoaiHoSo";
            ListLoaiHoSo = new List<LoaiHoSoEnity>();
            List<LOAIHOSO> LstResult = null;
            string IdResult = "";
            using (var db = new QLPHONGKHAMEntities())
            {
                DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                IdResult = Dao.Select(db, out LstResult, ref Messages);
                if (IdResult == Constant.RES_FAI)
                {
                    Messages.Add(new MessageError
                    {
                        IdError = Constant.MES_DB,
                        Message = string.Format("Lỗi Database trong truy vấn select table LOAIHOSO - {0}", ProgramName)
                    });
                    return Constant.RES_FAI;
                }
                if (LstResult.Count == 0)
                {
                    Messages.Add(new MessageError
                    {
                        IdError = Constant.MES_DB,
                        Message = string.Format("Không select được dữ liệu (Data is empty) - {0}", ProgramName)
                    });
                    return Constant.RES_FAI;
                }
            }
            foreach (var loaihoso in LstResult)
            {
                LoaiHoSoEnity temp = new LoaiHoSoEnity();
                BUS.Com.Utils.CopyPropertiesFrom(loaihoso, temp);
                ListLoaiHoSo.Add(temp);
            }
            return IdResult;
        }

        public string GetInformationLoaiHoSo(string MaLoaiHoSo, out LoaiHoSoEnity InformationLoaiHoSo, ref List<MessageError> Messages)
        {
            string ProgramName = "LoaiHoSoImplement_GetListLoaiHoSo";
            // khởi tạo đối tượng LoaiHoSo
            InformationLoaiHoSo = new LoaiHoSoEnity();
            // Khởi tạo danh sách LoaiHoSoDAO trả về 
            List<LOAIHOSO> ListLoaiHoSoDAO = null;
            // Biến đón kết quả từ dao
            string IdResult;
            // Khởi tạo DB
            using (var db = new QLPHONGKHAMEntities())
            {
                // Tạo đối tượng DAO
                BaseDAO dao = new BaseDAO();
                // thực hiện lệnh select
                IdResult = dao.Select(db, lhs => lhs.MaLoaiHoSo == MaLoaiHoSo, out ListLoaiHoSoDAO, ref Messages);
            }
            // trường hợp select fail
            if (IdResult.Equals(Constant.RES_FAI))
            {
                // thêm Message Error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi xãy ra khi select dữ liệu từ Table LOAIHOSO - {0}", ProgramName)
                });
                // return fail;
                return Constant.RES_FAI;
            }
            // trường hợp data rỗng
            if (ListLoaiHoSoDAO.Count == 0)
            {
                // thêm Message Error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi empty dữ liệu từ Table LOAIHOSO - {0}", ProgramName)
                });
                // return fail;
                return Constant.RES_FAI;
            }
            // trường hợp data trả về nhiều hơn 1 record
            if (ListLoaiHoSoDAO.Count > 1)
            {
                // thêm Message Error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi select trên key nhiều hơn 1 record dữ liệu từ Table LOAIHOSO - {0}", ProgramName)
                });
                // return fail;
                return Constant.RES_FAI;
            }
            // copy property
            Utils.CopyPropertiesFrom(ListLoaiHoSoDAO.ElementAt(0), InformationLoaiHoSo);
            // return success
            return Constant.RES_SUC;
        }
    }
}
