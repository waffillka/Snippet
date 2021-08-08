using Snippet.Common.Parameters;
using Snippet.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Interfaces.Repositories
{
    public interface ISnippetRepository
    {
        Task<SnippetEntity?> GetByIdAsync(long id, CancellationToken ct = default, bool tracking = false);
        Task<IReadOnlyCollection<SnippetEntity>> GetAllAsync(SnippetPostParams? parameters = default, CancellationToken ct = default);
        Task<SnippetEntity> CreateAsync(SnippetEntity entity, CancellationToken ct = default);
        SnippetEntity Update(SnippetEntity entity);
        Task<bool> DeleteAsync(long id, CancellationToken ct = default);
        Task<int> CountLike(long id, CancellationToken ct = default);
    }
}
