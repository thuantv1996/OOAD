using BUS.Imp;
using COM;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using BUS.Com;

namespace BUS.Mdl
{
    public class ThanhToanModule
    {
        // Lấy danh sách hồ sơ bệnh án hiện tại
        public string GetListHoSo(out List<HoSoBenhAnDTO> hoSoBenhAnDTOs)
        {
            hoSoBenhAnDTOs = new List<HoSoBenhAnDTO>();
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                hoSoBenhAnBUS.GetListHoSo(db, out hoSoBenhAnDTOs);
            }
            return Constant.RES_SUC;
        }

        // lấy danh sách hồ sơ của một bệnh nhân
        public string GetListHoSo(string MaBenhNhan, out List<HoSoBenhAnDTO> hoSoBenhAnDTOs)
        {
            hoSoBenhAnDTOs = new List<HoSoBenhAnDTO>();
            HoSoBenhAnBUS hoSoBenhAnBUS = new HoSoBenhAnBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                hoSoBenhAnBUS.GetListHoSoWithIdBenhNhan(db, MaBenhNhan, out hoSoBenhAnDTOs);
            }
            return Constant.RES_SUC;
        }

        // lấy danh sách xét nghiệm của 1 hồ sơ
        public string GetListXetNghiemByHoSo(string MaHoSo, out List<KetQuaXetNghiemDTO> ketQuaXetNghiemDTOs)
        {
            ketQuaXetNghiemDTOs = new List<KetQuaXetNghiemDTO>();
            KetQuaXetNghiemBUS ketQuaXetNghiemBUS = new KetQuaXetNghiemBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                ketQuaXetNghiemBUS.GetKetQuaXetNghiemWithIdHoSo(db, MaHoSo, out ketQuaXetNghiemDTOs);
            }
            return Constant.RES_SUC;
        }

        // lấy thông tin xét nghiệm với mã
        public string GetInformationXetNghiem(string MaXetNghiem, out XetNghiemDTO xetNghiem)
        {
            xetNghiem = new XetNghiemDTO();
            XetNghiemBUS xetNghiemBUS = new XetNghiemBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                xetNghiemBUS.GetInfomationXetNghiem(db, MaXetNghiem, out xetNghiem);
            }
            return Constant.RES_SUC;
        }

        // xử lý thanh toán
        public string ThanhToanProcessing(List<KetQuaXetNghiemDTO> ketQuaXetNghiems)
        {

            if(ketQuaXetNghiems == null || ketQuaXetNghiems.Count == 0)
            {
                return Constant.RES_FAI;
            }
            KetQuaXetNghiemBUS ketQuaXetNghiemBUS = new KetQuaXetNghiemBUS();
            ThanhToanBUS thanhToanBUS = new ThanhToanBUS();
            LuonCongViecBUS luonCongViecBUS = new LuonCongViecBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                ThanhToanDTO thanhToan = new ThanhToanDTO();
                if (thanhToanBUS.GetThanhToan(db, ketQuaXetNghiems.ElementAt(0).MaHoSo, out thanhToan) == Constant.RES_FAI)
                {
                    return Constant.RES_FAI;
                }
                if (thanhToan == null)
                {
                    return Constant.RES_FAI;
                }
                decimal tongtien = 0;
                foreach (var kq in ketQuaXetNghiems)
                {
                    tongtien += kq.TongChiPhi;
                }
                thanhToan.TongChiPhi += tongtien;
                thanhToan.ChiPhiXetNghiem = tongtien;

                LuonCongViecDTO luonCongViec = new LuonCongViecDTO();
                if(luonCongViecBUS.GetInformationLuonCongViec(db, thanhToan.MaHoSo, out luonCongViec) == Constant.RES_FAI)
                {
                    return Constant.RES_FAI;
                }
                
                luonCongViec.NodeHienTai = BusConstant.NODE_XET_NGHIEM;
                using (var trans = db.Database.BeginTransaction())
                {
                    foreach(var kq in ketQuaXetNghiems)
                    {
                        // yeu cau PRESENT phai update doi tuong
                        if (ketQuaXetNghiemBUS.UpdateKetQuaXetNghiem(db, kq).Equals(Constant.RES_FAI))
                        {
                            trans.Rollback();
                            return Constant.RES_FAI;
                        }
                    }
                    if (thanhToanBUS.UpdateThanhToan(db, thanhToan).Equals(Constant.RES_FAI))
                    {
                        trans.Rollback();
                        return Constant.RES_FAI;
                    }
                    if (luonCongViecBUS.UpdateLuonCongViec(db, luonCongViec).Equals(Constant.RES_FAI))
                    {
                        trans.Rollback();
                        return Constant.RES_FAI;
                    }
                }
            }
            return Constant.RES_SUC;
        }

        public string GetThanhToan(string MaHoSo, out ThanhToanDTO thanhToan)
        {
            string result;
            ThanhToanBUS thanhToanBUS= new ThanhToanBUS();
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                result = thanhToanBUS.GetThanhToan(db, MaHoSo, out thanhToan);
            }
            return result;
        }
    }
}
