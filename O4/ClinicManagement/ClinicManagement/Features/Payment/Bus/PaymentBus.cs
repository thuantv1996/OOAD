using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Features.Payment.Bus
{
    class PaymentBus
    {
        private static PaymentBus _instance;
        public static PaymentBus SharedInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PaymentBus();
                }
                return _instance;
            }
        }
        private BUS.Mdl.ThanhToanModule clientBus = new BUS.Mdl.ThanhToanModule();

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
            var listKQXN = new List<DTO.KetQuaXetNghiemDTO>();
            var result = this.clientBus.GetListXetNghiemByHoSo(MaHoSo, out listKQXN);
            completion(listKQXN, result);
        }
    
        public DTO.XetNghiemDTO getXetNghiemInformation(string maXetNghiem)
        {
            var xetNghiem = new DTO.XetNghiemDTO();
            this.clientBus.GetInformationXetNghiem(maXetNghiem, out xetNghiem);
            return xetNghiem;
        }

        public void thanhToanProcessing(List<DTO.KetQuaXetNghiemDTO> danhSachKQXN, Action<string> completion)
        {
            danhSachKQXN.ForEach(kqxn => kqxn.ThanhToan = true);
            var result = this.clientBus.ThanhToanProcessing(danhSachKQXN);
            completion(result);
        }

        public void getThanhToan(string MaThanhToan, Action<DTO.ThanhToanDTO, string> completion)
        {

        }

        public DTO.HoSoBenhAnDTO getHoSoBenhAnDTO(string maHoSo)
        {
            var listHoSo = new List<DTO.HoSoBenhAnDTO>();
            this.clientBus.GetListHoSo(out listHoSo);

            return listHoSo.Find(hs => hs.MaHoSo.Equals(maHoSo));
        }

        public DTO.KetQuaXetNghiemDTO getKetQuaXetNghiem(string maHoSo, string maXetNghiem)
        {
            var listKQXN = new List<DTO.KetQuaXetNghiemDTO>();
            this.clientBus.GetListXetNghiemByHoSo(maHoSo, out listKQXN);
            return listKQXN.Find(kqxn => kqxn.MaXetNghiem.Equals(maXetNghiem));
        }

        public List<Model.ThanhToanView> convertThanhToanToView(List<DTO.KetQuaXetNghiemDTO> danhSachCanThanhToan)
        {
            var danhSachView = new List<Model.ThanhToanView>();
            danhSachCanThanhToan.ForEach(kqxn =>
            {
                var xetNghiem = this.getXetNghiemInformation(kqxn.MaXetNghiem);
                if (xetNghiem != null)
                {
                    danhSachView.Add(new Model.ThanhToanView()
                    {
                        TenThanhToan = xetNghiem.TenXetNghiem,
                        ChiPhi = kqxn.TongChiPhi.ToString()
                    });
                }
            });
            return danhSachView;
        }
    }
}
