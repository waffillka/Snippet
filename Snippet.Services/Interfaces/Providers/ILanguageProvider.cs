using System.Runtime.CompilerServices;
using Snippet.Services.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Snippet.Common.Parameters;

namespace Snippet.Services.Interfaces.Providers
{
    public interface ILanguageProvider
    {
        Task<Language?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<IEnumerable<Language>> GetAllAsync(ParamsBase? parameters = default, CancellationToken ct = default);
        Task<Language> CreateAsync(Language model, CancellationToken ct = default);
        Task<Language?> GetByNameAsync(string name, CancellationToken ct = default);
        Task<Language> UpdateAsync(Language model, CancellationToken ct = default);
        Task<bool> DeleteAsync(long id, CancellationToken ct = default);
    }
}
