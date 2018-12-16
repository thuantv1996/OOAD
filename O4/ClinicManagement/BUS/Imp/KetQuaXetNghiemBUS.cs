using System.Collections.Generic;
using DTO;
using DAO;
using COM;
using DAO.Implement;

namespace BUS.Imp
{
    public class KetQuaXetNghiemBUS
    {
        private KetQuaXetNghiemDAO ketQuaXetNghiemServices = null;

        public KetQuaXetNghiemBUS()
        {
            ketQuaXetNghiemServices = new KetQuaXetNghiemDAO();
        }

        public string AddKetQuaXetNghiem(QLPHONGKHAMEntities db, KetQuaXetNghiemDTO KetQuaXetNghiem)
        {
            KETQUAXETNGHIEM ketQuaXetNghiemDAO = new KETQUAXETNGHIEM();
            BUS.Com.Utils.CopyPropertiesFrom(KetQuaXetNghiem, ketQuaXetNghiemDAO);
            return ketQuaXetNghiemServices.Save(db, ketQuaXetNghiemDAO);
        }

        public string GetInformationWithId(QLPHONGKHAMEntities db, string MaHoSo, string MaXetNghiem, out KetQuaXetNghiemDTO KetQuaXetNghiem)
        {
            KetQuaXetNghiem = new KetQuaXetNghiemDTO();
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

        public string GetKetQuaXetNghiemWithIdHoSo(QLPHONGKHAMEntities db, string MaHoSo, out List<KetQuaXetNghiemDTO> ListKetQuaXetNghiem)
        {
            ListKetQuaXetNghiem = new List<KetQuaXetNghiemDTO>();
            List<KETQUAXETNGHIEM> listDAO = null;
            if (ketQuaXetNghiemServices.GetListWithIdHoSo(db, MaHoSo, out listDAO) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if(listDAO == null)
            {
                return Constant.RES_FAI;
            }
            foreach(var kq in listDAO)
            {
                KetQuaXetNghiemDTO entity = new KetQuaXetNghiemDTO();
                BUS.Com.Utils.CopyPropertiesFrom(kq, entity);
                ListKetQuaXetNghiem.Add(entity);
            }
            return Constant.RES_SUC;
        }

        public string GetListHasResWithIdHoSo(QLPHONGKHAMEntities db, string MaHoSo, out List<KetQuaXetNghiemDTO> ListKetQuaXetNghiem)
        {
            ListKetQuaXetNghiem = new List<KetQuaXetNghiemDTO>();
            List<KETQUAXETNGHIEM> listDAO = null;
            if (ketQuaXetNghiemServices.GetListHasResWithIdHoSo(db, MaHoSo, out listDAO) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (listDAO == null)
            {
                return Constant.RES_FAI;
            }
            foreach (var kq in listDAO)
            {
                KetQuaXetNghiemDTO entity = new KetQuaXetNghiemDTO();
                BUS.Com.Utils.CopyPropertiesFrom(kq, entity);
                ListKetQuaXetNghiem.Add(entity);
            }
            return Constant.RES_SUC;
        }

        public string UpdateKetQuaXetNghiem(QLPHONGKHAMEntities db, KetQuaXetNghiemDTO KetQuaXetNghiem)
        {
            KETQUAXETNGHIEM ketQuaXetNghiemDAO = new KETQUAXETNGHIEM();
            BUS.Com.Utils.CopyPropertiesFrom(KetQuaXetNghiem, ketQuaXetNghiemDAO);
            return ketQuaXetNghiemServices.Save(db, ketQuaXetNghiemDAO);
        }
    }
}
