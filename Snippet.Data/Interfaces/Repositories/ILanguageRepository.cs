using Snippet.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Interfaces.Repositories
{
    public interface ILanguageRepository
    {
        Task<LanguageEntity?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<LanguageEntity> CreateAsync(LanguageEntity entity, CancellationToken ct = default);
        Task<LanguageEntity> UpdateAsync(LanguageEntity entity, CancellationToken ct = default);
        Task<bool> DeleteAsync(long id, CancellationToken ct = default);
    }
}
