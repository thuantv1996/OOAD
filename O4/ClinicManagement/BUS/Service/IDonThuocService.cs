using System.Collections.Generic;
using DTO;
using BUS.Entities;
using DAO;
using COM;

namespace BUS.Service
{
    interface IDonThuocService
    {
        // LƯU MỘT ĐƠN THUÔC
        string SaveDonThuoc(QLPHONGKHAMEntities db, DonThuocEnity DonThuocEntity, ref List<MessageError> Messages);
        // LẤY THÔNG TIN ĐƠN THUỐC DỰA VÀO MÃ HỒ SƠ BỆNH ÁN
        string GetInformationDonThuocWithId(string MaHoSo, DonThuocEnity DonThuocEntity, ref List<MessageError> Messages);
    }
}
