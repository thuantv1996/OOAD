using BUS.Imp;
using COM;
using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS.Inc
{
    public class TiepNhanInputCheck
    {
        public class TiepNhanEntity
        {
            public string MaHoSoTruoc { get; set; }
            public string MaLoaiHoSo { get; set; }
            public string NgayTiepNhan { get; set; }
            public string MaNguoiTN { get; set; }
            public string MaPhongKham { get; set; }
            public decimal ChiPhiKham { get; set; }
            public string YeuCauKham { get; set; }
        }

        public string InputCheck(TiepNhanEntity entity, ref List<string> Messages)
        {
            if(CheckEmpty(entity, ref Messages) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (CheckMaxLength(entity, ref Messages) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (CheckExist(entity, ref Messages) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }

        private string CheckEmpty(TiepNhanEntity entity, ref List<string> Messages)
        {
            if (string.IsNullOrEmpty(entity.MaLoaiHoSo))
            {
                Messages.Add("Xin chọn loại hồ sơ!");
                return Constant.RES_FAI;
            }
            if (string.IsNullOrEmpty(entity.NgayTiepNhan))
            {
                Messages.Add("Ngày tiếp nhận rỗng!");
                return Constant.RES_FAI;
            }
            if (entity.MaLoaiHoSo == "LHS0000002" && string.IsNullOrEmpty(entity.MaHoSoTruoc))
            {
                Messages.Add("Chọn hồ sơ trước đó!");
                return Constant.RES_FAI;
            }
            if (string.IsNullOrEmpty(entity.MaNguoiTN))
            {
                Messages.Add("Xin Chọn người tiếp nhận!");
                return Constant.RES_FAI;
            }
            if (string.IsNullOrEmpty(entity.YeuCauKham))
            {
                Messages.Add("Xin nhập yêu cầu khám!");
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }

        private string CheckMaxLength(TiepNhanEntity entity, ref List<string> Messages)
        {
            if(entity.YeuCauKham.Length > 250)
            {
                Messages.Add("Yêu cầu khám không quá 250 ký tự!");
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }

        private string CheckExist(TiepNhanEntity entity, ref List<string> Messages)
        {
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            PhongKhamBUS phongKhamBUS = new PhongKhamBUS();
            NhanVienBUS nhanVienBUS = new NhanVienBUS();
            using(QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                if (entity.MaLoaiHoSo != Com.BusConstant.HS_KHAMMOI && entity.MaLoaiHoSo != BUS.Com.BusConstant.HS_TAIKHAM)
                {
                    Messages.Add("Loại hồ sơ không tồn tại!");
                    return Constant.RES_FAI;
                }

                HoSoBenhAnDTO hoSoBenhAn = new HoSoBenhAnDTO();
                if (hoSoBenhAnBUS.GetInfomationHoSo(db, entity.MaHoSoTruoc, out hoSoBenhAn) == Constant.RES_FAI && entity.MaLoaiHoSo == Com.BusConstant.HS_TAIKHAM)
                {
                    Messages.Add("Hồ sơ bệnh án trước không tồn tại!");
                    return Constant.RES_FAI;
                }
                PhongKhamDTO phong = new PhongKhamDTO();
                if (phongKhamBUS.GetInformationPhongKham(db, entity.MaPhongKham, out phong) == Constant.RES_FAI)
                {
                    Messages.Add("Phòng khám không tồn tại!");
                    return Constant.RES_FAI;
                }
                NhanVienDTO nhanVien = new NhanVienDTO();
                if (nhanVienBUS.GetInfomationNhanVien(db, entity.MaNguoiTN, out nhanVien) == Constant.RES_FAI)
                {
                    Messages.Add("Nhân viên tiếp nhận không tồn tại!");
                    return Constant.RES_FAI;
                }
            }
            return Constant.RES_SUC;  
        }
    }
}
