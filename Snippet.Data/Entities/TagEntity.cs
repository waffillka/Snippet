using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippet.Data.Entities
{
    public class TagEntity
    {

        public long Id { get; set; }

        [Required(ErrorMessage = "Tag name is a required field.")]
        public string Name { get; set; }

        public ICollection<SnippetEntity> SnippetPosts { get; set; }
    }
}
