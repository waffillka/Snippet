using Snippet.Common.Parameters;
using Snippet.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Interfaces.Repositories
{
    public interface ILanguageRepository
    {
        Task<LanguageEntity?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<LanguageEntity?> GetByNameAsync(string name, CancellationToken ct = default);
        Task<IReadOnlyCollection<LanguageEntity>> GetAllAsync(ParamsBase? parameters = default, CancellationToken ct = default);
        Task<LanguageEntity> CreateAsync(LanguageEntity entity, CancellationToken ct = default);
        LanguageEntity Update(LanguageEntity entity);
        Task<bool> DeleteAsync(long id, CancellationToken ct = default);
    }
}
