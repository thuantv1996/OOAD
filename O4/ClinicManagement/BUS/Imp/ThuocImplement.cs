using System.Collections.Generic;
using BUS.Service;
using DTO;
using BUS.Entities;
using DAO;
using COM;



namespace BUS.Imp
{
    class ThuocImplement : IThuocService
    {
        DAO.Interface.IThuocServices donThuocService = null;

        public ThuocImplement()
        {
            donThuocService = new DAO.Implement.ThuocImplement();
        }

        public string GetListThuoc(QLPHONGKHAMEntities db, out List<ThuocEnity> ListThuocEntity)
        {
            ListThuocEntity = new List<ThuocEnity>();
            List<THUOC> listObjectDAO = null;
            if (donThuocService.Select(db, out listObjectDAO) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (listObjectDAO == null)
            {
                return Constant.RES_FAI;
            }
            foreach (var thuoc in listObjectDAO)
            {
                // tạo đối tượng entity
                ThuocEnity thuocEntity = new ThuocEnity();
                // copy property
                BUS.Com.Utils.CopyPropertiesFrom(thuoc, thuocEntity);
                // add vào list ouput
                ListThuocEntity.Add(thuocEntity);
            }
            return Constant.RES_SUC;

        }
    }

}
