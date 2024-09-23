using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Catalog.Application.Queries;

public class GetProductByIdQuery : IRequest<ProductResponse>
{
    public string Id { get; set; }
}

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetProductByIdHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProduct(request.Id);
        var result = _mapper.Map<ProductResponse>(product);
        return result;
    }
}
