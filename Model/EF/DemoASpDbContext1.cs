namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DemoASpDbContext1 : DbContext
    {
        public DemoASpDbContext1()
            : base("name=DemoASpDbContext1")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.PasswordHash)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Customers)
                .Map(m => m.ToTable("UserRoles").MapLeftKey("UserId").MapRightKey("RoleId"));

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.ProductPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.PriceItem)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrderDetail>()
                .HasMany(e => e.Products)
                .WithMany(e => e.OrderDetails)
                .Map(m => m.ToTable("OrderProduct").MapLeftKey("OrderDetailId").MapRightKey("ProductId"));

            modelBuilder.Entity<Order>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.SalePrice)
                .HasPrecision(18, 0);
        }
    }
}
