using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Features.Examination.Bus
{
    class ExaminationBus
    {
        private BUS.Mdl.KhamModule clientBus = new BUS.Mdl.KhamModule();
        private BUS.Mdl.XetNghiemModule xetNghiemBus = new BUS.Mdl.XetNghiemModule();

        private Common.User user = Common.User.SharedInstance;

        static private ExaminationBus sharedInstance;
        static public ExaminationBus SharedInstance
        {
            get
            {
                if (sharedInstance == null)
                    sharedInstance = new ExaminationBus();
                return sharedInstance;
            }
        }
        //MARK: - Public function

        public DTO.BenhNhanDTO getBenhNhan(string MaBenhNhan)
        {
            var patient = new DTO.BenhNhanDTO();
            var result = this.clientBus.GetInformationBenhNhan(MaBenhNhan, out patient);
            if (result.Equals(COM.Constant.RES_SUC))
                return patient;
            else
                return null;
        }

        public void getListHoSo(Action<List<Model.HoSoBenhAnView>, string> completion)
        {
            Task.Run(() =>
            {
                var listResult = new List<DTO.HoSoBenhAnDTO>();
                var result = this.clientBus.GetListHoSoKhamByPhong(user.RoomId, out listResult);
                var listHoSoView = new List<Model.HoSoBenhAnView>();
                
                //Convert from List of HoSoBenhAnDTO to HoSoBenhAnView
                listResult.ForEach(hoso =>
                {
                    var patient = this.getBenhNhan(hoso.MaBenhNhan);
                    if (patient != null)
                    {
                        var hosoView = new Model.HoSoBenhAnView()
                        {
                            MaHoSo = hoso.MaHoSo,
                            MaBenhNhan = patient.MaBenhNhan,
                            SoThuTu = hoso.SoThuTu,
                            HoTen = patient.HoTen,
                            CMND = patient.CMND,
                            SoDienThoai = patient.SoDienThoai
                        };
                        listHoSoView.Add(hosoView);
                    }
                });
                listHoSoView.Sort((x, y) => x.SoThuTu < y.SoThuTu ? 1 : 0);
                completion(listHoSoView, result);
            });
        }

        public void getListHoSoSauXetNghiem(Action<List<Model.HoSoBenhAnView>, string> completion)
        {
            Task.Run(() =>
            {
                var listResult = new List<DTO.HoSoBenhAnDTO>();
                var result = this.clientBus.GetListHoSoXetNgiemByPhong(user.RoomId, out listResult);
                var listHoSoView = new List<Model.HoSoBenhAnView>();

                //Convert from List of HoSoBenhAnDTO to HoSoBenhAnView
                listResult.ForEach(hoso =>
                {
                    var patient = this.getBenhNhan(hoso.MaBenhNhan);
                    if (patient != null)
                    {
                        var hosoView = new Model.HoSoBenhAnView()
                        {
                            MaHoSo = hoso.MaHoSo,
                            MaBenhNhan = patient.MaBenhNhan,
                            SoThuTu = hoso.SoThuTu,
                            HoTen = patient.HoTen,
                            CMND = patient.CMND,
                            SoDienThoai = patient.SoDienThoai
                        };
                        listHoSoView.Add(hosoView);
                    }
                });
                listHoSoView.Sort((x, y) => x.SoThuTu < y.SoThuTu ? 1 : 0);
                completion(listHoSoView, result);
            });
        }

        public void searchHoSo(DTO.BenhNhanDTO patient, Action<List<Model.HoSoBenhAnView>, string> completion)
        {
            var listResult = new List<Model.HoSoBenhAnView>();
            var MaBenhNhan = patient.MaBenhNhan;
            var HoTen = patient.HoTen;
            var CMND = patient.CMND;

            this.getListHoSo((listHoSo, result) =>
            {
                listHoSo.ForEach(hoso =>
                {
                    if (hoso.MaBenhNhan.Contains(MaBenhNhan) && hoso.HoTen.Contains(HoTen) && hoso.CMND.Contains(CMND))
                        listResult.Add(hoso);
                });

                completion(listHoSo, result);
            });
        }

        public void getListKetQuaXetNghiem(string MaHoSo, Action<List<Model.KetQuaXetNghiemView>, string> completion)
        {
            var listResult = new List<Model.KetQuaXetNghiemView>();

            listResult.Add(new Model.KetQuaXetNghiemView()
            {
                MaXetNghiem = "XN00000001",
                MaBacSi = "BS00000001",
                TenXetNghiem = "Xet nghiem mau",
                TenBacSi = "Nguyen Van A",
                NgayXetNghiem = Common.ClinicBus.convertDateToView("20181203"),
                KetQua = "Het mau Het mau Het mau Het mau Het mau \nHet mau Het mau Het mau Het mau Het mau Het mau Het mau Het \nmau Het mau Het mau Het mau Het mau Het mau Het mau Het mau Het mau Het mau Het mau"
            });

            var result = COM.Constant.RES_SUC;
            completion(listResult, result);
        }

        //MARK: - Xét nghiệm
        public void getListXetNghiem(Action<string, List<DTO.XetNghiemDTO>> completion)
        {
            var listResult = new List<DTO.XetNghiemDTO>();
            var result = this.clientBus.GetListXetNghiem(out listResult);
            completion(result, listResult);
        }

        public DTO.XetNghiemDTO getXetNghiem(string MaXetNghiem)
        {
            DTO.XetNghiemDTO xetNghiem = null;
            this.getListXetNghiem((result, listResult) =>
            {
                xetNghiem = listResult.Find(xn => xn.MaXetNghiem.Equals(MaXetNghiem));
            });

            return xetNghiem;
        }

        public void getListThuoc(Action<string, List<DTO.ThuocDTO>> completion)
        {
            var listResult = new List<DTO.ThuocDTO>();
            var result = this.clientBus.GetListThuoc(out listResult);
            completion(result, listResult);
        }

        //MARK: - Save data
        public void saveDonThuoc(DTO.DonThuocDTO donThuoc, List<DTO.ChiTietDonThuocDTO> danhSachThuoc, Action<string> completion)
        {
            completion(this.clientBus.SaveDonthuoc(donThuoc, danhSachThuoc));
        }

        public DTO.ThuocDTO getThuoc(string MaThuoc)
        {
            DTO.ThuocDTO thuoc = null;
            this.getListThuoc((result, listResult) =>
            {
                thuoc = listResult.Find(t => t.MaThuoc.Equals(MaThuoc));
            });
            return thuoc;
        }

        public DTO.PhongKhamDTO getPhong(string maPhong)
        {
            var phong = new DTO.PhongKhamDTO();
            this.clientBus.GetInformationPhong(maPhong, out phong);
            return phong;
        }

        public DTO.HoSoBenhAnDTO getHoSoKham(string MaHS)
        {
            DTO.HoSoBenhAnDTO hoso = null;
            this.clientBus.GetInformationHoSo(MaHS, out hoso);
            return hoso;
        }

        public void confirmExaminationWithoutAssignTests(DTO.HoSoBenhAnDTO hoso, List<DTO.ChiTietDonThuocDTO> danhSachThuoc, Action<string> completion)
        {
            var result = COM.Constant.RES_SUC;
            completion(result);
        }

        public DTO.HoSoBenhAnDTO getLatestHoSo(string MaBN)
        {
            var listHoSo = new List<DTO.HoSoBenhAnDTO>();
            var result = this.clientBus.GetListHoSoByBenhNhan(MaBN, out listHoSo);
            return listHoSo.First();
        }

        public void getInformationToShowLatestRecord(DTO.HoSoBenhAnDTO hoso, Action<string, string, string, List<Model.ThuocView>, string> completion)
        {
            var ngayTiepNhan = Common.ClinicBus.convertDateToView(hoso.NgayKham);
            var listNhanVien = new List<DTO.NhanVienDTO>();
            this.clientBus.GetListNhanVien(Common.User.SharedInstance.RoomId, out listNhanVien);

            var bacSi = listNhanVien.Find(nv => nv.MaNV.Equals(hoso.MaBacSi));
            if (bacSi == null)
            {
                completion("", "", "", null, COM.Constant.RES_FAI);
                return;
            }

            var chuanDoan = hoso.ChuanDoan;

            var donThuoc = new DTO.DonThuocDTO();
            var chiTietDonThuoc = new List<DTO.ChiTietDonThuocDTO>();
            var rs = this.clientBus.GetDonThuoc(hoso.MaHoSo, out donThuoc, out chiTietDonThuoc);

            if (rs.Equals(COM.Constant.RES_FAI))
            {
                completion("", "", "", null, COM.Constant.RES_FAI);
                return;
            }

            var listThuoc = new List<Model.ThuocView>();
            chiTietDonThuoc.ForEach(ctThuoc =>
            {
                var thuoc = this.getThuoc(ctThuoc.MaThuoc);

                if (thuoc != null)
                {
                    listThuoc.Add(new Model.ThuocView()
                    {
                        MaThuoc = ctThuoc.MaThuoc,
                        TenThuoc = thuoc.TenThuoc,
                        GhiChu = donThuoc.GhiChu,
                        SoLuong = ctThuoc.SoLuong
                    });
                }
            });

            completion(ngayTiepNhan, bacSi.HoTenNV, chuanDoan, listThuoc, COM.Constant.RES_SUC);
        }

        public void assignTests(List<DTO.KetQuaXetNghiemDTO> danhSachXN, Action<string> completion)
        {
            var result = this.xetNghiemBus.AssignXetNghiem(danhSachXN);
            completion(result);
        }

        public void khamProcessing(DTO.HoSoBenhAnDTO hoso, DTO.DonThuocDTO donThuoc, List<DTO.ChiTietDonThuocDTO> danhSachChiTietThuoc, Action<string> completion)
        {
            var processingResult = this.clientBus.KhamProcessing(hoso);
            if (processingResult.Equals(COM.Constant.RES_FAI))
            {
                completion(processingResult);
                return;
            }
            var resultSaveThuoc = this.clientBus.SaveDonthuoc(donThuoc, danhSachChiTietThuoc);
            completion(resultSaveThuoc);
        }
    }
}
