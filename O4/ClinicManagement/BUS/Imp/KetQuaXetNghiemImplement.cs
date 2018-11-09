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
    public class KetQuaXetNghiemImplement : IKetQuaXetNguyenService
    {
        public string AddKetQuaXetNghiem(QLPHONGKHAMEntities db, KetQuaXetNghiemEnity KetQuaXetNghiem, ref List<MessageError> Messages)
        {
            string ProgramName = "KetQuaXetNghiemImplement-AddKetQuaXetNghiem";
            string IdResult;
            KETQUAXETNGHIEM KetQuaXetNghiemDAO = new KETQUAXETNGHIEM();
            BUS.Com.Utils.CopyPropertiesFrom(KetQuaXetNghiem, KetQuaXetNghiemDAO);
            DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
            IdResult = Dao.Insert(KetQuaXetNghiemDAO, db, ref Messages);
            if (IdResult == Constant.RES_FAI)
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = string.Format("Lỗi khi Update vao Table KETQUAXETNGHIEM - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }
        public string UpdateKetQuaXetNghiem(QLPHONGKHAMEntities db, KetQuaXetNghiemEnity KetQuaXetNghiem, ref List<MessageError> Messages)
        {
            string ProgramName = "KetQuaXetNghiemImplement-AddKetQuaXetNghiem";
            string IdResult;
            KETQUAXETNGHIEM KetQuaXetNghiemResult = new KETQUAXETNGHIEM();
            BUS.Com.Utils.CopyPropertiesFrom(KetQuaXetNghiem, KetQuaXetNghiemResult);
            DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
            IdResult = Dao.Update(KetQuaXetNghiemResult, db, ref Messages);
            if (IdResult == Constant.RES_FAI)
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = string.Format("Lỗi khi Update vao Table KETQUAXETNGHIEM - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }
    }
}
