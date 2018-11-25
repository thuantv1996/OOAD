using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KetQuaXetNghiemDTO
    {
        public string MaHoSo { get; set; }
        public string MaXetNghiem { get; set; }
        public string MaBacSi { get; set; }
        public string NgayXetNghiem { get; set; }
        public string KetQua { get; set; }
        public bool ThanhToan { get; set; }
        public decimal TongChiPhi { get; set; }
    }
}
