using System.Collections.Generic;
using DTO;
using BUS.Entities;
using DAO;
using COM;

namespace BUS.Service
{
    interface IHoSoBenhAnService
    {
        // LẤY DANH SÁCH HỒ SƠ
        string GetListHoSo(out List<HoSoBenhAnEntity> ListHoSo, ref List<MessageError> Messages);
        // TÌM HỒ SƠ
        string SearchHoSo( HoSoSearchEntity HoSoSearch, out List<HoSoBenhAnEntity> ListHoSo, ref List<MessageError> Messages);
        // LẤY THÔNG TIN MỘT HỒ SƠ
        string GetInfomationHoSo(string MaHoSo, out HoSoBenhAnEntity HoSoEntity, ref List<MessageError> Messages);
        // INSERT MỘT HỒ SƠ
        string AddHoSoBenhAn(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSoEntity, ref List<MessageError> Messages);
        // UPDATE MỘT HỒ SƠ
        string UpdateHoSoBenhAn(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSoEntity, ref List<MessageError> Messages);
        // DELETE MỘT HỒ SƠ
        string DeleteHoSoBenhAn(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSoEntity, ref List<MessageError> Messages);
    }
}
