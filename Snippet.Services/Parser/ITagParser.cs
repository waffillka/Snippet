using Snippet.Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Parser
{
    public interface ITagParser
    {
        Task<ICollection<Tag>> GetTags(string data, CancellationToken ct = default);
    }
}