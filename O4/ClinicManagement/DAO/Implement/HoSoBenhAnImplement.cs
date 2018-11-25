using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAO.Common;
using DAO.Interface;

namespace DAO.Implement
{
    public class HoSoBenhAnDAO : IBaseDAO<HOSOBENHAN>
    {
        public string Delete(DbContext db, HOSOBENHAN entity)
        {
            try
            {
                (db as QLPHONGKHAMEntities).HOSOBENHANs.Remove(entity);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Select(DbContext db, out List<HOSOBENHAN> listObject)
        {
            listObject = new List<HOSOBENHAN>();
            try
            {
                listObject = (db as QLPHONGKHAMEntities).HOSOBENHANs.ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string FindById(DbContext db, object[] id, out HOSOBENHAN entity)
        {
            entity = new HOSOBENHAN();
            try
            {
                entity = (db as QLPHONGKHAMEntities).HOSOBENHANs.Find(id);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string Save(DbContext db, HOSOBENHAN entity)
        {
            object[] id = { entity.MaHoSo };
            HOSOBENHAN obj = (db as QLPHONGKHAMEntities).HOSOBENHANs.Find(id);
            if (obj == null)
            {
                try
                {
                    (db as QLPHONGKHAMEntities).HOSOBENHANs.Add(entity);
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

        public string SearchHoSo(QLPHONGKHAMEntities db, object[] param, out List<HOSOBENHAN> listHoSo)
        {
            listHoSo = null;
            try
            {
                listHoSo = (from hs in db.HOSOBENHANs
                            join bn in db.BENHNHANs on hs.MaBenhNhan equals bn.MaBenhNhan
                            where hs.MaHoSo.Contains(param[0].ToString()) &&
                                  bn.MaBenhNhan.Contains(param[1].ToString()) &&
                                  hs.NgayKham.Equals(param[2])
                            select hs
                            ).ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string GetListHoSoWithRoomAndNode(QLPHONGKHAMEntities db, object[] param, out List<HOSOBENHAN> listHoSo)
        {
            listHoSo = null;
            try
            {
                listHoSo = (from hs in db.HOSOBENHANs
                            join p in db.PHONGs on hs.MaPhongKham equals p.MaPhong
                            join lcv in db.LUONCONGVIECs on hs.MaHoSo equals lcv.MaHoSo
                            where hs.MaPhongKham == param[0].ToString() &&
                                  lcv.NodeHienTai == param[1].ToString()
                            select hs
                            ).ToList();
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            return DAOCommon.SUCCESS;
        }

        public string GetRootHoSo(QLPHONGKHAMEntities db, string MaHoSoTruoc, out HOSOBENHAN hoSoBenhAnRoot)
        {
            hoSoBenhAnRoot = null;
            HOSOBENHAN hoSoTruoc = null;
            try
            {
                hoSoTruoc = db.HOSOBENHANs.Find(MaHoSoTruoc);
            }
            catch (Exception e)
            {
                string log = LogManager.GetErrorFromException(e);
                LogManager.WriteLog(log);
                return DAOCommon.FAIL;
            }
            if (hoSoTruoc == null)
            {
                return DAOCommon.FAIL;
            }
            if (hoSoTruoc.MaHoSoGoc == null && hoSoTruoc.MaHoSoGoc == "")
            {
                hoSoBenhAnRoot = hoSoTruoc;
            }
            else
            {
                hoSoBenhAnRoot = db.HOSOBENHANs.Find(hoSoTruoc.MaHoSoGoc);
                if (hoSoBenhAnRoot == null)
                {
                    return DAOCommon.FAIL;
                }
            }
            return DAOCommon.SUCCESS;

        }

        public string CreateId(QLPHONGKHAMEntities db, out string Id)
        {
            List<HOSOBENHAN> ListHoSoDAO = new List<HOSOBENHAN>();
            Id = "HS00000001";
            ListHoSoDAO = (from hs in db.HOSOBENHANs
                           orderby hs.MaHoSo descending
                           select hs).ToList();
            if (ListHoSoDAO.Count > 0)
            {
                string curId = ListHoSoDAO.ElementAt(0).MaHoSo;
                try
                {
                    int curNumId = Int32.Parse(curId.Substring(2, 8));
                    curNumId += 1;
                    Id = "HS";
                    for (int i = 0; i < (8 - curNumId.ToString().Length); i++)
                    {
                        Id += "0";
                    }
                    Id += curNumId.ToString();
                }
                catch (Exception e)
                {
                    string log = LogManager.GetErrorFromException(e);
                    LogManager.WriteLog(log);
                    return DAOCommon.FAIL;
                }
            }
            return DAOCommon.FAIL;
        }

        public string GetListHoSoWithIdBenhNhan(QLPHONGKHAMEntities db, string MaBenhNhan, out List<HOSOBENHAN> ListHoSo)
        {
            ListHoSo = new List<HOSOBENHAN>();
            try
            {
                ListHoSo = (from hs in db.HOSOBENHANs
                            where hs.MaBenhNhan == MaBenhNhan
                            select hs).ToList();
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
