using DTO;
using DAO;

namespace BUS.Service
{
    public interface IDonThuocService
    {
        // LƯU MỘT ĐƠN THUÔC
        string SaveDonThuoc(QLPHONGKHAMEntities db, DonThuocDTO DonThuocEntity);
        // LẤY THÔNG TIN ĐƠN THUỐC DỰA VÀO MÃ HỒ SƠ BỆNH ÁN
        string GetInformationDonThuocWithId(QLPHONGKHAMEntities db, string MaHoSo, out DonThuocDTO DonThuocEntity);
    }
}
