using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAO.Common;
using DAO.Interface;

namespace DAO.Implement
{
   public class TrangThaiPhongImplement : ITrangThaiPhongServices
    {
        public string Delete(DbContext db, TRANGTHAIPHONG entity)
        {
            try
            {
                (db as QLPHONGKHAMEntities).TRANGTHAIPHONGs.Remove(entity);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Select(DbContext db, out List<TRANGTHAIPHONG> listObject)
        {
            listObject = new List<TRANGTHAIPHONG>();
            try
            {
                listObject = (db as QLPHONGKHAMEntities).TRANGTHAIPHONGs.ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string FindById(DbContext db, object[] id, out TRANGTHAIPHONG entity)
        {
            entity = new TRANGTHAIPHONG();
            try
            {
                entity = (db as QLPHONGKHAMEntities).TRANGTHAIPHONGs.Find(id);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Save(DbContext db, TRANGTHAIPHONG entity)
        {
            object[] id = { entity.MaPhong, entity.NgayKham };
            TRANGTHAIPHONG obj = (db as QLPHONGKHAMEntities).TRANGTHAIPHONGs.Find(id);
            if (obj == null)
            {
                try
                {
                    (db as QLPHONGKHAMEntities).TRANGTHAIPHONGs.Add(entity);
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
