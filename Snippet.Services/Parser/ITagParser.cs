using Snippet.Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Parser
{
    public interface ITagParser
    {
        IReadOnlyCollection<string> ParseTags(string data, CancellationToken ct = default);
    }
}