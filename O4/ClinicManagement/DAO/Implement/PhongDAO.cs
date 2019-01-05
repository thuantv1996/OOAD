using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAO.Common;
using DAO.Interface;

namespace DAO.Implement
{
    public class PhongDAO : IBaseDAO<PHONG>
    {
        public string Delete(DbContext db, PHONG entity)
        {
            try
            {
                (db as QLPHONGKHAMEntities).PHONGs.Remove(entity);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Select(DbContext db, out List<PHONG> listObject)
        {
            listObject = new List<PHONG>();
            try
            {
                listObject = (db as QLPHONGKHAMEntities).PHONGs.ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string FindById(DbContext db, object[] id, out PHONG entity)
        {
            entity = new PHONG();
            try
            {
                entity = (db as QLPHONGKHAMEntities).PHONGs.Find(id);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Save(DbContext db, PHONG entity)
        {
            object[] id = { entity.MaPhong };
            PHONG obj = (db as QLPHONGKHAMEntities).PHONGs.Find(id);
            if (obj == null)
            {
                try
                {
                    (db as QLPHONGKHAMEntities).PHONGs.Add(entity);
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
