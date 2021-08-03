using Snippet.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Interfaces.Repositories
{
    public interface ITagRepository
    {
        Task<TagEntity?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<TagEntity?> GetByNameAsync(string name, CancellationToken ct = default);
        Task<TagEntity> CreateAsync(TagEntity entity, CancellationToken ct = default);
        Task<TagEntity> UpdateAsync(TagEntity entity, CancellationToken ct = default);
        Task<bool> DeleteAsync(long id, CancellationToken ct = default);
    }
}
