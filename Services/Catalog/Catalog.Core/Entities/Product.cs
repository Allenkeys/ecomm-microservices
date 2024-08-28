using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities;

public class Product : BaseEntity
{
    [BsonElement("Name")]
    public string Name { get; set; }
    public string Description { get; set; }
    [BsonRepresentation(BsonType.Decimal128)]
    public Decimal Price { get; set; }
    public string PictureUrl { get; set; }
    public ProductType ProductType { get; set; }
    public Brand Brand { get; set; }
    public int AvailableStock { get; set; }
}