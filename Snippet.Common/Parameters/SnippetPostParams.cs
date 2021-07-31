using System;
using System.Collections.Generic;

namespace Snippet.Common.Parameters
{
    public class SnippetPostParams : ParamsBase
    {
        public ICollection<ulong>? Authors { get; set; }
        public ICollection<ulong>? AuthorsExclude { get; set; }

        public ICollection<ulong>? Tags { get; set; }
        public ICollection<ulong>? TagsExclude { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        //match something in title, description or snippet
        public string? MatchString { get; set; }
    }
}