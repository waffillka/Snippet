using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
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
            var result = new List<Tag>();
            var matches = Regex.Matches(data, Pattern);
            foreach (Match match in matches)
            {
                ct.ThrowIfCancellationRequested();
                var tagFromDb = await _provider.GetByNameAsync(match.Value, ct).ConfigureAwait(false);

                result.Add(tagFromDb ?? await _provider.CreateAsync(new Tag {Name = match.Value}, ct)
                    .ConfigureAwait(false));
            }

            return result;
        }
    }
}