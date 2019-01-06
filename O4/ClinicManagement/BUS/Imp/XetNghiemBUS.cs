using System.Collections.Generic;
using DTO;
using DAO;
using COM;
using DAO.Implement;
using System;

namespace BUS.Imp
{
    public class XetNghiemBUS
    {
        private XetNghiemDAO xetNghiemServices = null;
        public XetNghiemBUS()
        {
            xetNghiemServices = new XetNghiemDAO();
        }

        public string GetListXetNghiem(QLPHONGKHAMEntities db, out List<XetNghiemDTO> ListXetNghiem)
        {
            ListXetNghiem = new List<XetNghiemDTO>();
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
                XetNghiemDTO xetNghiemEntity = new XetNghiemDTO();
                // copy property
                BUS.Com.Utils.CopyPropertiesFrom(xetnghiem, xetNghiemEntity);
                // add vào list ouput
                ListXetNghiem.Add(xetNghiemEntity);
            }
            return Constant.RES_SUC;
        }

        // LẤY THÔNG TIN CHI TIẾT CỦA 1 XÉT NGHIỆM
        public string GetInfomationXetNghiem(QLPHONGKHAMEntities db, string MaXetNghiem, out XetNghiemDTO XetNghiemEntity)
        {
            XetNghiemEntity = new XetNghiemDTO();
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

        public string GetXetNghiemByPhong(QLPHONGKHAMEntities db, string MaPhong, ref XetNghiemDTO xetNghiemDTO)
        {
            XETNGHIEM entity = null;
            if (xetNghiemServices.GetXetNghiemByPhong(db, MaPhong, out entity) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (entity == null)
            {
                return Constant.RES_FAI;
            }
            BUS.Com.Utils.CopyPropertiesFrom(entity, xetNghiemDTO);
            return Constant.RES_SUC;
        }
    }
}
