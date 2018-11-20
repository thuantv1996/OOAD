using DTO;
using DAO;

namespace BUS.Service
{
    interface ITrangThaiPhongService
    {
        /// <summary>
        /// LẤY THÔNG TIN TRẠNG THÁI PHÒNG
        /// </summary>
        /// <param name="MaPhongKham"></param>
        /// <param name="NgayThang"></param>
        /// <param name="TrangThaiPhong"></param>
        /// <param name="Messages"></param>
        /// <returns></returns>
        string GetTrangThaiPhong(QLPHONGKHAMEntities db, string MaPhongKham, string NgayThang, out TrangThaiPhongDTO TrangThaiPhong);
        /// <summary>
        /// UPDATE TRẠNG THÁI PHÒNG
        /// </summary>
        /// <param name="TrangThaiPhong"></param>
        /// <param name="Messages"></param>
        /// <returns></returns>
        string UpdateTrangThaiPhong(QLPHONGKHAMEntities db, TrangThaiPhongDTO TrangThaiPhong);
    }
}
