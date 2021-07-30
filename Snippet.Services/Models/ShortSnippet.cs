using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippet.Services.Models
{
    public class ShortSnippetPost
    {
        public ulong Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;

        public Language Language { get; set; }

        public User User { get; set; }

        public int Like { get; set; }
        public ICollection<Tag>? Tags { get; set; }
    }
}
