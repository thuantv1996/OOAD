using System.Collections.Generic;
using DTO;
using BUS.Entities;
using DAO;
using COM;

namespace BUS.Service
{
    interface IChiTietDonThuocService
    {
        // LƯU MỘT CHI TIẾT ĐƠN THUÔC
        string SaveChiTietDonThuoc(QLPHONGKHAMEntities db, ChiTietDonThuocEnity ChiTietDonThuocEntity);
        // UPDATE MỘT CHI TIẾT ĐƠN THUỐC
        string UpdateChiTietDonThuoc(QLPHONGKHAMEntities db, ChiTietDonThuocEnity ChiTietDonThuocEntity);
    }
}
