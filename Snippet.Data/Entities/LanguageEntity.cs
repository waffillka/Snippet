using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippet.Data.Entities
{
    public class LanguageEntity
    {

        public long Id { get; set; }

        [Required(ErrorMessage = "Language name is a required field.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Latinname is a required field.")]
        public string Latinname { get; set; }
        [Required(ErrorMessage = "Description is a required field.")]
        public string Description { get; set; }
        public ICollection<SnippetEntity> SnippetPosts { get; set; }
    }
}
