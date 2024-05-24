using EShop.Application.Products.Queries.GetProducts;
using EShop.Domain.Contract;
using EShop.Domain.Entities.Products;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.IntegrationTest.Products
{
    public class GetProductsQueryHandlerTests
    {
        [Fact]
        public async Task Handle_WhenCalled_ShouldReturnProductList()
        {
            // Arrange
            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(r => r.GetProductListAsync(1, 10, CancellationToken.None))
                .ReturnsAsync(Enumerable.Empty<Product>().ToImmutableList());

            var handler = new GetProductsQueryHandler(productRepository.Object);

            var request = new GetProductsQuery
            {
                PageNumber = 1,
                PageSize = 10
            };

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(response);
            Assert.IsAssignableFrom<IReadOnlyList<GetProductsQueryResponse>>(response);
        }
    }
}
