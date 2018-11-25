using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAO.Common;
using DAO.Interface;

namespace DAO.Implement
{
    public class XetNghiemDAO : IBaseDAO<XETNGHIEM>
    {
        public string Delete(DbContext db, XETNGHIEM entity)
        {
            try
            {
                (db as QLPHONGKHAMEntities).XETNGHIEMs.Remove(entity);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Select(DbContext db, out List<XETNGHIEM> listObject)
        {
            listObject = new List<XETNGHIEM>();
            try
            {
                listObject = (db as QLPHONGKHAMEntities).XETNGHIEMs.ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string FindById(DbContext db, object[] id, out XETNGHIEM entity)
        {
            entity = new XETNGHIEM();
            try
            {
                entity = (db as QLPHONGKHAMEntities).XETNGHIEMs.Find(id);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Save(DbContext db, XETNGHIEM entity)
        {
            object[] id = { entity.MaXetNghiem };
            XETNGHIEM obj = (db as QLPHONGKHAMEntities).XETNGHIEMs.Find(id);
            if (obj == null)
            {
                try
                {
                    (db as QLPHONGKHAMEntities).XETNGHIEMs.Add(entity);
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
