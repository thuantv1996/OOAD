using System.Collections.Generic;
using BUS.Service;
using DTO;
using DAO;
using COM;

namespace BUS.Imp
{
    public class LoaiHoSoImplement : ILoaiHoSoService
    {
        DAO.Interface.ILoaiHoSoServices loaiHoSoService = null;

        public LoaiHoSoImplement()
        {
            loaiHoSoService = new DAO.Implement.LoaiHoSoImplement();
        }

        public string GetListLoaiHoSo(QLPHONGKHAMEntities db, out List<LoaiHoSoEnity> ListLoaiHoSo)
        {
            ListLoaiHoSo = new List<LoaiHoSoEnity>();
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
                LoaiHoSoEnity loaiHoSoEnity = new LoaiHoSoEnity();
                BUS.Com.Utils.CopyPropertiesFrom(lhs, loaiHoSoEnity);
                ListLoaiHoSo.Add(loaiHoSoEnity);
            }
            return Constant.RES_SUC;
        }

        public string GetInformationLoaiHoSo(QLPHONGKHAMEntities db, string MaLoaiHoSo, out LoaiHoSoEnity InformationLoaiHoSo)
        {
            InformationLoaiHoSo = new LoaiHoSoEnity();
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
