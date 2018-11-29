using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Features.Reception.Bus
{
    public class ReceptionBus: Common.ClinicBus
    {
        static public ReceptionBus SharedInstance
        {
            get
            {
                if (sharedInstance == null)
                    sharedInstance = new ReceptionBus();
                return sharedInstance;
            }
        }
        protected ReceptionBus(){}

        public void fetchListBenhNhan(Action<List<DTO.BenhNhanDTO>, string> completion)
        {
            Task.Run(() =>
            {
                var listResult = new List<DTO.BenhNhanDTO>();
                var result = this.clientBus.GetListBenhNhan(out listResult);
                completion(listResult, result);
            });
        }

        public void searchBenhNhan(DTO.BenhNhanDTO benhNhanEntity, Action<List<DTO.BenhNhanDTO>, string> completion)
        {
            var listResult = new List<DTO.BenhNhanDTO>();
            var result = this.clientBus.SearchBenhNhan(benhNhanEntity, out listResult, 0);
            completion(listResult, result);
        }

        public void saveBenhNhan(DTO.BenhNhanDTO patient, Action<string> completion)
        {
            completion(COM.Constant.RES_FAI);
        }

        public void insertBenhNhan(DTO.BenhNhanDTO patient, Action<List<COM.MessageError>, string> completion)
        {
            Task.Run(() =>
            {
                var listMessageError = new List<COM.MessageError>();
                //var result = this.benhNhanBus.InsertBenhNhan()
                //completion(listMessageError, result);
            });
        }

        public void getListLoaiHoSo(Action<List<DTO.LoaiHoSoDTO>, string> completion)
        {
            var listResult = new List<DTO.LoaiHoSoDTO>();
            var result = this.clientBus.GetListLoaiHoSo(out listResult);
            completion(listResult, result);
        }

        public void getListMaHoSoTruoc(string MaBenhNhan, Action<List<DTO.HoSoBenhAnDTO>, string> completion)
        {
            var listResult = new List<DTO.HoSoBenhAnDTO>();
            var listMessageError = new List<COM.MessageError>();
            var result = this.clientBus.GetListRelativeHoSo(MaBenhNhan, out listResult, ref listMessageError);
            completion(listResult, result);
        }

        public void getListPhong(Action<List<DTO.PhongKhamDTO>, string> completion)
        {
            var listResult = new List<DTO.PhongKhamDTO>();
            var result = this.clientBus.GetListPhongKham(out listResult);
            completion(listResult, result);
        }

        public void getListNhanVien(Action<List<DTO.NhanVienDTO>, string> completion)
        {
            var listResult = new List<DTO.NhanVienDTO>();
            //var result = this.clientBus(out listResult);
            completion(listResult, "");
        }

        static protected ReceptionBus sharedInstance;

        private BUS.Mdl.TiepNhanModule clientBus = new BUS.Mdl.TiepNhanModule();
    }
}
