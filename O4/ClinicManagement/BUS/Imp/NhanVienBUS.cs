using System.Collections.Generic;
using DTO;
using DAO;
using COM;
using DAO.Implement;

namespace BUS.Imp
{
    public class NhanVienBUS
    {
        private NhanVienDAO nhanVienService = null;

        public NhanVienBUS()
        {
            nhanVienService = new NhanVienDAO();
        }

        public string GetInfomationNhanVien(QLPHONGKHAMEntities db, string MaNhanVien, out NhanVienDTO NhanVienEntity)
        {
            NhanVienEntity = new NhanVienDTO();
            NHANVIEN entity = null;
            object[] id = { MaNhanVien };
            if (nhanVienService.FindById(db, id, out entity) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (entity == null)
            {
                return Constant.RES_FAI;
            }
            BUS.Com.Utils.CopyPropertiesFrom(entity, NhanVienEntity);
            return Constant.RES_SUC;
        }

        public string GetListNhanVien(QLPHONGKHAMEntities db, out List<NhanVienDTO> ListNhanVienEntity)
        {
            ListNhanVienEntity = new List<NhanVienDTO>();
            List<NHANVIEN> listObjectDAO = null;
            if (nhanVienService.Select(db, out listObjectDAO) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (listObjectDAO == null)
            {
                return Constant.RES_FAI;
            }
            foreach (NHANVIEN nv in listObjectDAO)
            {
                NhanVienDTO NhanVienDTO = new NhanVienDTO();
                BUS.Com.Utils.CopyPropertiesFrom(nv, NhanVienDTO);
                ListNhanVienEntity.Add(NhanVienDTO);
            }
            return Constant.RES_SUC;
        }

        public string GetListNhanVienWithIdRoom(QLPHONGKHAMEntities db, string maPhong, out List<NhanVienDTO> ListNhanVienEntity)
        {
            ListNhanVienEntity = new List<NhanVienDTO>();
            List<NHANVIEN> listObjectDAO = null;
            object[] param = { maPhong };
            if (nhanVienService.GetListNhanVienWithIdRoom(db, param, out listObjectDAO) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (listObjectDAO == null)
            {
                return Constant.RES_FAI;
            }
            foreach (NHANVIEN nv in listObjectDAO)
            {
                NhanVienDTO NhanVienDTO = new NhanVienDTO();
                BUS.Com.Utils.CopyPropertiesFrom(nv, NhanVienDTO);
                ListNhanVienEntity.Add(NhanVienDTO);
            }
            return Constant.RES_SUC;
        }
    }
}
