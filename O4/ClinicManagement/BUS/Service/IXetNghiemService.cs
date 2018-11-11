using System.Collections.Generic;
using DTO;
using COM;
using BUS.Entities;

namespace BUS.Service
{
    interface IXetNghiemService
    {
        string GetListXetNghiem(out List<XetNghiemEnity> ListHoSo, ref List<MessageError> Messages);
        string GetInfomationXetNghiem(string MaXetNghiem, out XetNghiemEnity XetNghiemEntity, ref List<MessageError> Messages);
    }
}
