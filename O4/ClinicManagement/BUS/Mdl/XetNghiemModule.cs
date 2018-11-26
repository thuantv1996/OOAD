using BUS.Com;
using BUS.Imp;
using COM;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Mdl
{
    public class XetNghiemModule
    {
        // lấy danh sách chờ xét nghiệm
        public string GetListHoSoKhamByPhong(string MaPhong, out List<HoSoBenhAnDTO> listHoSoBenhAn)
        {
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                hoSoBenhAnBUS.GetListHoSo(db, MaPhong, BusConstant.NODE_XET_NGHIEM, out listHoSoBenhAn);
            }
            return Constant.RES_SUC;
        }

        // chỉ định các xét nghiệm
        public string AssignXetNghiem(List<KetQuaXetNghiemDTO> ketQuaXetNghiemDTOs)
        {
            if(ketQuaXetNghiemDTOs == null || ketQuaXetNghiemDTOs.Count == 0)
            {
                return Constant.RES_FAI;
            }
            KetQuaXetNghiemBUS ketQuaXetNghiemBUS = new KetQuaXetNghiemBUS();
            LuonCongViecBUS luonCongViecBUS = new LuonCongViecBUS();
            using(QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                LuonCongViecDTO luonCongViec = null;
                luonCongViecBUS.GetInformationLuonCongViec(db, ketQuaXetNghiemDTOs.ElementAt(0).MaHoSo, out luonCongViec);
                if(luonCongViec == null)
                {
                    return Constant.RES_FAI;
                }
                luonCongViec.NodeHienTai = BusConstant.NODE_THANH_TOAN_XET_NGHIEM;
                
                using(var trans = db.Database.BeginTransaction())
                {
                    foreach(var kq in ketQuaXetNghiemDTOs)
                    {
                        kq.ThanhToan = false;
                        if (ketQuaXetNghiemBUS.AddKetQuaXetNghiem(db, kq).Equals(Constant.RES_FAI))
                        {
                            trans.Rollback();
                            return Constant.RES_FAI;
                        }
                    }
                    if(luonCongViecBUS.UpdateLuonCongViec(db, luonCongViec).Equals(Constant.RES_FAI))
                    {
                        trans.Rollback();
                        return Constant.RES_FAI;
                    }
                }
            }
            return Constant.RES_SUC;
        }

        // lấy danh sách nhân viên theo phòng khám
        public string GetListNhanVien(string MaPhong, out List<NhanVienDTO> nhanVienDTOs)
        {
            NhanVienBUS nhanVienBUS = new NhanVienBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                nhanVienBUS.GetListNhanVienWithIdRoom(db, MaPhong, out nhanVienDTOs);
            }
            return Constant.RES_SUC;
        }

        // xử lý xét nghiệm
        public string XetNghiemProcessing(KetQuaXetNghiemDTO ketQuaXetNghiem)
        {
            KetQuaXetNghiemBUS ketQuaXetNghiemBUS = new KetQuaXetNghiemBUS();
            LuonCongViecBUS luonCongViecBUS = new LuonCongViecBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                LuonCongViecDTO luonCongViec = null;
                luonCongViecBUS.GetInformationLuonCongViec(db, ketQuaXetNghiem.MaHoSo, out luonCongViec);
                if (luonCongViec == null)
                {
                    return Constant.RES_FAI;
                }
                using (var trans = db.Database.BeginTransaction())
                {
                    if (ketQuaXetNghiemBUS.UpdateKetQuaXetNghiem(db, ketQuaXetNghiem).Equals(Constant.RES_FAI))
                    {
                        trans.Rollback();
                        return Constant.RES_FAI;
                    }

                    if(GetNumberXetNghiemActive(db, ketQuaXetNghiem.MaHoSo) == 0)
                    {
                        luonCongViec.NodeHienTai = BusConstant.NODE_KHAM_SAU_XN;
                        if (luonCongViecBUS.UpdateLuonCongViec(db, luonCongViec).Equals(Constant.RES_FAI))
                        {
                            trans.Rollback();
                            return Constant.RES_FAI;
                        }
                    }
                }
            }
            return Constant.RES_SUC;
        }

        // lấy số xét nghiệm còn lại
        private int GetNumberXetNghiemActive(QLPHONGKHAMEntities db, string MaHoSo)
        {
            KetQuaXetNghiemBUS ketQuaXetNghiemBUS = new KetQuaXetNghiemBUS();
            List<KetQuaXetNghiemDTO> ketQuaXetNghiemDTOs = new List<KetQuaXetNghiemDTO>();
            ketQuaXetNghiemBUS.GetKetQuaXetNghiemWithIdHoSo(db, MaHoSo, out ketQuaXetNghiemDTOs);
            if(ketQuaXetNghiemDTOs == null || ketQuaXetNghiemDTOs.Count == 0)
            {
                return 0;
            }
            int total = 0;
            int number = 0;
            foreach(var kq in ketQuaXetNghiemDTOs)
            {
                if(kq.ThanhToan)
                {
                    total++;
                    if (!kq.KetQua.Equals(""))
                    {
                        number++;
                    }
                }
            }
            return total - number;
        }
    }
}
