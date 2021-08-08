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
    public class LanguageRepository : ILanguageRepository
    {
        private readonly SnippetDbContext _dbContext;
        public LanguageRepository(SnippetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LanguageEntity?> GetByNameAsync(string name, CancellationToken ct = default)
        {
            return await _dbContext.Languages.AsNoTracking()
                .FirstOrDefaultAsync(lang => lang.ExtraName == name, ct)
                .ConfigureAwait(false);
        }
        
        public Task<LanguageEntity?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            return _dbContext.Languages
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == id, ct)!;
        }

        public async Task<IReadOnlyCollection<LanguageEntity>> GetAllAsync(ParamsBase? parameters = default, CancellationToken ct = default)
        {
            var result = _dbContext.Languages
                .Include(x => x.SnippetPosts)
                .AsNoTracking();

            parameters ??= new ParamsBase();

            if (!string.IsNullOrEmpty(parameters.SortOption))
            {
                switch (parameters.SortOption.ToLower())
                {
                    case "popular":
                        result = result.OrderByDescending(x => x.SnippetPosts.Count);
                        break;
                    case "unpopular":
                        result = result.OrderBy(x => x.SnippetPosts.Count);
                        break;
                    case "abc":
                        result = result.OrderBy(x => x.Name);
                        break;
                }
            }

            result = result.Skip((parameters.Page - 1) * parameters.PageSize)
                .Take(parameters.PageSize);

            return await result.ToListAsync(ct).ConfigureAwait(false);
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

        public LanguageEntity Update(LanguageEntity entity)
        {
            var entityEntry = _dbContext.Languages.Update(entity);
            return entityEntry.Entity;
        }
    }
}
