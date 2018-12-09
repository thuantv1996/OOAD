using BUS.Imp;
using COM;
using DTO;
using System.Collections.Generic;
using DAO;
using BUS.Com;
using BUS.Inc;

namespace BUS.Mdl
{
    public class KhamModule
    {
        // lấy danh sách hồ sơ khám theo phòng
        public string GetListHoSoKhamByPhong(string MaPhong, out List<HoSoBenhAnDTO> listHoSoBenhAn)
        {
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            using(QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                hoSoBenhAnBUS.GetListHoSo(db, MaPhong, BusConstant.NODE_KHAM, out listHoSoBenhAn);
            }
            return Constant.RES_SUC;
        }

        // lấy danh sách hồ sơ sau xét nghiệm theo phòng
        public string GetListHoSoXetNgiemByPhong(string MaPhong, out List<HoSoBenhAnDTO> listHoSoBenhAn)
        {
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                hoSoBenhAnBUS.GetListHoSo(db, MaPhong, BusConstant.NODE_KHAM_SAU_XN, out listHoSoBenhAn);
            }
            return Constant.RES_SUC;
        }
        
        // lấy thông tin toàn bồ hồ sơ
        public string GetInformationHoSo(string MaHoSo, out HoSoBenhAnDTO hoSoBenhAn)
        {
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                hoSoBenhAnBUS.GetInfomationHoSo(db, MaHoSo, out hoSoBenhAn);
            }
            return Constant.RES_SUC;
        }

        // lấy danh sách nhân viên theo phòng khám
        public string GetListNhanVien(string MaPhong, out List<NhanVienDTO> nhanVienDTOs)
        {
            NhanVienBUS nhanVienBUS = new NhanVienBUS();
            using(QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                nhanVienBUS.GetListNhanVienWithIdRoom(db, MaPhong, out nhanVienDTOs);
            }
            return Constant.RES_SUC;
        }

        // Lấy danh sách xét nghiệm
        public string GetListXetNghiem(out List<XetNghiemDTO> xetNghiemDTOs)
        {
            XetNghiemBUS xetNghiemBUS = new XetNghiemBUS();
            using(QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                xetNghiemBUS.GetListXetNghiem(db, out xetNghiemDTOs);
            }
            return Constant.RES_SUC;
        }

        // check input
        public string InputCheck(HoSoBenhAnDTO hoSo, ref List<string> MessageError)
        {
            KhamInputCheck inputCheck = new KhamInputCheck();
            return inputCheck.InputCheck(hoSo, ref MessageError);
        }

        // Lưu thông tin Khám
        public string KhamProcessing(HoSoBenhAnDTO hoSoBenhAn)
        {
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            LuonCongViecBUS luonCongViecBUS = new LuonCongViecBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                LuonCongViecDTO luonCongViec = new LuonCongViecDTO();
                try
                {
                    luonCongViecBUS.GetInformationLuonCongViec(db, hoSoBenhAn.MaHoSo, out luonCongViec);
                    luonCongViec.NodeHienTai = BusConstant.NODE_HOAN_TAT;
                    luonCongViec.KhamBenh = true;
                }
                catch
                {
                    return Constant.RES_FAI;
                }
                using (var trans = db.Database.BeginTransaction())
                {
                    if (hoSoBenhAnBUS.UpdateHoSoBenhAn(db, hoSoBenhAn).Equals(Constant.RES_FAI))
                    {
                        trans.Rollback();
                        return Constant.RES_FAI;
                    }
                    if (luonCongViecBUS.UpdateLuonCongViec(db, luonCongViec).Equals(Constant.RES_FAI))
                    {
                        trans.Rollback();
                        return Constant.RES_FAI;
                    }
                    trans.Commit();
                }
                db.SaveChanges();
            }
            return Constant.RES_SUC;
        }

        // lấy thông tin bệnh nhân
        public string GetInformationBenhNhan(string MaBenhNhan, out BenhNhanDTO benhNhan)
        {
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            using(QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                benhNhanBUS.GetInformationBenhNhan(db, MaBenhNhan, out benhNhan);
            }
            return Constant.RES_SUC;
        }

        // lấy danh sách hồ sơ theo bệnh nhân
        public string GetListHoSoByBenhNhan(string MaBenhNhan, out List<HoSoBenhAnDTO> hoSoBenhAnDTOs)
        {
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                hoSoBenhAnBUS.GetListHoSoWithIdBenhNhan(db, MaBenhNhan,out hoSoBenhAnDTOs);
            }
            return Constant.RES_SUC;
        }

        // lưu đơn thuốc
        public string SaveDonthuoc(DonThuocDTO donThuoc, List<ChiTietDonThuocDTO> chiTietDonThuocs)
        {
            DonThuocBUS donThuocBUS = new DonThuocBUS();
            ChiTietDonThuocBUS chiTietDonThuocBUS = new ChiTietDonThuocBUS();
            using(QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                using(var trans = db.Database.BeginTransaction())
                {
                    if (donThuocBUS.SaveDonThuoc(db, donThuoc).Equals(Constant.RES_FAI))
                    {
                        trans.Rollback();
                        return Constant.RES_FAI;
                    }
                    foreach(var ct in chiTietDonThuocs)
                    {
                        if (chiTietDonThuocBUS.SaveChiTietDonThuoc(db, ct).Equals(Constant.RES_FAI))
                        {
                            trans.Rollback();
                            return Constant.RES_FAI;
                        }
                    }
                    trans.Commit();
                }
                db.SaveChanges();
            }
            return Constant.RES_SUC;
        }

        // Lay thong tin don thuoc
        public string GetDonThuoc(string MaHoSo,out DonThuocDTO donThuoc, out List<ChiTietDonThuocDTO> chiTietDonThuocs)
        {
            DonThuocBUS donThuocBUS = new DonThuocBUS();
            ChiTietDonThuocBUS chiTietDonThuocBUS = new ChiTietDonThuocBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                donThuocBUS.GetInformationDonThuocWithId(db, MaHoSo, out donThuoc);
                chiTietDonThuocBUS.GetListWithIdDonThuoc(db, donThuoc.MaDonThuoc, out chiTietDonThuocs);
            }
            return Constant.RES_SUC;
        }

        // lay danh sach thuoc
        public string GetListThuoc(out List<ThuocDTO> thuocs)
        {
            ThuocBUS thuocBUS = new ThuocBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                if (thuocBUS.GetListThuoc(db, out thuocs) == Constant.RES_FAI) 
                {
                    return Constant.RES_FAI;
                }
            }
            if(thuocs == null)
            {
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }

        // lay thong tin phong
        public string GetInformationPhong(string MaPhong, out PhongKhamDTO phong)
        {
            PhongKhamBUS phongKhamBUS = new PhongKhamBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                return phongKhamBUS.GetInformationPhongKham(db, MaPhong, out phong);
            }
        }   
    }
}
