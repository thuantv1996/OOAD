using COM;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Inc
{
    public class XetNghiemInputCheck
    {
        public string InputCheck(KetQuaXetNghiemDTO ketQuaXetNghiemDTO, ref List<string> MessageError)
        {
            MessageError = new List<string>();
            if(CheckEmpty(ketQuaXetNghiemDTO, ref MessageError) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (CheckExits(ketQuaXetNghiemDTO, ref MessageError) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }

        private string CheckEmpty(KetQuaXetNghiemDTO ketQuaXetNghiemDTO, ref List<string> MessageError)
        {
            if (String.IsNullOrEmpty(ketQuaXetNghiemDTO.MaBacSi))
            {
                MessageError.Add("Vui lòng chọn bác sĩ!");
                return Constant.RES_FAI;
            }
            if (String.IsNullOrEmpty(ketQuaXetNghiemDTO.KetQua))
            {
                MessageError.Add("Vui lòng nhập kết quả!");
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }

        private string CheckExits(KetQuaXetNghiemDTO ketQuaXetNghiemDTO, ref List<string> MessageError)
        {
            using (QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                NHANVIEN bacSi = null;
                try
                {
                    bacSi = db.NHANVIENs.Find(ketQuaXetNghiemDTO.MaBacSi);
                }
                catch
                {
                    MessageError.Add("Bác sĩ xét nghiệm không tồn tại!");
                    return Constant.RES_FAI;
                }

                if (bacSi == null)
                {
                    MessageError.Add("Bác sĩ xét nghiệm không tồn tại!");
                    return Constant.RES_FAI;
                }

                if (bacSi.MaLoaiNV != COM.Constant.ID_LNV_XN)
                {
                    MessageError.Add("Bác sĩ xét nghiệm không tồn tại!");
                    return Constant.RES_FAI;
                }
            }
            return Constant.RES_SUC;
        }
    }
}
