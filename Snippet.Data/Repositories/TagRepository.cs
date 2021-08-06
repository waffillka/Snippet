using Microsoft.EntityFrameworkCore;
using Snippet.Common.Parameters;
using Snippet.Data.DbContext;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<TagEntity?> GetByNameAsync(string name, CancellationToken ct = default)
        {
            return await _dbContext.Tags
                .AsNoTracking()
                .FirstOrDefaultAsync(tag => tag.Name == name, ct)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<TagEntity>> GetAllAsync(ParamsBase? parameters = default, CancellationToken ct = default)
        {
            var result = _dbContext.Tags
                .Include(x => x.SnippetPosts)
                .AsNoTracking();

            parameters ??= new ParamsBase();

            if (!string.IsNullOrEmpty(parameters.SortOptions))
            {
                switch (parameters.SortOptions.ToLower())
                {
                    case "popular":
                        result = result.OrderBy(x => x.SnippetPosts.Count);
                        break;
                    case "unpopular":
                        result = result.OrderByDescending(x => x.SnippetPosts.Count);
                        break;
                    case "abc":
                        result = result.OrderBy(x => x.Name);
                        break;
                }
            }

            result = result.Skip((parameters.Page - 1) * parameters.PageSize).Take(parameters.PageSize);

            return await result.ToListAsync(cancellationToken: ct).ConfigureAwait(false);
        }

        public async Task<TagEntity> CreateAsync(TagEntity entity, CancellationToken ct = default)
        {
            var entityEntry = await _dbContext.Tags.AddAsync(entity, ct).ConfigureAwait(false);
            return entityEntry.Entity;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            var entity = await GetByIdAsync(id, ct).ConfigureAwait(false);
            if (entity != null)
            {
                var entityEntry = _dbContext.Tags.Remove(entity);
                return entityEntry != null;
            }

            return false;
        }

        public Task<TagEntity?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            return _dbContext.Tags
                 .AsNoTracking()
                 .FirstOrDefaultAsync(user => user.Id == id, ct)!;
        }

        public TagEntity Update(TagEntity entity)
        {
            var entityEntry = _dbContext.Tags.Update(entity);
            return entityEntry.Entity;
        }
        
        public async Task<ICollection<TagEntity>> GetByNamesAsync(IEnumerable<string> names, CancellationToken ct = default)
        {
            var result = _dbContext.Tags
                .AsNoTracking()
                .Where(tag => names.Contains(tag.Name));
            
            return await result.ToListAsync(ct).ConfigureAwait(false);
        }
    }
}
