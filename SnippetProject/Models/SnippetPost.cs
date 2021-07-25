using System;

namespace SnippetProject.Models
{
    public class SnippetPost : ShortSnippetPost
    {
        public string Snippet { get; set; }

        public Tag[] Tags { get; set; }
        
        public int Likes { get; set; }
    }
}