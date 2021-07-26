using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Like
    {
        public Guid SnippetPostId { get; set; }
        public Guid UserId { get; set; }
    }
}
