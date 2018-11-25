using System.Collections.Generic;
using DTO;
using DAO;
using COM;
using DAO.Implement;

namespace BUS.Imp
{
    class ThuocBUS
    {
        private ThuocDAO donThuocService = null;

        public ThuocBUS()
        {
            donThuocService = new ThuocDAO();
        }

        public string GetListThuoc(QLPHONGKHAMEntities db, out List<ThuocDTO> ListThuocEntity)
        {
            ListThuocEntity = new List<ThuocDTO>();
            List<THUOC> listObjectDAO = null;
            if (donThuocService.Select(db, out listObjectDAO) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (listObjectDAO == null)
            {
                return Constant.RES_FAI;
            }
            foreach (var thuoc in listObjectDAO)
            {
                // tạo đối tượng entity
                ThuocDTO thuocEntity = new ThuocDTO();
                // copy property
                BUS.Com.Utils.CopyPropertiesFrom(thuoc, thuocEntity);
                // add vào list ouput
                ListThuocEntity.Add(thuocEntity);
            }
            return Constant.RES_SUC;

        }
    }

}
