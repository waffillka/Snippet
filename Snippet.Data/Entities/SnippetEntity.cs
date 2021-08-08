using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippet.Data.Entities
{
    public class SnippetEntity
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Title is a required field.")]
        [MaxLength(140, ErrorMessage = "Maximum length for the Title is 140 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is a required field.")]
        [MaxLength(2000, ErrorMessage = "Maximum length for the Description is 2000 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Snippet is a required field.")]
        [MaxLength(4000, ErrorMessage = "Maximum length for the Snippet is 2000 characters.")]
        public string Snippet { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "LanguageId is a required field.")]
        public long LanguageId { get; set; }
        public LanguageEntity Language { get; set; }

        [Required(ErrorMessage = "UserId is a required field.")]
        public long UserId { get; set; }
        public UserEntity User { get; set; }

        public ICollection<TagEntity>? Tags { get; set; }
        public ICollection<UserEntity>? LikedUser { get; set; }
    }
}
