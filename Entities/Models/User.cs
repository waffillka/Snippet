using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Username is a required field.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is a required field.")]
        public string Password { get; set; }

        public ICollection<SnippetPost> LakedSnippetPost { get; set; }
    }
}
