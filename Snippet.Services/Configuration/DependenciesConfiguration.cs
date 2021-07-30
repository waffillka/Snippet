using Microsoft.Extensions.DependencyInjection;
using Snippet.Data.Configuration;

namespace Snippet.Services.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection RegisterProviders(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection
                .ConfigureSqlContext(connectionString)
                .RegisterRepositories();

            return serviceCollection;
        }
    }
}
