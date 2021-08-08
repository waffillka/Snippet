using System;
using System.Collections.Generic;

namespace Snippet.Common.Parameters
{
    public class SnippetPostParams : ParamsBase
    {
        public ICollection<long>? Authors { get; set; } = default;
        public ICollection<long>? AuthorsExclude { get; set; } = default;

        public ICollection<string>? Tags { get; set; } = default;
        public ICollection<string>? TagsExclude { get; set; } = default;

        public ICollection<string>? Langs { get; set; } = default;
        public ICollection<string>? LangsExclude { get; set; } = default;

        public DateTime CreationDate { get; set; } = default;
        public DateTime From { get; set; } = default;
        public DateTime To { get; set; } = default;

        //match something in title, description or snippet
        public string? MatchString { get; set; } = string.Empty;
    }
}