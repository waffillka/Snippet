using System.ComponentModel.DataAnnotations;

namespace Snippet.Services.Models
{
    public class Language
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Language name is a required field.")]
        public string Name { get; set; }
        public string ExtraName { get; set; }
        [Required(ErrorMessage = "Description is a required field.")]
        public string Description { get; set; }
    }
}
