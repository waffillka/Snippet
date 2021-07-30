using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippet.Services.Models
{
    public class SnippetShortPost
    {
        public ulong Id { get; set; }

        [Required(ErrorMessage = "Title is a required field.")]
        [MaxLength(140, ErrorMessage = "Maximum length for the Title is 140 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is a required field.")]
        [MaxLength(2000, ErrorMessage = "Maximum length for the Description is 2000 characters.")]
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "LanguageId is a required field.")]
        public ulong LanguageId { get; set; }

        public Language Language { get; set; }

        [Required(ErrorMessage = "UserId is a required field.")]
        public ulong UserId { get; set; }

        public User? User { get; set; }

        public int Like { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
