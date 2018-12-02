using System;
using System.Collections.Generic;
using COM;
using BUS.Imp;
using BUS.Entities;
using DAO;
using BUS.Com;
using DTO;
using BUS.Inc;

namespace BUS.Mdl
{
    public class TiepNhanModule
    {
        public string GetListBenhNhan(out List<BenhNhanDTO> ListBenhNhan)
        {
            // Tạo đối tượng BenhNhanBUS
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                // getListBenhNhan
                benhNhanBUS.GetListBenhNhan(db, out ListBenhNhan);
            }
            // return
            return Constant.RES_SUC;
        }

        public string SearchBenhNhan(BenhNhanDTO BenhNhan, out List<BenhNhanDTO> ListBenhNhan, int IdScreen)
        {
            // nếu đối tượng search == null
            if(BenhNhan == null)
            {
                // tạo mới đối tượng
                BenhNhan = new BenhNhanDTO();
            }
            // Tạo dối tượng BenhNhanBUS
            BenhNhanBUS benhNhanBus = new BenhNhanBUS();
            // Tạo Search key object
            BenhNhanSearchEntity benhNhanSearchEntity = new BenhNhanSearchEntity{ MaBenhNhan = BenhNhan.MaBenhNhan,
                                                                                  TenBenhNhan = BenhNhan.HoTen,
                                                                                  CMND = BenhNhan.CMND };
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                benhNhanBus.SearchBenhNhan(db, benhNhanSearchEntity, out ListBenhNhan);
            }
            // nếu kết quả trả về là list rỗng
            if(ListBenhNhan.Count == 0)
            {
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }

        public string GetListLoaiHoSo(out List<LoaiHoSoDTO> loaiHoSoDTOs)
        {
            // tạo bus
            LoaiHoSoBUS loaiHoSoBUS = new LoaiHoSoBUS();
            // tạo data base
            using(QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                // get list 
                loaiHoSoBUS.GetListLoaiHoSo(db,out loaiHoSoDTOs);
            }
            // nếu kế quả trả về là null
            if(loaiHoSoDTOs == null)
            {
                loaiHoSoDTOs = new List<LoaiHoSoDTO>();
            }
            return Constant.RES_SUC;
        }
        
        public string GetListPhongKham(out List<PhongKhamDTO> ListPhongKham)
        {
            PhongKhamBUS phongKhamBUS = new PhongKhamBUS();
            using(QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                phongKhamBUS.GetListPhongKham(db, out ListPhongKham);
            }
            if(ListPhongKham == null)
            {
                ListPhongKham = new List<PhongKhamDTO>();
            }
            return Constant.RES_SUC;
        }

        public int GetSoThuTu(string MaPhong, ref List<MessageError> Messages)
        {
            // Tạo đối tượng bus
            TrangThaiPhongBUS trangThaiPhongBUS = new TrangThaiPhongBUS();
            // Tạo đối tượng DTO
            TrangThaiPhongDTO trangThaiPhong = null;
            // get System date
            string SystemDate = DateTime.Now.Year.ToString()
                              + DateTime.Now.Month.ToString()
                              + DateTime.Now.Day.ToString();
            using(QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                // gọi hàm lấy trạng thái phòng
                trangThaiPhongBUS.GetTrangThaiPhong(db, MaPhong, SystemDate, out trangThaiPhong);
            }
            // Trả về STT
            return trangThaiPhong.SttCaoNhat + 1;
        }

        public string GetMaHoSo(ref List<MessageError> Messages)
        {
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            string Id = "";
            using(QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                hoSoBenhAnBUS.CreateIdHoSoBenhAn(db, out Id);
            }
            return Id;
        }

        public string GetListRelativeHoSo(string MaBenhNhan, out List<HoSoBenhAnDTO> ListRelativeHoSo, ref List<MessageError> Messages)
        {
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            using(var db = new QLPHONGKHAMEntities())
            {
                if(hoSoBenhAnBUS.GetListHoSoWithIdBenhNhan(db, MaBenhNhan, out ListRelativeHoSo) == Constant.RES_FAI)
                {
                    return Constant.RES_FAI;
                }
            }
            return Constant.RES_SUC;
        }

