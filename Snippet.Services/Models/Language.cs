using System.ComponentModel.DataAnnotations;

namespace Snippet.Services.Models
{
    public class Language
    {
        public ulong Id { get; set; }
        [Required(ErrorMessage = "Language name is a required field.")]
        public string Name { get; set; }
    }
}
