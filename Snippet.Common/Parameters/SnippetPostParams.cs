using System;
using System.Collections.Generic;

namespace Snippet.Common.Parameters
{
    public class SnippetPostParams : ParamsBase
    {
        public ICollection<long>? Authors { get; set; }
        public ICollection<long>? AuthorsExclude { get; set; }

        public ICollection<long>? Tags { get; set; }
        public ICollection<long>? TagsExclude { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        //match something in title, description or snippet
        public string? MatchString { get; set; }
    }
}