using Snippet.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Interfaces.Repositories
{
    public interface ILanguageRepository
    {
        Task<LanguageEntity?> GetByIdAsync(ulong id, CancellationToken ct = default);
        Task<LanguageEntity> CreateAsync(LanguageEntity entity, CancellationToken ct = default);
        Task<LanguageEntity> UpdateAsync(LanguageEntity entity, CancellationToken ct = default);
        Task<bool> DeleteAsync(ulong id, CancellationToken ct = default);
    }
}
