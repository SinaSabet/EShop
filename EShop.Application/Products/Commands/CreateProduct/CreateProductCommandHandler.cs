using EShop.Application.Abstractions;
using EShop.Domain.Contract;
using EShop.Domain.Entities.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product(request.Title, request.Price);
            await _productRepository.CreateProductAsync(product, cancellationToken);
            await _productRepository.SaveChangesAsync(cancellationToken);

            return new CreateProductCommandResponse(product.Id);
        }
    }
}
