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
    }
}

