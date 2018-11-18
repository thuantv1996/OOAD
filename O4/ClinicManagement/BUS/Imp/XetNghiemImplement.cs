using System.Collections.Generic;
using BUS.Service;
using DTO;
using BUS.Entities;
using DAO;
using COM;

namespace BUS.Imp
{
    class XetNghiemImplement : IXetNghiemService
    {
        DAO.Interface.IXetNhiemServices xetNghiemServices = null;
        public XetNghiemImplement()
        {
            xetNghiemServices = new DAO.Implement.XetNghiemImplement();
        }

        public string GetListXetNghiem(QLPHONGKHAMEntities db, out List<XetNghiemEnity> ListHoSo)
        {
            ListHoSo = new List<XetNghiemEnity>();
            List<XETNGHIEM> listObjectDAO = null;
            if (xetNghiemServices.Select(db, out listObjectDAO) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (listObjectDAO == null)
            {
                return Constant.RES_FAI;
            }

            // duyệt qua danh sách xét nghiệm
            foreach (var xetnghiem in listObjectDAO)
            {
                // tạo đối tượng entity
                XetNghiemEnity xetNghiemEntity = new XetNghiemEnity();
                // copy property
                BUS.Com.Utils.CopyPropertiesFrom(xetnghiem, xetNghiemEntity);
                // add vào list ouput
                ListHoSo.Add(xetNghiemEntity);
            }
            return Constant.RES_SUC;
        }

        // LẤY THÔNG TIN CHI TIẾT CỦA 1 XÉT NGHIỆM
        public string GetInfomationXetNghiem(QLPHONGKHAMEntities db, string MaXetNghiem, out XetNghiemEnity XetNghiemEntity)
        {
            XetNghiemEntity = new XetNghiemEnity();
            XETNGHIEM entity = null;
            object[] id = { MaXetNghiem };

            if (xetNghiemServices.FindById(db, id, out entity) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }

            if (entity == null)
            {
                return Constant.RES_FAI;
            }
            BUS.Com.Utils.CopyPropertiesFrom(entity, XetNghiemEntity);
            return Constant.RES_SUC;
        }
    }
}
