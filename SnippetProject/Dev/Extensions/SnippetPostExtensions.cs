using System;
using SnippetProject.Models;

namespace SnippetProject.Dev.Extensions
{
    public static class SnippetPostExtensions
    {
        public static SnippetPost ConfigureAll(this SnippetPost post)
        {
            return post.ConfigureDescription("default description")
                .ConfigureSnippet("default snippet")
                .ConfigureTags(Global.DefaultTags)
                .ConfigureId(Global.DefaultGuid)
                .ConfigureTitle("default title")
                .ConfigureLanguage(Global.DefaultGuid)
                .ConfigureCreatorId(Global.DefaultGuid)
                .AsSnippetPost();
        }

        public static SnippetPost ConfigureDescription(this SnippetPost post, string description)
        {
            post.Description = description;
            return post;
        }

        public static SnippetPost ConfigureSnippet(this SnippetPost post, string snippet)
        {
            post.Snippet = snippet;
            return post;
        }


        public static SnippetPost ConfigureTags(this SnippetPost post, Tag[] tags)
        {
            post.Tags = tags;
            return post;
        }

        public static SnippetPost ConfigureLikes(this SnippetPost post, int likes)
        {
            post.Likes = likes;
            return post;
        }

        public static SnippetPost AsSnippetPost(this ShortSnippetPost post)
        {
            return post as SnippetPost;
        }

        public static SnippetPost DeepCopy(this SnippetPost post)
        {
            var result = post.AsShortSnippetPost()
                .DeepCopy()
                .AsSnippetPost();

            result.Likes = post.Likes;
            result.Snippet = post.Snippet;
            result.Tags = post.Tags;

            return result;
        }
    }
}