using Catalog.Core.Entities;
using Catalog.Infrastructure.Utilities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public class CatalogDBContext : ICatalogDBContext
    {
        public IMongoCollection<Product> Products { get; }
        public IMongoCollection<Brand> Brands { get; }
        public IMongoCollection<ProductType> ProductTypes { get; }

        public CatalogDBContext(IOptions<MongoDbSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionURI);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
            Products = database.GetCollection<Product>(databaseSettings.Value.ProductCollection);
            ProductTypes = database.GetCollection<ProductType>(databaseSettings.Value.ProductTypeCollection);
            Brands = database.GetCollection<Brand>(databaseSettings.Value.BrandCollection);
            _ = PopulateDatabase();
        }

        private async Task PopulateDatabase()
        {
            await Task.WhenAll
                (
                    ProductContextSeeder.SeedData(Products),
                    ProductTypeContextSeeder.SeedData(ProductTypes),
                    BrandContextSeeder.SeedData(Brands)
                ).ConfigureAwait(false);
        }
    }
}
