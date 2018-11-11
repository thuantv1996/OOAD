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
        // LẤY DANH SÁCH HỒ SƠ KHÁM
        // LẤY DANH SÁCH HỒ SƠ THANH TOÁN XÉT NGHIỆM
        // LẤY DANH SÁCH HỒ SƠ XÉT NGHIỆM
        // LẤY DANH SÁCH HỒ SƠ XÉT NGHIỆM XONG
        // TẠO MÃ HỒ SƠ MỚI
        string CreateIdHoSoBenhAn(out string Id, ref List<MessageError> Messages);
        // LẤY HỒ SƠ GỐC
        string GetRootHoSoBenhAn(QLPHONGKHAMEntities db, string MaHoSoTruoc, out HoSoBenhAnEntity hoSoBenhAnRoot, ref List<MessageError> Messages);
        // LẤY DANH SÁCH HỒ SƠ THEO MÃ BỆNH NHÂN
        string GetListHoSoBenhAnWithId(QLPHONGKHAMEntities db, string MaBenhNhan, out List<HoSoBenhAnEntity> ListHoSo,ref List<MessageError> Messages);
        // LẤY DANH SÁCH HỒ SƠ DỰA THEO MÃ PHÒNG VÀ NODE_KHAM
        string GetListHoSoWithIdAndNodeKham(QLPHONGKHAMEntities db, string MaPhong, string Node_Kham, out List<HoSoBenhAnEntity> ListHoSo, ref List<MessageError> Messages);
    }
}
