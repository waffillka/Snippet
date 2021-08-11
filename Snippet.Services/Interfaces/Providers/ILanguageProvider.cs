using Snippet.Common.Parameters;
using Snippet.Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Interfaces.Providers
{
    public interface ILanguageProvider
    {
        Task<Language?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<IReadOnlyCollection<Language>> GetAllAsync(ParamsBase? parameters = default, CancellationToken ct = default);
        Task<Language?> GetByNameAsync(string name, CancellationToken ct = default);
    }
}
