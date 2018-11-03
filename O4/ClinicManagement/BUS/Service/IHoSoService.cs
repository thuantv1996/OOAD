using System.Collections.Generic;
using DTO;
using BUS.Entities;
using DAO;
using COM;

namespace BUS.Service
{
    interface IHoSoService
    {
        // LẤY DANH SÁCH HỒ SƠ
        string GetListHoSo(out List<HoSoBenhAnEntity> ListHoSo, ref List<MessageError> Messages);
        // TÌM HỒ SƠ
        string SearchHoSo( HoSoSearchEntity HoSoSearch, out List<HoSoBenhAnEntity> ListHoSo, ref List<MessageError> Messages);
        // LẤY THÔNG TIN MỘT HỒ SƠ
        string GetInfomationHoSo(string MaHoSo, out HoSoBenhAnEntity HoSo, ref List<MessageError> Messages);
        // INSERT MỘT HỒ SƠ
        string AddHoSo(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSo, ref List<MessageError> Messages);
        // UPDATE MỘT HỒ SƠ
        string UpdateHoSo(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSo, ref List<MessageError> Messages);
        // DELETE MỘT HỒ SƠ
        string DeleteHoSo(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSo, ref List<MessageError> Messages);
    }
}
