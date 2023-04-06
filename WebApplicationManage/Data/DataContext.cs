using Microsoft.EntityFrameworkCore;

namespace WebApplicationManage.Data
{
    public class DataContext : DbContext    {
        public DataContext(DbContextOptions options) : base(options) { }
        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Category> Categories { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("users");
                e.HasIndex(x => x.Email).IsUnique();
                e.Property(e => e.Created).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Token>(e =>
            {
                e.ToTable("tokens");
                e.HasOne(e => e.User)
                .WithMany(e => e.Tokens)
                .HasForeignKey(e => e.UserID);
            });

            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Category");
                e.HasKey(c => c.Id);
                e.Property(e => e.Created).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Customer>(e =>
            {
                e.ToTable("Customer");
                e.HasKey(c => c.Id);
                e.Property(c => c.FullName).HasMaxLength(50);
                e.Property(c => c.Email).IsRequired();
                e.Property(c => c.Password);
                e.Property(c => c.Address).HasMaxLength(150);
                e.Property(c => c.Phone).HasMaxLength(11);
                e.HasMany(e => e.Orders).WithOne(e => e.Customer).HasForeignKey(e => e.Customerid);
                e.Property(e => e.Created).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<OrderDetail>(e => {
                e.ToTable("OrderDetail");
                e.HasKey(od => od.Id);
                e.Property(od => od.OrderId)
                    .IsRequired();
                e.Property(od => od.ProductId)
                    .IsRequired()
                    .HasMaxLength(100);
                e.Property(od => od.Count)
                    .IsRequired();
                e.Property(od => od.Price)
                    .IsRequired();
                e.Property(od => od.Status)
                    .IsRequired();
                e.HasOne(od => od.Order)
                    .WithMany(o => o.OrderDetails)
                    .HasForeignKey(od => od.OrderId);
                e.HasOne(od => od.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(od => od.ProductId);
            });

            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(o => o.Id);
                e.Property(o => o.OrderCode)
                    .IsRequired()
                    .HasMaxLength(50);
                e.Property(o => o.Customerid)
                    .IsRequired();
                e.Property(e => e.Created).HasDefaultValueSql("GETDATE()");
                e.Property(e => e.Orderdate).HasDefaultValueSql("GETDATE()");
                e.Property(o => o.FullName)
                    .HasMaxLength(100);
                e.Property(o => o.Phone)
                    .HasMaxLength(20);
                e.Property(o => o.Money)
                    .IsRequired();
                e.Property(o => o.Price_ship);
                e.Property(o => o.Coupon);
                e.Property(e => e.Status).HasDefaultValue(1);
                e.Property(o => o.Address)
                    .HasMaxLength(200);
                e.HasOne(o => o.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(o => o.Customerid);
            });


            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable("product");
                e.HasKey(p => p.Id);
                e.Property(p => p.Name).IsRequired().HasMaxLength(50);
                e.Property(p => p.Avatar);
                e.Property(p => p.Image);
                e.Property(p => p.SortDesc).HasMaxLength(200);
                e.Property(p => p.Detail).HasMaxLength(1000);
                e.Property(p => p.Producer).IsRequired();
                e.Property(p => p.Number).IsRequired();
                e.Property(p => p.Number_buy).IsRequired();
                e.Property(p => p.Price).IsRequired();
                e.Property(p => p.Sale).IsRequired();
                e.Property(p => p.Price_sale).IsRequired();
                e.Property(p => p.Modified);
                e.HasOne(p => p.producer).WithMany(p => p.Products).HasForeignKey(p => p.Producer);
                e.HasOne(e => e.Category).WithMany(e => e.Products).HasForeignKey(e => e.CatId);
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.ToTable("Producer");
                entity.HasKey(e => e.Id); 
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255); 
                entity.Property(e => e.Code).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Keyword).IsRequired();
                entity.Property(e => e.Modified).IsRequired(); 
                entity.Property(e => e.Trash).IsRequired().HasDefaultValue(1); 
                entity.Property(e => e.Status).IsRequired().HasDefaultValue(1);
                entity.HasOne(e => e.User).WithMany(e => e.Producers).HasForeignKey(e => e.UserId);
            });
        }
    }
}
