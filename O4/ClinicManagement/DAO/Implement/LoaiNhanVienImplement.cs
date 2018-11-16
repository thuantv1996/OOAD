using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAO.Common;
using DAO.Interface;


namespace DAO.Implement
{
    class LoaiNhanVienImplement : ILoaiNhanVienServices
    {
        public string Delete(DbContext db, LOAINHANVIEN entity)
        {
            try
            {
                (db as QLPHONGKHAMEntities).LOAINHANVIENs.Remove(entity);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Select(DbContext db, out List<LOAINHANVIEN> listObject)
        {
            listObject = new List<LOAINHANVIEN>();
            try
            {
                listObject = (db as QLPHONGKHAMEntities).LOAINHANVIENs.ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string FindById(DbContext db, object[] id, out LOAINHANVIEN entity)
        {
            entity = new LOAINHANVIEN();
            try
            {
                entity = (db as QLPHONGKHAMEntities).LOAINHANVIENs.Find(id);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Save(DbContext db, LOAINHANVIEN entity)
        {
            object[] id = { entity.MaLoaiNV };
            LOAINHANVIEN obj = (db as QLPHONGKHAMEntities).LOAINHANVIENs.Find(id);
            if (obj == null)
            {
                try
                {
                    (db as QLPHONGKHAMEntities).LOAINHANVIENs.Add(entity);
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
