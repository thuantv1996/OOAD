using DTO;
using DAO;
using DAO.Implement;
using COM;

namespace BUS.Imp
{
    public class ThanhToanBUS
    { 
        private ThanhToanDAO thanhToanService = null;

        public ThanhToanBUS()
        {
            thanhToanService = new ThanhToanDAO();
        }

        public string InsertThanhToan(QLPHONGKHAMEntities db, ThanhToanDTO ThanhToan)
        {
            THANHTOAN thanhToanDAO = new THANHTOAN();
            BUS.Com.Utils.CopyPropertiesFrom(ThanhToan, thanhToanDAO);
            return thanhToanService.Save(db, thanhToanDAO);
        }

        public string CreateIdThanhToan(QLPHONGKHAMEntities db, out string Id)
        {
            return thanhToanService.CreateId(db, out Id);
        }

        public string UpdateThanhToan(QLPHONGKHAMEntities db, ThanhToanDTO ThanhToan)
        {
            THANHTOAN thanhToanDAO = new THANHTOAN();
            BUS.Com.Utils.CopyPropertiesFrom(ThanhToan, thanhToanDAO);
            return thanhToanService.Save(db, thanhToanDAO);
        }

        public string GetThanhToan(QLPHONGKHAMEntities db, string MaHoSo, out ThanhToanDTO thanhToan)
        {
            thanhToan = new ThanhToanDTO();
            THANHTOAN ResObject = new THANHTOAN();
            thanhToanService.GetThanhToan(db, MaHoSo, out ResObject);
            if(ResObject == null)
            {
                return Constant.RES_FAI;
            }
            BUS.Com.Utils.CopyPropertiesFrom(ResObject, thanhToan);
            return Constant.RES_SUC;
        }
    }

}
