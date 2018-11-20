using System.Collections.Generic;
using DTO;
using DAO;


namespace BUS.Service
{
    interface IXetNghiemService
    {
        string GetListXetNghiem(QLPHONGKHAMEntities db, out List<XetNghiemDTO> ListHoSo);
        string GetInfomationXetNghiem(QLPHONGKHAMEntities db, string MaXetNghiem, out XetNghiemDTO XetNghiemEntity);
    }
}
