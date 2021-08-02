using Microsoft.Extensions.DependencyInjection;
using Snippet.Data.Configuration;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Mapping;
using Snippet.Services.Providers;

namespace Snippet.Services.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection RegisterMappingConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(
                //c => c.AddProfile<MappingConfiguration>(),
                typeof(MappingConfiguration));

            return services;
        }

        public static IServiceCollection RegisterProviders(this IServiceCollection services, string connectionString)
        {
            services
                .ConfigureSqlContext(connectionString)
                .RegisterRepositories();

            services.AddScoped<ITagProvider, TagProvider>();
            services.AddScoped<ILanguageProvider, LanguageProvider>();
            services.AddScoped<ISnippetProvider, SnippetProvider>();
            services.AddScoped<IUserProvider, UserProvider>();

            return services;
        }
    }
}
