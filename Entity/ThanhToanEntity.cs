//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nhom15_FinalProject.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class ThanhToanEntity
    {
        public string MaThanhToan { get; set; }
        public Nullable<decimal> ThanhTien { get; set; }
        public Nullable<System.DateTime> NgayThanhToan { get; set; }
        public string MaThuePhong { get; set; }
        public string MaNV { get; set; }
        public Nullable<System.DateTime> NgayVao { get; set; }
    
        public virtual ThuePhongEntity ThuePhong { get; set; }
    }
}