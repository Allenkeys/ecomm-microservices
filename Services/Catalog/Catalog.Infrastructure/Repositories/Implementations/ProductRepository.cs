using Catalog.Core.Entities;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories.Interfaces;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _products;

        public ProductRepository(ICatalogDBContext context)
        {
            _products = context.Products;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await _products.InsertOneAsync(product);
            return product;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var deletedResult = await _products.DeleteOneAsync(x =>  x.Id == id);
            return deletedResult.IsAcknowledged && deletedResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _products.Find(x => true).ToListAsync();
        }

        public async Task<Product> GetProduct(string id) => await _products.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Product>> GetProductsByBrandName(string brandName)
        {
            return await _products.Find(x => x.Brand.Name == brandName).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            return await _products.Find(x => x.Name == name).ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await _products.ReplaceOneAsync(x => x.Id == product.Id, product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
