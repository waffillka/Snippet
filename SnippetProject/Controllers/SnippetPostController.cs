﻿#nullable enable
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
        public ShortSnippetPost[] GetShortPosts(SnippetPostParams? parameters, CancellationToken ct)
        {
            //TODO: Validate params. Page size must be >0
            parameters ??= new SnippetPostParams();
            var result = new ShortSnippetPost[parameters.PageSize].Select(x => x.ConfigureDefault());

            return result.ToArray();
        }

        [HttpGet("snippet/many")]
        public SnippetPost[] GetPosts(SnippetPostParams? parameters, CancellationToken ct)
        {
            parameters ??= new SnippetPostParams();
            var result = new SnippetPost[parameters.PageSize].Select(x => x.ConfigureDefault());

            return result.ToArray();
        }

        [HttpPost("snippet/create")]
        public SnippetPost CreateSnippetPost(SnippetPost post, CancellationToken ct)
        {
            post.Title += "[created]";
            post.Date = DateTime.Now;
            return post;
        }

        [HttpPut("snippet/update")]
        public SnippetPost UpdateSnippetPost(SnippetPost post, CancellationToken ct)
        {
            post.Title += "[updated]";
            post.Date = DateTime.Now;

            return post;
        }

        [HttpDelete("snippet/delete")]
        public bool DeleteSnippetPost(ulong postId, CancellationToken ct)
        {
            return true;
        }

        [HttpGet("snippet/liked-by")]
        public bool PostLikedBy(ulong postId, ulong userId)
        {
            return true;
        }
    }
}