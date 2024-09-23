using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Core.Entities;
using Catalog.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Catalog.Application.Commands
{
    public class CreateProductCommand : IRequest<ProductResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public Decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; }
        public Brand Brand { get; set; }
        public int AvailableStock { get; set; }
    }

    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = _mapper.Map<Product>(request) ?? throw new ArgumentNullException("Product cannot be null");
            var createdProduct = await _productRepository.CreateProduct(newProduct);
            var result = _mapper.Map<ProductResponse>(createdProduct);
            return result;
        }
    }
}
