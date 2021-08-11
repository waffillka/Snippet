using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Snippet.Services.Parser
{
    public class TagParser : ITagParser
    {
        private const string Pattern = @"#\w+";

        public IReadOnlyCollection<string> ParseTags(string data, CancellationToken ct = default)
        {
            return Regex.Matches(data, Pattern).Select(match => match.Value).ToList();
        }
    }
}