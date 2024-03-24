using EatGood_Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eat_Good_Data
{
    public class EatGood_DBContext :IdentityDbContext<AppUser>
    {
        public EatGood_DBContext(DbContextOptions<EatGood_DBContext> options) : base(options)
        {
            
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<DeliveryStatus> DeliveryStatuses { get; set;}
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Wallet> Wallets { get; set; } 
        public DbSet<WalletFunding> WalletFundings { get; set; }


    }
}
