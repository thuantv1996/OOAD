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
    public class HoSoBenhNhanImplement : IHoSoBenhNhanService
    {
        public string AddHoSoBenhNhan(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSoBenhAn, ref List<MessageError> Messages)
        {
            string ProgramName = "HoSoBenhNhanImplement-AddHoSoBenhNhan";
            string IdResult;
            HOSOBENHAN HoSoBenhAnResult = new HOSOBENHAN();
            BUS.Com.Utils.CopyPropertiesFrom(HoSoBenhAn, HoSoBenhAnResult);
            using (db = new QLPHONGKHAMEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                    IdResult = Dao.Insert(HoSoBenhAnResult, db, ref Messages);
                    if (IdResult == Constant.RES_FAI)
                    {
                        Messages.Add(new MessageError
                        {
                            IdError = Constant.MES_DB,
                            Message = string.Format("Lỗi khi Update vao Table HOSOBENHAN - {0}", ProgramName)
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

        public string UpdateKetQuaXetNghiem(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSoBenhAn, ref List<MessageError> Messages)
        {
            string ProgramName = "HoSoBenhNhanImplement-AddHoSoBenhNhan";
            string IdResult;
            HOSOBENHAN HoSoBenhAnResult = new HOSOBENHAN();
            BUS.Com.Utils.CopyPropertiesFrom(HoSoBenhAn, HoSoBenhAnResult);
            using (db = new QLPHONGKHAMEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
                    IdResult = Dao.Update(HoSoBenhAnResult, db, ref Messages);
                    if (IdResult == Constant.RES_FAI)
                    {
                        Messages.Add(new MessageError
                        {
                            IdError = Constant.MES_DB,
                            Message = string.Format("Lỗi khi Update vao Table HOSOBENHAN - {0}", ProgramName)
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
