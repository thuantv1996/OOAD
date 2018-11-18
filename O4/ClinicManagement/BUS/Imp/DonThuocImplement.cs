using System;
using BUS.Service;
using DTO;
using DAO;

namespace BUS.Imp
{
    public class DonThuocImplement : IDonThuocService
    {
        DAO.Interface.IDonThuocServices donThuocService = null;

        public DonThuocImplement()
        {
            donThuocService = new DAO.Implement.DonThuocImplement();
        }

        public string GetInformationDonThuocWithId(QLPHONGKHAMEntities db, string MaHoSo,out DonThuocEnity DonThuocEntity)
        {
            DonThuocEntity = new DonThuocEnity();
            DONTHUOC donThuocDAO = null;
            if(donThuocService.FindByParameter(db, MaHoSo, out donThuocDAO) == COM.Constant.RES_FAI)
            {
                return COM.Constant.RES_FAI;
            }
            if (donThuocDAO == null)
            {
                return COM.Constant.RES_FAI;
            }
            BUS.Com.Utils.CopyPropertiesFrom(donThuocDAO, DonThuocEntity);
            return COM.Constant.RES_SUC;
        }

        public string SaveDonThuoc(QLPHONGKHAMEntities db, DonThuocEnity donThuocEntity)
        {
            DONTHUOC donThuocDAO = new DONTHUOC();
            BUS.Com.Utils.CopyPropertiesFrom(donThuocEntity, donThuocDAO);
            return donThuocService.Save(db,donThuocDAO);

        }
    }
}
