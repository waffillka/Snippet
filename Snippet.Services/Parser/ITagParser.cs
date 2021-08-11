using System.Collections.Generic;
using System.Threading;

namespace Snippet.Services.Parser
{
    public interface ITagParser
    {
        IReadOnlyCollection<string> ParseTags(string data, CancellationToken ct = default);
    }
}