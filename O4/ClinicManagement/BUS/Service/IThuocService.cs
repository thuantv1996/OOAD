﻿using System.Collections.Generic;
using DTO;
using BUS.Entities;
using DAO;
using COM;

namespace BUS.Service
{
    interface IThuocService
    {
        // LẤY DANH SÁCH THUỐC
        string GetListThuoc(out List<ThuocEnity> ListThuocEntity, ref List<MessageError> Messages);
    }
}
