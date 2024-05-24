using EShop.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Contract
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int productId,CancellationToken cancellationToken);
        Task<bool> HasIdAsync(int productId, CancellationToken cancellationToken);
        Task CreateProductAsync(Product product,CancellationToken cancellationToken);
        Task<IReadOnlyList<Product>> GetProductListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

        Task SaveChangesAsync(CancellationToken cancellationToken);

    }
}
