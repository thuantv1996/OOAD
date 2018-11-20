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
        string AddKetQuaXetNghiem(QLPHONGKHAMEntities db, KetQuaXetNghiemDTO KetQuaXetNghiem);
        // UPDATE KẾT QUẢ XÉT NGHIỆM
        string UpdateKetQuaXetNghiem(QLPHONGKHAMEntities db, KetQuaXetNghiemDTO KetQuaXetNghiem);
        // LẤY THÔNG TIN CHI TIẾT KẾT QUẢ XÉT NGHIỆM DỰA VÀO MÃ HỒ SƠ & MÃ XÉT NGHIỆM
        string GetInformationWithId(QLPHONGKHAMEntities db, string MaHoSo, string MaXetNghiem, out KetQuaXetNghiemDTO KetQuaXetNghiem);
        // LẤY DANH SÁCH KẾT QUẢ XÉT NGHIỆM CỦA MỘT HỒ SƠ
        string GetKetQuaXetNghiemWithIdHoSo(QLPHONGKHAMEntities db, string MaHoSo, out List<KetQuaXetNghiemDTO> ListKetQuaXetNghiem);
    }
}
