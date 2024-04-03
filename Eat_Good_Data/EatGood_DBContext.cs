using EatGood_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eat_Good_Data
{
    public class EatGood_DBContext :IdentityDbContext<AppUser>
    {
        public EatGood_DBContext(DbContextOptions<EatGood_DBContext> options) : base(options)
        {
            
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerWallet> CustomerWallets { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<ShippingDetails> ShippingDetails { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorWallet> VendorWallets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();

            modelBuilder.Entity<VendorWallet>()
                .Property(vw => vw.Balance)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Order>()
                .Property(vw => vw.TotalAmount)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Order>()
                .Property(vw => vw.Price)
                .HasPrecision(18, 2);
            modelBuilder.Entity<FoodItem>()
                .Property(vw => vw.Price)
                .HasPrecision(18, 2);
            modelBuilder.Entity<CustomerWallet>()
                .Property(vw => vw.Balance)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Cart>()
                .Property(vw => vw.TotalPrice)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Cart>()
                .Property(vw => vw.Tax)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Cart>()
                .Property(vw => vw.Subtotal)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Cart>()
                .Property(vw => vw.Discount)
                .HasPrecision(18, 2);

        }


    }
}