        public string SaveHoSo(HoSoBenhAnDTO hoSoBenhAn,
                               ThanhToanDTO thanhToan,
                               TrangThaiPhongDTO trangThaiPhong,
                               ref List<MessageError> Messages)
        {
            // Check input

            ThanhToanBUS thanhToanBUS = new ThanhToanBUS();
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            LuonCongViecBUS luonCongViecBUS = new LuonCongViecBUS();
            TrangThaiPhongBUS trangThaiPhongBUS = new TrangThaiPhongBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                // nếu là hồ sơ tái khám
                if (hoSoBenhAn.MaLoaiHoSo == BusConstant.HS_TAIKHAM)
                {
                    HoSoBenhAnDTO root = new HoSoBenhAnDTO();

                    // get MaHoSoGoc
                    hoSoBenhAnBUS.GetRootHoSoBenhAn(db, hoSoBenhAn.MaHoSoTruoc, out root);
                    hoSoBenhAn.MaHoSoGoc = root.MaHoSoGoc;

                }


                // điền thông tin vào thanh toán

                string MaThanhToan = "";
                thanhToanBUS.CreateIdThanhToan(db, out MaThanhToan);
                thanhToan.MaThanhToan = MaThanhToan;
                thanhToan.TongChiPhi = thanhToan.ChiPhiKham;
                // điền thông tin Workflow
                LuonCongViecDTO luonCongViec = new LuonCongViecDTO();
                luonCongViec.MaHoSo = hoSoBenhAn.MaHoSo;
                luonCongViec.NodeHienTai = BusConstant.NODE_KHAM;
                luonCongViec.TiepNhan = true;
                luonCongViec.XetNghiem = false;
                luonCongViec.KhamBenh = false;

                // Tạo transaction
                using (var trans = db.Database.BeginTransaction())
                {
                    // save hồ sơ
                    if (hoSoBenhAnBUS.AddHoSoBenhAn(db, hoSoBenhAn) == Constant.RES_FAI)
                    {
                        trans.Rollback();
                        return Constant.RES_FAI;
                    }
                    // save luồn công việc 
                    if (luonCongViecBUS.AddLuonCongViec(db, luonCongViec) == Constant.RES_FAI)
                    {
                        trans.Rollback();
                        return Constant.RES_FAI;
                    }
                    // save thanh toán
                    if (thanhToanBUS.InsertThanhToan(db, thanhToan) == Constant.RES_FAI)
                    {
                        trans.Rollback();
                        return Constant.RES_FAI;
                    }
                    // update Trang thanh phong
                    if (trangThaiPhongBUS.UpdateTrangThaiPhong(db, trangThaiPhong) == Constant.RES_FAI)
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

        public string InsertBenhNhan(BenhNhanDTO benhNhan)
        {
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            using(QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                string id = "";
                benhNhanBUS.CreateIdBenhNhan(db, out id);
                benhNhan.MaBenhNhan = id;
                if (benhNhanBUS.InsertBenhNhan(db, benhNhan) == Constant.RES_FAI)
                {
                    return Constant.RES_FAI;
                }
            }
            return Constant.RES_SUC;
        }

        public string UpdateBenhNhan(BenhNhanDTO benhNhan)
        {
            BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                if (benhNhanBUS.UpdateBenhNhan(db, benhNhan) == Constant.RES_FAI)
                {
                    return Constant.RES_FAI;
                }
            }
            return Constant.RES_SUC;
        }

        public string GetListNhanVienTiepNhan(out List<NhanVienDTO> listNhanVienTN)
        {
            listNhanVienTN = new List<NhanVienDTO>();
            NhanVienBUS nhanVienBUS = new NhanVienBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                if (nhanVienBUS.GetListNhanVienWithLNV(db, COM.Constant.ID_LNV_TN, out listNhanVienTN) == Constant.RES_FAI)
                {
                    return Constant.RES_FAI;
                }
            }
            return Constant.RES_SUC;
        }

        public string BenhNhanInputCheck(BenhNhanDTO benhNhan, ref List<string> MessageError)
        {
            BenhNhanInputCheck benhNhanInputCheck = new BenhNhanInputCheck();
            return benhNhanInputCheck.CheckInput(benhNhan, ref MessageError);
        }

        public string TiepNhanInputCheck(TiepNhanInputCheck.TiepNhanEntity entity, ref List<string> MessageError)
        {
            TiepNhanInputCheck inputCheck = new TiepNhanInputCheck();
            return inputCheck.InputCheck(entity, ref MessageError);
        }
    }
}
