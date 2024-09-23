using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Application.DTOs
{
    public class ProductTypeResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
