using Snippet.Common.Parameters;
using Snippet.Services.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Snippet.Services.Interfaces.Service
{
    public interface ISnippetSevice
    {
        Task<SnippetPost> CreateAsync(SnippetPost model, CancellationToken ct = default);
        Task<SnippetPost> UpdateAsync(SnippetPost model, CancellationToken ct = default);
        Task<ShortSnippetPost?> GetShortPostById(long id, CancellationToken ct = default);
        Task<bool> DeleteAsync(long id, CancellationToken ct = default);
        Task<SnippetPost?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<IReadOnlyCollection<ShortSnippetPost>> GetAllShortAsync(SnippetPostParams? parameters = default, CancellationToken ct = default);
    }
}
