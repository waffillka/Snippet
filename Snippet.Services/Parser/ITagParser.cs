using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Snippet.Services.Models;

namespace Snippet.Services.Parser
{
    public interface ITagParser
    {
        Task<ICollection<Tag>> GetTags(string data, CancellationToken ct = default);
    }
}