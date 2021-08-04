using System.ComponentModel.DataAnnotations;

namespace Snippet.Services.Models
{
    public class Tag
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Tag name is a required field.")]
        public string Name { get; set; }
    }
}
