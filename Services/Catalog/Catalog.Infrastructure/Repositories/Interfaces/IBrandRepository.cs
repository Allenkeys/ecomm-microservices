using Catalog.Core.Entities;

namespace Catalog.Infrastructure.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetAllBrands();
    }
}
