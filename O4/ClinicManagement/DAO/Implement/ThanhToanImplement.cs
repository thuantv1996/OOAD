using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAO.Common;
using DAO.Interface;

namespace DAO.Implement
{
    public class ThanhToanDAO : IBaseDAO<THANHTOAN>
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

        public string CreateId(QLPHONGKHAMEntities db, out string id)
        {
            List<THANHTOAN> listThanhToanDAO = new List<THANHTOAN>();
            id = "TT00000001";
            listThanhToanDAO = (from tt in db.THANHTOANs
                                    orderby tt.MaThanhToan descending
                                    select tt).ToList();
            if(listThanhToanDAO == null)
            {
                return DAOCommon.SUCCESS;
            }
            if(listThanhToanDAO.Count == 0)
            {
                return DAOCommon.SUCCESS;
            }
            if (listThanhToanDAO.Count > 0)
            {
                string curId = listThanhToanDAO.ElementAt(0).MaThanhToan;
                try
                {
                    int curNumId = Int32.Parse(curId.Substring(2, 8));
                    curNumId += 1;
                    id = "TT";
                    for (int i = 0; i < (8 - curNumId.ToString().Length); i++)
                    {
                        id += "0";
                    }
                    id += curNumId.ToString();
                }
                catch(Exception e)
                {
                    string log = LogManager.GetErrorFromException(e);
                    LogManager.WriteLog(log);
                    // return fail;
                    return DAOCommon.FAIL;
                }
            }
            return DAOCommon.SUCCESS;
        }
    }
}
