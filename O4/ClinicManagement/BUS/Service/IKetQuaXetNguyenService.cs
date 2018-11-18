using System.Collections.Generic;
using DTO;
using BUS.Entities;
using DAO;
using COM;

namespace BUS.Service
{
    interface IKetQuaXetNguyenService
    {
        // THÊM KẾT QUẢ XÉT NGHIỆM
        string AddKetQuaXetNghiem(QLPHONGKHAMEntities db, KetQuaXetNghiemEnity KetQuaXetNghiem);
        // UPDATE KẾT QUẢ XÉT NGHIỆM
        string UpdateKetQuaXetNghiem(QLPHONGKHAMEntities db, KetQuaXetNghiemEnity KetQuaXetNghiem);
        // LẤY THÔNG TIN CHI TIẾT KẾT QUẢ XÉT NGHIỆM DỰA VÀO MÃ HỒ SƠ & MÃ XÉT NGHIỆM
        string GetInformationWithId(QLPHONGKHAMEntities db, string MaHoSo, string MaXetNghiem, out KetQuaXetNghiemEnity KetQuaXetNghiem);
        // LẤY DANH SÁCH KẾT QUẢ XÉT NGHIỆM CỦA MỘT HỒ SƠ
        string GetKetQuaXetNghiemWithIdHoSo(QLPHONGKHAMEntities db, string MaHoSo, out List<KetQuaXetNghiemEnity> ListKetQuaXetNghiem);
    }
}
