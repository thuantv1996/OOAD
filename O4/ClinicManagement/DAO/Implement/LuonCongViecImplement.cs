using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAO.Common;
using DAO.Interface;

namespace DAO.Implement
{
    public class LuonCongViecImplement : ILuonCongViecServices
    {
        public string Delete(DbContext db, LUONCONGVIEC entity)
        {
            try
            {
                (db as QLPHONGKHAMEntities).LUONCONGVIECs.Remove(entity);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Select(DbContext db, out List<LUONCONGVIEC> listObject)
        {
            listObject = new List<LUONCONGVIEC>();
            try
            {
                listObject = (db as QLPHONGKHAMEntities).LUONCONGVIECs.ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string FindById(DbContext db, object[] id, out LUONCONGVIEC entity)
        {
            entity = new LUONCONGVIEC();
            try
            {
                entity = (db as QLPHONGKHAMEntities).LUONCONGVIECs.Find(id);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Save(DbContext db, LUONCONGVIEC entity)
        {
            object[] id = { entity.MaHoSo };
            LUONCONGVIEC obj = (db as QLPHONGKHAMEntities).LUONCONGVIECs.Find(id);
            if (obj == null)
            {
                try
                {
                    (db as QLPHONGKHAMEntities).LUONCONGVIECs.Add(entity);
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
