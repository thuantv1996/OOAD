using System.Collections.Generic;
using DTO;
using DAO; 

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
        string GetListLoaiHoSo(QLPHONGKHAMEntities db, out List<LoaiHoSoDTO> ListLoaiHoSo);
        /// <summary>
        /// LẤY THÔNG TIN LOẠI HỒ SƠ
        /// </summary>
        /// <param name="MaLoaiHoSo"></param>
        /// <param name="InformationLoaiHoSo"></param>
        /// <param name="Messages"></param>
        /// <returns></returns>
        string GetInformationLoaiHoSo(QLPHONGKHAMEntities db, string MaLoaiHoSo, out LoaiHoSoDTO InformationLoaiHoSo);
    }
}
