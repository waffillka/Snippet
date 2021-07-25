using System;
using Microsoft.AspNetCore.SignalR.Protocol;
using SnippetProject.Models;

namespace SnippetProject.Dev.Extensions
{
    public static class ShortSnippetPostExtensions
    {
        public static ShortSnippetPost[] Duplicate(this ShortSnippetPost item, int quantity)
        {
            var result = new ShortSnippetPost[quantity];
            for (int i = 0; i < quantity; i++)
            {
                result[i] = item.DeepCopy();
            }
            
            return result;
        }
        
        public static ShortSnippetPost ConfigureId(this ShortSnippetPost post, Guid id)
        {
            post.Id = id;
            return post;
        }

        public static ShortSnippetPost ConfigureCreatorId(this ShortSnippetPost post, Guid id)
        {
            post.Creator = id;
            return post;
        }

        public static ShortSnippetPost ConfigureLanguage(this ShortSnippetPost post, Guid languageId)
        {
            post.Language = languageId;
            return post;
        }
        
        public static ShortSnippetPost ConfigureTitle(this ShortSnippetPost post, string title)
        {
            post.Title = title;
            return post;
        }

        public static ShortSnippetPost ConfigureCreationDate(this ShortSnippetPost post, DateTime creationDate)
        {
            post.CreationDate = creationDate;
            return post;
        }

       


        public static ShortSnippetPost DeepCopy(this ShortSnippetPost origin)
        {
            var result = new ShortSnippetPost
            {
                Id = origin.Id,
                Creator = origin.Creator,
                Description = origin.Description,
                Language = origin.Language,
                Title = origin.Title,
                CreationDate = origin.CreationDate
            };
            return result;
        }

        public static ShortSnippetPost AsShortSnippetPost(this SnippetPost post)
        {
            return post;
        }
        
    }
}