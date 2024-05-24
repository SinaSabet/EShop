using EShop.Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Report.Queries.GetTotalSales
{
    public record GetTotalSalesQuery(int ProductId) :IRequest<decimal>, ICachedQuery
    {
        public  string Key => $"total-sales-by-id-{ProductId}";
    }
}
