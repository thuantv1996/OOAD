using DTO;
using DAO;
using DAO.Implement;
using System.Collections.Generic;
using BUS.Com;
using COM;
using System;

namespace BUS.Imp
{
    public class ChiTietDonThuocBUS
    {
        private ChiTietDonThuocDAO chiTietDonThuocDAO = null;

        public ChiTietDonThuocBUS()
        {
            chiTietDonThuocDAO = new ChiTietDonThuocDAO();
        }

        public string SaveChiTietDonThuoc(QLPHONGKHAMEntities db, ChiTietDonThuocDTO ChiTietDonThuocEntity)
        {
            // convert DTO -> DAO
            CHITIETDONTHUOC chiTietDonThuoc = new CHITIETDONTHUOC();
            BUS.Com.Utils.CopyPropertiesFrom(ChiTietDonThuocEntity, chiTietDonThuoc);
            // save 
            return chiTietDonThuocDAO.Save(db, chiTietDonThuoc);
        }
    

        public string UpdateChiTietDonThuoc(QLPHONGKHAMEntities db, ChiTietDonThuocDTO ChiTietDonThuocEntity)
        {
            // convert DTO -> DAO
            CHITIETDONTHUOC chiTietDonThuoc = new CHITIETDONTHUOC();
            BUS.Com.Utils.CopyPropertiesFrom(ChiTietDonThuocEntity, chiTietDonThuoc);
            // save 
            return chiTietDonThuocDAO.Save(db, chiTietDonThuoc);
        }

        public string GetListWithIdDonThuoc(QLPHONGKHAMEntities db, string MaDonthuoc, out List<ChiTietDonThuocDTO> listChiTiet)
        {
            listChiTiet = new List<ChiTietDonThuocDTO>();
            List<CHITIETDONTHUOC> listChiTietDAO = new List<CHITIETDONTHUOC>();
            chiTietDonThuocDAO.GetListWithIdDonThuoc(db, MaDonthuoc, out listChiTietDAO);
            try
            {
                foreach (var ct in listChiTietDAO)
                {
                    ChiTietDonThuocDTO temp = new ChiTietDonThuocDTO();
                    Utils.CopyPropertiesFrom(ct, temp);
                    listChiTiet.Add(temp);
                }
            }catch(Exception e)
            {
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }
    }
}
