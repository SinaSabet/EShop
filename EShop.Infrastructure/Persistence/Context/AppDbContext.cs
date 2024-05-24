using EShop.Domain.Contract.Context;
using EShop.Domain.Entities.OrderLines;
using EShop.Domain.Entities.Orders;
using EShop.Domain.Entities.Products;
using EShop.Infrastructure.Persistence.Context.ConfigurationEntity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EShop.Infrastructure.Persistence.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }

}
