using System.Collections.Generic;
using DTO;
using COM;
using BUS.Entities;
using DAO;


namespace BUS.Service
{
    interface IBenhNhanService
    {
        // HÀM LẤY DANH SÁCH BỆNH NHÂN
        string GetListBenhNhan(QLPHONGKHAMEntities db, out List<BenhNhanEnity> ListBenhNhan);

        // TÌM KIẾM THÔNG TIN BỆNH NHÂN
        string SearchBenhNhan(QLPHONGKHAMEntities db, BenhNhanSearchEntity BenhNhanSearchEntity,out List<BenhNhanEnity> ListBenhNhan);
        
        // LẤY THÔNG TIN BỆNH NHÂN KHI BIẾT MÃ
        string GetInformationBenhNhan(QLPHONGKHAMEntities db, string MaBenhNhan,out BenhNhanEnity InformationBenhNhan);
        
        // THÊM MỚI MỘT BỆNH NHÂN
        string InsertBenhNhan(QLPHONGKHAMEntities db, BenhNhanEnity BenhNhan);

        // UPDATE THÔNG TIN BỆNH NHÂN
        string UpdateBenhNhan(QLPHONGKHAMEntities db, BenhNhanEnity BenhNhan);
    }
}
