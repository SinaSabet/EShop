using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Report.Queries.GetSoldProductCount
{
    public class GetSoldProductCountQueryValidator: AbstractValidator<GetSoldProductCountQuery>
    {
        public GetSoldProductCountQueryValidator()
        {
            RuleFor(u => u.StartDate)
                .NotEmpty().WithMessage("Start Date field is requierd");

            RuleFor(u => u.EndDate)
               .NotEmpty().WithMessage("End Date field is requierd");
        }
    }
}
