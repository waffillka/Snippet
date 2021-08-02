using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snippet.Services.Response
{
    public class UserResponse
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Username is a required field.")]
        public string Username { get; set; } = string.Empty;

    }
}
