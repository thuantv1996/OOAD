using System.Collections.Generic;
using BUS.Entities;
using DAO;
using COM;
using DTO;
using DAO.Implement;

namespace BUS.Imp
{
    public class BenhNhanBUS
    {
        BenhNhanDAO benhNhanDao = null;

        public BenhNhanBUS()
        {
            benhNhanDao = new BenhNhanDAO();
        }

        public string GetInformationBenhNhan(QLPHONGKHAMEntities db, string MaBenhNhan, out BenhNhanDTO InformationBenhNhan)
        {
            InformationBenhNhan = new BenhNhanDTO();
            BENHNHAN entity = null;
            object[] id = { MaBenhNhan };
            if(benhNhanDao.FindById(db, id, out entity) == Constant.RES_FAI)
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

        public string GetListBenhNhan(QLPHONGKHAMEntities db, out List<BenhNhanDTO> ListBenhNhan)
        {
            ListBenhNhan = new List<BenhNhanDTO>();
            List<BENHNHAN> listObjectDAO = null;
            if (benhNhanDao.Select(db, out listObjectDAO) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (listObjectDAO == null)
            {
                return Constant.RES_FAI;
            }
            foreach(BENHNHAN bn in listObjectDAO)
            {
                BenhNhanDTO BenhNhanDTO = new BenhNhanDTO();
                BUS.Com.Utils.CopyPropertiesFrom(bn, BenhNhanDTO);
                ListBenhNhan.Add(BenhNhanDTO);
            }
            return Constant.RES_SUC;
        }

        public string InsertBenhNhan(QLPHONGKHAMEntities db, BenhNhanDTO BenhNhan)
        {
            BENHNHAN benhNhanDAO = new BENHNHAN();
            BUS.Com.Utils.CopyPropertiesFrom(BenhNhan, benhNhanDAO);
            return benhNhanDao.Save(db, benhNhanDAO);
        }

        public string SearchBenhNhan(QLPHONGKHAMEntities db, BenhNhanSearchEntity BenhNhanSearchEntity, out List<BenhNhanDTO> ListBenhNhan)
        {
            ListBenhNhan = new List<BenhNhanDTO>();
            List<BENHNHAN> listBenhNhanDAO = null;
            object[] param = { BenhNhanSearchEntity.MaBenhNhan, BenhNhanSearchEntity.TenBenhNhan, BenhNhanSearchEntity.CMND };
            if(benhNhanDao.SearchWithParameter(db, param, out listBenhNhanDAO) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            foreach (BENHNHAN bn in listBenhNhanDAO)
            {
                BenhNhanDTO BenhNhanDTO = new BenhNhanDTO();
                BUS.Com.Utils.CopyPropertiesFrom(bn, BenhNhanDTO);
                ListBenhNhan.Add(BenhNhanDTO);
            }
            return Constant.RES_SUC;
        }

        public string UpdateBenhNhan(QLPHONGKHAMEntities db, BenhNhanDTO BenhNhan)
        {
            BENHNHAN benhNhanDAO = new BENHNHAN();
            BUS.Com.Utils.CopyPropertiesFrom(BenhNhan, benhNhanDAO);
            return benhNhanDao.Save(db, benhNhanDAO);
        }
    }
}
