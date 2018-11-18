using BUS.Service;
using DTO;
using DAO;
using COM;

namespace BUS.Imp
{
    public class LuonCongViecImplement : ILuonCongViecService
    {
        DAO.Interface.ILuonCongViecServices luonCongViecService = null;

        public LuonCongViecImplement()
        {
            luonCongViecService = new DAO.Implement.LuonCongViecImplement();
        }

        public string AddLuonCongViec(QLPHONGKHAMEntities db, LuonCongViecEnity LuonCongViec)
        {
            LUONCONGVIEC luonCongViecDAO = new LUONCONGVIEC();
            BUS.Com.Utils.CopyPropertiesFrom(LuonCongViec, luonCongViecDAO);
            return luonCongViecService.Save(db, luonCongViecDAO);
        }

        public string GetInformationLuonCongViec(QLPHONGKHAMEntities db, string MaHoSo, out LuonCongViecEnity LuonCongViecEntity)
        {
            LuonCongViecEntity = new LuonCongViecEnity();
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

        public string UpdateLuonCongViec(QLPHONGKHAMEntities db, LuonCongViecEnity LuonCongViec)
        {
            LUONCONGVIEC luonCongViecDAO = new LUONCONGVIEC();
            BUS.Com.Utils.CopyPropertiesFrom(LuonCongViec, luonCongViecDAO);
            return luonCongViecService.Save(db, luonCongViecDAO);
        }
    }
}

