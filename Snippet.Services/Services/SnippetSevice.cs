using Snippet.Common.Parameters;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Interfaces.Service;
using Snippet.Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Services
{
    public class SnippetSevice : ISnippetSevice
    {
        private readonly ISnippetProvider _snippetProvider;
        public SnippetSevice(ISnippetProvider snippetProvider)
        {
            _snippetProvider = snippetProvider;
        }

        public Task<SnippetPost> CreateAsync(SnippetPost model, CancellationToken ct = default)
        {
            return _snippetProvider.CreateAsync(model, ct);
        }

        public Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            return _snippetProvider.DeleteAsync(id, ct);
        }

        public async Task<IReadOnlyCollection<ShortSnippetPost>> GetAllShortAsync(SnippetPostParams? parameters = null, CancellationToken ct = default)
        {
            var shortPosts = await _snippetProvider.GetAllShortAsync(parameters, ct).ConfigureAwait(false);

            foreach(var item in shortPosts)
            {
                item.Like = await _snippetProvider.CountLike(item.Id, ct).ConfigureAwait(false);
            }

            return shortPosts;
        }

        public async Task<SnippetPost?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            var snippetModel = await _snippetProvider.GetByIdAsync(id, ct).ConfigureAwait(false);
            if (snippetModel == null)
            {
                throw new System.NotImplementedException();
            }
            snippetModel.Like = await _snippetProvider.CountLike(id, ct).ConfigureAwait(false);
            return snippetModel;
        }

        public async Task<ShortSnippetPost?> GetShortPostById(long id, CancellationToken ct = default)
        {
            var snippetShortModel = await _snippetProvider.GetShortPostById(id, ct).ConfigureAwait(false);
            if (snippetShortModel == null)
            {
                throw new System.NotImplementedException();
            }
            snippetShortModel.Like = await _snippetProvider.CountLike(id, ct).ConfigureAwait(false);
            return snippetShortModel;
        }

        public Task<SnippetPost> UpdateAsync(SnippetPost model, CancellationToken ct = default)
        {
            return _snippetProvider.CreateAsync(model, ct);
        }
    }
}
