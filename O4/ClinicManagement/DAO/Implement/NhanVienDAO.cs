using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAO.Common;
using DAO.Interface;

namespace DAO.Implement
{
    public class NhanVienDAO : IBaseDAO<NHANVIEN>
    {
        public string Delete(DbContext db, NHANVIEN entity)
        {
            try
            {
                (db as QLPHONGKHAMEntities).NHANVIENs.Remove(entity);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Select(DbContext db, out List<NHANVIEN> listObject)
        {
            listObject = new List<NHANVIEN>();
            try
            {
                listObject = (db as QLPHONGKHAMEntities).NHANVIENs.ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string FindById(DbContext db, object[] id, out NHANVIEN entity)
        {
            entity = new NHANVIEN();
            try
            {
                entity = (db as QLPHONGKHAMEntities).NHANVIENs.Find(id);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Save(DbContext db, NHANVIEN entity)
        {
            object[] id = { entity.MaNV };
            NHANVIEN obj = (db as QLPHONGKHAMEntities).NHANVIENs.Find(id);
            if (obj == null)
            {
                try
                {
                    (db as QLPHONGKHAMEntities).NHANVIENs.Add(entity);
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

        public string GetListNhanVienWithIdRoom(QLPHONGKHAMEntities db, object[] param, out List<NHANVIEN> listEntity)
        {
            listEntity = null;
            string maPhong = param[0].ToString();
            try
            {
                listEntity = (from nv in db.NHANVIENs
                              where nv.MaPhong == maPhong
                              select nv).ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }
        public string GetListNhanVienWithLNV(QLPHONGKHAMEntities db, string MaLNV, out List<NHANVIEN> listEntity)
        {
            listEntity = null;
            try
            {
                listEntity = (from nv in db.NHANVIENs
                              where nv.MaLoaiNV == MaLNV
                              select nv).ToList();
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
