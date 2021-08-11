using System.Threading;
using System.Threading.Tasks;
using Snippet.Common.Exceptions;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Interfaces.Service;

namespace Snippet.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserProvider _userProvider;
        private readonly ISnippetProvider _snippetProvider;

        public UserService(IUserProvider userProvider, ISnippetProvider snippetProvider)
        {
            _userProvider = userProvider;
            _snippetProvider = snippetProvider;
        }

        public async Task<bool> IsOwner(long postId, string username, CancellationToken ct = default)
        {
            var post = await _snippetProvider.GetByIdAsync(postId, ct).ConfigureAwait(false);

            if (post == null)
                throw new ResourceNotFoundException("Snippet post with specified id does not exist.");

            var user = await _userProvider.GetByNameAsync(username, ct).ConfigureAwait(false);

            if (user == null)
                throw new ResourceNotFoundException("User with specified username does not exist.");

            return post.UserId == user.Id;
        }
    }
}