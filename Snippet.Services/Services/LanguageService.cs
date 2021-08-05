using System.Threading;
using System.Threading.Tasks;
using Snippet.Services.Interfaces.Service;
using Snippet.Services.Models;
using Snippet.Services.Providers;

namespace Snippet.Services.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly LanguageProvider _provider;

        public LanguageService(LanguageProvider provider)
        {
            _provider = provider;
        }

        public Task<Language?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            return _provider.GetByIdAsync(id, ct);
        }

        public Task<Language> CreateAsync(Language model, CancellationToken ct = default)
        {
            return _provider.CreateAsync(model, ct);
        }

        public Task<Language> UpdateAsync(Language model, CancellationToken ct = default)
        {
            return _provider.UpdateAsync(model, ct);
        }

        public Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            return _provider.DeleteAsync(id, ct);
        }
    }
}