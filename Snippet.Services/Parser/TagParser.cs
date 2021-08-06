using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Parser
{
    public class TagParser : ITagParser
    {
        private const string Pattern = @"#\w+";

        private readonly ITagProvider _provider;

        public TagParser(ITagProvider provider)
        {
            _provider = provider;
        }

        public async Task<ICollection<Tag>> GetTags(string data, CancellationToken ct = default)
        {
            var matches = Regex.Matches(data, Pattern);
            
            var result = await _provider
                .GetByNamesAsync(matches.Select(match => match.Value), ct)
                .ConfigureAwait(false);
            
            return result;
        }
    }
}