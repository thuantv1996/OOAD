using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Common;
using DAO.Interface;

namespace DAO.Implement
{
    class DonThuocImplement : IDonThuocServices
    {
        public string Delete(DbContext db, DONTHUOC entity)
        {
            try
            {
                (db as QLPHONGKHAMEntities).DONTHUOCs.Remove(entity);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Select(DbContext db, out List<DONTHUOC> listObject)
        {
            listObject = new List<DONTHUOC>();
            try
            {
                listObject = (db as QLPHONGKHAMEntities).DONTHUOCs.ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string FindById(DbContext db, object[] id, out DONTHUOC entity)
        {
            entity = new DONTHUOC();
            try
            {
                entity = (db as QLPHONGKHAMEntities).DONTHUOCs.Find(id);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Save(DbContext db, DONTHUOC entity)
        {
            object[] id = { entity.MaDonThuoc };
            DONTHUOC obj = (db as QLPHONGKHAMEntities).DONTHUOCs.Find(id);
            if (obj == null)
            {
                try
                {
                    (db as QLPHONGKHAMEntities).DONTHUOCs.Add(entity);
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
