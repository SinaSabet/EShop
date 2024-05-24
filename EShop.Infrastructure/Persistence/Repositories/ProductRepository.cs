using EShop.Domain.Contract;
using EShop.Domain.Contract.Context;
using EShop.Domain.Entities.Products;
using EShop.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Infrastructure.Persistence.Repositories
{
    public class ProductRepository(IAppDbContext appDbContext) : IProductRepository
    {
        private readonly IAppDbContext _appDbContext = appDbContext;

        public async Task CreateProductAsync(Product product, CancellationToken cancellationToken)
        {
            await _appDbContext.Products.AddAsync(product, cancellationToken);
        }

        public async Task<Product> GetProductById(int productId, CancellationToken cancellationToken)
        {
            return await _appDbContext.Products.FindAsync( productId, cancellationToken);
        }

        public async Task<IReadOnlyList<Product>> GetProductListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var products= await _appDbContext.Products.AsNoTracking()
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .ToListAsync(cancellationToken);
            return products.ToImmutableList();
        }

        public async Task<bool> HasIdAsync(int productId, CancellationToken cancellationToken)
        {
            return await _appDbContext.Products.AnyAsync(x => x.Id == productId, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
          await  _appDbContext.SaveChangesAsync(cancellationToken);  
        }
    }
}
