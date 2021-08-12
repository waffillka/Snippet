using Snippet.Services.Models;
using Snippet.Services.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Interfaces.Providers
{
    public interface IUserProvider
    {
        Task<User?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<User?> GetByNameAsync(string username, CancellationToken ct = default);
        Task<User> GetOrAddAsync(string username, CancellationToken ct = default);
    }
}
