using System.Collections.Generic;
using DAO;
using DTO;
using COM;
using DAO.Implement;

namespace BUS.Imp
{
    public class PhongKhamBUS
    {
        private PhongDAO phongKhamService = null;

        public PhongKhamBUS()
        {
            phongKhamService = new PhongDAO();
        }

        public string GetInformationPhongKham(QLPHONGKHAMEntities db, string MaPhongKham, out PhongKhamDTO InformationPhongKham)
        {
            InformationPhongKham = new PhongKhamDTO();
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

        public string GetListPhongKham(QLPHONGKHAMEntities db, out List<PhongKhamDTO> ListPhongKham)
        {
            ListPhongKham = new List<PhongKhamDTO>();
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
                PhongKhamDTO PhongKhamDTO = new PhongKhamDTO();
                if(pk.GhiChu == Com.BusConstant.KHAM)
                {
                    BUS.Com.Utils.CopyPropertiesFrom(pk, PhongKhamDTO);
                    ListPhongKham.Add(PhongKhamDTO);
                }
            }
            return Constant.RES_SUC;
        }
    }
}
