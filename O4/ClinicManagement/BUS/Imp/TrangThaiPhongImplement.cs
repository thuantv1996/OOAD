using System.Collections.Generic;
using System.Linq;
using BUS.Service;
using DAO;
using DTO;
using COM;
using BUS.Entities;

namespace BUS.Imp
{
    public class TrangThaiPhongImplement : ITrangThaiPhongService
    {
        DAO.Interface.ITrangThaiPhongServices trangThaiPhongServices = null;
        public TrangThaiPhongImplement()
        {
            trangThaiPhongServices = new DAO.Implement.TrangThaiPhongImplement();
        }

        public string GetTrangThaiPhong(QLPHONGKHAMEntities db, string MaPhongKham, string NgayThang, out TrangThaiPhongEnity TrangThaiPhong)
        {
            TrangThaiPhong = new TrangThaiPhongEnity();
            TRANGTHAIPHONG entity = null;
            object[] id = { MaPhongKham, NgayThang };
            if(trangThaiPhongServices.FindById(db, id, out entity) == Constant.RES_FAI )
            {
                return Constant.RES_FAI;
            }

            if(entity == null)
            {
                return Constant.RES_FAI;
            }
            BUS.Com.Utils.CopyPropertiesFrom(entity, TrangThaiPhong);
            return Constant.RES_SUC;


            
        }

        public string UpdateTrangThaiPhong(QLPHONGKHAMEntities db, TrangThaiPhongEnity TrangThaiPhong)
        {
            TRANGTHAIPHONG trangthaiphongDAO = new TRANGTHAIPHONG();
            BUS.Com.Utils.CopyPropertiesFrom(TrangThaiPhong, trangthaiphongDAO);
            return trangThaiPhongServices.Save(db, trangthaiphongDAO);
            
        }
    }
}
