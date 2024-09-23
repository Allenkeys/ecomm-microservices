using Catalog.Application.DTOs;
using Catalog.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<ProductResponse>), 200)]
        public async Task<IActionResult> GetProducts() => Ok(await _mediator.Send(new GetProductsQuery()));

        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(typeof(ProductResponse), 200)]
        public async Task<IActionResult> GetProductById(string Id) => Ok(await _mediator.Send(new GetProductByIdQuery { Id = Id }));

        [HttpGet]
        [Route("getbybrand/{brand}")]
        [ProducesResponseType(typeof(IList<ProductResponse>), 200)]
        public async Task<IActionResult> GetProductsByBrand(string brand) => Ok(await _mediator.Send(new GetProductsByBrandQuery { Name = brand }));
    }
}
