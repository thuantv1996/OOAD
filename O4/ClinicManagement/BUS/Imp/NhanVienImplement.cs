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
    class NhanVienImplement : INhanVienService
    {
        public string GetInfomationNhanVien(string MaNhanVien, out NhanVienEnity NhanVienEntity, ref List<MessageError> Messages)
        {
            string ProgramName = "NhanVienImplement-GetInfomationNhanVien";
            NhanVienEntity = new NhanVienEnity();
            List<NHANVIEN> ListNhanVienDAO = null;
            string IdResult;
            using (var db = new QLPHONGKHAMEntities())
            {
                BaseDAO dao = new BaseDAO();
                IdResult = dao.Select(db, nv => nv.MaNV == MaNhanVien, out ListNhanVienDAO, ref Messages);
            }
            // trường hợp select fail
            if (IdResult.Equals(Constant.RES_FAI))
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi xãy ra khi select dữ liệu từ Table NHANVIEN - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            // trường hợp data rỗng
            if (ListNhanVienDAO.Count == 0)
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi empty dữ liệu từ Table NHANVIEN - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            // trường hợp data trả về nhiều hơn 1 record
            if (ListNhanVienDAO.Count > 1)
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi select trên key nhiều hơn 1 record dữ liệu từ Table NHANVIEN - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            // copy property
            Utils.CopyPropertiesFrom(ListNhanVienDAO.ElementAt(0), NhanVienEntity);
            // return success
            return Constant.RES_SUC;
        }

        public string GetListNhanVien(out List<NhanVienEnity> ListNhanVienEntity, ref List<MessageError> Messages)
        {
            string ProgramName = "NhanVienImplement-GetListNhanVien";
            ListNhanVienEntity = new List<NhanVienEnity>();
            List<NHANVIEN> ListNhanVienDAO = null;
            string IdResult;
            using (var db = new QLPHONGKHAMEntities())
            {
                BaseDAO dao = new BaseDAO();
                IdResult = dao.Select(db, out ListNhanVienDAO, ref Messages);
            }
            // trường hợp select fail
            if (IdResult.Equals(Constant.RES_FAI))
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi xãy ra khi select dữ liệu từ Table NHANVIEN - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            // trường hợp data rỗng
            if (ListNhanVienDAO.Count == 0)
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi empty dữ liệu từ Table NHANVIEN - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            // duyệt qua danh sách hồ sơ
            foreach (var nhanvien in ListNhanVienDAO)
            {
                // tạo đối tượng entity
                NhanVienEnity nhanVienEntity = new NhanVienEnity();
                // copy property
                Utils.CopyPropertiesFrom(nhanvien, nhanVienEntity);
                // add vào list ouput
                ListNhanVienEntity.Add(nhanVienEntity);
            }
            return Constant.RES_SUC;
        }
    }
}
