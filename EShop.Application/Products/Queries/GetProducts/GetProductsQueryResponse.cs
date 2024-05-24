using EShop.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Products.Queries.GetProducts
{
    public record GetProductsQueryResponse(int ProductId,string Titlt,int Price)
    {
        public static explicit operator GetProductsQueryResponse(Product product)
            => new GetProductsQueryResponse(product.Id, product.Title, product.Price);
    }
}
