using System;

namespace SnippetProject.Models
{
    public class ShortSnippetPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public DateTime CreationDate { get; set; }
        public Guid Language { get; set; }
        public Guid Creator { get; set; }
    }
}