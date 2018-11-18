using System.Collections.Generic;
using BUS.Service;
using DTO;
using DAO;
using COM;
namespace BUS.Imp
{
    public class NhanVienImplement : INhanVienService
    {
        DAO.Implement.NhanVienImplement nhanVienService = null;

        public NhanVienImplement()
        {
            nhanVienService = new DAO.Implement.NhanVienImplement();
        }

        public string GetInfomationNhanVien(QLPHONGKHAMEntities db, string MaNhanVien, out NhanVienEnity NhanVienEntity)
        {
            NhanVienEntity = new NhanVienEnity();
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

        public string GetListNhanVien(QLPHONGKHAMEntities db, out List<NhanVienEnity> ListNhanVienEntity)
        {
            ListNhanVienEntity = new List<NhanVienEnity>();
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
                NhanVienEnity nhanVienEnity = new NhanVienEnity();
                BUS.Com.Utils.CopyPropertiesFrom(nv, nhanVienEnity);
                ListNhanVienEntity.Add(nhanVienEnity);
            }
            return Constant.RES_SUC;
        }
    }
}
