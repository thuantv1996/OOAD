﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interface
{
    public interface IThanhToanServices : IBaseDAO<THANHTOAN>
    {
        string CreateId(QLPHONGKHAMEntities db, out string id);
    }
}