using Snippet.Services.Models;

namespace SnippetProject.Extensions.SnippetPostHelper
{
    public static class SnippetPostExtensions
    {
        public static SnippetPost ConfigureDefault(this SnippetPost post, long id = default)
        {
            post.Id = id;
            post.Title = "default title";
            post.Description = "default description";
            post.Snippet = "default snippet";
            //post.Date = DateTime.Now;
            return post;
        }

        public static ShortSnippetPost ConfigureDefault(this ShortSnippetPost post, long id = default)
        {
            post.Id = id;
            post.Title = "default title";
            post.Description = "default description";
            // post.Date = DateTime.Now;
            return post;
        }
    }
}