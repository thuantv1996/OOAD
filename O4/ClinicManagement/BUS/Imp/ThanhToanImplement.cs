using System;
using System.Collections.Generic;
using System.Linq;
using BUS.Service;
using DTO;
using DAO;
using COM;

namespace BUS.Imp
{
    public class ThanhToanImplement : IThanhToanService
    {
        DAO.Interface.IThanhToanServices thanhToanService = null;

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
            return thanhToanService.CreateId(db, out Id);
        }

        public string UpdateThanhToan(QLPHONGKHAMEntities db, ThanhToanEntity ThanhToan)
        {
            THANHTOAN thanhToanDAO = new THANHTOAN();
            BUS.Com.Utils.CopyPropertiesFrom(ThanhToan, thanhToanDAO);
            return thanhToanService.Save(db, thanhToanDAO);
        }
    }

}
