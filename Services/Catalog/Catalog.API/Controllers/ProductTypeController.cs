using Catalog.Application.DTOs;
using Catalog.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/product-types")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<ProductTypeResponse>), 200)]
        public async Task<IActionResult> GetProductTypes()
        {
            var productTypes = await _mediator.Send(new GetAllProductTypesQuery());
            return Ok(productTypes);
        }
    }
}
