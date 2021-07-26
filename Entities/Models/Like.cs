using System;

namespace Entities.Models
{
    public class Like
    {
        public Guid SnippetPostId { get; set; }
        public Guid UserId { get; set; }
    }
}
