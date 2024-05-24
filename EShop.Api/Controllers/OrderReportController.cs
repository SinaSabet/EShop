using EShop.Api.Model;
using EShop.Application.Report.Queries.GetSoldProductCount;
using EShop.Application.Report.Queries.GetTotalSales;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderReportController(IMediator mediator) : ControllerBase
    {

        private readonly IMediator _mediator = mediator;


        /// <summary>
        /// GET Sales of Product with ProductId
        /// </summary>
        /// 
        [HttpPost]
        public async Task<IActionResult> GetSevenDaysTotalSales(int ProductId)
        {
            var data = new GetTotalSalesQuery(ProductId);
            var result = await _mediator.Send(data);
            var response = new Response<decimal>(result, "Success");

            return Ok(response);

        }


        /// <summary>
        /// Get Sold Product Count from date to date
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> GetSoldCount([FromBody] GetSoldProductCountQuery data)
        {
            var result = await _mediator.Send(data);
            var response = new Response<int>(result, "Success");

            return Ok(response);

        }


    }
}
