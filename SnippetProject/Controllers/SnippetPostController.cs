#nullable enable
using System;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Snippet.Common.Parameters;
using Snippet.Services.Models;
using SnippetProject.Extensions.SnippetPostHelper;

namespace SnippetProject.Controllers
{
    [ApiController]
    public class SnippetPostController : ControllerBase
    {
        [HttpGet("snippet/{id}")]
        public SnippetPost GetPostById(ulong id, CancellationToken ct)
        {
            var result = new SnippetPost().ConfigureDefault(id);
            return result;
        }

        [HttpGet("snippet-short/{id}")]
        public ShortSnippetPost GetShortPostById(ulong id, CancellationToken ct)
        {
            var result = new ShortSnippetPost().ConfigureDefault(id);
            return result;
        }

        [HttpGet("snippet-short/many")]
        public ShortSnippetPost[] GetShortPosts([FromQuery] SnippetPostParams? parameters, CancellationToken ct)
        {
            parameters ??= new SnippetPostParams();
            
            var result = new ShortSnippetPost[parameters.PageSize].Select(x =>
            {
                x = new ShortSnippetPost().ConfigureDefault();
                return x;
            });

            return result.ToArray();
        }

        [HttpGet("snippet/many")]
        public SnippetPost[] GetPosts([FromQuery] SnippetPostParams? parameters, CancellationToken ct)
        {
            parameters ??= new SnippetPostParams();
            var result = new SnippetPost[parameters.PageSize].Select(x =>
            {
                x = new SnippetPost().ConfigureDefault();
                return x;
            });

            return result.ToArray();
        }

        [HttpPost("snippet/create")]
        public SnippetPost CreateSnippetPost(SnippetPost post, CancellationToken ct)
        {
            if (post == null)
                throw new ArgumentNullException(nameof(post));
            post.Title += "[created]";
            post.Date = DateTime.Now;
            return post;
        }

        [HttpPut("snippet/update")]
        public SnippetPost UpdateSnippetPost(SnippetPost post, CancellationToken ct)
        {
            if (post == null)
                throw new ArgumentNullException(nameof(post));
            post.Title += "[updated]";
            post.Date = DateTime.Now;

            return post;
        }

        [HttpDelete("snippet/delete/{postId}")]
        public bool DeleteSnippetPost(ulong postId, CancellationToken ct)
        {
            return true;
        }

        [HttpGet("snippet/liked-by/{postId}")]
        public bool PostLikedBy(ulong postId, ulong userId)
        {
            return true;
        }
    }
}