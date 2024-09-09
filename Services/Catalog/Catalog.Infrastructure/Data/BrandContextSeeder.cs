using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public static class BrandContextSeeder
    {
        public static async Task SeedBrand(IMongoCollection<Brand> brandCollection)
        {
            bool existingBrand = brandCollection.Find(x => true).Any();
            if (!existingBrand)
            {
                string path = Path.Combine("Data", "SeedData", "Brands.json") ?? "";

                bool pathExists = File.Exists(path);

                if (!pathExists)
                {
                    return;
                }

                var rawData = File.ReadAllText(path);

                var brands = JsonSerializer.Deserialize<IEnumerable<Brand>>(rawData) ?? Enumerable.Empty<Brand>();

                await brandCollection.InsertManyAsync(brands);
            }
        }
    }
}
