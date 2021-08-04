using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snippet.Services.Models
{
    public class ShortSnippetPost
    {
        public long Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;

        public Language Language { get; set; }

        public User User { get; set; }

        public int Like { get; set; }
        public ICollection<Tag>? Tags { get; set; }
    }
}
