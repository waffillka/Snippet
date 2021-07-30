using Microsoft.Extensions.DependencyInjection;
using Snippet.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
