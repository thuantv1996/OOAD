using System.Collections.Generic;
using BUS.Entities;
using DTO;
using DAO;
using COM;
using DAO.Implement;
using System;

namespace BUS.Imp
{
    public class HoSoBenhAnBUS
    {

        private HoSoBenhAnDAO hoSoBenhAnService = null;

        public HoSoBenhAnBUS()
        {
            hoSoBenhAnService = new HoSoBenhAnDAO();
        }

        public string AddHoSoBenhAn(QLPHONGKHAMEntities db, HoSoBenhAnDTO HoSoEntity)
        {
            HOSOBENHAN hoSoBenhAnDAO = new HOSOBENHAN();
            BUS.Com.Utils.CopyPropertiesFrom(HoSoEntity, hoSoBenhAnDAO);
            return hoSoBenhAnService.Save(db, hoSoBenhAnDAO);
        }

        public string CreateIdHoSoBenhAn(QLPHONGKHAMEntities db, out string Id)
        {
            Id = null;
            return hoSoBenhAnService.CreateId(db, out Id);
        }

        public string GetRootHoSoBenhAn(QLPHONGKHAMEntities db, string MaHoSoTruoc, out HoSoBenhAnDTO hoSoBenhAnRoot)
        {
            hoSoBenhAnRoot = new HoSoBenhAnDTO();
            HOSOBENHAN rootDAO = null;
            if (hoSoBenhAnService.GetRootHoSo(db, MaHoSoTruoc, out rootDAO) == COM.Constant.RES_FAI)
            {
                return COM.Constant.RES_FAI;
            }
            BUS.Com.Utils.CopyPropertiesFrom(rootDAO, hoSoBenhAnRoot);
            return COM.Constant.RES_SUC;
        }

