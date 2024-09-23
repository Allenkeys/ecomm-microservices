using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories.Implementations;
using Catalog.Infrastructure.Repositories.Interfaces;
using Catalog.Infrastructure.Utilities;

namespace Catalog.API.Configurations
{
    public static class DIContainerConfig
    {
        public static void ConfigureAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection(nameof(MongoDbSettings)));
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICatalogDBContext, CatalogDBContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();

            return services;
        }
    }
}
