using DAO;
using DTO;

namespace BUS.Service
{
    interface IThanhToanService
    {
        //INSERT MOT THANH TOAN
        string InsertThanhToan(QLPHONGKHAMEntities db, ThanhToanEntity ThanhToan);

        //UPDATE MOT THANH TOAN
        string UpdateThanhToan(QLPHONGKHAMEntities db, ThanhToanEntity ThanhToan);

        //CREATE ID THANH TOAN
        string CreateIdThanhToan(QLPHONGKHAMEntities db, out string Id);

    }
}
