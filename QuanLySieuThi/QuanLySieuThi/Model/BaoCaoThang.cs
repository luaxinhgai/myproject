//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLySieuThi.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class BaoCaoThang
    {
        public BaoCaoThang()
        {
            this.ChiTietBaoCaos = new HashSet<ChiTietBaoCao>();
        }
    
        public long MaBaoCao { get; set; }
        public string ThoiGian { get; set; }
        public Nullable<System.DateTime> NgayLap { get; set; }
        public string MoTa { get; set; }
    
        public virtual ICollection<ChiTietBaoCao> ChiTietBaoCaos { get; set; }
    }
}
