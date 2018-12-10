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
            listResult.Add(new DTO.ThuocDTO()
            {
                MaThuoc = "T000000001",
                TenThuoc = "Paradol",
                ChiDinh = "Uống khi bệnh",
                ChongChiDinh = "Không dùng cho phụ nữ có thai"
            });

            listResult.Add(new DTO.ThuocDTO()
            {
                MaThuoc = "T000000002",
                TenThuoc = "Tiphi",
                ChiDinh = "Uống khi bệnh",
                ChongChiDinh = "Không dùng cho phụ nữ có thai"
            });

            var result = COM.Constant.RES_SUC;
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
            return new DTO.PhongKhamDTO() {
                MaPhong = maPhong,
                TenPhong = "Phong 1"
            };
        }

        public void confirmExaminationWithAssignTests(DTO.HoSoBenhAnDTO hoso, List<DTO.XetNghiemDTO> danhSachXetNghiem, Action<string> completion)
        {
            var result = COM.Constant.RES_SUC;
            completion(result);
        }

        public void confirmExaminationWithoutAssignTests(DTO.HoSoBenhAnDTO hoso, List<DTO.ChiTietDonThuocDTO> danhSachThuoc, Action<string> completion)
        {
            var result = COM.Constant.RES_SUC;
            completion(result);
        }
    }
}
