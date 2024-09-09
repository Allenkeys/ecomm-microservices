using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public interface ICatalogDBContext
    {
        IMongoCollection<Product> Products { get; }
        IMongoCollection<ProductType> ProductTypes { get; }
        IMongoCollection<Brand> Brands { get; }
    }
}
