using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using COM;
using DTO;
using BUS.Entities;

namespace BUS.Service
{
    interface IThanhToanService
    {
        //INSERT MOT THANH TOAN
        string AddThanhToan(QLPHONGKHAMEntities db, ThanhToanEntity ThanhToan, ref List<MessageError> Messages);

        //UPDATE MOT THANH TOAN
        string UpdateThanhToan(QLPHONGKHAMEntities db, ThanhToanEntity ThanhToan, ref List<MessageError> Messages);

        //CREATE ID THANH TOAN
        string CreateIdThanhToan(out string Id, ref List<MessageError> Messages);

    }
}
