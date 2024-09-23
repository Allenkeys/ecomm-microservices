using Catalog.Core.Entities;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories.Interfaces;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories.Implementations
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly IMongoCollection<ProductType> _types;

        public ProductTypeRepository(ICatalogDBContext context)
        {
            _types = context.ProductTypes;
        }
        public async Task<IEnumerable<ProductType>> GetAllTypes()
        {
            return await _types.Find(x => true).ToListAsync();
        }
    }
}
