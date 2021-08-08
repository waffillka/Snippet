using System;
using Snippet.Common.Parameters;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Interfaces.Service;
using Snippet.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Snippet.Common.Exceptions;
using Snippet.Services.Parser;

namespace Snippet.Services.Services
{
    public class SnippetService : ISnippetService
    {
        private readonly ISnippetProvider _snippetProvider;
        private readonly ILanguageProvider _languageProvider;
        public SnippetService(ISnippetProvider snippetProvider, ILanguageProvider languageProvider)
        {
            _snippetProvider = snippetProvider;
            _languageProvider = languageProvider;
            
        }

        public async Task<SnippetPost> CreateAsync(SnippetPost? model, CancellationToken ct = default)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (await _languageProvider.GetByIdAsync(model.Id, ct).ConfigureAwait(false) == null)
                throw new ResourceNotFoundException("Language with specified id does not exist.");

            var createdSnippet = await _snippetProvider.CreateAsync(model, ct).ConfigureAwait(false);
            
            return createdSnippet;
        }

        public Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            if (id < 0)
                throw new ResourceNotFoundException("You are trying to find snippet post with deprecated id");
            
            return _snippetProvider.DeleteAsync(id, ct);
        }

        public Task<IReadOnlyCollection<SnippetPost>> GetAllAsync(SnippetPostParams? parameters = null, CancellationToken ct = default)
        {
            return _snippetProvider.GetAllAsync(parameters, ct);
        }

        public Task<IReadOnlyCollection<ShortSnippetPost>> GetAllShortAsync(SnippetPostParams? parameters = null, CancellationToken ct = default)
        {
            return _snippetProvider.GetAllShortAsync(parameters, ct);
        }

        public Task<SnippetPost?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            if (id < 0)
                throw new ResourceNotFoundException("You are trying to find snippet post with deprecated id");
            
            return _snippetProvider.GetByIdAsync(id, ct);
        }

        public Task<ShortSnippetPost?> GetShortPostById(long id, CancellationToken ct = default)
        {
            if (id < 0)
                throw new ResourceNotFoundException("You are trying to find snippet post with deprecated id");

            return _snippetProvider.GetShortPostById(id, ct);
        }

        public async Task<SnippetPost> UpdateAsync(SnippetPost? model, CancellationToken ct = default)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            if (await _languageProvider.GetByIdAsync(model.Id, ct).ConfigureAwait(false) == null)
                throw new ResourceNotFoundException("Language with specified id does not exist.");
            
            return await _snippetProvider.UpdateAsync(model, ct).ConfigureAwait(false);
        }
    }
}
