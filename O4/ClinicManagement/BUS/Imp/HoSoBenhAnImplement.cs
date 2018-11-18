using System.Collections.Generic;
using BUS.Entities;
using BUS.Service;
using DTO;
using DAO;
using COM;

namespace BUS.Imp
{
    class HoSoBenhAnImplement : IHoSoBenhAnService
    {

        private DAO.Interface.IHoSoBenhAnServices hoSoBenhAnService = null;

        public HoSoBenhAnImplement()
        {
            hoSoBenhAnService = new DAO.Implement.HoSoBenhAnImplement();
        }

        public string AddHoSoBenhAn(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSoEntity)
        {
            HOSOBENHAN hoSoBenhAnDAO = new HOSOBENHAN();
            BUS.Com.Utils.CopyPropertiesFrom(HoSoEntity, hoSoBenhAnDAO);
            return hoSoBenhAnService.Save(db, hoSoBenhAnDAO);
        }

        public string CreateIdHoSoBenhAn(QLPHONGKHAMEntities db,out string Id)
        {
            Id = null;
            return hoSoBenhAnService.CreateId(db,out Id);
        }

        public string GetRootHoSoBenhAn(QLPHONGKHAMEntities db, string MaHoSoTruoc, out HoSoBenhAnEntity hoSoBenhAnRoot)
        {
            hoSoBenhAnRoot = new HoSoBenhAnEntity();
            HOSOBENHAN rootDAO = null;
            if(hoSoBenhAnService.GetRootHoSo(db,MaHoSoTruoc,out rootDAO) == COM.Constant.RES_FAI)
            {
                return COM.Constant.RES_FAI;
            }
            BUS.Com.Utils.CopyPropertiesFrom(rootDAO, hoSoBenhAnRoot);
            return COM.Constant.RES_SUC;
        }

        public string GetListHoSo(QLPHONGKHAMEntities db, string MaBenhNhan, out List<HoSoBenhAnEntity> ListHoSo)
        {
            ListHoSo = new List<HoSoBenhAnEntity>();
            List<HOSOBENHAN> hoSoDAO = null;
            if(hoSoBenhAnService.GetListHoSoWithIdBenhNhan(db, MaBenhNhan, out hoSoDAO) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            foreach(var hs in hoSoDAO)
            {
                HoSoBenhAnEntity entity = new HoSoBenhAnEntity();
                BUS.Com.Utils.CopyPropertiesFrom(hs, entity);
                ListHoSo.Add(entity);
            }
            return Constant.RES_SUC;
        }

        public string DeleteHoSoBenhAn(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSoEntity)
        {
            object[] id = { HoSoEntity.MaHoSo };
            HOSOBENHAN hoSoBenhAnDAO = null;
            if(hoSoBenhAnService.FindById(db, id, out hoSoBenhAnDAO) == COM.Constant.RES_FAI)
            {
                return COM.Constant.RES_FAI;
            }
            if(hoSoBenhAnDAO == null)
            {
                return COM.Constant.RES_FAI;
            }
            return hoSoBenhAnService.Delete(db, hoSoBenhAnDAO);
        }

        public string GetInfomationHoSo(QLPHONGKHAMEntities db, string MaHoSo, out HoSoBenhAnEntity HoSoEntity)
        {
            HoSoEntity = new HoSoBenhAnEntity();
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

        public string GetListHoSo(QLPHONGKHAMEntities db, out List<HoSoBenhAnEntity> ListHoSoEntity)
        {
            ListHoSoEntity = new List<HoSoBenhAnEntity>();
            List<HOSOBENHAN> listHoSoDAO = null;
            if(hoSoBenhAnService.Select(db, out listHoSoDAO) == COM.Constant.RES_FAI)
            {
                return COM.Constant.RES_FAI;
            }
            if(listHoSoDAO == null)
            {
                return COM.Constant.RES_FAI;
            }
            foreach(var hs in listHoSoDAO)
            {
                HoSoBenhAnEntity entity = new HoSoBenhAnEntity();
                BUS.Com.Utils.CopyPropertiesFrom(hs, entity);
                ListHoSoEntity.Add(entity);
            }
            return COM.Constant.RES_SUC;

        }

        public string SearchHoSo(QLPHONGKHAMEntities db, HoSoSearchEntity HoSoSearch, out List<HoSoBenhAnEntity> ListHoSoEntity)
        {
            ListHoSoEntity = new List<HoSoBenhAnEntity>();
            List<HOSOBENHAN> listHoSoDAO = null;
            object[] param = { HoSoSearch.MaHoSo, HoSoSearch.TenBenhNhan, HoSoSearch.NgayKham };
            if (hoSoBenhAnService.SearchHoSo(db,param, out listHoSoDAO) == COM.Constant.RES_FAI)
            {
                return COM.Constant.RES_FAI;
            }
            if (listHoSoDAO == null)
            {
                return COM.Constant.RES_FAI;
            }
            foreach (var hs in listHoSoDAO)
            {
                HoSoBenhAnEntity entity = new HoSoBenhAnEntity();
                BUS.Com.Utils.CopyPropertiesFrom(hs, entity);
                ListHoSoEntity.Add(entity);
            }
            return COM.Constant.RES_SUC;
        }

        public string UpdateHoSoBenhAn(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSoEntity)
        {
            HOSOBENHAN hoSoBenhAnDAO = new HOSOBENHAN();
            BUS.Com.Utils.CopyPropertiesFrom(HoSoEntity, hoSoBenhAnDAO);
            return hoSoBenhAnService.Save(db, hoSoBenhAnDAO);
        }

        public string GetListHoSo(QLPHONGKHAMEntities db, string MaPhong, string NodeKham, out List<HoSoBenhAnEntity> ListHoSo)
        {
            List<HOSOBENHAN> listHoSoDAO = null;
            ListHoSo = new List<HoSoBenhAnEntity>();
            object[] param = { MaPhong, NodeKham };
            if (hoSoBenhAnService.GetListHoSoWithRoomAndNode(db,param,out listHoSoDAO) == COM.Constant.RES_FAI)
            {
                return COM.Constant.RES_FAI;
            }
            if(listHoSoDAO == null)
            {
                return COM.Constant.RES_FAI;
            }
            foreach (var hs in listHoSoDAO)
            {
                HoSoBenhAnEntity entity = new HoSoBenhAnEntity();
                BUS.Com.Utils.CopyPropertiesFrom(hs, entity);
                ListHoSo.Add(entity);
            }
            return COM.Constant.RES_SUC;
        }
    
    }
}
