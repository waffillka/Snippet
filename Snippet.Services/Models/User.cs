﻿using System.ComponentModel.DataAnnotations;

namespace Snippet.Services.Models
{
    public class User
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Username is a required field.")]
        public string Username { get; set; } = string.Empty;
    }
}
