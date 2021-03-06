﻿using DTO;
using DAO;
using DAO.Implement;
using System;

namespace BUS.Imp
{
    public class DonThuocBUS
    {
        private DonThuocDAO donThuocService = null;

        public DonThuocBUS()
        {
            donThuocService = new DonThuocDAO();
        }

        public string GetInformationDonThuocWithId(QLPHONGKHAMEntities db, string MaHoSo,out DonThuocDTO DonThuocEntity)
        {
            DonThuocEntity = new DonThuocDTO();
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

        public string SaveDonThuoc(QLPHONGKHAMEntities db, DonThuocDTO donThuocEntity)
        {
            DONTHUOC donThuocDAO = new DONTHUOC();
            BUS.Com.Utils.CopyPropertiesFrom(donThuocEntity, donThuocDAO);
            return donThuocService.Save(db,donThuocDAO);

        }

        internal string Delete(QLPHONGKHAMEntities db, string maDonThuoc)
        {
            DONTHUOC donThuocDAO = new DONTHUOC();
            object[] id = { maDonThuoc };
            if(donThuocService.FindById(db, id, out donThuocDAO) == COM.Constant.RES_FAI)
            {
                return COM.Constant.RES_FAI;
            }
            return donThuocService.Delete(db, donThuocDAO);
        }

        internal string getMaDonThuoc(QLPHONGKHAMEntities db)
        {
            return donThuocService.getMaDonThuoc(db);
        }
    }
}
