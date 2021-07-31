using Snippet.Common.Enums;
using Snippet.Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Interfaces.Providers
{
    public interface ISnippetProvider
    {
        Task<IReadOnlyCollection<ShortSnippetPost>> GetPageAsync(string orderBy, OrderDirection order, int page = 0, int pageSize = 10, CancellationToken ct = default); //SortDirection
        Task<SnippetPost?> GetByIdAsync(ulong id, CancellationToken ct = default);
        Task<SnippetPost> CreateAsync(SnippetPost model, CancellationToken ct = default);
        Task<SnippetPost> UpdateAsync(SnippetPost model, CancellationToken ct = default);
        Task<bool> DeleteAsync(ulong id, CancellationToken ct = default);
        Task<IReadOnlyCollection<ShortSnippetPost>> GetAllAsync(int page = 1, int pageSize = 10, CancellationToken ct = default);
        Task<int> CountLike(ulong id);
    }
}
