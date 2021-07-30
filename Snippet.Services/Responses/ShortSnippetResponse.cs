#nullable enable
using System;
using System.Collections.Generic;

namespace Snippet.Services.Responses
{
    public class ShortSnippetPost
    {
        public ulong Id { get; set; }
        
        public string Title { get; set; } 
        
        public DateTime Date { get; set; } = DateTime.Now;
        
        public ulong LanguageId { get; set; }
        
        public ulong UserId { get; set; }

        public ICollection<ulong>? Tags { get; set; } = null;
    }
}