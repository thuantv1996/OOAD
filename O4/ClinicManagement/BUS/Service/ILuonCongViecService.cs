using DAO;
using DTO;

namespace BUS.Service
{
    interface ILuonCongViecService
    {
        //INSERT MOT LUON CONG VIEC
        string AddLuonCongViec(QLPHONGKHAMEntities db,  LuonCongViecEnity LuonCongViec);

        //UPDATE MOT LUON CONG VIEC
        string UpdateLuonCongViec(QLPHONGKHAMEntities db, LuonCongViecEnity LuonCongViec);

        //LẤY THÔNG TIN MỘT LUỒN CÔNG VIỆC
        string GetInformationLuonCongViec(QLPHONGKHAMEntities db, string MaHoSo, out LuonCongViecEnity LuonCongViecEntity);
    }
}
