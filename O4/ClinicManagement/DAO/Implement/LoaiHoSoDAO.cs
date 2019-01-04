using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAO.Common;
using DAO.Interface;

namespace DAO.Implement
{
    public class LoaiHoSoDAO : IBaseDAO<LOAIHOSO>
    {
        public string Delete(DbContext db, LOAIHOSO entity)
        {
            try
            {
                (db as QLPHONGKHAMEntities).LOAIHOSOes.Remove(entity);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Select(DbContext db, out List<LOAIHOSO> listObject)
        {
            listObject = new List<LOAIHOSO>();
            try
            {
                listObject = (db as QLPHONGKHAMEntities).LOAIHOSOes.ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string FindById(DbContext db, object[] id, out LOAIHOSO entity)
        {
            entity = new LOAIHOSO();
            try
            {
                entity = (db as QLPHONGKHAMEntities).LOAIHOSOes.Find(id);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Save(DbContext db, LOAIHOSO entity)
        {
            if (!entity.Validate())
            {
                string log = "Error validate in LOAIHOSO object";
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            object[] id = { entity.MaLoaiHoSo };
            LOAIHOSO obj = (db as QLPHONGKHAMEntities).LOAIHOSOes.Find(id);
            if (obj == null)
            {
                try
                {
                    (db as QLPHONGKHAMEntities).LOAIHOSOes.Add(entity);
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
