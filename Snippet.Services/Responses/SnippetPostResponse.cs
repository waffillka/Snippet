using Snippet.Services.Models;

namespace Snippet.Services.Responses
{
    public class SnippetPostResponse : SnippetPost
    {
        public int Likes { get; set; }
    }
}