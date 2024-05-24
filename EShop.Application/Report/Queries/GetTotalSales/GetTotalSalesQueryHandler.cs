using EShop.Application.Exceptions;
using EShop.Domain.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Report.Queries.GetTotalSales
{
    public class GetTotalSalesQueryHandler(IOrderLineRepository orderLineRepository, IProductRepository productRepository) : IRequestHandler<GetTotalSalesQuery, decimal>
    {
        private readonly IOrderLineRepository _orderLineRepository = orderLineRepository;
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<decimal> Handle(GetTotalSalesQuery request, CancellationToken cancellationToken)
        {

            var product = await _productRepository.HasIdAsync(request.ProductId,cancellationToken);
            if (product == false)
                throw new ProductNotFoundException(request.ProductId);


            var totalSales =await _orderLineRepository.GetTotalSalesByProductId(request.ProductId);
            return totalSales;
        }
    }
}
