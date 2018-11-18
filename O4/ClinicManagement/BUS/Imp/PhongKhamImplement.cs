using System.Collections.Generic;
using BUS.Service;
using DAO;
using DTO;
using COM;

namespace BUS.Imp
{
    public class PhongKhamImplement : IPhongKhamService
    {
        DAO.Implement.PhongImplement phongKhamService = null;

        public PhongKhamImplement()
        {
            phongKhamService = new DAO.Implement.PhongImplement();
        }

        public string GetInformationPhongKham(QLPHONGKHAMEntities db, string MaPhongKham, out PhongKhamEnity InformationPhongKham)
        {
            InformationPhongKham = new PhongKhamEnity();
            PHONG entity = null;
            object[] id = { MaPhongKham };
            if (phongKhamService.FindById(db, id, out entity) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (entity == null)
            {
                return Constant.RES_FAI;
            }
            BUS.Com.Utils.CopyPropertiesFrom(entity, InformationPhongKham);
            return Constant.RES_SUC;
        }

        public string GetListPhongKham(QLPHONGKHAMEntities db, out List<PhongKhamEnity> ListPhongKham)
        {
            ListPhongKham = new List<PhongKhamEnity>();
            List<PHONG> listObjectDAO = null;
            if (phongKhamService.Select(db, out listObjectDAO) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (listObjectDAO == null)
            {
                return Constant.RES_FAI;
            }
            foreach (PHONG pk in listObjectDAO)
            {
                PhongKhamEnity phongKhamEnity = new PhongKhamEnity();
                BUS.Com.Utils.CopyPropertiesFrom(pk, phongKhamEnity);
                ListPhongKham.Add(phongKhamEnity);
            }
            return Constant.RES_SUC;
        }
    }
}
