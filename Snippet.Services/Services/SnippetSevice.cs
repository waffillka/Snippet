using Snippet.Common.Parameters;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Interfaces.Service;
using Snippet.Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Snippet.Services.Parser;

namespace Snippet.Services.Services
{
    public class SnippetSevice : ISnippetSevice
    {
        private readonly ISnippetProvider _snippetProvider;
        private readonly ITagParser _parser;
        public SnippetSevice(ISnippetProvider snippetProvider, ITagParser parser)
        {
            _snippetProvider = snippetProvider;
            _parser = parser;
        }

        public async Task<SnippetPost> CreateAsync(SnippetPost model, CancellationToken ct = default)
        {
            var tags = await _parser.GetTags(model.Snippet, ct).ConfigureAwait(false);
            model.Tags = tags;
            return await _snippetProvider.CreateAsync(model, ct).ConfigureAwait(false);
        }

        public Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            return _snippetProvider.DeleteAsync(id, ct);
        }

        public async Task<IReadOnlyCollection<SnippetPost>> GetAllAsync(SnippetPostParams? parameters = null, CancellationToken ct = default)
        {
            var posts = await _snippetProvider.GetAllAsync(parameters, ct).ConfigureAwait(false);

            return posts;
        }

        public async Task<IReadOnlyCollection<ShortSnippetPost>> GetAllShortAsync(SnippetPostParams? parameters = null, CancellationToken ct = default)
        {
            var shortPosts = await _snippetProvider.GetAllShortAsync(parameters, ct).ConfigureAwait(false);

            return shortPosts;
        }

        public async Task<SnippetPost?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            var snippetModel = await _snippetProvider.GetByIdAsync(id, ct).ConfigureAwait(false);
            if (snippetModel == null)
            {
                throw new System.NotImplementedException();
            }
            return snippetModel;
        }

        public async Task<ShortSnippetPost?> GetShortPostById(long id, CancellationToken ct = default)
        {
            var snippetShortModel = await _snippetProvider.GetShortPostById(id, ct).ConfigureAwait(false);
            if (snippetShortModel == null)
            {
                throw new System.NotImplementedException();
            }

            return snippetShortModel;
        }

        public Task<SnippetPost> UpdateAsync(SnippetPost model, CancellationToken ct = default)
        {
            return _snippetProvider.CreateAsync(model, ct);
        }
    }
}
