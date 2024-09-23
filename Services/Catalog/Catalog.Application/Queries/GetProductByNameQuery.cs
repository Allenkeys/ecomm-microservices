using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Catalog.Application.Queries;

public class GetProductsByNameQuery : IRequest<IList<ProductResponse>>
{
    public string Name { get; set; }
}

public class GetProductsByNameHandler : IRequestHandler<GetProductsByNameQuery, IList<ProductResponse>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetProductsByNameHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public async Task<IList<ProductResponse>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetProductsByName(request.Name);
        var result = _mapper.Map<IList<ProductResponse>>(products);
        return result;
    }
}
