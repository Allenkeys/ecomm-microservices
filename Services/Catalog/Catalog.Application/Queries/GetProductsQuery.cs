using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProductsQuery : IRequest<IList<ProductResponse>>
    {
    }

    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IList<ProductResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductsHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<IList<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProducts();
            var result = _mapper.Map<IList<ProductResponse>>(products);
            return result;
        }
    }
}
