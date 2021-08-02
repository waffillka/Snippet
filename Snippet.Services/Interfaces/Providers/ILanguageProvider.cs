using Snippet.Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Interfaces.Providers
{
    public interface ILanguageProvider
    {
        Task<Language?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<Language> CreateAsync(Language model, CancellationToken ct = default);
        Task<Language> UpdateAsync(Language model, CancellationToken ct = default);
        Task<bool> DeleteAsync(long id, CancellationToken ct = default);
    }
}
