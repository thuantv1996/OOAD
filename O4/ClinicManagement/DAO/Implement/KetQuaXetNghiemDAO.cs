using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAO.Common;
using DAO.Interface;

namespace DAO.Implement
{
    public class KetQuaXetNghiemDAO : IBaseDAO<KETQUAXETNGHIEM>
    {
        public string Delete(DbContext db, KETQUAXETNGHIEM entity)
        {
            try
            {
                (db as QLPHONGKHAMEntities).KETQUAXETNGHIEMs.Remove(entity);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Select(DbContext db, out List<KETQUAXETNGHIEM> listObject)
        {
            listObject = new List<KETQUAXETNGHIEM>();
            try
            {
                listObject = (db as QLPHONGKHAMEntities).KETQUAXETNGHIEMs.ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string FindById(DbContext db, object[] id, out KETQUAXETNGHIEM entity)
        {
            entity = new KETQUAXETNGHIEM();
            try
            {
                entity = (db as QLPHONGKHAMEntities).KETQUAXETNGHIEMs.Find(id);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Save(DbContext db, KETQUAXETNGHIEM entity)
        {
            object[] id = { entity.MaHoSo, entity.MaXetNghiem };
            KETQUAXETNGHIEM obj = (db as QLPHONGKHAMEntities).KETQUAXETNGHIEMs.Find(id);
            if (obj == null)
            {
                try
                {
                    (db as QLPHONGKHAMEntities).KETQUAXETNGHIEMs.Add(entity);
                }
                catch (Exception e)
                {
                    string log = LogManager.GetErrorFromException(e);
                    LogManager.WriteLog(log);
                    return DAOCommon.FAIL;
                }
            }
            else
            {
                try
                {
                    (db as QLPHONGKHAMEntities).Entry(obj).CurrentValues.SetValues(entity);
                }
                catch (Exception e)
                {
                    string log = LogManager.GetErrorFromException(e);
                    LogManager.WriteLog(log);
                    return DAOCommon.FAIL;
                }
            }
            return DAOCommon.SUCCESS;
        }

        public string GetListWithIdHoSo(QLPHONGKHAMEntities db, string MaHoSo, out List<KETQUAXETNGHIEM> ListKetQuaXetNghiem)
        {
            ListKetQuaXetNghiem = new List<KETQUAXETNGHIEM>();
            try
            {
                ListKetQuaXetNghiem = (from kq in db.KETQUAXETNGHIEMs
                                       where kq.MaHoSo == MaHoSo
                                       select kq).ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string GetListHasResWithIdHoSo(QLPHONGKHAMEntities db, string MaHoSo, out List<KETQUAXETNGHIEM> ListKetQuaXetNghiem)
        {
            ListKetQuaXetNghiem = new List<KETQUAXETNGHIEM>();
            try
            {
                ListKetQuaXetNghiem = (from kq in db.KETQUAXETNGHIEMs
                                       where kq.MaHoSo == MaHoSo && kq.ThanhToan.Value == true
                                       select kq).ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }
    }
}
