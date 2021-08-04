using System.Collections.Generic;
using Snippet.Data.Entities;
using System.Threading;
using System.Threading.Tasks;
using Snippet.Common.Parameters;

namespace Snippet.Data.Interfaces.Repositories
{
    public interface ILanguageRepository
    {
        Task<LanguageEntity?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<LanguageEntity?> GetByNameAsync(string name, CancellationToken ct = default);
        Task<IEnumerable<LanguageEntity>> GetAllAsync(ParamsBase? parameters = default, CancellationToken ct = default);
        Task<LanguageEntity> CreateAsync(LanguageEntity entity, CancellationToken ct = default);
        Task<LanguageEntity> UpdateAsync(LanguageEntity entity, CancellationToken ct = default);
        Task<bool> DeleteAsync(long id, CancellationToken ct = default);
    }
}
