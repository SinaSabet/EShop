using EShop.Domain.Entities.OrderLines;
using EShop.Domain.Entities.Orders;
using EShop.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace EShop.Domain.Contract.Context
{
    public interface IAppDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderLine> OrderLines { get; set; }


        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}
