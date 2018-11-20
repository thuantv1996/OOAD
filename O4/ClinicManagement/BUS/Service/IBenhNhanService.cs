using System.Collections.Generic;
using DTO;
using BUS.Entities;
using DAO;


namespace BUS.Service
{
    interface IBenhNhanService
    {
        // HÀM LẤY DANH SÁCH BỆNH NHÂN
        string GetListBenhNhan(QLPHONGKHAMEntities db, out List<BenhNhanDTO> ListBenhNhan);

        // TÌM KIẾM THÔNG TIN BỆNH NHÂN
        string SearchBenhNhan(QLPHONGKHAMEntities db, BenhNhanSearchEntity BenhNhanSearchEntity,out List<BenhNhanDTO> ListBenhNhan);
        
        // LẤY THÔNG TIN BỆNH NHÂN KHI BIẾT MÃ
        string GetInformationBenhNhan(QLPHONGKHAMEntities db, string MaBenhNhan,out BenhNhanDTO InformationBenhNhan);
        
        // THÊM MỚI MỘT BỆNH NHÂN
        string InsertBenhNhan(QLPHONGKHAMEntities db, BenhNhanDTO BenhNhan);

        // UPDATE THÔNG TIN BỆNH NHÂN
        string UpdateBenhNhan(QLPHONGKHAMEntities db, BenhNhanDTO BenhNhan);
    }
}
