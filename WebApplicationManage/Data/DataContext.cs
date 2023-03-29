using Microsoft.EntityFrameworkCore;

namespace WebApplicationManage.Data
{
    public class DataContext : DbContext    {
        public DataContext(DbContextOptions options) : base(options) { }
        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }

        public DbSet<Producter> Producters { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("users");
                e.HasIndex(x => x.Email).IsUnique();
            });

            modelBuilder.Entity<Token>(e =>
            {
                e.ToTable("tokens");
                e.HasOne(e => e.User)
                .WithMany(e => e.Tokens)
                .HasForeignKey(e => e.UserID);
            });

            modelBuilder.Entity<Producter>(entity =>
            {
                entity.ToTable("Producter");
                entity.HasKey(e => e.Id); 
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255); 
                entity.Property(e => e.Code).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Keyword).IsRequired();
                entity.Property(e => e.Created).IsRequired();
                entity.Property(e => e.Modified).IsRequired(); 
                entity.Property(e => e.Trash).IsRequired().HasDefaultValue(1); 
                entity.Property(e => e.Status).IsRequired().HasDefaultValue(1); ; 
            });
        }
    }
}
