using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Features.Analysis.Bus
{
    partial class AnalysisBus
    {
        private static AnalysisBus _instance;
        private Common.User sharedUser = Common.User.SharedInstance;
        private BUS.Mdl.XetNghiemModule clientBus = new BUS.Mdl.XetNghiemModule();

        public static AnalysisBus SharedInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AnalysisBus();
                }
                return _instance;
            }
        }

        public void getListHoSoXetNghiem(Action<List<Model.HoSoBenhAnView>, string> completion)
        {
            var listHoSoDTO = new List<DTO.HoSoBenhAnDTO>();
            var listHoSoView = new List<Model.HoSoBenhAnView>();
            var result = this.clientBus.GetListHoSoKhamByPhong(this.sharedUser.RoomId, out listHoSoDTO);
            listHoSoDTO.ForEach(hoso =>
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

            completion(listHoSoView, result);
        }

        public void getListNhanVien(Action<List<DTO.NhanVienDTO>, string> completion)
        {
            var maPhong = this.sharedUser.RoomId;
            var listNhanVien = new List<DTO.NhanVienDTO>();
            var result = this.clientBus.GetListNhanVien(maPhong, out listNhanVien);
            completion(listNhanVien, result);
        }

        public void checkInput(DTO.KetQuaXetNghiemDTO ketQuaXetNghiem, Action<List<string>, string> completion)
        {
            var listMessageError = new List<string>();
            var result = this.clientBus.CheckInput(ketQuaXetNghiem, ref listMessageError);
            completion(listMessageError, result);
        }

        public DTO.HoSoBenhAnDTO getHoSoBenhAnDTO(string maHoSo)
        {
            var listHoSo = new List<DTO.HoSoBenhAnDTO>();
            this.clientBus.GetListHoSoKhamByPhong(this.sharedUser.RoomId, out listHoSo);
            return listHoSo.Find(hs => hs.MaHoSo.Equals(maHoSo));
        }

        public DTO.BenhNhanDTO getBenhNhan(string maBenhNhan)
        {
            var patient = new DTO.BenhNhanDTO();
            //var result = this.clientBus.GetInformationBenhNhan(MaBenhNhan, out patient);
            var result = COM.Constant.RES_SUC;
            if (result.Equals(COM.Constant.RES_SUC))
                return patient;
            else
                return null;
        }

        public void xetNghiemProcessing(DTO.KetQuaXetNghiemDTO kqxn, Action<string> completion)
        {
            var result = this.clientBus.XetNghiemProcessing(kqxn);
            completion(result);
        }
    }

}
