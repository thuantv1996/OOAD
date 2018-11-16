using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COM;
using DAO.Common;
using DAO.Interface;
namespace DAO.Implement
{
    class BenhNhanImplement : IBenhNhanServices
    {
        public string Delete(DbContext db, BENHNHAN entity)
        {
            try
            {
                (db as QLPHONGKHAMEntities).BENHNHANs.Remove(entity);
            }catch(Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Select(DbContext db, out List<BENHNHAN> listObject)
        {
            listObject = new List<BENHNHAN>();
            try
            {
                listObject = (db as QLPHONGKHAMEntities).BENHNHANs.ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string FindById(DbContext db, object[] id, out BENHNHAN entity)
        {
            entity = new BENHNHAN();
            try
            {
                entity = (db as QLPHONGKHAMEntities).BENHNHANs.Find(id);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Save(DbContext db, BENHNHAN entity)
        {
            BENHNHAN obj = (db as QLPHONGKHAMEntities).BENHNHANs.Find(entity.MaBenhNhan);
            if (obj == null)
            {
                try
                {
                    (db as QLPHONGKHAMEntities).BENHNHANs.Add(entity);
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
