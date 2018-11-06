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
    interface IKetQuaXetNguyenService
    {
        /// <summary>
        /// THÊM KẾT QUẢ XÉT NGHIỆM
        /// </summary>
        /// <param name="db"></param>
        /// <param name="ThanhToan"></param>
        /// <param name="Messages"></param>
        /// <returns></returns>
        string AddKetQuaXetNghiem(QLPHONGKHAMEntities db, KetQuaXetNghiemEnity KetQuaXetNghiem, ref List<MessageError> Messages);
        /// <summary>
        /// UPDATE KẾT QUẢ XÉT NGHIỆM
        /// </summary>
        /// <param name="db"></param>
        /// <param name="ThanhToan"></param>
        /// <param name="Messages"></param>
        /// <returns></returns>
        string UpdateKetQuaXetNghiem(QLPHONGKHAMEntities db, KetQuaXetNghiemEnity KetQuaXetNghiem, ref List<MessageError> Messages);
    }
}
