using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Snippet.Data.DbContext;
using Snippet.Data.Interfaces.Repositories;
using Snippet.Data.Interfaces.UnitOfWork;
using Snippet.Data.Repositories;

namespace Snippet.Data.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection ConfigureSqlContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SnippetDbContext>(opts =>
                opts.UseSqlServer(connectionString, b => b.MigrationsAssembly("SnippetProject")));

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISnippetRepository, SnippetRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}
