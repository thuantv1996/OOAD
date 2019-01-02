using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Features.Payment.Bus
{
    class PaymentBus
    {
        private BUS.Mdl.ThanhToanModule clientBus = new BUS.Mdl.ThanhToanModule();

        public DTO.BenhNhanDTO getBenhNhan(string MaBenhNhan)
        {
            var patient = new DTO.BenhNhanDTO();
            //var result = this.clientBus.GetInformationBenhNhan(MaBenhNhan, out patient);
            var result = COM.Constant.RES_SUC;
            if (result.Equals(COM.Constant.RES_SUC))
                return patient;
            else
                return null;
        }

        public void getListHoSo(Action<List<Model.HoSoBenhAnView>, string> completion)
        {
            var listHoSoDTO = new List<DTO.HoSoBenhAnDTO>();
            var listResult = new List<Model.HoSoBenhAnView>();

            var result = this.clientBus.GetListHoSo(out listHoSoDTO);

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
                    listResult.Add(hosoView);
                }
            });
            completion(listResult, result);
        }

        public void getListXetNghiemByHoSo(string MaHoSo, Action<List<DTO.KetQuaXetNghiemDTO>, string> completion)
        {

        }

        public void getKetQuaXetNghiemInformation(string MaXetNghiem, Action<DTO.XetNghiemDTO, string> completion)
        {

        }

        public void thanhToanProcessing(List<DTO.KetQuaXetNghiemDTO> danhSachKQXN, Action<string> completion)
        {

        }

        public void getThanhToan(string MaThanhToan, Action<DTO.ThanhToanDTO, string> completion)
        {

        }
    }
}
