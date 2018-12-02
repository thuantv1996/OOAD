using System;
using System.Collections.Generic;
using BUS.Com;
using System.Globalization;
using DTO;
using COM;

namespace BUS.Inc
{
    partial class BenhNhanInputCheck
    {
        public string CheckInput(BenhNhanDTO BenhNhan, ref List<string> MessageError)
        {
            MessageError = new List<string>();
            if(CheckEmpty(BenhNhan, ref MessageError) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (CheckDataType(BenhNhan, ref MessageError) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            if (CheckMaxLength(BenhNhan, ref MessageError) == Constant.RES_FAI)
            {
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }
        private string CheckEmpty(BenhNhanDTO BenhNhan, ref List<string> MessageError)
        {
            if (String.IsNullOrEmpty(BenhNhan.HoTen))
            {
                MessageError.Add("Vui lòng nhập tên bệnh nhân!");
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }
        private string CheckDataType(BenhNhanDTO BenhNhan, ref List<string> MessageError)
        {
            foreach(char index in BenhNhan.CMND)
            {
                if(index < '0' || index > '9')
                {
                    MessageError.Add("Số CMND phải là số!");
                    return Constant.RES_FAI;
                }
            }

            try
            {
                DateTime ngaySinh = new DateTime(Int32.Parse(BenhNhan.NgaySinh.Substring(0, 4)),
                                                 Int32.Parse(BenhNhan.NgaySinh.Substring(4, 2)),
                                                 Int32.Parse(BenhNhan.NgaySinh.Substring(6, 2))
                                                );
            }catch(Exception e)
            {
                MessageError.Add("Ngày sinh không hợp lệ");
                return Constant.RES_FAI;
            }

            foreach (char index in BenhNhan.SoDienThoai)
            {
                if (index < '0' || index > '9')
                {
                    MessageError.Add("Số điện thoại phải là số!");
                    return Constant.RES_FAI;
                }
            }

            return Constant.RES_SUC;
        }
        private string CheckMaxLength(BenhNhanDTO BenhNhan, ref List<string> MessageError)
        {
            if(BenhNhan.HoTen.Length > 50)
            {
                MessageError.Add("Họ tên bệnh nhân không quá 50 ký tự!");
                return Constant.RES_FAI;
            }

            if (BenhNhan.CMND.Length != 9 && BenhNhan.CMND.Length != 12)
            {
                MessageError.Add("Số CMND không hợp lệ!");
                return Constant.RES_FAI;
            }

            if (BenhNhan.NgaySinh.Length != 8)
            {
                MessageError.Add("Ngày sinh không hợp lệ!");
                return Constant.RES_FAI;
            }

            if (BenhNhan.SoDienThoai.Length > 11)
            {
                MessageError.Add("Số điện thoại không hợp lệ!");
                return Constant.RES_FAI;
            }

            if (BenhNhan.DiaChi.Length > 250)
            {
                MessageError.Add("Địa chỉ dài không quá 250 ký tự!");
                return Constant.RES_FAI;
            }

            if (BenhNhan.GhiChu.Length > 250)
            {
                MessageError.Add("Ghi chú dài không quá 250 ký tự!");
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }
    }
}
