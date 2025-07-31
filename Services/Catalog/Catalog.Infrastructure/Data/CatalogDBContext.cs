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
            var settings = databaseSettings.Value;
            var client = new MongoClient(settings.ConnectionURI);
            var database = client.GetDatabase(settings.DatabaseName);
            Products = database.GetCollection<Product>(settings.ProductCollection);
            ProductTypes = database.GetCollection<ProductType>(settings.ProductTypeCollection);
            Brands = database.GetCollection<Brand>(settings.BrandCollection);
            _ = PopulateDatabase();
        }

        private async Task PopulateDatabase()
        {
            await Task.WhenAll
            (
                ProductContextSeeder.SeedData(Products),
                ProductTypeContextSeeder.SeedData(ProductTypes),
                BrandContextSeeder.SeedData(Brands)
            );
        }
    }
}
