using DAO;
using DTO;

namespace BUS.Service
{
    interface IThanhToanService
    {
        //INSERT MOT THANH TOAN
        string InsertThanhToan(QLPHONGKHAMEntities db, ThanhToanDTO ThanhToan);

        //UPDATE MOT THANH TOAN
        string UpdateThanhToan(QLPHONGKHAMEntities db, ThanhToanDTO ThanhToan);

        //CREATE ID THANH TOAN
        string CreateIdThanhToan(QLPHONGKHAMEntities db, out string Id);

    }
}
