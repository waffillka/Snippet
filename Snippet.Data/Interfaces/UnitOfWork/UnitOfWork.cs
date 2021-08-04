using Snippet.Data.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        ISnippetRepository Snippets { get; }
        ILanguageRepository Language { get; }
        ITagRepository Tags { get; }
        IUserRepository Users { get; }
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
