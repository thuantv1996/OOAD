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
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
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
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                nhanVienBUS.GetListNhanVienWithIdRoom(db, MaPhong, out nhanVienDTOs);
            }
            return Constant.RES_SUC;
        }

        // Lấy danh sách xét nghiệm
        public string GetListXetNghiem(out List<XetNghiemDTO> xetNghiemDTOs)
        {
            XetNghiemBUS xetNghiemBUS = new XetNghiemBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
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
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
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
                hoSoBenhAnBUS.GetListHoSoWithIdBenhNhan(db, MaBenhNhan, out hoSoBenhAnDTOs);
            }
            return Constant.RES_SUC;
        }

        // lưu đơn thuốc
        public string SaveDonthuoc(DonThuocDTO donThuoc, List<ChiTietDonThuocDTO> chiTietDonThuocs)
        {
            DonThuocBUS donThuocBUS = new DonThuocBUS();
            ChiTietDonThuocBUS chiTietDonThuocBUS = new ChiTietDonThuocBUS();
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    string maDonThuoc = donThuocBUS.getMaDonThuoc(db);
                    donThuoc.MaDonThuoc = maDonThuoc;
                    if (donThuocBUS.SaveDonThuoc(db, donThuoc).Equals(Constant.RES_FAI))
                    {
                        trans.Rollback();
                        return Constant.RES_FAI;
                    }

                    foreach (var ct in chiTietDonThuocs)
                    {
                        ct.MaDonThuoc = maDonThuoc;
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

        // XÓA ĐƠN THUỐC
        public string DeleteDonThuoc(DonThuocDTO donThuoc)
        {
            DonThuocBUS donThuocBUS = new DonThuocBUS();
            ChiTietDonThuocBUS chiTietDonThuocBUS = new ChiTietDonThuocBUS();
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    // xoá tất cả ctdt
                    if (chiTietDonThuocBUS.DeleteAllWithId(db, donThuoc.MaDonThuoc) == Constant.RES_FAI)
                    {
                        trans.Rollback();
                        return Constant.RES_FAI;
                    }
                    // Xóa đơn thuốc
                    if (donThuocBUS.Delete(db, donThuoc.MaDonThuoc) == Constant.RES_FAI)
                    {
                        trans.Rollback();
                        return Constant.RES_FAI;
                    }
                    HoSoBenhAnDTO hoSo = new HoSoBenhAnDTO();
                    if (hoSoBenhAnBUS.GetInfomationHoSo(db, donThuoc.MaHoSo, out hoSo) == Constant.RES_FAI)
                    {
                        trans.Rollback();
                        return Constant.RES_FAI;
                    }
                    hoSo.CoKeDon = false;
                    if (hoSoBenhAnBUS.UpdateHoSoBenhAn(db, hoSo) == Constant.RES_FAI)
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

        // Lay thong tin don thuoc
        public string GetDonThuoc(string MaHoSo, out DonThuocDTO donThuoc, out List<ChiTietDonThuocDTO> chiTietDonThuocs)
        {
            donThuoc = new DonThuocDTO();
            chiTietDonThuocs = new List<ChiTietDonThuocDTO>();
            DonThuocBUS donThuocBUS = new DonThuocBUS();
            ChiTietDonThuocBUS chiTietDonThuocBUS = new ChiTietDonThuocBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                if (donThuocBUS.GetInformationDonThuocWithId(db, MaHoSo, out donThuoc) == Constant.RES_FAI)
                {
                    return Constant.RES_FAI;
                }
                if (chiTietDonThuocBUS.GetListWithIdDonThuoc(db, donThuoc.MaDonThuoc, out chiTietDonThuocs) == Constant.RES_FAI)
                {
                    return Constant.RES_FAI;
                }
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
            if (thuocs == null)
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

        // lay danh sach ket qua xet nghiem da xet nghiem
        public string GetListKetQuaXetNghiem(string MaHoSo, out List<KetQuaXetNghiemDTO> ketQuaXetNghiems)
        {
            KetQuaXetNghiemBUS bus = new KetQuaXetNghiemBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                return bus.GetListHasResWithIdHoSo(db, MaHoSo, out ketQuaXetNghiems);
            }
        }

        //Update hồ sơ bệnh án
        public string UpdateHoSo(DTO.HoSoBenhAnDTO hoso)
        {
            HoSoBenhAnBUS bus = new HoSoBenhAnBUS();

            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                if (bus.UpdateHoSoBenhAn(db, hoso) == COM.Constant.RES_FAI)
                {
                    return COM.Constant.RES_FAI;
                }

                db.SaveChanges();
            }

            return COM.Constant.RES_SUC;
        }
    }
}
