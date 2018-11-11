using System.Collections.Generic;
using DTO;
using COM;
using BUS.Entities;

namespace BUS.Service
{
    interface ILoaiHoSoService
    {
        /// <summary>
        /// LẤY DANH SÁCH LOẠI HỒ SƠ
        /// </summary>
        /// <param name="ListLoaiHoSo"></param>
        /// <param name="Messages"></param>
        /// <returns></returns>
        string GetListLoaiHoSo(out List<LoaiHoSoEnity> ListLoaiHoSo, ref List<MessageError> Messages);
        /// <summary>
        /// LẤY THÔNG TIN LOẠI HỒ SƠ
        /// </summary>
        /// <param name="MaLoaiHoSo"></param>
        /// <param name="InformationLoaiHoSo"></param>
        /// <param name="Messages"></param>
        /// <returns></returns>
        string GetInformationLoaiHoSo(string MaLoaiHoSo, out LoaiHoSoEnity InformationLoaiHoSo, ref List<MessageError> Messages);
    }
}
