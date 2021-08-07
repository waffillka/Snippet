using Snippet.Common.Parameters;
using Snippet.Services.Models;
using Snippet.Services.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Interfaces.Providers
{
    public interface ISnippetProvider
    {
        Task<SnippetPost?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<ShortSnippetPost?> GetShortPostById(long id, CancellationToken ct = default);
        Task<SnippetPost> CreateAsync(SnippetPost model, CancellationToken ct = default);
        Task<SnippetPost> UpdateAsync(SnippetPost model, CancellationToken ct = default);
        Task<bool> DeleteAsync(long id, CancellationToken ct = default);
        Task<IReadOnlyCollection<ShortSnippetPost>> GetAllShortAsync(SnippetPostParams? parameters = default, CancellationToken ct = default);
        Task<IReadOnlyCollection<SnippetPost>> GetAllAsync(SnippetPostParams? parameters = default, CancellationToken ct = default);
        Task<int> CountLike(long id, CancellationToken ct = default);
    }
}
