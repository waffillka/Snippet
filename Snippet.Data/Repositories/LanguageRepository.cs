using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Snippet.Data.DbContext;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Snippet.Common.Enums;
using Snippet.Common.Parameters;

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
                .FirstOrDefaultAsync(lang => lang.Name == name, ct)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<LanguageEntity>> GetAllAsync(ParamsBase? parameters = default, CancellationToken ct = default)
        {
            var result = _dbContext.Languages.AsNoTracking();

            parameters ??= new ParamsBase();
            
            if (!string.IsNullOrEmpty(parameters.OrderBy))
            {
                switch (parameters.OrderBy)
                {
                    case "Id":
                        result = parameters.OrderDirection == OrderDirection.Asc
                            ? result.OrderBy(x => x.Id)
                            : result.OrderByDescending(x => x.Id);
                        break;
                    case "Name":
                        result = parameters.OrderDirection == OrderDirection.Asc
                            ? result.OrderBy(x => x.Name)
                            : result.OrderByDescending(x => x.Name);
                        break;
                    case "Likes":
                        result = parameters.OrderDirection == OrderDirection.Asc
                            ? result.OrderBy(x => x.SnippetPosts.Count)
                            : result.OrderByDescending(x => x.SnippetPosts.Count);
                        break;
                }
            }
            
            result = result.Skip(parameters.Page * parameters.PageSize).Take(parameters.PageSize);

            return await result.ToListAsync(ct);
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
