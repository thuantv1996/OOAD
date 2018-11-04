using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using COM;
using BUS.Imp;
using BUS.Enities;

namespace BUS.Mdl
{
    class ReceptionModule
    {/*
        public string GetListBenhNhan(out List<BenhNhanEnity> ListBenhNhan, ref List<MessageError> Messages)
        {
            BenhNhanImplement benhNhanImplement = new BenhNhanImplement();
            benhNhanImplement.GetListBenhNhan(out ListBenhNhan, ref Messages);
            return Constant.RES_SUC;
        }

        public string SearchBenhNhan(BenhNhanEnity BenhNhan, out List<BenhNhanEnity> ListBenhNhan, ref List<MessageError> Messages)
        {
            BenhNhanImplement benhNhanImplement = new BenhNhanImplement();
            BenhNhanSearchEntity benhNhanSearchEntity = new BenhNhanSearchEntity
            {
                MaBenhNhan = BenhNhan.MaBenhNhan,
                TenBenhNhan = BenhNhan.HoTen,
                CMND = BenhNhan.CMND
            };
            if (benhNhanImplement.SearchBenhNhan(benhNhanSearchEntity, out ListBenhNhan, ref Messages).Equals(Constant.RES_FAI))
            {
                MessageError Mes = new MessageError { IdError = Constant.MES_PRE, Message = "Không tìm thấy bệnh nhân!" };
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }

        public string GetInformationBenhNhan(string MaBenhNhan, out BenhNhanEnity BenhNhan, ref List<MessageError> Messages)
        {
            BenhNhanImplement benhNhanImplement = new BenhNhanImplement();
            if (benhNhanImplement.GetInformationBenhNhan(MaBenhNhan, out BenhNhan, ref Messages).Equals(Constant.RES_FAI))
            {
                MessageError Mes = new MessageError { IdError = Constant.MES_PRE, Message = "Một lỗi bất ngờ đã xãy ra vui lòng thao tác lại!" };
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }

        public string GetListPhongKham()
        {

        }
        public string GetInformationPhongKham()
        {

        }

        public int GetSoThuTu()
        {
            // get stt
        }

        public string SaveHoSo()
        {
            // check input
            // save ho so
        }
    */}
}
