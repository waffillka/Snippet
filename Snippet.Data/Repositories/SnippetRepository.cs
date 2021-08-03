using Microsoft.EntityFrameworkCore;
using Snippet.Common.Enums;
using Snippet.Data.DbContext;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Snippet.Common.Parameters;

namespace Snippet.Data.Repositories
{
    public class SnippetRepository : ISnippetRepository
    {
        private readonly SnippetDbContext _dbContext;
        public SnippetRepository(SnippetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SnippetEntity> CreateAsync(SnippetEntity entity, CancellationToken ct = default)
        {
            var entityEntry = await _dbContext.SnippetPosts.AddAsync(entity, ct).ConfigureAwait(false);
            return entityEntry.Entity;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            var entity = await GetByIdAsync(id, ct).ConfigureAwait(false);
            if (entity != null)
            {
                var entityEntry = _dbContext.SnippetPosts.Remove(entity);
                return entityEntry != null;
            }

            return false;
        }

        public Task<SnippetEntity?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            return _dbContext.SnippetPosts.Include(x => x.Language).Include(x => x.User).Include(x => x.Tags)
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == id, ct)!;
        }
        
        public async Task<SnippetEntity> UpdateAsync(SnippetEntity entity, CancellationToken ct = default)
        {
            var entityEntry = _dbContext.SnippetPosts.Update(entity);
            return entityEntry.Entity;
        }

        public async Task<IReadOnlyCollection<SnippetEntity>> GetAllAsync(SnippetPostParams? parameters = default, CancellationToken ct = default)
        {
            var result = _dbContext.SnippetPosts.Include(x => x.Language)
                .Include(x => x.User)
                .Include(x => x.Tags)
                .AsNoTracking();

            parameters ??= new SnippetPostParams();
            
            if(parameters.Authors != null)
            {
                result = result.Where(snippet => parameters.Authors.Contains(snippet.Id));
            }
            
            if (parameters.AuthorsExclude != null)
            {
                result = result.Where(snippet => !parameters.AuthorsExclude.Contains(snippet.Id));
            }

            if (parameters.Tags != null)
            {
                result = result.Where(snippet => snippet.Tags!.Select(x=> x.Id).Intersect(parameters.Tags).Any());
            }

            if (parameters.TagsExclude != null)
            {                                           //damn...
                result = result.Where(snippet => !snippet.Tags!.Select(x=> x.Id).Intersect(parameters.TagsExclude).Any());
            }

            if (parameters.CreationDate != default)
            {
                result = result.Where(snippet => snippet.Date == parameters.CreationDate);
            }
            else if (parameters.From != default && parameters.To != default)
            {
                result = result.Where(snippet => snippet.Date >= parameters.From && snippet.Date <= parameters.To);
            }

            if (!string.IsNullOrEmpty(parameters.MatchString))
            {
                result = result.Where(snippet => snippet.Title.Contains(parameters.MatchString)
                                            || snippet.Description.Contains(parameters.MatchString)
                                            || snippet.Snippet.Contains(parameters.MatchString));
            }

            switch (parameters.OrderBy)
            {
                case "Id":
                    result = parameters.OrderDirection == OrderDirection.Asc
                        ? result.OrderBy(x => x.Id)
                        : result.OrderByDescending(x => x.Id);
                    break;
                case "Date":
                    result = parameters.OrderDirection == OrderDirection.Asc
                        ? result.OrderBy(x => x.Date)
                        : result.OrderByDescending(x => x.Date);
                    break;
                case "Likes":
                    result = parameters.OrderDirection == OrderDirection.Asc
                        ? result.OrderBy(x => x.LikedUser!.Count)
                        : result.OrderByDescending(x => x.LikedUser!.Count);
                    break;
            }
            
            return await result.Skip((parameters.Page-1)*parameters.PageSize).Take(parameters.PageSize).ToListAsync(ct).ConfigureAwait(false);
        }

        public async Task<int> CountLike(long id, CancellationToken ct = default) 
        {
            var user = await GetByIdAsync(id, ct).ConfigureAwait(false);
            return user?.LikedUser?.Count ?? 0;
        }
    }
}
