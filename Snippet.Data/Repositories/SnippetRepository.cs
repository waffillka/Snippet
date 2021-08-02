using Microsoft.EntityFrameworkCore;
using Snippet.Common.Enums;
using Snippet.Data.DbContext;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
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
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == id, ct)!;
        }

        public async Task<IReadOnlyCollection<SnippetEntity>> GetPageAsync(string orderBy, OrderDirection order, int page = 1, int pageSize = 10, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return await GetAllAsync(page, pageSize, ct).ConfigureAwait(false);
            }

            Expression<Func<SnippetEntity, object>> orderByExp;

            orderBy = orderBy.ToUpper(CultureInfo.CurrentCulture);

            if (orderBy == nameof(SnippetEntity.Title).ToUpper(CultureInfo.CurrentCulture))
            {
                orderByExp = entity => entity.Title;
            }
            else if (orderBy == nameof(SnippetEntity.Language).ToUpper(CultureInfo.CurrentCulture))
            {
                orderByExp = entity => entity.Language;
            }
            else if (orderBy == nameof(SnippetEntity.User).ToUpper(CultureInfo.CurrentCulture))
            {
                orderByExp = entity => entity.User;
            }
            else if (orderBy == nameof(SnippetEntity.Date).ToUpper(CultureInfo.CurrentCulture))
            {
                orderByExp = entity => entity.Date;
            }
            else
            {
                return await GetAllAsync(page, pageSize, ct).ConfigureAwait(false);
            }

            if (order == OrderDirection.Asc)
            {
                return await _dbContext.SnippetPosts.OrderBy(orderByExp)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(ct)
                    .ConfigureAwait(false);
            }

            return await _dbContext.SnippetPosts.OrderByDescending(orderByExp)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct)
                .ConfigureAwait(false);
        }

        public async Task<SnippetEntity> UpdateAsync(SnippetEntity entity, CancellationToken ct = default)
        {
            var entityEntry = _dbContext.SnippetPosts.Update(entity);
            return entityEntry.Entity;
        }

        public async Task<IReadOnlyCollection<SnippetEntity>> GetAllAsync(int page = 1, int pageSize = 10, CancellationToken ct = default)
        {
            return await _dbContext.SnippetPosts
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync(ct)
                .ConfigureAwait(false);
        }

        public Task<int> CountLike(long id) /// don't know 
        {
            var like = _dbContext.SnippetPosts.Where(post => post.Id == id).Include(p => p.LikedUser).Select(p => p.LikedUser).Count();
            return Task.FromResult(like);
        }
    }
}
