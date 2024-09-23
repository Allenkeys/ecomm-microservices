using Catalog.Core.Entities;

namespace Catalog.Infrastructure.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllBrands();
    }
}
