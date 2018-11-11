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
    class ChiTietDonThuocImplement : IChiTietDonThuocService
    {
        public string SaveChiTietDonThuoc(QLPHONGKHAMEntities db, ChiTietDonThuocEnity ChiTietDonThuocEntity, ref List<MessageError> Messages)
        {
            string ProgramName = "ChiTietDonThuocImplement-SaveChiTietDonThuoc";
            // Tạo đối tượng ChiTietDonThuocDAO
            CHITIETDONTHUOC ChiTietDonThuocDAO = new CHITIETDONTHUOC();
            // Copy property từ ChiTietDonThuoc sang ChiTietDonThuocDAO
            Utils.CopyPropertiesFrom(ChiTietDonThuocEntity, ChiTietDonThuocDAO);
            // Biến đón kết quả từ dao
            string IdResult;

            // Tạo đối tượng DAO
            BaseDAO dao = new BaseDAO();
            IdResult = dao.Insert(ChiTietDonThuocDAO, db, ref Messages);
            if (IdResult.Equals(Constant.RES_FAI))
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi xãy ra khi insert dữ liệu từ Table CHITIETDONTHUOC - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            // return success
            return Constant.RES_SUC;
        }
    

        public string UpdateChiTietDonThuoc(QLPHONGKHAMEntities db, ChiTietDonThuocEnity ChiTietDonThuocEntity, ref List<MessageError> Messages)
        {
            string ProgramName = "ChiTietDonThuocImplement-UpdateChiTietDonThuoc";
            // Tạo đối tượng ChiTietDonThuocDAO
            CHITIETDONTHUOC ChiTietDonThuocDAO = new CHITIETDONTHUOC();
            // Copy property từ ChiTietDonThuoc sang ChiTietDonThuocDAO
            Utils.CopyPropertiesFrom(ChiTietDonThuocEntity, ChiTietDonThuocDAO);
            // Biến đón kết quả từ dao
            string IdResult;

            // Tạo đối tượng DAO
            BaseDAO dao = new BaseDAO();
            // Thực thi update ChiTietDonThuoc
            IdResult = dao.Update(ChiTietDonThuocDAO, db, ref Messages);

            // Nếu lệnh update fail
            if (IdResult.Equals(Constant.RES_FAI))
            {
                // thêm Message Error
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi xãy ra khi update dữ liệu từ Table CHITIETDONTHUOC - {0}", ProgramName)
                });
                // return fail;
                return Constant.RES_FAI;
            }
            // return success
            return Constant.RES_SUC;
        }
    }
}
