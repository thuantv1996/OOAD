using System;
using System.Collections.Generic;
using System.Linq;
using BUS.Service;
using DTO;
using DAO;
using COM;
using BUS.Com;

namespace BUS.Imp
{
    public class KetQuaXetNghiemImplement : IKetQuaXetNguyenService
    {
        private DAO.Interface.IKetQuaXetNghiemServices ketQuaXetNghiemServices = null;

        public KetQuaXetNghiemImplement()
        {
            ketQuaXetNghiemServices = new DAO.Implement.KetQuaXetNghiemImplement();
        }

        public string AddKetQuaXetNghiem(QLPHONGKHAMEntities db, KetQuaXetNghiemEnity KetQuaXetNghiem)
        {
            KETQUAXETNGHIEM ketQuaXetNghiemDAO = new KETQUAXETNGHIEM();
            BUS.Com.Utils.CopyPropertiesFrom(KetQuaXetNghiem, ketQuaXetNghiemDAO);
            return ketQuaXetNghiemServices.Save(db, ketQuaXetNghiemDAO);
        }

        public string GetInformationWithId(QLPHONGKHAMEntities db, string MaHoSo, string MaXetNghiem, out KetQuaXetNghiemEnity KetQuaXetNghiem)
        {
            KetQuaXetNghiem = new KetQuaXetNghiemEnity();
            KETQUAXETNGHIEM ketQuaXetNghiemDAO = null;
            object[] id = { MaHoSo, MaXetNghiem };
            if(ketQuaXetNghiemServices.FindById(db, id, out ketQuaXetNghiemDAO) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if(ketQuaXetNghiemDAO == null)
            {
                return Constant.RES_FAI;
            }
            BUS.Com.Utils.CopyPropertiesFrom(ketQuaXetNghiemDAO, KetQuaXetNghiem);
            return Constant.RES_SUC;
        }

        public string GetKetQuaXetNghiemWithIdHoSo(QLPHONGKHAMEntities db, string MaHoSo, out List<KetQuaXetNghiemEnity> ListKetQuaXetNghiem)
        {
            ListKetQuaXetNghiem = new List<KetQuaXetNghiemEnity>();
            List<KETQUAXETNGHIEM> listDAO = null;
            if (ketQuaXetNghiemServices.GetKetQuaXetNghiemWithIdHoSo(db, MaHoSo, out listDAO) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if(listDAO == null)
            {
                return Constant.RES_FAI;
            }
            foreach(var kq in listDAO)
            {
                KetQuaXetNghiemEnity entity = new KetQuaXetNghiemEnity();
                BUS.Com.Utils.CopyPropertiesFrom(kq, entity);
                ListKetQuaXetNghiem.Add(entity);
            }
            return Constant.RES_SUC;
        }

        public string UpdateKetQuaXetNghiem(QLPHONGKHAMEntities db, KetQuaXetNghiemEnity KetQuaXetNghiem)
        {
            KETQUAXETNGHIEM ketQuaXetNghiemDAO = new KETQUAXETNGHIEM();
            BUS.Com.Utils.CopyPropertiesFrom(KetQuaXetNghiem, ketQuaXetNghiemDAO);
            return ketQuaXetNghiemServices.Save(db, ketQuaXetNghiemDAO);
        }
    }
}
