using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThuocDTO
    {
        public string MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string ChiDinh { get; set; }
        public string ChongChiDinh { get; set; }

        public override string ToString()
        {
            return this.TenThuoc;
        }
    }
}
