using Contracts.Repositoies;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SnippetPostRepository: RepositoryBase<SnippetPost>, ISnippetPostRepository
    {
        public SnippetPostRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
