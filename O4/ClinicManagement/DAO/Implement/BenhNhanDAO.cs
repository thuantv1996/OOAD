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
                listObject = (from bn in (db as QLPHONGKHAMEntities).BENHNHANs
                              orderby bn.HoTen ascending
                              select bn).ToList();
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
            string maBenhNhan = param[0].ToString();
            string hoTen = param[1].ToString();
            string cmnd = param[2].ToString();
            try
            {
                listBenhNhan = (from bn in db.BENHNHANs
                                where bn.MaBenhNhan.Contains(maBenhNhan) &&
                                      bn.HoTen.Contains(hoTen) &&
                                      bn.CMND.Contains(cmnd)
                                orderby bn.HoTen ascending
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
