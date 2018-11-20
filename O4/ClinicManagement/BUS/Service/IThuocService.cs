using System.Collections.Generic;
using DTO;
using DAO;

namespace BUS.Service
{
    interface IThuocService
    {
        // LẤY DANH SÁCH THUỐC
        string GetListThuoc(QLPHONGKHAMEntities db,  out List<ThuocDTO> ListThuocEntity);
    }
}
