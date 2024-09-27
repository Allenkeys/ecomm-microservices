using Catalog.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Catalog.Application.Commands;

public class DeleteProductCommand: IRequest<bool>
{
    public string ProductId { get; set; }
}

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var isDeleted = await _productRepository.DeleteProduct(request.ProductId);
        return isDeleted;
    }
}