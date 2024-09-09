namespace Catalog.Infrastructure.Utilities
{
    public class MongoDbSettings
    {
        public string ConnectionURI { get; set; }
        public string DatabaseName { get; set; }
        public string ProductCollection { get; set; }
        public string ProductTypeCollection { get; set; }
        public string BrandCollection { get; set; }
    }
}
