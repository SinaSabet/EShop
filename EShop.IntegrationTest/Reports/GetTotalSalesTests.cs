using EShop.Application.Exceptions;
using EShop.Application.Report.Queries.GetTotalSales;
using EShop.Domain.Contract;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.IntegrationTest.Reports
{
    public class GetTotalSalesTests
    {
        private readonly Mock<IOrderLineRepository> _orderLineRepositoryMock;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly GetTotalSalesQueryHandler _handler;

        public GetTotalSalesTests()
        {
            _orderLineRepositoryMock = new Mock<IOrderLineRepository>();
            _productRepositoryMock = new Mock<IProductRepository>();
            _handler = new GetTotalSalesQueryHandler(_orderLineRepositoryMock.Object, _productRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ProductExists_ReturnsTotalSales()
        {
            // Arrange
            var productId = 1;
            var expectedTotalSales = 100m;

            _productRepositoryMock
                .Setup(repo => repo.HasIdAsync(productId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            _orderLineRepositoryMock
                .Setup(repo => repo.GetTotalSalesByProductId(productId))
                .ReturnsAsync(expectedTotalSales);

            var query = new GetTotalSalesQuery(productId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(expectedTotalSales, result);
            _productRepositoryMock.Verify(repo => repo.HasIdAsync(productId, It.IsAny<CancellationToken>()), Times.Once);
            _orderLineRepositoryMock.Verify(repo => repo.GetTotalSalesByProductId(productId), Times.Once);
        }

        [Fact]
        public async Task Handle_ProductDoesNotExist_ThrowsProductNotFoundException()
        {
            // Arrange
            var productId = 1;

            _productRepositoryMock
                .Setup(repo => repo.HasIdAsync(productId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var query = new GetTotalSalesQuery(productId);

            // Act & Assert
            await Assert.ThrowsAsync<ProductNotFoundException>(() => _handler.Handle(query, CancellationToken.None));
            _productRepositoryMock.Verify(repo => repo.HasIdAsync(productId, It.IsAny<CancellationToken>()), Times.Once);
            _orderLineRepositoryMock.Verify(repo => repo.GetTotalSalesByProductId(It.IsAny<int>()), Times.Never);
        }
    }
}
