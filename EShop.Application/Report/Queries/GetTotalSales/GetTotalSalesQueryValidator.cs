using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Report.Queries.GetTotalSales
{
    public class GetTotalSalesQueryValidator: AbstractValidator<GetTotalSalesQuery>
    {
        public GetTotalSalesQueryValidator()
        {
            RuleFor(u => u.ProductId)
             .NotEmpty().WithMessage("ProductId field is required");
        }
    }
}
