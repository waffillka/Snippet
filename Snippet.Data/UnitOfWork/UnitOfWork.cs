using Snippet.Data.DbContext;
using Snippet.Data.Interfaces.Repositories;
using Snippet.Data.Interfaces.UnitOfWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SnippetDbContext _dbContext;

        public UnitOfWork(SnippetDbContext dbContext, ISnippetRepository snippetRepository, ILanguageRepository languageRepository, ITagRepository tagRepository)
        {
            _dbContext = dbContext;
            Snippets = snippetRepository;
            Language = languageRepository;
            Tags = tagRepository;
        }

        public ISnippetRepository Snippets { get; }

        public ILanguageRepository Language { get; }

        public ITagRepository Tags { get; }

        public Task SaveChangesAsync(CancellationToken ct = default)
        {
            return _dbContext.SaveChangesAsync(ct);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
