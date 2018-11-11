using System.Collections.Generic;
using DTO;
using BUS.Entities;
using DAO;
using COM;

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
        // LẤY THÔNG TIN CHI TIẾT KẾT QUẢ XÉT NGHIỆM DỰA VÀO MÃ HỒ SƠ & MÃ XÉT NGHIỆM
        string GetInformationWithId(string MaHoSo, string MaXetNghiem, KetQuaXetNghiemEnity KetQuaXetNghiem, ref List<MessageError> Messages);
        // LẤY DANH SÁCH KẾT QUẢ XÉT NGHIỆM CỦA MỘT HỒ SƠ
        string GetListKetQuaXetNghiemWithId(QLPHONGKHAMEntities db, string MaHoSo, out List<KetQuaXetNghiemEnity> ListKetQuaXetNghiem, ref List<MessageError> Messages)
    }
}
