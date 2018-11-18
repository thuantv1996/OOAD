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
        string GetListHoSo(QLPHONGKHAMEntities db, out List<HoSoBenhAnEntity> ListHoSo);
        
        // TÌM HỒ SƠ
        string SearchHoSo(QLPHONGKHAMEntities db, HoSoSearchEntity HoSoSearch, out List<HoSoBenhAnEntity> ListHoSo);
        // LẤY THÔNG TIN MỘT HỒ SƠ
        string GetInfomationHoSo(QLPHONGKHAMEntities db, string MaHoSo, out HoSoBenhAnEntity HoSoEntity);
        // INSERT MỘT HỒ SƠ
        string AddHoSoBenhAn(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSoEntity);
        // UPDATE MỘT HỒ SƠ
        string UpdateHoSoBenhAn(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSoEntity);
        // DELETE MỘT HỒ SƠ
        string DeleteHoSoBenhAn(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSoEntity);
        // TẠO MÃ HỒ SƠ MỚI
        string CreateIdHoSoBenhAn(QLPHONGKHAMEntities db, out string Id);
        // LẤY HỒ SƠ GỐC
        string GetRootHoSoBenhAn(QLPHONGKHAMEntities db, string MaHoSoTruoc, out HoSoBenhAnEntity hoSoBenhAnRoot);
        // LẤY DANH SÁCH HỒ SƠ THEO MÃ BỆNH NHÂN
        string GetListHoSo(QLPHONGKHAMEntities db, string MaBenhNhan, out List<HoSoBenhAnEntity> ListHoSo);
        // LẤY DANH SÁCH HỒ SƠ DỰA THEO MÃ PHÒNG VÀ NODE_KHAM
        string GetListHoSo(QLPHONGKHAMEntities db, string MaPhong, string NodeKham, out List<HoSoBenhAnEntity> ListHoSo);
    }
}
