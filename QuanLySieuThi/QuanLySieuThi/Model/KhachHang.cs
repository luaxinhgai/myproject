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
    
    public partial class KhachHang
    {
        public KhachHang()
        {
            this.DonHangs = new HashSet<DonHang>();
        }
    
        public int MaKh { get; set; }
        public string TenKh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
