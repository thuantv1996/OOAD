using System.Collections.Generic;
using DTO;
using BUS.Entities;
using DAO;
using COM;

namespace BUS.Service
{
    interface INhanVienService
    {
        // LẤY DANH SÁCH NHÂN VIÊN
        string GetListNhanVien(out List<NhanVienEnity> ListNhanVienEntity, ref List<MessageError> Messages);
        // LẤY THÔNG TIN CHI TIẾT CỦA 1 NHÂN VIÊN
        string GetInfomationNhanVien(string MaNhanVien, out NhanVienEnity NhanVienEntity, ref List<MessageError> Messages);
    }
}
