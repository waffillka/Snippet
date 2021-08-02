using Snippet.Common.Enums;
using Snippet.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Interfaces.Repositories
{
    public interface ISnippetRepository
    {
        Task<IReadOnlyCollection<SnippetEntity>> GetPageAsync(string orderBy, OrderDirection order, int page, int pageSize, CancellationToken ct = default); //SortDirection
        Task<SnippetEntity?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<SnippetEntity> CreateAsync(SnippetEntity entity, CancellationToken ct = default);
        Task<SnippetEntity> UpdateAsync(SnippetEntity entity, CancellationToken ct = default);
        Task<bool> DeleteAsync(long id, CancellationToken ct = default);
        Task<IReadOnlyCollection<SnippetEntity>> GetAllAsync(int page = 1, int pageSize = 10, CancellationToken ct = default);
        Task<int> CountLike(long id);
    }
}
