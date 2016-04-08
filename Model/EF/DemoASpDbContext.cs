namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DemoASpDbContext : DbContext
    {
        public DemoASpDbContext()
            : base("name=DemoASpDbContext")
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }
        public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }
        public virtual DbSet<DanhMucSanPhamCuaSanPham> DanhMucSanPhamCuaSanPhams { get; set; }
        public virtual DbSet<DiaChi> DiaChis { get; set; }
        public virtual DbSet<DiaChiGiaoHang> DiaChiGiaoHangs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<GiaBanSanPham> GiaBanSanPhams { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhomKhachHang> NhomKhachHangs { get; set; }
        public virtual DbSet<NhomKhachHangCuaKhachHang> NhomKhachHangCuaKhachHangs { get; set; }
        public virtual DbSet<NhomTaiKhoan> NhomTaiKhoans { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TaiKhoanKhachHang> TaiKhoanKhachHangs { get; set; }
        public virtual DbSet<VanChuyen> VanChuyens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.GiaBan)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.ThanhTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ChiTietSanPham>()
                .HasOptional(e => e.SanPham)
                .WithRequired(e => e.ChiTietSanPham);

            modelBuilder.Entity<GiaBanSanPham>()
                .Property(e => e.GiaBan)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GiaBanSanPham>()
                .Property(e => e.GiaKhuyenMai)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NhomKhachHang>()
                .Property(e => e.Active)
                .IsFixedLength();

            modelBuilder.Entity<Quyen>()
                .HasMany(e => e.TaiKhoans)
                .WithMany(e => e.Quyens)
                .Map(m => m.ToTable("PhanQuyen").MapLeftKey("QuyenId").MapRightKey("UserName"));

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Gia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.GiaKhuyenMai)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TaiKhoanKhachHang>()
                .HasOptional(e => e.TaiKhoan)
                .WithRequired(e => e.TaiKhoanKhachHang);
        }
    }
}
