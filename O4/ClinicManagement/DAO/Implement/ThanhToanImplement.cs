using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAO.Common;
using DAO.Interface;

namespace DAO.Implement
{
    public class ThanhToanImplement : IThanhToanServices
    {
        public string Delete(DbContext db, THANHTOAN entity)
        {
            try
            {
                (db as QLPHONGKHAMEntities).THANHTOANs.Remove(entity);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Select(DbContext db, out List<THANHTOAN> listObject)
        {
            listObject = new List<THANHTOAN>();
            try
            {
                listObject = (db as QLPHONGKHAMEntities).THANHTOANs.ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string FindById(DbContext db, object[] id, out THANHTOAN entity)
        {
            entity = new THANHTOAN();
            try
            {
                entity = (db as QLPHONGKHAMEntities).THANHTOANs.Find(id);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Save(DbContext db, THANHTOAN entity)
        {
            object[] id = { entity.MaThanhToan };
            THANHTOAN obj = (db as QLPHONGKHAMEntities).THANHTOANs.Find(id);
            if (obj == null)
            {
                try
                {
                    (db as QLPHONGKHAMEntities).THANHTOANs.Add(entity);
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
