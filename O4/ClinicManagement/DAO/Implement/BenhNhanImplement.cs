using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAO.Common;
using DAO.Interface;

namespace DAO.Implement
{
    public class BenhNhanDAO : IBaseDAO<BENHNHAN>
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

        public string SearchWithParameter(QLPHONGKHAMEntities db, object[] param, out List<BENHNHAN> listBenhNhan)
        {
            listBenhNhan = new List<BENHNHAN>();
            try
            {
                listBenhNhan = (from bn in db.BENHNHANs
                                where bn.MaBenhNhan.Contains(param[0].ToString()) &&
                                      bn.HoTen.Contains(param[1].ToString()) &&
                                      bn.CMND.Contains(param[2].ToString())
                                select bn).ToList();
            }
            catch(Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }
    }
}
