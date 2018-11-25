using DTO;
using DAO;
using COM;
using DAO.Implement;

namespace BUS.Imp
{
    public class LuonCongViecBUS
    {
        private LuonCongViecDAO luonCongViecService = null;

        public LuonCongViecBUS()
        {
            luonCongViecService = new LuonCongViecDAO();
        }

        public string AddLuonCongViec(QLPHONGKHAMEntities db, LuonCongViecDTO LuonCongViec)
        {
            LUONCONGVIEC luonCongViecDAO = new LUONCONGVIEC();
            BUS.Com.Utils.CopyPropertiesFrom(LuonCongViec, luonCongViecDAO);
            return luonCongViecService.Save(db, luonCongViecDAO);
        }

        public string GetInformationLuonCongViec(QLPHONGKHAMEntities db, string MaHoSo, out LuonCongViecDTO LuonCongViecEntity)
        {
            LuonCongViecEntity = new LuonCongViecDTO();
            LUONCONGVIEC entity = null;
            object[] id = { MaHoSo };
            if (luonCongViecService.FindById(db, id, out entity) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (entity == null)
            {
                return Constant.RES_FAI;
            }
            BUS.Com.Utils.CopyPropertiesFrom(entity, LuonCongViecEntity);
            return Constant.RES_SUC;
        }

        public string UpdateLuonCongViec(QLPHONGKHAMEntities db, LuonCongViecDTO LuonCongViec)
        {
            LUONCONGVIEC luonCongViecDAO = new LUONCONGVIEC();
            BUS.Com.Utils.CopyPropertiesFrom(LuonCongViec, luonCongViecDAO);
            return luonCongViecService.Save(db, luonCongViecDAO);
        }
    }
}

