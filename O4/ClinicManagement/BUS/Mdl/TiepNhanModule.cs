using System;
using System.Collections.Generic;
using COM;
using BUS.Imp;
using BUS.Entities;
using DAO;
using BUS.Com;

namespace BUS.Mdl
{
    public class TiepNhanModule
    {
        /*
        // trường hợp quay về màn hình list
        const int ID_SCREEN_BACK = 0;
        // trường hợp chuyển sang mành hình tạo mới
        const int ID_SCREEN_CREATE = 1;
        // trường hợp chuyển sang mành hình tạo hồ sơ
        const int ID_SCREEN_GO = 1;
        public string GetListBenhNhan(out List<BenhNhanEnity> ListBenhNhan, ref List<MessageError> Messages)
        {
            // Tạo đối tượng BenhNhanImplement  
            BenhNhanImplement benhNhanImplement = new BenhNhanImplement();
            // getListBenhNhan
            benhNhanImplement.GetListBenhNhan(out ListBenhNhan, ref Messages);
            // return
            return Constant.RES_SUC;
        }

        public string SearchBenhNhan(BenhNhanEnity BenhNhan, out List<BenhNhanEnity> ListBenhNhan, 
                                     ref List<MessageError> Messages, int IdScreen)
        {
            // nếu đối tượng search == null
            if(BenhNhan == null)
            {
                // tạo mới đối tượng
                BenhNhan = new BenhNhanEnity();
            }
            // Tạo dối tượng BenhNhanImplement
            BenhNhanImplement benhNhanImplement = new BenhNhanImplement();
            // Tạo Search key object
            BenhNhanSearchEntity benhNhanSearchEntity = new BenhNhanSearchEntity{ MaBenhNhan = BenhNhan.MaBenhNhan,
                                                                                  TenBenhNhan = BenhNhan.HoTen,
                                                                                  CMND = BenhNhan.CMND };
            // Nếu search thất bại
            if (benhNhanImplement.SearchBenhNhan(benhNhanSearchEntity, out ListBenhNhan, ref Messages).Equals(Constant.RES_FAI))
            {
                MessageError Mes = new MessageError { IdError = Constant.MES_PRE,
                                                      Message = "Có lỗi xãy ra trong khi search vui lòng thực hiện lại" };
                IdScreen = ID_SCREEN_BACK;
                return Constant.RES_FAI;
            }
            // nếu kết quả trả về là list rỗng
            if(ListBenhNhan.Count == 0)
            {
                MessageError Mes = new MessageError
                {
                    IdError = Constant.MES_PRE,
                    Message = "Không tìm thấy bệnh nhân"
                };
                IdScreen = ID_SCREEN_CREATE;
                return Constant.RES_FAI;
            }
            // nếu có kết quả trả về
            IdScreen = ID_SCREEN_BACK;
            return Constant.RES_SUC;
        }

        public string GetInformationBenhNhan(string MaBenhNhan, out BenhNhanEnity BenhNhan, ref List<MessageError> Messages)
        {
            // Tạo đối tượng BenhNhanImplement  
            BenhNhanImplement benhNhanImplement = new BenhNhanImplement();
            // nếu get information fail
            if (benhNhanImplement.GetInformationBenhNhan(MaBenhNhan, out BenhNhan, ref Messages).Equals(Constant.RES_FAI))
            {
                MessageError Mes = new MessageError
                { IdError = Constant.MES_PRE,
                  Message = "Một lỗi bất ngờ đã xãy ra vui lòng thực hiện lại!" };
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }

        // HÀM NÀY CHƯA VIẾT
        public string GetListLoaiHoSo()
        {
            return Constant.RES_SUC;
        }

        public string GetListPhongKham(out List<PhongKhamEnity> ListPhongKham, ref List<MessageError> Messages)
        {
            PhongKhamImplement phongKhamImplement = new PhongKhamImplement();
            phongKhamImplement.GetListPhongKham(out ListPhongKham, ref Messages);
            return Constant.RES_SUC;
        }
        
        public string GetInformationPhongKham(string MaPhongKham, out PhongKhamEnity informationPhongKham, ref List<MessageError> Messages)
        {
            PhongKhamImplement phongKhamImplement = new PhongKhamImplement();
            phongKhamImplement.GetInformationPhongKham(MaPhongKham, out informationPhongKham, ref Messages);
            return Constant.RES_SUC;
        }

        public int GetSoThuTu(string MaPhong, ref List<MessageError> Messages)
        {
            // Tạo đối tượng implement
            TrangThaiPhongImplement trangThaiPhongImplement = new TrangThaiPhongImplement();
            // Tạo đối tượng Entity
            TrangThaiPhongEnity trangThaiPhongEnity = null;
            // get System date
            string SystemDate = DateTime.Now.Year.ToString()
                              + DateTime.Now.Month.ToString()
                              + DateTime.Now.Day.ToString();
            // gọi hàm lấy trạng thái phòng
            trangThaiPhongImplement.GetTrangThaiPhong(MaPhong, SystemDate, out trangThaiPhongEnity, ref Messages);
            // Trả về STT
            return trangThaiPhongEnity.SttCaoNhat + 1;
        }

        public string GetMaHoSo(ref List<MessageError> Messages)
        {
            HoSoBenhAnImplement hoSoBenhAnImplement = new HoSoBenhAnImplement();
            string Id = "";
            hoSoBenhAnImplement.CreateIdHoSoBenhAn(out Id, ref Messages);
            return Id;
        }

        public string GetListRelativeHoSo(string MaBenhNhan, out List<HoSoBenhAnEntity> ListRelativeHoSo, ref List<MessageError> Messages)
        {
            HoSoBenhAnImplement hoSoBenhAnImplement = new HoSoBenhAnImplement();
            using(var db = new QLPHONGKHAMEntities())
            {
                if(hoSoBenhAnImplement.GetListHoSoBenhAnWithId(db, MaBenhNhan, out ListRelativeHoSo, ref Messages) == Constant.RES_FAI)
                {
                    return Constant.RES_FAI;
                }
            }
            return Constant.RES_SUC;
        }

        public string SaveHoSo(HoSoBenhAnEntity hoSoBenhAn,
                               ThanhToanEntity thanhToan,
                               TrangThaiPhongEnity trangThaiPhong,
                               ref List<MessageError> Messages)
        {
            // Check input

            // initialize information
            ThanhToanImplement thanhToanImplement = new ThanhToanImplement();
            HoSoBenhAnImplement hoSoBenhAnImplement = new HoSoBenhAnImplement();
            LuonCongViecImplement luonCongViecImplement = new LuonCongViecImplement();
            TrangThaiPhongImplement trangThaiPhongImplement = new TrangThaiPhongImplement();
            // nếu là hồ sơ tái khám
            if (hoSoBenhAn.MaLoaiHoSo == BusConstant.HS_TAIKHAM)
            {
                // get MaHoSoGoc
            }
            // điền thông tin vào thanh toán
            
            string MaThanhToan = "";
            thanhToanImplement.CreateIdThanhToan(out MaThanhToan, ref Messages);
            thanhToan.MaThanhToan = MaThanhToan;
            thanhToan.TongChiPhi = thanhToan.ChiPhiKham;
            // điền thông tin Workflow
            LuonCongViecEnity luonCongViec = new LuonCongViecEnity();
            luonCongViec.MaHoSo = hoSoBenhAn.MaHoSo;
            luonCongViec.NodeHienTai = BusConstant.NODE_KHAM;
            luonCongViec.TiepNhan = true;
            luonCongViec.XetNghiem = false;
            luonCongViec.KhamBenh = false;

            // tạo đối tượng database
            using (var db = new QLPHONGKHAMEntities())
            {
                // Tạo transaction
                using(var trans = db.Database.BeginTransaction())
                {
                    // save hồ sơ
                    if(hoSoBenhAnImplement.AddHoSoBenhAn(db, hoSoBenhAn, ref Messages) == Constant.RES_FAI)
                    {
                        MessageError Mes = new MessageError
                        {
                            IdError = Constant.MES_PRE,
                            Message = "Có lỗi xãy ra trong khi lưu hồ sơ vui lòng thực hiện lại"
                        };
                        trans.Rollback();
                        return Constant.RES_FAI;
                    }
                    // save luồn công việc 
                    if(luonCongViecImplement.AddLuonCongViec(db, luonCongViec, ref Messages) == Constant.RES_FAI)
                    {
                        MessageError Mes = new MessageError
                        {
                            IdError = Constant.MES_PRE,
                            Message = "Có lỗi xãy ra trong khi lưu hồ sơ vui lòng thực hiện lại"
                        };
                        trans.Rollback();
                        return Constant.RES_FAI;
                    }
                    // save thanh toán
                    if(thanhToanImplement.AddThanhToan(db, thanhToan, ref Messages) == Constant.RES_FAI)
                    {
                        MessageError Mes = new MessageError
                        {
                            IdError = Constant.MES_PRE,
                            Message = "Có lỗi xãy ra trong khi lưu hồ sơ vui lòng thực hiện lại"
                        };
                        trans.Rollback();
                        return Constant.RES_FAI;
                    }
                    // update Trang thanh phong
                    if(trangThaiPhongImplement.UpdateTrangThaiPhong(db, trangThaiPhong, ref Messages) == Constant.RES_FAI)
                    {
                        MessageError Mes = new MessageError
                        {
                            IdError = Constant.MES_PRE,
                            Message = "Có lỗi xãy ra trong khi lưu hồ sơ vui lòng thực hiện lại"
                        };
                        trans.Rollback();
                        return Constant.RES_FAI;
                    }
                    
                    trans.Commit();
                    
                }
                db.SaveChanges();
            }
            return Constant.RES_SUC;
        }
        */
    }
}
