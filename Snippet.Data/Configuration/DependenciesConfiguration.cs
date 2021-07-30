using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Snippet.Data.DbContext;
using Snippet.Data.Interfaces.Repositories;
using Snippet.Data.Repositories;

namespace Snippet.Data.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection ConfigureSqlContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SnippetDbContext>(opts =>
                opts.UseSqlServer(connectionString, b => b.MigrationsAssembly("Snippet.Data")));

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISnippetRepository, SnippetRepository>();

            return serviceCollection;
        }
    }
}
