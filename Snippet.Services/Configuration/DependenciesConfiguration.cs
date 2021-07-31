using Microsoft.Extensions.DependencyInjection;
using Snippet.Data.Configuration;
using Snippet.Services.Mapping;

namespace Snippet.Services.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection RegisterMappingConfig(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(
                c => c.AddProfile<MappingConfiguration>(),
                typeof(MappingConfiguration));

            return serviceCollection;
        }

        public static IServiceCollection RegisterProviders(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection
                .ConfigureSqlContext(connectionString)
                .RegisterRepositories();

            return serviceCollection;
        }
    }
}
