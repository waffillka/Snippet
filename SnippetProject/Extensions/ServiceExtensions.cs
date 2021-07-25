using Contracts.LoggerService;
using LoggerService;
using Microsoft.Extensions.DependencyInjection;

namespace SnippetProject.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();
    }
}
