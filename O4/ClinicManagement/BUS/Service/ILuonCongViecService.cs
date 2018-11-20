using DAO;
using DTO;

namespace BUS.Service
{
    interface ILuonCongViecService
    {
        //INSERT MOT LUON CONG VIEC
        string AddLuonCongViec(QLPHONGKHAMEntities db,  LuonCongViecDTO LuonCongViec);

        //UPDATE MOT LUON CONG VIEC
        string UpdateLuonCongViec(QLPHONGKHAMEntities db, LuonCongViecDTO LuonCongViec);

        //LẤY THÔNG TIN MỘT LUỒN CÔNG VIỆC
        string GetInformationLuonCongViec(QLPHONGKHAMEntities db, string MaHoSo, out LuonCongViecDTO LuonCongViecEntity);
    }
}
