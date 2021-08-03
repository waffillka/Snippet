using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Models;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;

namespace Snippet.Services.Parser
{
    public class TagParser
    {
        private const string Pattern = @"#\w+\s?";

        private readonly ITagProvider _provider;

        public TagParser(ITagProvider provider)
        {
            _provider = provider;
        }

        public async IAsyncEnumerable<Tag> GetTags(string data, [EnumeratorCancellation] CancellationToken ct = default)
        {
            var matches = Regex.Matches(data, Pattern);
            foreach (Match match in matches)
            {
                ct.ThrowIfCancellationRequested();
                // var tagFromDb = await _provider.GetByNameAsync(match.Value, ct).ConfigureAwait(false);

                // yield return tagFromDb ?? await _provider.CreateAsync(new Tag {Name = match.Value}, ct)
                //     .ConfigureAwait(false);

                yield return new Tag { Name = match.Value };
            }
        }
    }
}