using Snippet.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Interfaces.Repositories
{
    public interface ITagRepository
    {
        Task<TagEntity?> GetByIdAsync(ulong id, CancellationToken ct = default);
        Task<TagEntity> CreateAsync(TagEntity entity, CancellationToken ct = default);
        Task<TagEntity> UpdateAsync(TagEntity entity, CancellationToken ct = default);
        Task<bool> DeleteAsync(ulong id, CancellationToken ct = default);
    }
}
