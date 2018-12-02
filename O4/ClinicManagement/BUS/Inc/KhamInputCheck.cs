using DTO;
using System;
using System.Collections.Generic;
using COM;
using DAO;

namespace BUS.Inc
{
    public class KhamInputCheck
    {
        public string InputCheck(HoSoBenhAnDTO hoSoBenhAnDTO, ref List<string> MessageError)
        {
            MessageError = new List<string>();
            if(CheckEmpty(hoSoBenhAnDTO, ref MessageError) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if(CheckMaxLength(hoSoBenhAnDTO, ref MessageError) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (CheckExits(hoSoBenhAnDTO, ref MessageError) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }

        private string CheckEmpty(HoSoBenhAnDTO hoSo, ref List<string> MessageError)
        {
            if (String.IsNullOrEmpty(hoSo.TrieuChung))
            {
                MessageError.Add("Vui lòng nhập triệu chứng bệnh!");
                return Constant.RES_FAI;
            }
            if (String.IsNullOrEmpty(hoSo.ChuanDoan))
            {
                MessageError.Add("Vui lòng nhập chuẩn đoán bệnh!");
                return Constant.RES_FAI;
            }
            if (String.IsNullOrEmpty(hoSo.MaBacSi))
            {
                MessageError.Add("Vui lòng chọn bác sĩ khám!");
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }

        private string CheckMaxLength(HoSoBenhAnDTO hoSo, ref List<string> MessageError)
        {
            if(hoSo.TrieuChung.Length > 250)
            {
                MessageError.Add("Triệu chứng không quá 250 ký tự!");
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }

        private string CheckExits(HoSoBenhAnDTO hoSo, ref List<string> MessageError)
        {
            using(QLPHONGKHAMEntities db = new QLPHONGKHAMEntities())
            {
                NHANVIEN bacSi = null;
                try
                {
                    bacSi  = db.NHANVIENs.Find(hoSo.MaBacSi);
                }
                catch
                {
                    MessageError.Add("Bác sĩ khám không tồn tại!");
                    return Constant.RES_FAI;
                }
                
                if(bacSi == null)
                {
                    MessageError.Add("Bác sĩ khám không tồn tại!");
                    return Constant.RES_FAI;
                }

                if(bacSi.MaLoaiNV != "LNV0000002")
                {
                    MessageError.Add("Bác sĩ khám không tồn tại!");
                    return Constant.RES_FAI;
                }
            }
            return Constant.RES_SUC;
        }
    }
}
