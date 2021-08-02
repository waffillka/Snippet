using Microsoft.EntityFrameworkCore;
using Snippet.Data.DbContext;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly SnippetDbContext _dbContext;
        public LanguageRepository(SnippetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LanguageEntity> CreateAsync(LanguageEntity entity, CancellationToken ct = default)
        {
            var entityEntry = await _dbContext.Languages.AddAsync(entity, ct).ConfigureAwait(false);
            return entityEntry.Entity;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            var entity = await GetByIdAsync(id, ct).ConfigureAwait(false);
            if (entity != null)
            {
                var entityEntry = _dbContext.Languages.Remove(entity);
                return entityEntry != null;
            }

            return false;
        }

        public Task<LanguageEntity?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            return _dbContext.Languages
                 .AsNoTracking()
                 .FirstOrDefaultAsync(user => user.Id == id, ct)!;
        }

        public async Task<LanguageEntity> UpdateAsync(LanguageEntity entity, CancellationToken ct = default)
        {
            var entityEntry = _dbContext.Languages.Update(entity);
            return entityEntry.Entity;
        }
    }
}
