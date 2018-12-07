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

        public void getListHoSo(string MaPhong, Action<List<Model.HoSoBenhAnView>, string> completion)
        {
            Task.Run(() =>
            {
                var listResult = new List<DTO.HoSoBenhAnDTO>();
                var result = this.clientBus.GetListHoSoKhamByPhong(MaPhong, out listResult);
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

        public void searchHoSo(string MaPhong, DTO.BenhNhanDTO patient, Action<List<Model.HoSoBenhAnView>, string> completion)
        {
            var listResult = new List<Model.HoSoBenhAnView>();
            var MaBenhNhan = patient.MaBenhNhan;
            var HoTen = patient.HoTen;
            var CMND = patient.CMND;

            this.getListHoSo(MaPhong, (listHoSo, result) =>
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


    }
}
