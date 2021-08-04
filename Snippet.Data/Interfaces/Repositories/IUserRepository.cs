using Snippet.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> GetByIdAsync(long id, CancellationToken ct = default);
        Task<UserEntity> CreateAsync(UserEntity entity, CancellationToken ct = default);
        UserEntity UpdateAsync(UserEntity entity);
        Task<bool> DeleteAsync(long id, CancellationToken ct = default);
    }
}
