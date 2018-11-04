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

namespace BUS.Imp
{
    class ThanhToanImplement : IThanhToanService
    {
        public string AddThanhToan(QLPHONGKHAMEntities db, ThanhToanEntity ThanhToan, ref List<MessageError> Messages)
        {
            throw new NotImplementedException();
        }

        public string UpdateThanhToan(QLPHONGKHAMEntities db, ThanhToanEntity ThanhToan, ref List<MessageError> Messages)
        {
            string ProgramName = "ThanhToanImplement-Update";
            // khai báo các biến đón kết quả rả về từ Select
            List<THANHTOAN> ListSelectResult = null;
            string IdResult;
            THANHTOAN ThanhToanDAO = new THANHTOAN();
            BUS.Com.Utils.CopyPropertiesFrom(ThanhToan, ThanhToanDAO);


            throw new NotImplementedException();
        }
    }
}
