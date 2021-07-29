using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snippet.Data.Repositories
{
    public class SnippetRepository : ISnippetRepository
    {
        public Task<SnippetEntity> GetById(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<SnippetEntity>> GetPage(string orderBy, int page = 0, int pageSize = 10)
        {
            throw new NotImplementedException();
        }
    }
}
