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
    public class KetQuaXetNghiemImplement : IKetQuaXetNguyenService
    {
        public string AddKetQuaXetNghiem(QLPHONGKHAMEntities db, KetQuaXetNghiemEnity KetQuaXetNghiem, ref List<MessageError> Messages)
        {
            string ProgramName = "KetQuaXetNghiemImplement-AddKetQuaXetNghiem";
            string IdResult;
            KETQUAXETNGHIEM KetQuaXetNghiemDAO = new KETQUAXETNGHIEM();
            BUS.Com.Utils.CopyPropertiesFrom(KetQuaXetNghiem, KetQuaXetNghiemDAO);
            DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
            IdResult = Dao.Insert(KetQuaXetNghiemDAO, db, ref Messages);
            if (IdResult == Constant.RES_FAI)
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = string.Format("Lỗi khi Update vao Table KETQUAXETNGHIEM - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }

        public string GetInformationWithId(string MaHoSo, string MaXetNghiem, KetQuaXetNghiemEnity KetQuaXetNghiem, ref List<MessageError> Messages)
        {
            string ProgramName = "KetQuaXetNghiemImplement-GetInformationWithId";
            KetQuaXetNghiem = new KetQuaXetNghiemEnity();
            List<KETQUAXETNGHIEM> ListKetQuaXetNghiemDAO = null;
            string IdResult;
            using (var db = new QLPHONGKHAMEntities())
            {
                BaseDAO dao = new BaseDAO();
                IdResult = dao.Select(db, kqxn => kqxn.MaHoSo == MaHoSo && kqxn.MaXetNghiem == MaXetNghiem, out ListKetQuaXetNghiemDAO, ref Messages);
            }
            // trường hợp select fail
            if (IdResult.Equals(Constant.RES_FAI))
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi xãy ra khi select dữ liệu từ Table KETQUAXETNGHIEM - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            // trường hợp data rỗng
            if (ListKetQuaXetNghiemDAO.Count == 0)
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi empty dữ liệu từ Table KETQUAXETNGHIEM - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            // trường hợp data trả về nhiều hơn 1 record
            if (ListKetQuaXetNghiemDAO.Count > 1)
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi select trên key nhiều hơn 1 record dữ liệu từ Table KETQUAXETNGHIEM - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            // copy property
            Utils.CopyPropertiesFrom(ListKetQuaXetNghiemDAO.ElementAt(0), KetQuaXetNghiem);
            // return success
            return Constant.RES_SUC;
        }

        public string GetListKetQuaXetNghiemWithId(QLPHONGKHAMEntities db, string MaHoSo, out List<KetQuaXetNghiemEnity> ListKetQuaXetNghiem, ref List<MessageError> Messages)
        {
            ListKetQuaXetNghiem = new List<KetQuaXetNghiemEnity>();
            List<KETQUAXETNGHIEM> ListKetQuaXetNghiemDAO = new List<KETQUAXETNGHIEM>();
            string IdResult;
            
            // Tạo đối tượng DAO
            BaseDAO dao = new BaseDAO();
            // Thực hiện câu lệnh Select
            IdResult = dao.Select(db, kqxn => kqxn.ThanhToan == true, out ListKetQuaXetNghiemDAO, ref Messages);
            // Nếu lệnh select true
            if (IdResult.Equals(Constant.RES_SUC))
            {
                ListKetQuaXetNghiemDAO = (from kqxn in db.KETQUAXETNGHIEMs
                                          where kqxn.MaHoSo == MaHoSo
                                          select kqxn).ToList();
                foreach (var kqxn in ListKetQuaXetNghiemDAO)
                {
                    KetQuaXetNghiemEnity ketQuaXetNghiem = new KetQuaXetNghiemEnity();
                    Utils.CopyPropertiesFrom(kqxn, ketQuaXetNghiem);
                    ListKetQuaXetNghiem.Add(ketQuaXetNghiem);
                }
                return Constant.RES_SUC;
            }
            // Return failed
            return Constant.RES_FAI;
            
        }

        public string UpdateKetQuaXetNghiem(QLPHONGKHAMEntities db, KetQuaXetNghiemEnity KetQuaXetNghiem, ref List<MessageError> Messages)
        {
            string ProgramName = "KetQuaXetNghiemImplement-AddKetQuaXetNghiem";
            string IdResult;
            KETQUAXETNGHIEM KetQuaXetNghiemResult = new KETQUAXETNGHIEM();
            BUS.Com.Utils.CopyPropertiesFrom(KetQuaXetNghiem, KetQuaXetNghiemResult);
            DAO.Imp.BaseDAO Dao = new DAO.Imp.BaseDAO();
            IdResult = Dao.Update(KetQuaXetNghiemResult, db, ref Messages);
            if (IdResult == Constant.RES_FAI)
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = string.Format("Lỗi khi Update vao Table KETQUAXETNGHIEM - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            return Constant.RES_SUC;
        }
    }
}
