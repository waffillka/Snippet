using Snippet.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snippet.Data.Interfaces.Repositories
{
    public interface ISnippetRepository
    {
        Task<IReadOnlyList<SnippetEntity>> GetPage(string orderBy, int page = 0, int pageSize = 10); //SortDirection
        Task<SnippetEntity> GetById(ulong id);
    }
}
