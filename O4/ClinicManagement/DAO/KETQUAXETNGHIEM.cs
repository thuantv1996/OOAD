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
    
    public partial class KETQUAXETNGHIEM
    {
        public string MaHoSo { get; set; }
        public string MaXetNghiem { get; set; }
        public string MaBacSi { get; set; }
        public string NgayXetNghiem { get; set; }
        public string KetQua { get; set; }
        public Nullable<bool> ThanhToan { get; set; }
        public Nullable<decimal> TongChiPhi { get; set; }
    
        public virtual HOSOBENHAN HOSOBENHAN { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
        public virtual XETNGHIEM XETNGHIEM { get; set; }
    }
}