using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippet.Data.Entities
{
    public class LanguageEntity
    {

        public ulong Id { get; set; }

        [Required(ErrorMessage = "Language name is a required field.")]
        public string Name { get; set; }
        public ICollection<SnippetEntity> SnippetPosts { get; set; }
    }
}
