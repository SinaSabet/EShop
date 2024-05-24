using EShop.Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Report.Queries.GetSoldProductCount
{
    public record GetSoldProductCountQuery(DateTime StartDate, DateTime EndDate) : IRequest<int>, ICachedQuery
    {
        public string Key => $"get-sold-product-count-query:{StartDate:yyyy-MM-dd}:{EndDate:yyyy-MM-dd}";
    }
}
