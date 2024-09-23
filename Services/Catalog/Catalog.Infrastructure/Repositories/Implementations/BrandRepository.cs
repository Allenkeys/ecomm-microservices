using Catalog.Core.Entities;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories.Interfaces;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories.Implementations
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IMongoCollection<Brand> _brands;

        public BrandRepository(ICatalogDBContext context)
        {
            _brands = context.Brands;
        }
        public async Task<IEnumerable<Brand>> GetAllBrands()
        {
            return await _brands.Find(x => true).ToListAsync();
        }
    }
}
