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
    class ThuocImplement : IThuocService
    {
        public string GetListThuoc(out List<ThuocEnity> ListThuocEntity, ref List<MessageError> Messages)
        {
            string ProgramName = "ThuocImplement-GetListThuoc";
            ListThuocEntity = new List<ThuocEnity>();
            List<THUOC> ListThuocDAO = null;
            string IdResult;
            using (var db = new QLPHONGKHAMEntities())
            {
                BaseDAO dao = new BaseDAO();
                IdResult = dao.Select(db, out ListThuocDAO, ref Messages);
            }
            // trường hợp select fail
            if (IdResult.Equals(Constant.RES_FAI))
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi xãy ra khi select dữ liệu từ Table THUOC - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            // trường hợp data rỗng
            if (ListThuocDAO.Count == 0)
            {
                Messages.Add(new MessageError
                {
                    IdError = Constant.MES_DB,
                    Message = String.Format("Lỗi empty dữ liệu từ Table THUOC - {0}", ProgramName)
                });
                return Constant.RES_FAI;
            }
            // duyệt qua danh sách hồ sơ
            foreach (var thuoc in ListThuocDAO)
            {
                // tạo đối tượng entity
                ThuocEnity thuocEntity = new ThuocEnity();
                // copy property
                Utils.CopyPropertiesFrom(thuoc, thuocEntity);
                // add vào list ouput
                ListThuocEntity.Add(thuocEntity);
            }
            return Constant.RES_SUC;
        }
    }
}
