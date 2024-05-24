using EShop.Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Products.Queries.GetProducts
{
    public record GetProductsQuery(int PageNumber=1,int PageSize=10):IRequest<IReadOnlyList<GetProductsQueryResponse>>,ICachedQuery
    {
        public string Key => $"product-list-pagenumber-{PageNumber}-pagecount{PageSize}";
    }
}
