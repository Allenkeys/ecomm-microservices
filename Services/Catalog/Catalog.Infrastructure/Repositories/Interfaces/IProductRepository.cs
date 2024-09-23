using Catalog.Core.Entities;

namespace Catalog.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProduct(string Id);
        Task<IEnumerable<Product>> GetProductsByName(string Name);
        Task<IEnumerable<Product>> GetProductsByBrandName(string BrandName);
        Task<Product> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string productId);
    }
}
