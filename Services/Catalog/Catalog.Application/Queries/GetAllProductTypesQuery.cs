using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Catalog.Application.Queries;

public class GetAllProductTypesQuery : IRequest<IList<ProductTypeResponse>>
{
}

public class GetProductTypesHandler : IRequestHandler<GetAllProductTypesQuery, IList<ProductTypeResponse>>
{
    private readonly IMapper _mapper;
    private readonly IProductTypeRepository _typeRepo;

    public GetProductTypesHandler(IMapper mapper, IProductTypeRepository typeRepository)
    {
        _mapper = mapper;
        _typeRepo = typeRepository;
    }
    public async Task<IList<ProductTypeResponse>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
    {
        var types = await _typeRepo.GetAllTypes();
        var result = _mapper.Map<IList<ProductTypeResponse>>(types);
        return result;
    }
}
