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
    
    public partial class ChiTietBaoCao
    {
        public long MaBaoCao { get; set; }
        public int MaHang { get; set; }
        public Nullable<long> TonDau { get; set; }
        public Nullable<long> SlNhap { get; set; }
        public Nullable<long> SlXuat { get; set; }
        public Nullable<long> TonCuoi { get; set; }
    
        public virtual BaoCaoThang BaoCaoThang { get; set; }
        public virtual HangHoa HangHoa { get; set; }
    }
}
