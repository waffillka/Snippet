using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Tag
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Tag name is a required field.")]
        public string Name { get; set; }

        public ICollection<SnippetPost> SnippetPosts { get; set; }
    }
}
