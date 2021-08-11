using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Interfaces.Service
{
    public interface IUserService
    {
        Task<bool> IsOwner(long postId, string username, CancellationToken ct = default);
    }
}