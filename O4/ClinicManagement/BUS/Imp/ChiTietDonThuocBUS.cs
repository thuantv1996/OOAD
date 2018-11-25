using DTO;
using DAO;
using DAO.Implement;

namespace BUS.Imp
{
    public class ChiTietDonThuocBUS
    {
        private ChiTietDonThuocDAO chiTietDonThuocDAO = null;

        public ChiTietDonThuocBUS()
        {
            chiTietDonThuocDAO = new ChiTietDonThuocDAO();
        }

        public string SaveChiTietDonThuoc(QLPHONGKHAMEntities db, ChiTietDonThuocDTO ChiTietDonThuocEntity)
        {
            // convert DTO -> DAO
            CHITIETDONTHUOC chiTietDonThuoc = new CHITIETDONTHUOC();
            BUS.Com.Utils.CopyPropertiesFrom(ChiTietDonThuocEntity, chiTietDonThuoc);
            // save 
            return chiTietDonThuocDAO.Save(db, chiTietDonThuoc);
        }
    

        public string UpdateChiTietDonThuoc(QLPHONGKHAMEntities db, ChiTietDonThuocDTO ChiTietDonThuocEntity)
        {
            // convert DTO -> DAO
            CHITIETDONTHUOC chiTietDonThuoc = new CHITIETDONTHUOC();
            BUS.Com.Utils.CopyPropertiesFrom(ChiTietDonThuocEntity, chiTietDonThuoc);
            // save 
            return chiTietDonThuocDAO.Save(db, chiTietDonThuoc);
        }
    }
}
