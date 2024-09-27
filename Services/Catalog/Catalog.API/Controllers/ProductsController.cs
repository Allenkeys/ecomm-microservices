using Catalog.Application.Commands;
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
        [Route("{id}")]
        [ProducesResponseType(typeof(ProductResponse), 200)]
        public async Task<IActionResult> GetProductById(string id) => Ok(await _mediator.Send(new GetProductByIdQuery { Id = id }));

        [HttpGet]
        [Route("getbybrand/{brand}")]
        [ProducesResponseType(typeof(IList<ProductResponse>), 200)]
        public async Task<IActionResult> GetProductsByBrand(string brand) => Ok(await _mediator.Send(new GetProductsByBrandQuery { Name = brand }));

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(ProductResponse), 201)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {   
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            return Ok(await _mediator.Send(new DeleteProductCommand(){ProductId = id}));
        }
    }
}
