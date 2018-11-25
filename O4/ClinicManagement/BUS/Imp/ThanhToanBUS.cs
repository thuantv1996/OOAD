using DTO;
using DAO;
using DAO.Implement;

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
    }

}
