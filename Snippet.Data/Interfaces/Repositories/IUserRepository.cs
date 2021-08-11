using Snippet.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<UserEntity> GetOrAddAsync(string username, CancellationToken ct = default);
        Task<UserEntity?> GetByNameAsync(string username, CancellationToken ct = default);
        public bool IsOwner(string username);
    }
}
