using EShop.Application.Products.Commands.CreateProduct;
using EShop.Domain.Entities.Products;
using EShop.Infrastructure.Persistence.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.IntegrationTest.Products
{
    public class CreateProductCommandHandlerTests
    {
        [Fact]
        public async Task Handle_WhenCalledWithValidRequest_ShouldCreateProductAndReturnResponse()
        {
            const string Title = "Test Product";
            const int Price = 10;



            // Arrange
            var productRepository = new Mock<ProductRepository>();
            var handler = new CreateProductCommandHandler(productRepository.Object);

            var request = new CreateProductCommand(Title, Price);
       

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            productRepository.Verify(r => r.CreateProductAsync(It.IsAny<Product>(), CancellationToken.None), Times.Once);
            productRepository.Verify(r => r.SaveChangesAsync(CancellationToken.None), Times.Once);
            Assert.True(response.ProductId != 0);
        }
    }
}
