using System.Collections.Generic;
using DTO;
using DAO;

namespace BUS.Service
{
    interface IPhongKhamService
    {
        /// <summary>
        /// LẤY DANH SÁCH BỆNH NHÂN
        /// </summary>
        /// <param name="ListPhongKham"></param>
        /// <param name="Messages"></param>
        /// <returns></returns>
        string GetListPhongKham(QLPHONGKHAMEntities db, out List<PhongKhamDTO> ListPhongKham);
        /// <summary>
        /// LẤY THÔNG TIN PHÒNG KHÁM DỰA TRÊN MÃ PHÒNG KHÁM
        /// </summary>
        /// <param name="MaPhongKham"></param>
        /// <param name="InformationPhongKham"></param>
        /// <param name="Messages"></param>
        /// <returns></returns>
        string GetInformationPhongKham(QLPHONGKHAMEntities db, string MaPhongKham, out PhongKhamDTO InformationPhongKham);
    }
}
