using Snippet.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Snippet.Common.Parameters;

namespace Snippet.Data.Interfaces.Repositories
{
    public interface ISnippetRepository
    {
        Task<SnippetEntity?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<SnippetEntity> CreateAsync(SnippetEntity entity, CancellationToken ct = default);
        Task<SnippetEntity> UpdateAsync(SnippetEntity entity, CancellationToken ct = default);
        Task<bool> DeleteAsync(long id, CancellationToken ct = default);
        Task<IReadOnlyCollection<SnippetEntity>> GetAllAsync(SnippetPostParams? parameters = default, CancellationToken ct = default);
        Task<int> CountLike(long id, CancellationToken ct = default);
    }
}
