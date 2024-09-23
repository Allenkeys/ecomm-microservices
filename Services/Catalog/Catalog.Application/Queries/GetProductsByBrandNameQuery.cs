using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Catalog.Application.Queries;

public class GetProductsByBrandQuery : IRequest<IList<ProductResponse>>
{
    public string Name { get; set; }
}

public class GetProductsByBrandHandler : IRequestHandler<GetProductsByBrandQuery, IList<ProductResponse>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetProductsByBrandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public async Task<IList<ProductResponse>> Handle(GetProductsByBrandQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetProductsByBrandName(request.Name);
        var result = _mapper.Map<IList<ProductResponse>>(products);
        return result;
    }
}