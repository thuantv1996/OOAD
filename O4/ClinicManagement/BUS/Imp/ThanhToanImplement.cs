using System;
using System.Collections.Generic;
using System.Linq;
using BUS.Service;
using DTO;
using DAO;
using COM;
using DAO.Common;

namespace BUS.Imp
{
    public class ThanhToanImplement : IThanhToanService
    {
        DAO.Implement.ThanhToanImplement thanhToanService = null;

        public ThanhToanImplement()
        {
            thanhToanService = new DAO.Implement.ThanhToanImplement();
        }

        public string InsertThanhToan(QLPHONGKHAMEntities db, ThanhToanEntity ThanhToan)
        {
            THANHTOAN thanhToanDAO = new THANHTOAN();
            BUS.Com.Utils.CopyPropertiesFrom(ThanhToan, thanhToanDAO);
            return thanhToanService.Save(db, thanhToanDAO);
        }

        public string CreateIdThanhToan(QLPHONGKHAMEntities db, out string Id)
        {
            List<THANHTOAN> listThanhToanDAO = new List<THANHTOAN>();
            Id = "TT00000001";
            using (db)
            {
                listThanhToanDAO = (from tt in db.THANHTOANs
                               orderby tt.MaThanhToan descending
                               select tt).ToList();
            }
            if (listThanhToanDAO.Count > 0)
            {
                string curId = listThanhToanDAO.ElementAt(0).MaThanhToan;
                try
                {
                    int curNumId = Int32.Parse(curId.Substring(2, 8));
                    curNumId += 1;
                    Id = "TT";
                    for (int i = 0; i < (8 - curNumId.ToString().Length); i++)
                    {
                        Id += "0";
                    }
                    Id += curNumId.ToString();
                }
                catch
                {
                    string log = LogManager.GetErrorFromException(e);
                    LogManager.WriteLog(log);
                    // return fail;
                    return Constant.RES_FAI;
                }
            }
            return Constant.RES_SUC;
        }

        public string UpdateThanhToan(QLPHONGKHAMEntities db, ThanhToanEntity ThanhToan)
        {
            THANHTOAN thanhToanDAO = new THANHTOAN();
            BUS.Com.Utils.CopyPropertiesFrom(ThanhToan, thanhToanDAO);
            return thanhToanService.Save(db, thanhToanDAO);
        }
    }

}
