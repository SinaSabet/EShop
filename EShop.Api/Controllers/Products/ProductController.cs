using EShop.Api.Model;
using EShop.Application.Products.Commands.CreateProduct;
using EShop.Application.Products.Queries.GetProducts;
using EShop.Application.Report.Queries.GetTotalSales;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Api.Controllers.Products
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;


        /// <summary>
        /// GET Product List
        /// </summary>
        /// 
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var data = new GetProductsQuery();
            var result = await _mediator.Send(data);
            var response = new Response<IReadOnlyList<GetProductsQueryResponse>>(result, "Success");

            return Ok(response);

        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            var response=  new Response<CreateProductCommandResponse>(result, "Success");
            return Ok(response);
        }
    }
}
