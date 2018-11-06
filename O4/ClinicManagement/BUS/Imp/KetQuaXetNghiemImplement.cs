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
            KETQUAXETNGHIEM KetQuaXetNghiemResult = new KETQUAXETNGHIEM();
            BUS.Com.Utils.CopyPropertiesFrom(KetQuaXetNghiem, KetQuaXetNghiemResult);
            using (db = new QLPHONGKHAMEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                    IdResult = Dao.Insert(KetQuaXetNghiemResult, db, ref Messages);
                    if (IdResult == Constant.RES_FAI)
                    {
                        Messages.Add(new MessageError
                        {
                            IdError = Constant.MES_DB,
                            Message = string.Format("Lỗi khi Update vao Table KETQUAXETNGHIEM - {0}", ProgramName)
                        });
                        trans.Rollback();
                        IdResult = Constant.RES_FAI;
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
        public string UpdateKetQuaXetNghiem(QLPHONGKHAMEntities db, KetQuaXetNghiemEnity KetQuaXetNghiem, ref List<MessageError> Messages)
        {
            using (db = new QLPHONGKHAMEntities())
            {
                string ProgramName = "KetQuaXetNghiemImplement-AddKetQuaXetNghiem";
                string IdResult;
                KETQUAXETNGHIEM KetQuaXetNghiemResult = new KETQUAXETNGHIEM();
                BUS.Com.Utils.CopyPropertiesFrom(KetQuaXetNghiem, KetQuaXetNghiemResult);
                using (var trans = db.Database.BeginTransaction())
                {
                    DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                    IdResult = Dao.Update(KetQuaXetNghiemResult, db, ref Messages);
                    if (IdResult == Constant.RES_FAI)
                    {
                        Messages.Add(new MessageError
                        {
                            IdError = Constant.MES_DB,
                            Message = string.Format("Lỗi khi Update vao Table KETQUAXETNGHIEM - {0}", ProgramName)
                        });
                        trans.Rollback();
                        IdResult = Constant.RES_FAI;
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
