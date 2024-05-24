using EShop.Application.Report.Queries.GetSoldProductCount;
using EShop.Domain.Contract;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.IntegrationTest.Reports
{
    public class ReportsServiceTest 
    {
        private readonly Mock<IOrderLineRepository> _orderLineRepositoryMock;
        private readonly GetSoldProductCountQueryHandler _handler;

        public ReportsServiceTest()
        {
            _orderLineRepositoryMock = new Mock<IOrderLineRepository>();
            _handler = new GetSoldProductCountQueryHandler(_orderLineRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnSoldProductCount()
        {
            // Arrange
            var startDate = new DateTime(2023, 5, 1);
            var endDate = new DateTime(2023, 5, 31);
            var expectedCount = 10;

            _orderLineRepositoryMock
                .Setup(repo => repo.GetSoldProductCountByDateRange(startDate, endDate))
                .ReturnsAsync(expectedCount);

            var query = new GetSoldProductCountQuery(startDate, endDate);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(expectedCount, result);
            _orderLineRepositoryMock.Verify(repo => repo.GetSoldProductCountByDateRange(startDate, endDate), Times.Once);
        }
    }
}
