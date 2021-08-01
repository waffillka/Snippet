﻿using System.ComponentModel.DataAnnotations;

namespace Snippet.Services.Models
{
    public class Language
    {
        public ulong Id { get; set; }
        [Required(ErrorMessage = "Language name is a required field.")]
        public string Name { get; set; }
        public string Latinname { get; set; }
        [Required(ErrorMessage = "Description is a required field.")]
        public string Description { get; set; }
    }
}
