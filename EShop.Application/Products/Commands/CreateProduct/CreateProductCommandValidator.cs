using EShop.Application.Report.Queries.GetTotalSales;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(u => u.Title)
             .NotEmpty().WithMessage("Title field is required");

            RuleFor(u => u.Price)
            .NotEmpty().WithMessage("Price field is required");
        }
    }
}
