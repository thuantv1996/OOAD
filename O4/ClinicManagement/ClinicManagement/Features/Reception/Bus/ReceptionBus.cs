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

        //MARK: -Private function
        private string getNguoiTiepNhanByMaNV(string MaNhanVien)
        {
            var listResult = new List<DTO.NhanVienDTO>();
            var result = this.clientBus.GetListNhanVienTiepNhan(out listResult);
            if (result.Equals(COM.Constant.RES_SUC))
                return listResult.Find(nv => nv.MaNV == MaNhanVien).HoTenNV;
            return null;
        }

        private string getLoaiHoSoByMaLoai(string MaLoaiHoSo)
        {
            var listResult = new List<DTO.LoaiHoSoDTO>();
            var result = this.clientBus.GetListLoaiHoSo(out listResult);
            DTO.LoaiHoSoDTO loaiHoSo = null;
            if (result.Equals(COM.Constant.RES_SUC))
                loaiHoSo = listResult.Find(loai => loai.MaLoaiHoSo == MaLoaiHoSo);

            return loaiHoSo != null ? loaiHoSo.TenLoaiHoSo : null;
        }

        
        //=============================================
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

        public void saveBenhNhan(DTO.BenhNhanDTO patient, Action<string, List<string>> completion)
        {
            var listMessageError = new List<string>();
            var checkInputResult = this.clientBus.BenhNhanInputCheck(patient, ref listMessageError);

            if (checkInputResult.Equals(COM.Constant.RES_SUC))
            {
                completion(this.clientBus.UpdateBenhNhan(patient), null);
            }

            completion(checkInputResult, listMessageError);
        }

        public void insertBenhNhan(DTO.BenhNhanDTO patient, Action<string, List<string>> completion)
        {
            var listMessageError = new List<string>();
            var checkInputResult = this.clientBus.BenhNhanInputCheck(patient, ref listMessageError);

            if (checkInputResult.Equals(COM.Constant.RES_SUC))
            {
                var result = this.clientBus.InsertBenhNhan(patient);
                completion(result, null);
            }

            completion(checkInputResult, listMessageError);
        }

        //MARK: - Reception
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
            var result = this.clientBus.GetListRelativeHoSo(MaBenhNhan, out listResult);
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
            var result = this.clientBus.GetListNhanVienTiepNhan(out listResult);
            completion(listResult, result);
        }

        //MARK: - Show Previous Records Table
        public void getListHoSoByBenhNhan(string MaBenhNhan, Action<List<Model.HoSoTruocView>, string> completion)
        {
            var listHoSoView = new List<Model.HoSoTruocView>();
            this.getListMaHoSoTruoc(MaBenhNhan, (listResult, result) =>
            {
                listResult.ForEach(hoso =>
                {
                    listHoSoView.Add(new Model.HoSoTruocView()
                    {
                        MaHoSo = hoso.MaHoSo,
                        LoaiHoSo = this.getLoaiHoSoByMaLoai(hoso.MaLoaiHoSo),
                        NguoiTiepNhan = this.getNguoiTiepNhanByMaNV(hoso.MaNguoiTN),
                        NgayTiepNhan = ClinicManagement.Common.ClinicBus.convertDateToView(hoso.NgayTiepNhan)
                    });
                });

                completion(listHoSoView, result);
            });
        }

        public void searchHoSoTruoc(string MaBenhNhan, Model.HoSoTruocView hoso, Action<List<Model.HoSoTruocView>, string> completion)
        {
            var listHoSoView = new List<Model.HoSoTruocView>();
            this.getListHoSoByBenhNhan(MaBenhNhan, (listResult, result) =>
            {
                listResult.ForEach(hs =>
                {
                    if (hs.MaHoSo.Contains(hoso.MaHoSo)
                    && hs.LoaiHoSo.Contains(hoso.LoaiHoSo)
                    && hs.NguoiTiepNhan.Contains(hoso.NguoiTiepNhan)) {
                        listHoSoView.Add(hs);
                    }
                });

                completion(listHoSoView, result);
            });
        }


        public void confirmReception(DTO.HoSoBenhAnDTO hoso, DTO.ThanhToanDTO thanhToan, Action<int, string, List<string>> completion)
        {
            var listMessageError = new List<string>();
            var tiepNhanEntity = new BUS.Inc.TiepNhanInputCheck.TiepNhanEntity()
            {
                MaHoSoTruoc = hoso.MaHoSoTruoc,
                MaLoaiHoSo = hoso.MaLoaiHoSo,
                NgayTiepNhan = hoso.NgayTiepNhan,
                MaNguoiTN = hoso.MaNguoiTN,
                MaPhongKham = hoso.MaPhongKham,
                ChiPhiKham = thanhToan.ChiPhiKham,
                YeuCauKham = hoso.YeuCauKham
            };
            var checkInputResult = this.clientBus.TiepNhanInputCheck(tiepNhanEntity, ref listMessageError);

            if (checkInputResult.Equals(COM.Constant.RES_SUC))
            {
                var result = this.clientBus.SaveHoSo(hoso, thanhToan);
                completion(hoso.SoThuTu, result, null);
            }
            completion(0, checkInputResult, listMessageError);
           
        }
        //=============================================

        static protected ReceptionBus sharedInstance;

        private BUS.Mdl.TiepNhanModule clientBus = new BUS.Mdl.TiepNhanModule();
    }
}
