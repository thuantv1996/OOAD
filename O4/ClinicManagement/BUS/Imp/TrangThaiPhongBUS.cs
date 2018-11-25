using DAO;
using DTO;
using COM;
using DAO.Implement;

namespace BUS.Imp
{
    public class TrangThaiPhongBUS
    {
        private TrangThaiPhongDAO trangThaiPhongServices = null;
        public TrangThaiPhongBUS()
        {
            trangThaiPhongServices = new TrangThaiPhongDAO();
        }

        public string GetTrangThaiPhong(QLPHONGKHAMEntities db, string MaPhongKham, string NgayThang, out TrangThaiPhongDTO TrangThaiPhong)
        {
            TrangThaiPhong = new TrangThaiPhongDTO();
            TRANGTHAIPHONG entity = null;
            object[] id = { MaPhongKham, NgayThang };
            if(trangThaiPhongServices.FindById(db, id, out entity) == Constant.RES_FAI )
            {
                return Constant.RES_FAI;
            }

            if(entity == null)
            {
                return Constant.RES_FAI;
            }
            BUS.Com.Utils.CopyPropertiesFrom(entity, TrangThaiPhong);
            return Constant.RES_SUC;


            
        }

        public string UpdateTrangThaiPhong(QLPHONGKHAMEntities db, TrangThaiPhongDTO TrangThaiPhong)
        {
            TRANGTHAIPHONG trangthaiphongDAO = new TRANGTHAIPHONG();
            BUS.Com.Utils.CopyPropertiesFrom(TrangThaiPhong, trangthaiphongDAO);
            return trangThaiPhongServices.Save(db, trangthaiphongDAO);
            
        }
    }
}
