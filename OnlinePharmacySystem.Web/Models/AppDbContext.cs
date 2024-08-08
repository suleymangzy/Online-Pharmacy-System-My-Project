using Microsoft.EntityFrameworkCore;

namespace onlinePharmacySystem.Web.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BlogPosts> BlogPosts { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Deliveries> Deliveries { get; set; }
        public DbSet<FAQs> FAQs { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Pharmacies> Pharmacies { get; set; }
        public DbSet<Prescriptions> Prescriptions { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // BlogPosts varlığı için birincil anahtar tanımlanır
            modelBuilder.Entity<BlogPosts>()
                .HasKey(b => b.BlogPostID);

            // Brands varlığı için birincil anahtar tanımlanır
            modelBuilder.Entity<Brands>()
                .HasKey(b => b.BrandID);

            // Categories varlığı için birincil anahtar tanımlanır
            modelBuilder.Entity<Categories>()
                .HasKey(c => c.CategoryID);

            // Deliveries varlığı için birincil anahtar tanımlanır
            modelBuilder.Entity<Deliveries>()
                .HasKey(d => d.DeliveryID);

            // FAQs varlığı için birincil anahtar tanımlanır
            modelBuilder.Entity<FAQs>()
                .HasKey(f => f.FaqID);

            // OrderDetails varlığı için birincil anahtar tanımlanır
            modelBuilder.Entity<OrderDetails>()
                .HasKey(o => o.OrderDetailID);

            // Orders varlığı için birincil anahtar tanımlanır
            modelBuilder.Entity<Orders>()
                .HasKey(o => o.OrderID);

            // Payments varlığı için birincil anahtar tanımlanır
            modelBuilder.Entity<Payments>()
                .HasKey(p => p.PaymentID);

            // Pharmacies varlığı için birincil anahtar tanımlanır
            modelBuilder.Entity<Pharmacies>()
                .HasKey(p => p.PharmacyID);

            // Prescriptions varlığı için birincil anahtar tanımlanır
            modelBuilder.Entity<Prescriptions>()
                .HasKey(p => p.PrescriptionID);

            // Products varlığı için birincil anahtar tanımlanır
            modelBuilder.Entity<Products>()
                .HasKey(p => p.ProductID);

            // Roles varlığı için birincil anahtar tanımlanır
            modelBuilder.Entity<Roles>()
                .HasKey(r => r.RoleID);

            // Suppliers varlığı için birincil anahtar tanımlanır
            modelBuilder.Entity<Suppliers>()
                .HasKey(s => s.SupplierID);

            // Users varlığı için birincil anahtar tanımlanır
            modelBuilder.Entity<Users>()
                .HasKey(u => u.UserID);

            // Decimal özellikler için precision ve scale tanımlamaları
            modelBuilder.Entity<OrderDetails>()
                .Property(o => o.TaxRate)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderDetails>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Products>()
                .Property(p => p.ProductPrice)
                .HasColumnType("decimal(18,2)");
        }

    }
}


