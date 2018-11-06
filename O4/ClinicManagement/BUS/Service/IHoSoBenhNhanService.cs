using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using COM;
using DTO;
using BUS.Entities;
namespace BUS.Service
{
    interface IHoSoBenhNhanService
    {
        /// <summary>
        /// THÊM HỒ SƠ BỆNH ÁN
        /// </summary>
        /// <param name="db"></param>
        /// <param name="ThanhToan"></param>
        /// <param name="Messages"></param>
        /// <returns></returns>
        string AddHoSoBenhNhan(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSoBenhAn, ref List<MessageError> Messages);
        /// <summary>
        /// UPDATE HỒ SƠ BỆNH ÁN
        /// </summary>
        /// <param name="db"></param>
        /// <param name="ThanhToan"></param>
        /// <param name="Messages"></param>
        /// <returns></returns>
        string UpdateKetQuaXetNghiem(QLPHONGKHAMEntities db, HoSoBenhAnEntity HoSoBenhAn, ref List<MessageError> Messages);
    }
}
