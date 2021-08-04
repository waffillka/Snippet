using Microsoft.EntityFrameworkCore;
using Snippet.Data.DbContext;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SnippetDbContext _dbContext;
        public UserRepository(SnippetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserEntity> CreateAsync(UserEntity entity, CancellationToken ct = default)
        {
            var entityEntry = await _dbContext.Users.AddAsync(entity, ct).ConfigureAwait(false);
            return entityEntry.Entity;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            var entity = await GetByIdAsync(id, ct).ConfigureAwait(false);
            if (entity != null)
            {
                var entityEntry = _dbContext.Users.Remove(entity);
                return entityEntry != null;
            }

            return false;
        }

        public Task<UserEntity> GetByIdAsync(long id, CancellationToken ct = default)
        {
            return _dbContext.Users
                 .AsNoTracking()
                 .FirstOrDefaultAsync(user => user.Id == id, ct);
        }

        public UserEntity UpdateAsync(UserEntity entity)
        {
            var entityEntry = _dbContext.Users.Update(entity);
            return entityEntry.Entity;
        }
    }
}
