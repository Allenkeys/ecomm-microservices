using Catalog.Core.Entities;

namespace Catalog.Infrastructure.Repositories.Interfaces
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<ProductType>> GetAllTypes();
    }
}
