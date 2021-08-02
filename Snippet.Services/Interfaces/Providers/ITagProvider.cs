using Snippet.Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Interfaces.Providers
{
    public interface ITagProvider
    {
        Task<Tag?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<Tag> CreateAsync(Tag model, CancellationToken ct = default);
        Task<Tag> UpdateAsync(Tag model, CancellationToken ct = default);
        Task<bool> DeleteAsync(long id, CancellationToken ct = default);
    }
}
