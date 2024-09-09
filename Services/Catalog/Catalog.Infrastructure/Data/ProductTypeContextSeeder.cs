using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public static class ProductTypeContextSeeder
    {
        public static async Task SeedBrand(IMongoCollection<ProductType> typeCollection)
        {
            bool existingType = typeCollection.Find(x => true).Any();
            if (!existingType)
            {
                string path = Path.Combine("Data", "SeedData", "ProductTypes.json") ?? "";

                bool pathExists = File.Exists(path);

                if (!pathExists)
                {
                    return;
                }

                var rawData = File.ReadAllText(path);

                var types = JsonSerializer.Deserialize<IEnumerable<ProductType>>(rawData) ?? Enumerable.Empty<ProductType>();

                await typeCollection.InsertManyAsync(types);
            }
        }
    }
}
