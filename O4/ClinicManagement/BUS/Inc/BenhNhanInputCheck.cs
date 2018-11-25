using System;
using System.Collections.Generic;
using BUS.Com;
using System.Globalization;
using DTO;

namespace BUS.Inc
{
    class BenhNhanInputCheck
    {
        public string CheckInput(BenhNhanDTO BenhNhan, out List<string> MessageError)
        {
            string ProgramName = "BenhNhanInputCheck_CheckInput";
            MessageError = new List<string>();
            int NumberError = 0;
            if(BenhNhan == null)
            {
                MessageError.Add(String.Format("Dữ liệu bệnh nhân là null - [{0}]",ProgramName));
                return COM.Constant.RES_FAI;
            }
            // Kiểm tra độ dài tên
            if(BenhNhan.HoTen.Length > BusConstant.LENGTH_HOTEN_BENHNHAN)
            {
                MessageError.Add(String.Format("Họ tên bệnh nhân tối đa {0} ký tự - [{1}]", BusConstant.LENGTH_HOTEN_BENHNHAN, ProgramName));
                NumberError++;
            }
            if (BenhNhan.HoTen.Equals(""))
            {
                MessageError.Add(String.Format("Hãy nhập họ tên bệnh nhân {0}", ProgramName));
                NumberError++;
            }

            // Kiểm tra ngày sinh
            try
            {
                DateTime.ParseExact(BenhNhan.NgaySinh, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageError.Add(String.Format("Ngày sinh không hợp lệ - Định dạng ngày sinh dd/MM/yyyy - [{0}]", ProgramName));
                NumberError++;
            }

            // Kiểm tra độ dài CMND
            if (BenhNhan.CMND.Length > BusConstant.LENGTH_CMND_BENHNHAN)
            {
                MessageError.Add(String.Format("Số CMND tối đa {0} ký tự - [{1}]", BusConstant.LENGTH_CMND_BENHNHAN, ProgramName));
                NumberError++;
            }
            // Kiểm tra CMND là số
            try
            {
                if (!BenhNhan.CMND.Equals(""))
                {
                    Int32.Parse(BenhNhan.CMND);
                }
            }
            catch
            {
                MessageError.Add(String.Format("Số chứng minh nhân dân không hợp lệ - [{0}]", ProgramName));
                NumberError++;
            }

            // Kiểm tra độ dài số điện thoại
            if (BenhNhan.SoDienThoai.Length > BusConstant.LENGTH_SODIENTHOAI_BENHNHAN)
            {
                MessageError.Add(String.Format("Số điện thoại tối đa {0} ký tự - [{1}]", BusConstant.LENGTH_SODIENTHOAI_BENHNHAN, ProgramName));
                NumberError++;
            }
            // Kiểm tra số điện thoại là số
            try
            {
                if (!BenhNhan.CMND.Equals(""))
                {
                    Int32.Parse(BenhNhan.CMND);
                }
            }
            catch
            {
                MessageError.Add(String.Format("Số điện thoại không hợp lệ - [{0}]", ProgramName));
                NumberError++;
            }
            // Kiểm tra độ dài địa chỉ
            if (BenhNhan.DiaChi.Length > BusConstant.LENGTH_DIACHI_BENHNHAN)
            {
                MessageError.Add(String.Format("Địa chỉ tối đa {0} ký tự - [{1}]", BusConstant.LENGTH_DIACHI_BENHNHAN, ProgramName));
                NumberError++;
            }
            // Kiểm tra độ dài ghi chú
            if (BenhNhan.GhiChu.Length > BusConstant.LENGTH_GHICHU_BENHNHAN)
            {
                MessageError.Add(String.Format("Ghi chú tối đa {0} ký tự - [{1}]", BusConstant.LENGTH_GHICHU_BENHNHAN, ProgramName));
                NumberError++;
            }

            

            if (NumberError != 0)
            {
                return COM.Constant.RES_FAI;
            } 
            return COM.Constant.RES_SUC;
        }
    }
}
