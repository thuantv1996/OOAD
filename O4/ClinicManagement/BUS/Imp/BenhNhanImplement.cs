using System.Collections.Generic;
using BUS.Service;
using DTO;
using BUS.Entities;
using DAO;
using COM;

namespace BUS.Imp
{
    public class BenhNhanImplement : IBenhNhanService
    {
        DAO.Implement.BenhNhanImplement benhNhanService = null;

        public BenhNhanImplement()
        {
            benhNhanService = new DAO.Implement.BenhNhanImplement();
        }

        public string GetInformationBenhNhan(QLPHONGKHAMEntities db, string MaBenhNhan, out BenhNhanEnity InformationBenhNhan)
        {
            InformationBenhNhan = new BenhNhanEnity();
            BENHNHAN entity = null;
            object[] id = { MaBenhNhan };
            if(benhNhanService.FindById(db, id, out entity) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if(entity == null)
            {
                return Constant.RES_FAI;
            }
            BUS.Com.Utils.CopyPropertiesFrom(entity, InformationBenhNhan);
            return Constant.RES_SUC;
        }

        public string GetListBenhNhan(QLPHONGKHAMEntities db, out List<BenhNhanEnity> ListBenhNhan)
        {
            ListBenhNhan = new List<BenhNhanEnity>();
            List<BENHNHAN> listObjectDAO = null;
            if (benhNhanService.Select(db, out listObjectDAO) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (listObjectDAO == null)
            {
                return Constant.RES_FAI;
            }
            foreach(BENHNHAN bn in listObjectDAO)
            {
                BenhNhanEnity benhNhanEnity = new BenhNhanEnity();
                BUS.Com.Utils.CopyPropertiesFrom(bn, benhNhanEnity);
                ListBenhNhan.Add(benhNhanEnity);
            }
            return Constant.RES_SUC;
        }

        public string InsertBenhNhan(QLPHONGKHAMEntities db, BenhNhanEnity BenhNhan)
        {
            BENHNHAN benhNhanDAO = new BENHNHAN();
            BUS.Com.Utils.CopyPropertiesFrom(BenhNhan, benhNhanDAO);
            return benhNhanService.Save(db, benhNhanDAO);
        }

        public string SearchBenhNhan(QLPHONGKHAMEntities db, BenhNhanSearchEntity BenhNhanSearchEntity, out List<BenhNhanEnity> ListBenhNhan)
        {
            ListBenhNhan = new List<BenhNhanEnity>();
            List<BENHNHAN> listBenhNhanDAO = null;
            object[] param = { BenhNhanSearchEntity.MaBenhNhan, BenhNhanSearchEntity.TenBenhNhan, BenhNhanSearchEntity.CMND };
            if(benhNhanService.GetDataWithParameter(db, param, out listBenhNhanDAO) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            foreach (BENHNHAN bn in listBenhNhanDAO)
            {
                BenhNhanEnity benhNhanEnity = new BenhNhanEnity();
                BUS.Com.Utils.CopyPropertiesFrom(bn, benhNhanEnity);
                ListBenhNhan.Add(benhNhanEnity);
            }
            return Constant.RES_SUC;
        }

        public string UpdateBenhNhan(QLPHONGKHAMEntities db, BenhNhanEnity BenhNhan)
        {
            BENHNHAN benhNhanDAO = new BENHNHAN();
            BUS.Com.Utils.CopyPropertiesFrom(BenhNhan, benhNhanDAO);
            return benhNhanService.Save(db, benhNhanDAO);
        }
    }
}
