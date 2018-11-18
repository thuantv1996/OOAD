using BUS.Service;
using DTO;
using DAO;

namespace BUS.Imp
{
    public class ChiTietDonThuocImplement : IChiTietDonThuocService
    {
        private DAO.Interface.IChiThietDonThuocServices chiTietDonThuocServices = null;

        public ChiTietDonThuocImplement()
        {
            chiTietDonThuocServices = new DAO.Implement.ChiTietDonThuocImplement();
        }

        public string SaveChiTietDonThuoc(QLPHONGKHAMEntities db, ChiTietDonThuocEnity ChiTietDonThuocEntity)
        {
            // convert DTO -> DAO
            CHITIETDONTHUOC chiTietDonThuocDAO = new CHITIETDONTHUOC();
            BUS.Com.Utils.CopyPropertiesFrom(ChiTietDonThuocEntity, chiTietDonThuocDAO);
            // save 
            return chiTietDonThuocServices.Save(db, chiTietDonThuocDAO);
        }
    

        public string UpdateChiTietDonThuoc(QLPHONGKHAMEntities db, ChiTietDonThuocEnity ChiTietDonThuocEntity)
        {
            // convert DTO -> DAO
            CHITIETDONTHUOC chiTietDonThuocDAO = new CHITIETDONTHUOC();
            BUS.Com.Utils.CopyPropertiesFrom(ChiTietDonThuocEntity, chiTietDonThuocDAO);
            // save 
            return chiTietDonThuocServices.Save(db, chiTietDonThuocDAO);
        }
    }
}
