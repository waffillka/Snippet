using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Snippet.Data.DbContext;

namespace Snippet.Data.Configuration
{
    public static class DependenciesConfiguration
    {
        public static void ConfigureSqlContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<SnippetDbContext>(opts =>
                opts.UseSqlServer(connectionString, b => b.MigrationsAssembly("Snippet.Data")));
    }
}
