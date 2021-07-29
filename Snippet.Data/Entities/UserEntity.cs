using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippet.Data.Entities
{
    public class UserEntity
    {
        public ulong Id { get; set; }

        [Required(ErrorMessage = "Username is a required field.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is a required field.")]
        public string Password { get; set; }

        public ICollection<SnippetEntity> LakedSnippetPost { get; set; }
    }
}
