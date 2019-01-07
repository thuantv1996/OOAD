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
    public class DonThuocDAO : IBaseDAO<DONTHUOC>
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

        public string getMaDonThuoc(QLPHONGKHAMEntities db)
        {
            List<DONTHUOC> listDonThuoc = new List<DONTHUOC>();
            string id = "DT00000000";
            try
            {
                listDonThuoc = (from dt in db.DONTHUOCs
                           orderby dt.MaDonThuoc descending
                           select dt).ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            if (listDonThuoc.Count > 0)
            {
                string curId = listDonThuoc.ElementAt(0).MaHoSo;
                try
                {
                    int curNumId = Int32.Parse(curId.Substring(2, 8));
                    curNumId += 1;
                    id = "DT";
                    for (int i = 0; i < (8 - curNumId.ToString().Length); i++)
                    {
                        id += "0";
                    }
                    id += curNumId.ToString();
                }
                catch (Exception e)
                {
                    string log = LogManager.GetErrorFromException(e);
                    LogManager.WriteLog(log);
                    return DAOCommon.FAIL;
                }
            }
            return id;
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

        public string FindByParameter(DbContext db, string maHoSo, out DONTHUOC entity)
        {
            entity = new DONTHUOC();
            try
            {
                entity = (from dt in (db as QLPHONGKHAMEntities).DONTHUOCs
                          where dt.MaHoSo == maHoSo
                          select dt).FirstOrDefault();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }
    }
}
