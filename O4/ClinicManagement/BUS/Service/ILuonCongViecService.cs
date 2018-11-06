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
    interface ILuonCongViecService
    {
        //INSERT MOT LUON CONG VIEC
        string AddLuonCongViec(QLPHONGKHAMEntities db,  LuonCongViecEnity LuonCongViec , ref List<MessageError> Messages);

        //UPDATE MOT LUON CONG VIEC
        string UpdateLuonCongViec(QLPHONGKHAMEntities db, LuonCongViecEnity LuonCongViec, ref List<MessageError> Messages);
    }
}
