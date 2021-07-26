using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Language
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<SnippetPost> SnippetPosts { get; set; }
    }
}
