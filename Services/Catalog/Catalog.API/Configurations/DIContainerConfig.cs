using Catalog.Infrastructure.Utilities;

namespace Catalog.API.Configurations
{
    public static class DIContainerConfig
    {
        public static void ConfigureAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection(nameof(MongoDbSettings)));
        }
    }
}
