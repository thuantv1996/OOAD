//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class THANHTOAN
    {
        public string MaThanhToan { get; set; }
        public string MaHoSo { get; set; }
        public Nullable<decimal> ChiPhiKham { get; set; }
        public Nullable<decimal> ChiPhiXetNghiem { get; set; }
        public Nullable<decimal> TongChiPhi { get; set; }
        public string NhanVienThu { get; set; }
        public string NgayThu { get; set; }
    
        public virtual HOSOBENHAN HOSOBENHAN { get; set; }

        public bool Validate()
        {
            if (MaThanhToan == null || MaThanhToan.Length != 10)
            {
                return false;
            }
            if (MaHoSo.Length > 10)
            {
                return false;
            }
            if (ChiPhiKham != null)
            {
                return false;
            }
            if (ChiPhiXetNghiem != null)
            {
                return false;
            }
            if (TongChiPhi != null)
            {
                return false;
            }
            if (NhanVienThu != null && NhanVienThu.Length > 10)
            {
                return false;
            }
            if (NgayThu != null && NgayThu.Length > 8)
            {
                return false;
            }
            return true;
        }
    }
}