        public string GetListHoSoXN(QLPHONGKHAMEntities db, string maXetNghiem, out List<HoSoBenhAnDTO> listHoSoBenhAn)
        {
            listHoSoBenhAn = new List<HoSoBenhAnDTO>();
            List<HOSOBENHAN> hoSoDAO = null;
            if (hoSoBenhAnService.GetListHoSoXN(db, maXetNghiem, out hoSoDAO) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            foreach (var hs in hoSoDAO)
            {
                HoSoBenhAnDTO entity = new HoSoBenhAnDTO();
                BUS.Com.Utils.CopyPropertiesFrom(hs, entity);
                listHoSoBenhAn.Add(entity);
            }
            return Constant.RES_SUC;
        }

        public string GetListHoSoWithIdBenhNhan(QLPHONGKHAMEntities db, string MaBenhNhan, out List<HoSoBenhAnDTO> ListHoSo)
        {
            ListHoSo = new List<HoSoBenhAnDTO>();
            List<HOSOBENHAN> hoSoDAO = null;
            if (hoSoBenhAnService.GetListHoSoWithIdBenhNhan(db, MaBenhNhan, out hoSoDAO) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            foreach (var hs in hoSoDAO)
            {
                HoSoBenhAnDTO entity = new HoSoBenhAnDTO();
                BUS.Com.Utils.CopyPropertiesFrom(hs, entity);
                ListHoSo.Add(entity);
            }
            return Constant.RES_SUC;
        }

        public string DeleteHoSoBenhAn(QLPHONGKHAMEntities db, HoSoBenhAnDTO HoSoEntity)
        {
            object[] id = { HoSoEntity.MaHoSo };
            HOSOBENHAN hoSoBenhAnDAO = null;
            if (hoSoBenhAnService.FindById(db, id, out hoSoBenhAnDAO) == COM.Constant.RES_FAI)
            {
                return COM.Constant.RES_FAI;
            }
            if (hoSoBenhAnDAO == null)
            {
                return COM.Constant.RES_FAI;
            }
            return hoSoBenhAnService.Delete(db, hoSoBenhAnDAO);
        }

        public string GetInfomationHoSo(QLPHONGKHAMEntities db, string MaHoSo, out HoSoBenhAnDTO HoSoEntity)
        {
            HoSoEntity = new HoSoBenhAnDTO();
            object[] id = { MaHoSo };
            HOSOBENHAN hoSoBenhAnDAO = null;
            if (hoSoBenhAnService.FindById(db, id, out hoSoBenhAnDAO) == COM.Constant.RES_FAI)
            {
                return COM.Constant.RES_FAI;
            }
            if (hoSoBenhAnDAO == null)
            {
                return COM.Constant.RES_FAI;
            }
            BUS.Com.Utils.CopyPropertiesFrom(hoSoBenhAnDAO, HoSoEntity);
            return COM.Constant.RES_SUC;
        }

        public string GetListHoSo(QLPHONGKHAMEntities db, out List<HoSoBenhAnDTO> ListHoSoEntity)
        {
            ListHoSoEntity = new List<HoSoBenhAnDTO>();
            List<HOSOBENHAN> listHoSoDAO = null;
            if (hoSoBenhAnService.Select(db, out listHoSoDAO) == COM.Constant.RES_FAI)
            {
                return COM.Constant.RES_FAI;
            }
            if (listHoSoDAO == null)
            {
                return COM.Constant.RES_FAI;
            }
            foreach (var hs in listHoSoDAO)
            {
                HoSoBenhAnDTO entity = new HoSoBenhAnDTO();
                BUS.Com.Utils.CopyPropertiesFrom(hs, entity);
                ListHoSoEntity.Add(entity);
            }
            return COM.Constant.RES_SUC;

        }

        public string SearchHoSo(QLPHONGKHAMEntities db, HoSoSearchEntity HoSoSearch, out List<HoSoBenhAnDTO> ListHoSoEntity)
        {
            ListHoSoEntity = new List<HoSoBenhAnDTO>();
            List<HOSOBENHAN> listHoSoDAO = null;
            object[] param = { HoSoSearch.MaHoSo, HoSoSearch.TenBenhNhan, HoSoSearch.NgayKham };
            if (hoSoBenhAnService.SearchHoSo(db, param, out listHoSoDAO) == COM.Constant.RES_FAI)
            {
                return COM.Constant.RES_FAI;
            }
            if (listHoSoDAO == null)
            {
                return COM.Constant.RES_FAI;
            }
            foreach (var hs in listHoSoDAO)
            {
                HoSoBenhAnDTO entity = new HoSoBenhAnDTO();
                BUS.Com.Utils.CopyPropertiesFrom(hs, entity);
                ListHoSoEntity.Add(entity);
            }
            return COM.Constant.RES_SUC;
        }

        public string UpdateHoSoBenhAn(QLPHONGKHAMEntities db, HoSoBenhAnDTO HoSoEntity)
        {
            HOSOBENHAN hoSoBenhAnDAO = new HOSOBENHAN();
            BUS.Com.Utils.CopyPropertiesFrom(HoSoEntity, hoSoBenhAnDAO);
            return hoSoBenhAnService.Save(db, hoSoBenhAnDAO);
        }

        public string GetListHoSo(QLPHONGKHAMEntities db, string MaPhong, string NodeKham, out List<HoSoBenhAnDTO> ListHoSo)
        {
            List<HOSOBENHAN> listHoSoDAO = null;
            ListHoSo = new List<HoSoBenhAnDTO>();
            object[] param = { MaPhong, NodeKham };
            if (hoSoBenhAnService.GetListHoSoWithRoomAndNode(db, param, out listHoSoDAO) == COM.Constant.RES_FAI)
            {
                return COM.Constant.RES_FAI;
            }
            if (listHoSoDAO == null)
            {
                return COM.Constant.RES_FAI;
            }
            foreach (var hs in listHoSoDAO)
            {
                HoSoBenhAnDTO entity = new HoSoBenhAnDTO();
                BUS.Com.Utils.CopyPropertiesFrom(hs, entity);
                ListHoSo.Add(entity);
            }
            return COM.Constant.RES_SUC;
        }

    }
}
