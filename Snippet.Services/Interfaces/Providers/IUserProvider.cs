using Snippet.Services.Models;
using Snippet.Services.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Interfaces.Providers
{
    public interface IUserProvider
    {
        Task<UserResponse?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<User> CreateAsync(User model, CancellationToken ct = default);
        Task<UserResponse> UpdateAsync(User model, CancellationToken ct = default);
        Task<bool> DeleteAsync(long id, CancellationToken ct = default);
    }
}
