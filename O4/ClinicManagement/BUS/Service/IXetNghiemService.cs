using System.Collections.Generic;
using DTO;
using COM;
using BUS.Entities;
using DAO;


namespace BUS.Service
{
    interface IXetNghiemService
    {
        string GetListXetNghiem(QLPHONGKHAMEntities db, out List<XetNghiemEnity> ListHoSo);
        string GetInfomationXetNghiem(QLPHONGKHAMEntities db, string MaXetNghiem, out XetNghiemEnity XetNghiemEntity);
    }
}
