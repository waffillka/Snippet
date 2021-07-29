﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snippet.Data.Entities
{
    public class SnippetEntity
    {
        public ulong Id { get; set; }

        [Required(ErrorMessage = "Title is a required field.")]
        [MaxLength(140, ErrorMessage = "Maximum length for the Title is 140 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is a required field.")]
        [MaxLength(2000, ErrorMessage = "Maximum length for the Description is 2000 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Snippet is a required field.")]
        [MaxLength(2000, ErrorMessage = "Maximum length for the Snippet is 2000 characters.")]
        public string Snippet { get; set; }
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "LanguageId is a required field.")]
        [ForeignKey(nameof(Language))]
        public ulong LanguageId { get; set; }

        [NotMapped]
        public LanguageEntity Language { get; set; }

        [Required(ErrorMessage = "UserId is a required field.")]
        [ForeignKey(nameof(User))]
        public ulong UserId { get; set; }

        [NotMapped]
        public UserEntity User { get; set; }

        public ICollection<TagEntity> Tags { get; set; }
        public ICollection<UserEntity> LikedUser { get; set; }
    }
}
