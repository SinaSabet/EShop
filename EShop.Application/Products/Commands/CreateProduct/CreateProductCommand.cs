using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Products.Commands.CreateProduct
{
    public record CreateProductCommand(string Title, int Price) : IRequest<CreateProductCommandResponse>
    {
    }
}
