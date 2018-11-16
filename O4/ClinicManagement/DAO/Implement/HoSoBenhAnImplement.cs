using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAO.Common;
using DAO.Interface;

namespace DAO.Implement
{
    class HoSoBenhAnImplement : IHoSoBenhAnServices
    {
        public string Delete(DbContext db, HOSOBENHAN entity)
        {
            try
            {
                (db as QLPHONGKHAMEntities).HOSOBENHANs.Remove(entity);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Select(DbContext db, out List<HOSOBENHAN> listObject)
        {
            listObject = new List<HOSOBENHAN>();
            try
            {
                listObject = (db as QLPHONGKHAMEntities).HOSOBENHANs.ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string FindById(DbContext db, object[] id, out HOSOBENHAN entity)
        {
            entity = new HOSOBENHAN();
            try
            {
                entity = (db as QLPHONGKHAMEntities).HOSOBENHANs.Find(id);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Save(DbContext db, HOSOBENHAN entity)
        {
            object[] id = { entity.MaHoSo };
            HOSOBENHAN obj = (db as QLPHONGKHAMEntities).HOSOBENHANs.Find(id);
            if (obj == null)
            {
                try
                {
                    (db as QLPHONGKHAMEntities).HOSOBENHANs.Add(entity);
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
    }
}
