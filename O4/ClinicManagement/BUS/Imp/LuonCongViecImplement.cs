using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.Entities;
using BUS.Service;
using DTO;
using DAO;
using COM;
using BUS.Com;
using DAO.Imp;

namespace BUS.Imp
{
    class LuonCongViecImplement : ILuonCongViecService
    {
        public string AddLuonCongViec(QLPHONGKHAMEntities db, LuonCongViecEnity LuonCongViec, ref List<MessageError> Messages)
        {
            string ProgramName = "LuonCongViecImplement-AddLuonCongViec";
            string IdResult;
            // Tạo đối tượng LUONCONGVIEC kết quả
            LUONCONGVIEC LuonCongViecDAO = new LUONCONGVIEC();

            // Convert đối tượng từ DTO sang DAO
            BUS.Com.Utils.CopyPropertiesFrom(LuonCongViec, LuonCongViecDAO);

            // Khởi tạo lớp DAO
            DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();

            // Thực hiện lệnh INSERT
            IdResult = Dao.Insert(LuonCongViecDAO, db, ref Messages);

            // Nếu hàm INSERT báo lỗi
            if (IdResult == Constant.RES_FAI)
            {
                // Thêm thông báo lỗi
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = string.Format("Lỗi khi Insert vao Table LUONCONGVIEC - {0}", ProgramName)
                });
                // Return faild
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }

        public string GetInformationLuonCongViec(string MaHoSo, out LuonCongViecEnity LuonCongViecEntity, ref List<MessageError> Messages)
        {
            string ProgramName = "LuonCongViecImplement-GetInformationLuonCongViec";
            LuonCongViecEntity = new LuonCongViecEnity();
            List<LUONCONGVIEC> ListLuonCongViecDAO = null;
            string IdResult;
            using (var db = new QLPHONGKHAMEntities())
            {
                BaseDAO dao = new BaseDAO();
                IdResult = dao.Select(db, lcv => lcv.MaHoSo == MaHoSo, out ListLuonCongViecDAO, ref Messages);
            }
            // trường hợp select fail
            if (IdResult.Equals(Constant.RES_FAI))
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi xãy ra khi select dữ liệu từ Table LUONCONGVIEC - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            // trường hợp data rỗng
            if (ListLuonCongViecDAO.Count == 0)
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi empty dữ liệu từ Table LUONCONGVIEC - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            // trường hợp data trả về nhiều hơn 1 record
            if (ListLuonCongViecDAO.Count > 1)
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi select trên key nhiều hơn 1 record dữ liệu từ Table LUONCONGVIEC - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            // copy property
            Utils.CopyPropertiesFrom(ListLuonCongViecDAO.ElementAt(0), LuonCongViecEntity);
            // return success
            return Constant.RES_SUC;
        }

        public string UpdateLuonCongViec(QLPHONGKHAMEntities db, LuonCongViecEnity LuonCongViec, ref List<MessageError> Messages)
        {
            string ProgramName = "LuonCongViecImplement-UpdateLuonCongViec";
            string IdResult;

            // Tạo đối tượng LUONCONGVIEC kết quả
            LUONCONGVIEC LuonCongViecDAO = new LUONCONGVIEC();

            // Convert đối tượng từ DTO sang DAO
            BUS.Com.Utils.CopyPropertiesFrom(LuonCongViec, LuonCongViecDAO);

            // Khởi tạo lớp DAO
            DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();

            // Thực hiện lệnh Update
            IdResult = Dao.Update(LuonCongViecDAO, db, ref Messages);

            // Nếu hàm Update báo lỗi
            if (IdResult == Constant.RES_FAI)
            {
                // Thêm thông báo lỗi
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = string.Format("Lỗi khi Update vao Table LUONCONGVIEC - {0}", ProgramName)
                });
                // Return faild
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }
    }
}

