using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAO.Common;
using DAO.Interface;

namespace DAO.Implement
{
    public class TaiKhoanDAO : IBaseDAO<TAIKHOAN>
    {
        public string Delete(DbContext db, TAIKHOAN entity)
        {
            try
            {
                (db as QLPHONGKHAMEntities).TAIKHOANs.Remove(entity);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Select(DbContext db, out List<TAIKHOAN> listObject)
        {
            listObject = new List<TAIKHOAN>();
            try
            {
                listObject = (db as QLPHONGKHAMEntities).TAIKHOANs.ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string FindById(DbContext db, object[] id, out TAIKHOAN entity)
        {
            entity = new TAIKHOAN();
            try
            {
                entity = (db as QLPHONGKHAMEntities).TAIKHOANs.Find(id);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Save(DbContext db, TAIKHOAN entity)
        {
            object[] id = { entity.MaTaiKhoan };
            TAIKHOAN obj = (db as QLPHONGKHAMEntities).TAIKHOANs.Find(id);
            if (obj == null)
            {
                try
                {
                    (db as QLPHONGKHAMEntities).TAIKHOANs.Add(entity);
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
       
        public string FindByParameter(QLPHONGKHAMEntities db, object[] param, out TAIKHOAN taiKhoan)
        {
            taiKhoan = null;
            try
            {
                taiKhoan = (from tk in db.TAIKHOANs
                            where tk.TenDangNhap == param[0].ToString() &&
                                  tk.MatKhau == param[1].ToString()
                            select tk).FirstOrDefault();
            }catch(Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            if(taiKhoan == null)
            {
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }
    }
}
