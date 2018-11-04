using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThanhToanEntity
    {
        public string MaThanhToan { get; set; }

        public string MaHoSo { get; set; }

        public Nullable<decimal> ChiPhiKham { get; set; }

        public Nullable<decimal> ChiPhiXetNghiem { get; set; }

        public Nullable<decimal> TongChiPhi { get; set; }

        public string NhanVienThu { get; set; }

        public string NgayThu { get; set; }

        
    }
}
