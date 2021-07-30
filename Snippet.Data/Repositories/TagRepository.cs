using Microsoft.EntityFrameworkCore;
using Snippet.Data.DbContext;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly SnippetDbContext _dbContext;
        public TagRepository(SnippetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TagEntity> CreateAsync(TagEntity entity, CancellationToken ct = default)
        {
            var entityEntry = await _dbContext.Tags.AddAsync(entity, ct).ConfigureAwait(false);
            return entityEntry.Entity;
        }

        public async Task<bool> DeleteAsync(ulong id, CancellationToken ct = default)
        {
            var entity = await GetByIdAsync(id, ct).ConfigureAwait(false);
            if (entity != null)
            {
                var entityEntry = _dbContext.Tags.Remove(entity);
                return entityEntry != null;
            }

            return false;
        }

        public Task<TagEntity?> GetByIdAsync(ulong id, CancellationToken ct = default)
        {
            return _dbContext.Tags
                 .AsNoTracking()
                 .FirstOrDefaultAsync(user => user.Id == id, ct)!;
        }

        public async Task<TagEntity> UpdateAsync(TagEntity entity, CancellationToken ct = default)
        {
            var entityEntry = _dbContext.Tags.Update(entity);
            return entityEntry.Entity;
        }
    }
}
