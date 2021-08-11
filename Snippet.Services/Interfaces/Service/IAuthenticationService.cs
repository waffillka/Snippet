using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Snippet.Services.Interfaces.Service
{
    public interface IAuthenticationService
    {
        Task<JObject?> DecodeTokenAsync(string token, CancellationToken ct = default);
    }
}