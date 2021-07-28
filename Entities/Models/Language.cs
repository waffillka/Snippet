using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Language
    {

        public ulong Id { get; set; }

        [Required(ErrorMessage = "Language name is a required field.")]
        public string Name { get; set; }
        public ICollection<SnippetPost> SnippetPosts { get; set; }
    }
}
