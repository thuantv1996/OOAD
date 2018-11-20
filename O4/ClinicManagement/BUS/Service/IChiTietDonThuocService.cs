using DTO;
using DAO;

namespace BUS.Service
{
    interface IChiTietDonThuocService
    {
        // LƯU MỘT CHI TIẾT ĐƠN THUÔC
        string SaveChiTietDonThuoc(QLPHONGKHAMEntities db, ChiTietDonThuocDTO ChiTietDonThuocEntity);
        // UPDATE MỘT CHI TIẾT ĐƠN THUỐC
        string UpdateChiTietDonThuoc(QLPHONGKHAMEntities db, ChiTietDonThuocDTO ChiTietDonThuocEntity);
    }
}
