using Snippet.Services.Interfaces.Service;
using Snippet.Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Services
{
    public class SnippetSevice : ISnippetSevice
    {
        public SnippetSevice()
        {

        }

        public Task<SnippetPost> CreateAsync(SnippetPost model, CancellationToken ct = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(ulong id, CancellationToken ct = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<SnippetPost> UpdateAsync(SnippetPost model, CancellationToken ct = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
