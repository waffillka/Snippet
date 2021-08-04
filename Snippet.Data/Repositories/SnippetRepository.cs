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
            return _dbContext.SnippetPosts
                .Include(x => x.Language)
                .Include(x => x.User).Include(x => x.Tags)
                .Include(x => x.LikedUser)
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == id, ct)!;
        }

        public SnippetEntity Update(SnippetEntity entity, CancellationToken ct = default)
        {
            var entityEntry = _dbContext.SnippetPosts.Update(entity);
            return entityEntry.Entity;
        }

        public async Task<IReadOnlyCollection<SnippetEntity>> GetAllAsync(SnippetPostParams? parameters = default, CancellationToken ct = default)
        {
            var result = _dbContext.SnippetPosts
                .Include(x => x.Language)
                .Include(x => x.User)
                .Include(x => x.Tags)
                .Include(x => x.LikedUser)
                .AsNoTracking();

            parameters ??= new SnippetPostParams();

            if (parameters.Authors != null)
            {
                result = result.Where(snippet => parameters.Authors.Contains(snippet.Id));
            }

            if (parameters.AuthorsExclude != null)
            {
                result = result.Where(snippet => !parameters.AuthorsExclude.Contains(snippet.Id));
            }

            if (parameters.Tags != null)
            {
                result = result.Where(snippet => snippet.Tags!.Select(x => x.Id).Intersect(parameters.Tags).Any());
            }

            if (parameters.TagsExclude != null)
            {                                           //damn...
                result = result.Where(snippet => !snippet.Tags!.Select(x => x.Id).Intersect(parameters.TagsExclude).Any());
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

            if (!string.IsNullOrEmpty(parameters.SortBy))
            {
                switch (parameters.SortBy.ToLower())
                {
                    case "new":
                        result = result.OrderBy(x => x.Date);
                        break;
                    case "old":
                        result = result.OrderByDescending(x => x.Date);
                        break;
                    case "popular":
                        result = result.OrderBy(x => x.LikedUser!.Count);
                        break;
                    case "unpopular":
                        result = result.OrderByDescending(x => x.LikedUser!.Count);
                        break;
                }
            }
            return await result.Skip((parameters.Page - 1) * parameters.PageSize).Take(parameters.PageSize).ToListAsync(ct).ConfigureAwait(false);
        }

        public async Task<int> CountLike(long id, CancellationToken ct = default)
        {
            var like = await _dbContext.SnippetPosts
                .Where(post => post.Id == id)
                .Include(p => p.LikedUser)
                .Select(p => new { Likes = p.LikedUser.Count })
                .ToListAsync(ct)
                .ConfigureAwait(false);

            return like[0].Likes;
        }
    }
}
