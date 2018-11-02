using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using BUS.Enities;
using DAO;

namespace BUS.Service
{
    interface IHoSoService
    {
        // LẤY DANH SÁCH HỒ SƠ
        string GetListHoSo(out List<HoSoBenhAnEntity> ListHoSo, out List<string> MessageError);
        // TÌM HỒ SƠ
        string SearchHoSo(HoSoSearchEntity HoSoSearch, out List<HoSoBenhAnEntity> ListHoSo, out List<string> MessageError);
        // LẤY THÔNG TIN MỘT HỒ SƠ
        string GetInfomationHoSo(string MaHoSo, out HoSoBenhAnEntity HoSo, out List<string> MessageError);
        // INSERT MỘT HỒ SƠ
        string AddHoSo(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSo, out List<string> MessageError);
        // UPDATE MỘT HỒ SƠ
        string UpdateHoSo(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSo, out List<string> MessageError);
        // DELETE MỘT HỒ SƠ
        string DeleteHoSo(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSo, out List<string> MessageError);
    }
}
