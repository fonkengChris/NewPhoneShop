using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewPhoneShop2.Models;

namespace NewPhoneShop2.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser> 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        
        //Tables for order related classes
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; } 

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
