using Snippet.Common.Parameters;
using Snippet.Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Interfaces.Providers
{
    public interface ITagProvider
    {
        Task<Tag?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<IReadOnlyCollection<Tag>> GetAllAsync(ParamsBase? parameters, CancellationToken ct = default);
        Task<Tag?> GetByNameAsync(string name, CancellationToken ct = default);
        Task<Tag> CreateAsync(Tag model, CancellationToken ct = default);
        Task<Tag?> UpdateAsync(Tag model, CancellationToken ct = default);
        Task<bool> DeleteAsync(long id, CancellationToken ct = default);
        Task<IReadOnlyCollection<Tag>> GetRangeByNameAsync(IEnumerable<string> names, CancellationToken ct = default);
        Task AddRangeAsync(IEnumerable<string> names, CancellationToken ct = default);
        Task<IReadOnlyCollection<Tag>> GetOrAddRangeAsync(IEnumerable<string> names, CancellationToken ct = default);
    }
}
