using Snippet.Common.Parameters;
using Snippet.Services.Models;
using Snippet.Services.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Interfaces.Service
{
    public interface ISnippetService
    {
        Task<SnippetPost> CreateAsync(SnippetPost? model, string username, CancellationToken ct = default);
        Task<SnippetPost> UpdateAsync(SnippetPost? model, string username, CancellationToken ct = default);
        Task<ShortSnippetPost?> GetShortPostById(long id, CancellationToken ct = default);
        Task<bool> DeleteAsync(long id, string username, CancellationToken ct = default);
        Task<SnippetPost?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<IReadOnlyCollection<ShortSnippetPost>> GetAllShortAsync(SnippetPostParams? parameters = default, CancellationToken ct = default);
        Task<bool> LikeSnippetPost(long postId, string username, CancellationToken ct = default);
    }
}
