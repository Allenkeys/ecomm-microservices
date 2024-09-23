using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public static class ProductContextSeeder
    {
        public static async Task SeedData(IMongoCollection<Product> productCollection)
        {
            bool existingProduct = productCollection.Find(x => true).Any();
            if (!existingProduct)
            {
                string path = Path.Combine("Data", "SeedData", "Products.json") ?? "";

                bool pathExists = File.Exists(path);

                if (!pathExists)
                {
                    return;
                }

                var rawData = File.ReadAllText(path);

                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(rawData) ?? Enumerable.Empty<Product>();

                await productCollection.InsertManyAsync(products);
            }
        }
    }
}
