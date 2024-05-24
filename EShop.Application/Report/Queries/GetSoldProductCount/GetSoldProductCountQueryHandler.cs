using EShop.Domain.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Report.Queries.GetSoldProductCount
{
    public class GetSoldProductCountQueryHandler(IOrderLineRepository orderLineRepository) : IRequestHandler<GetSoldProductCountQuery, int>
    {
        private readonly IOrderLineRepository _orderLineRepository = orderLineRepository;

        public async Task<int> Handle(GetSoldProductCountQuery request, CancellationToken cancellationToken)
        {


            return await _orderLineRepository.GetSoldProductCountByDateRange(request.StartDate, request.EndDate);

        }
    }
}
