﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class BANHANGSIEUTHIEntities : DbContext
    {
        public BANHANGSIEUTHIEntities()
            : base("name=BANHANGSIEUTHIEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BaoCaoThang> BaoCaoThangs { get; set; }
        public DbSet<ChiTietBaoCao> ChiTietBaoCaos { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DbSet<ChiTietNhap> ChiTietNhaps { get; set; }
        public DbSet<ChiTietXuat> ChiTietXuats { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<DoiTac> DoiTacs { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<LoaiHang> LoaiHangs { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public DbSet<PhieuXuat> PhieuXuats { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
    
        public virtual ObjectResult<DsPhieuNhap_Result> DsPhieuNhap(Nullable<System.DateTime> from, Nullable<System.DateTime> to)
        {
            var fromParameter = from.HasValue ?
                new ObjectParameter("from", from) :
                new ObjectParameter("from", typeof(System.DateTime));
    
            var toParameter = to.HasValue ?
                new ObjectParameter("to", to) :
                new ObjectParameter("to", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DsPhieuNhap_Result>("DsPhieuNhap", fromParameter, toParameter);
        }
    
        public virtual ObjectResult<DsPhieuXuat_Result> DsPhieuXuat(Nullable<System.DateTime> from, Nullable<System.DateTime> to)
        {
            var fromParameter = from.HasValue ?
                new ObjectParameter("from", from) :
                new ObjectParameter("from", typeof(System.DateTime));
    
            var toParameter = to.HasValue ?
                new ObjectParameter("to", to) :
                new ObjectParameter("to", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DsPhieuXuat_Result>("DsPhieuXuat", fromParameter, toParameter);
        }
    
        public virtual ObjectResult<procChiTietNhap_Result> procChiTietNhap(Nullable<int> ma)
        {
            var maParameter = ma.HasValue ?
                new ObjectParameter("ma", ma) :
                new ObjectParameter("ma", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<procChiTietNhap_Result>("procChiTietNhap", maParameter);
        }
    
        public virtual ObjectResult<procChiTietXuat_Result> procChiTietXuat(Nullable<int> ma)
        {
            var maParameter = ma.HasValue ?
                new ObjectParameter("ma", ma) :
                new ObjectParameter("ma", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<procChiTietXuat_Result>("procChiTietXuat", maParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
