using System;
using Snippet.Common.Parameters;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Interfaces.Service;
using Snippet.Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Snippet.Common.Exceptions;

namespace Snippet.Services.Services
{
    public class SnippetService : ISnippetService
    {
        private readonly ISnippetProvider _snippetProvider;
        private readonly ILanguageProvider _languageProvider;
        private readonly IUserProvider _userProvider;
        public SnippetService(ISnippetProvider snippetProvider, ILanguageProvider languageProvider, IUserProvider userProvider)
        {
            _snippetProvider = snippetProvider;
            _languageProvider = languageProvider;
            _userProvider = userProvider;
        }

        public async Task<SnippetPost> CreateAsync(SnippetPost? model, string username, CancellationToken ct = default)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (await _languageProvider.GetByIdAsync(model.LanguageId, ct).ConfigureAwait(false) == null)
                throw new ResourceNotFoundException("Language with specified id does not exist.");

            var user = await _userProvider
                .GetOrAddAsync(username, ct)
                .ConfigureAwait(false);

            model.UserId = user.Id;

            var createdSnippet = await _snippetProvider.CreateAsync(model, ct).ConfigureAwait(false);

            return createdSnippet;
        }

        public async Task<bool> DeleteAsync(long id, string username, CancellationToken ct = default)
        {
            var post = await GetByIdAsync(id, ct).ConfigureAwait(false);

            if (post == null)
                throw new ResourceNotFoundException("Snippet post specified id does not exist.");

            var user = await _userProvider
                .GetByNameAsync(username, ct)
                .ConfigureAwait(false);

            if (user == null)
                throw new DeprecatedOperationException("You don't have permission to perform this operation");

            return await _snippetProvider.DeleteAsync(id, ct).ConfigureAwait(false);
        }

        public Task<IReadOnlyCollection<ShortSnippetPost>> GetAllShortAsync(SnippetPostParams? parameters = null, CancellationToken ct = default)
        {
            return _snippetProvider.GetAllShortAsync(parameters, ct);
        }

        public Task<SnippetPost?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            return _snippetProvider.GetByIdAsync(id, ct);
        }

        public Task<ShortSnippetPost?> GetShortPostById(long id, CancellationToken ct = default)
        {
            return _snippetProvider.GetShortPostById(id, ct);
        }

        public async Task<SnippetPost> UpdateAsync(SnippetPost? model, string username, CancellationToken ct = default)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (await _languageProvider.GetByIdAsync(model.LanguageId, ct).ConfigureAwait(false) == null)
                throw new ResourceNotFoundException("Language with specified id does not exist.");

            var post = await GetByIdAsync(model.Id, ct).ConfigureAwait(false);

            if (post == null)
                throw new ResourceNotFoundException("Snippet post specified id does not exist.");

            var user = await _userProvider
                .GetByNameAsync(username, ct)
                .ConfigureAwait(false);

            if (user.Id != model.UserId)
                throw new DeprecatedOperationException("You don't have permission to perform this operation");

            return await _snippetProvider.UpdateAsync(model, ct).ConfigureAwait(false);
        }

        public async Task<bool> LikeSnippetPost(long postId, string username, CancellationToken ct = default)
        {
            var post = await GetByIdAsync(postId, ct).ConfigureAwait(false);

            if (post == null)
                throw new ResourceNotFoundException("Snippet post specified id does not exist.");

            return await _snippetProvider.LikeSnippetPost(postId, username, ct).ConfigureAwait(false);
        }

        public async Task<bool> LikedBy(long postId, string username, CancellationToken ct = default)
        {
            var post = await GetByIdAsync(postId, ct).ConfigureAwait(false);

            if (post == null)
                throw new ResourceNotFoundException("Snippet post specified id does not exist.");

            var user = await _userProvider.GetOrAddAsync(username, ct).ConfigureAwait(false);

            return await _snippetProvider.LikedBy(postId, user.Id, ct).ConfigureAwait(false);
        }
    }

}
