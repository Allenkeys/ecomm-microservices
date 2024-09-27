using Catalog.Application.DTOs;
using Catalog.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[Route("api/brands")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IMediator _mediator;

    public BrandController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IList<BrandResponse>), 200)]
    public async Task<IActionResult> GetBrands()
    {
        var brands = await _mediator.Send(new GetAllBrandsQuery());
        return Ok(brands);
    }
}