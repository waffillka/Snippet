using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class SnippetPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Snippet { get; set; }
        public DateTime Date { get; set; }
        public Guid LanguageId { get; set; }
        public Language Language { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
