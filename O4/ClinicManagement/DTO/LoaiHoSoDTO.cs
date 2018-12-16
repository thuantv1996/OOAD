using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiHoSoDTO
    {
        public string MaLoaiHoSo { get; set; }
        public string TenLoaiHoSo { get; set; }

        public override string ToString()
        {
            return TenLoaiHoSo;
        }
    }
}
