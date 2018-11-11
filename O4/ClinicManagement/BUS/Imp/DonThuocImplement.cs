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
    class DonThuocImplement : IDonThuocService
    {
        public string GetInformationDonThuocWithId(string MaHoSo, DonThuocEnity DonThuocEntity, ref List<MessageError> Messages)
        {
            string ProgramName = "DonThuocImplement-GetInformationDonThuocWithId";
            DonThuocEntity = new DonThuocEnity();
            List<DONTHUOC> ListDonThuocDAO = null;
            string IdResult;

            using (var db = new QLPHONGKHAMEntities())
            {
                BaseDAO dao = new BaseDAO();
                IdResult = dao.Select(db, dt => dt.MaHoSo == MaHoSo, out ListDonThuocDAO, ref Messages);
            }
            // trường hợp select fail
            if (IdResult.Equals(Constant.RES_FAI))
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi xãy ra khi select dữ liệu từ Table DONTHUOC - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            // trường hợp data rỗng
            if (ListDonThuocDAO.Count == 0)
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi empty dữ liệu từ Table DONTHUOC - {0}", ProgramName)
                });
                // return fail;
                return Constant.RES_FAI;
            }
            // trường hợp data trả về nhiều hơn 1 record
            if (ListDonThuocDAO.Count > 1)
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi select trên key nhiều hơn 1 record dữ liệu từ Table DONTHUOC - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            // copy property
            Utils.CopyPropertiesFrom(ListDonThuocDAO.ElementAt(0), DonThuocEntity);
            // return success
            return Constant.RES_SUC;
        }

        public string SaveDonThuoc(QLPHONGKHAMEntities db, DonThuocEnity DonThuocEntity, ref List<MessageError> Messages)
        {
            string ProgramName = "DonThuocImplement-SaveDonThuoc";
            // Tạo đối tượng DonThuocDAO
            DONTHUOC DonThuocDAO = new DONTHUOC();
            // Copy property từ DonThuoc sang DonThuocDAO
            Utils.CopyPropertiesFrom(DonThuocEntity, DonThuocDAO);
            // Biến đón kết quả từ dao
            string IdResult;

            // Tạo đối tượng DAO
            BaseDAO dao = new BaseDAO();
            IdResult = dao.Insert(DonThuocDAO, db, ref Messages);
            if (IdResult.Equals(Constant.RES_FAI))
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi xãy ra khi insert dữ liệu từ Table DONTHUOC - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            // return success
            return Constant.RES_SUC;
        }
    }
}
