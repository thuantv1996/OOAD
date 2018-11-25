using System.Collections.Generic;
using DTO;
using DAO;
using COM;
using DAO.Implement;

namespace BUS.Imp
{
    public class LoaiHoSoBUS
    {
        private LoaiHoSoDAO loaiHoSoService = null;

        public LoaiHoSoBUS()
        {
            loaiHoSoService = new LoaiHoSoDAO();
        }

        public string GetListLoaiHoSo(QLPHONGKHAMEntities db, out List<LoaiHoSoDTO> ListLoaiHoSo)
        {
            ListLoaiHoSo = new List<LoaiHoSoDTO>();
            List<LOAIHOSO> listObjectDAO = null;
            if (loaiHoSoService.Select(db, out listObjectDAO) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (listObjectDAO == null)
            {
                return Constant.RES_FAI;
            }
            foreach (LOAIHOSO lhs in listObjectDAO)
            {
                LoaiHoSoDTO loaiHoSoEnity = new LoaiHoSoDTO();
                BUS.Com.Utils.CopyPropertiesFrom(lhs, loaiHoSoEnity);
                ListLoaiHoSo.Add(loaiHoSoEnity);
            }
            return Constant.RES_SUC;
        }

        public string GetInformationLoaiHoSo(QLPHONGKHAMEntities db, string MaLoaiHoSo, out LoaiHoSoDTO InformationLoaiHoSo)
        {
            InformationLoaiHoSo = new LoaiHoSoDTO();
            LOAIHOSO entity = null;
            object[] id = { MaLoaiHoSo };
            if(loaiHoSoService.FindById(db, id, out entity) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if(entity == null)
            {
                return Constant.RES_FAI;
            }
            BUS.Com.Utils.CopyPropertiesFrom(entity, InformationLoaiHoSo);
            return Constant.RES_SUC;
        }
    }
}
