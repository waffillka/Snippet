using System.Linq;
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
        
        public async Task<UserEntity> GetOrAddAsync(string username, CancellationToken ct = default)
        {
            var result = await GetByNameAsync(username, ct).ConfigureAwait(false);

            result ??= (await _dbContext.Users.AddAsync(new UserEntity() { Username = username }, ct)
                .ConfigureAwait(false)).Entity ;

            return result;
        }

        public async Task<UserEntity?> GetByNameAsync(string username, CancellationToken ct = default, bool tracking = default)
        {
            return tracking
                ? await _dbContext.Users
                    .FirstOrDefaultAsync(user => user.Username == username, ct)
                    .ConfigureAwait(false)
                : await _dbContext.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(user => user.Username == username, ct)
                    .ConfigureAwait(false);
        }

        public async Task<UserEntity?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            return await _dbContext.Users
                 .AsNoTracking()
                 .FirstOrDefaultAsync(user => user.Id == id, ct)
                 .ConfigureAwait(false);
        }

        public bool IsOwner(string username)
        {
            return _dbContext.SnippetPosts
                .Include(snippet => snippet.User)
                .AsNoTracking()
                .Any(snippet => snippet.User.Username == username);
        }
    }
}
