using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Catalog.Application.Queries;

public class GetAllBrandsQuery : IRequest<List<BrandResponse>>{ }

public class GetBrandsHandler : IRequestHandler<GetAllBrandsQuery, List<BrandResponse>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetBrandsHandler(IMapper mapper, IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<List<BrandResponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var brandsList = await _brandRepository.GetAllBrands();
        var brandsResponse = _mapper.Map<List<BrandResponse>>(brandsList);

        return brandsResponse;
    }
}
