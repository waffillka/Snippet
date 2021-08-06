using Snippet.Common.Parameters;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Interfaces.Service;
using Snippet.Services.Models;
using Snippet.Services.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Services
{
    public class SnippetService : ISnippetService
    {
        private readonly ISnippetProvider _snippetProvider;
        public SnippetService(ISnippetProvider snippetProvider)
        {
            _snippetProvider = snippetProvider;
        }

        public Task<SnippetPostResponse> CreateAsync(SnippetPost model, CancellationToken ct = default)
        {
            return _snippetProvider.CreateAsync(model, ct);
        }

        public Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            return _snippetProvider.DeleteAsync(id, ct);
        }

        public Task<IReadOnlyCollection<SnippetPostResponse>> GetAllAsync(SnippetPostParams? parameters = null, CancellationToken ct = default)
        {
            return _snippetProvider.GetAllAsync(parameters, ct);
        }

        public Task<IReadOnlyCollection<ShortSnippetPost>> GetAllShortAsync(SnippetPostParams? parameters = null, CancellationToken ct = default)
        {
            return _snippetProvider.GetAllShortAsync(parameters, ct);
        }

        public Task<SnippetPostResponse?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            return _snippetProvider.GetByIdAsync(id, ct);
        }

        public Task<ShortSnippetPost?> GetShortPostById(long id, CancellationToken ct = default)
        {
            return _snippetProvider.GetShortPostById(id, ct);
        }

        public Task<SnippetPostResponse> UpdateAsync(SnippetPost model, CancellationToken ct = default)
        {
            return _snippetProvider.UpdateAsync(model, ct);
        }
    }
}
