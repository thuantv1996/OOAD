﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class XetNghiemDTO
    {
        public string MaXetNghiem { get; set; }
        public string TenXetNghiem { get; set; }
        public string MaPhong { get; set; }
        public decimal ChiPhi { get; set; }

        public override string ToString()
        {
            return TenXetNghiem;
        }
    }
}
