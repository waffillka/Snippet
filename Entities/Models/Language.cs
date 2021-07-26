using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Language
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<SnippetPost> SnippetPosts { get; set; }
    }
}
