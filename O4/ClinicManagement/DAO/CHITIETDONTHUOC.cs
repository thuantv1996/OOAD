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
    
    public partial class CHITIETDONTHUOC
    {
        public string MaDonThuoc { get; set; }
        public string MaThuoc { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public string GhiChu { get; set; }
    
        public virtual DONTHUOC DONTHUOC { get; set; }
        public virtual THUOC THUOC { get; set; }
    }
}
