#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippet.Services.Models
{
    public class SnippetPost
    {
        public ulong Id { get; set; }
        
        [Required(ErrorMessage = "Title is a required field.")]
        public string Title { get; set; } 
        
        [Required(ErrorMessage = "Description is a required field.")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Snippet is a required field.")]
        public string Snippet { get; set; }
        
        public DateTime Date { get; set; } = DateTime.Now;
        
        [Required(ErrorMessage = "LanguageId is a required field.")]
        public ulong LanguageId { get; set; }
        
        [Required(ErrorMessage = "UserId is a required field.")]
        public ulong UserId { get; set; }

        public ICollection<ulong>? Tags { get; set; } = null;
    }
}