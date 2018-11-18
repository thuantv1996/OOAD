using System.Collections.Generic;
using DTO;
using BUS.Entities;
using DAO;
using COM;

namespace BUS.Service
{
    public interface IDonThuocService
    {
        // LƯU MỘT ĐƠN THUÔC
        string SaveDonThuoc(QLPHONGKHAMEntities db, DonThuocEnity DonThuocEntity);
        // LẤY THÔNG TIN ĐƠN THUỐC DỰA VÀO MÃ HỒ SƠ BỆNH ÁN
        string GetInformationDonThuocWithId(QLPHONGKHAMEntities db, string MaHoSo, out DonThuocEnity DonThuocEntity);
    }
}
