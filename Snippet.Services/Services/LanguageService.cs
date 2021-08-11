using Snippet.Common.Exceptions;
using Snippet.Common.Parameters;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Interfaces.Service;
using Snippet.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
            if (id < 0)
                throw new ResourceNotFoundException("You are trying to find language with deprecated id");
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

        public Task<Language> CreateAsync(Language? model, CancellationToken ct = default)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return _provider.CreateAsync(model, ct);
        }

        public Task<Language?> UpdateAsync(Language? model, CancellationToken ct = default)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return _provider.UpdateAsync(model, ct);
        }

        public Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            if (id < 0)
                throw new ResourceNotFoundException("You are trying to find language with deprecated id");

            return _provider.DeleteAsync(id, ct);
        }
    }
}