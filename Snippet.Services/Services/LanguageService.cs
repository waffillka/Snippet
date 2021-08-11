using System;
using Snippet.Common.Parameters;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Interfaces.Service;
using Snippet.Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Snippet.Common.Exceptions;

namespace Snippet.Services.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageProvider _provider;

        public LanguageService(ILanguageProvider provider)
        {
            _provider = provider;
        }

        public Task<Language?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            return _provider.GetByIdAsync(id, ct);
        }

        public Task<Language?> GetByNameAsync(string name, CancellationToken ct = default)
        {
            return _provider.GetByNameAsync(name, ct);
        }
        
        public Task<IReadOnlyCollection<Language>> GetAllAsync(ParamsBase? parameters = null, CancellationToken ct = default)
        {
            return _provider.GetAllAsync(parameters, ct);
        }
    }
}