using System.Collections.Generic;
using DTO;
using DAO;

namespace BUS.Service
{
    interface INhanVienService
    {
        // LẤY DANH SÁCH NHÂN VIÊN
        string GetListNhanVien(QLPHONGKHAMEntities db, out List<NhanVienEnity> ListNhanVienEntity);
        // LẤY THÔNG TIN CHI TIẾT CỦA 1 NHÂN VIÊN
        string GetInfomationNhanVien(QLPHONGKHAMEntities db, string MaNhanVien, out NhanVienEnity NhanVienEntity);
    }
}
