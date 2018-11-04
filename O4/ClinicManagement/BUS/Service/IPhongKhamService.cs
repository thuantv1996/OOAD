using System.Collections.Generic;
using DTO;
using COM;
using BUS.Entities;

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
        string GetListPhongKham(out List<PhongKhamEnity> ListPhongKham, ref List<MessageError> Messages);
        /// <summary>
        /// LẤY THÔNG TIN PHÒNG KHÁM DỰA TRÊN MÃ PHÒNG KHÁM
        /// </summary>
        /// <param name="MaPhongKham"></param>
        /// <param name="InformationPhongKham"></param>
        /// <param name="Messages"></param>
        /// <returns></returns>
        string GetInformationPhongKham(string MaPhongKham, out PhongKhamEnity InformationPhongKham, ref List<MessageError> Messages);
    }
}
