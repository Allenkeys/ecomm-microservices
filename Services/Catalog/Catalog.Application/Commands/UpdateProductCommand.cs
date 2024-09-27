using Catalog.Core.Entities;
using Catalog.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Catalog.Application.Commands;

public class UpdateProductCommand : IRequest<bool>
{
    public string ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Summary { get; set; }
    public Decimal Price { get; set; }
    public string PictureUrl { get; set; }
    public ProductType ProductType { get; set; }
    public Brand Brand { get; set; }
    public int AvailableStock { get; set; }
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var updatedProduct = new Product()
        {
            Id = request.ProductId,
            Name = request.Name,
            AvailableStock = request.AvailableStock,
            Brand = new Brand
            {
                Id = request.Brand.Id,
                Name = request.Brand.Name,
            },
            Description = request.Description,
            PictureUrl = request.PictureUrl,
            ProductType = new ProductType
            {
                Id = request.ProductType.Id,
                Name = request.ProductType.Name,
            }
        };
        return await _productRepository.UpdateProduct(updatedProduct);
    }
    
}