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
    public class ChiTietDonThuocDAO : IBaseDAO<CHITIETDONTHUOC>
    {
        public string Delete(DbContext db, CHITIETDONTHUOC entity)
        {
            try
            {
                (db as QLPHONGKHAMEntities).CHITIETDONTHUOCs.Remove(entity);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Select(DbContext db, out List<CHITIETDONTHUOC> listObject)
        {
            listObject = new List<CHITIETDONTHUOC>();
            try
            {
                listObject = (db as QLPHONGKHAMEntities).CHITIETDONTHUOCs.ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string FindById(DbContext db, object[] id, out CHITIETDONTHUOC entity)
        {
            entity = new CHITIETDONTHUOC();
            try
            {
                entity = (db as QLPHONGKHAMEntities).CHITIETDONTHUOCs.Find(id);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Save(DbContext db, CHITIETDONTHUOC entity)
        {
            object[] id = { entity.MaDonThuoc, entity.MaThuoc };
            CHITIETDONTHUOC obj = (db as QLPHONGKHAMEntities).CHITIETDONTHUOCs.Find(id);
            if (obj == null)
            {
                try
                {
                    (db as QLPHONGKHAMEntities).CHITIETDONTHUOCs.Add(entity);
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

        public string GetListWithIdDonThuoc(QLPHONGKHAMEntities db, string MaDonthuoc, out List<CHITIETDONTHUOC> listChiTiet)
        {
            listChiTiet = new List<CHITIETDONTHUOC>();
            try
            {
                listChiTiet = (from ct in db.CHITIETDONTHUOCs
                               where ct.MaDonThuoc.Equals(MaDonthuoc)
                               select ct).ToList();
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
