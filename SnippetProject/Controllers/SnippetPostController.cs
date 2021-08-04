#nullable enable
using Microsoft.AspNetCore.Mvc;
using Snippet.Common.Parameters;
using Snippet.Services.Interfaces.Service;
using Snippet.Services.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SnippetProject.Controllers
{
    [ApiController]
    public class SnippetPostController : ControllerBase
    {
        private readonly ISnippetSevice _snippetService;

        public SnippetPostController(ISnippetSevice snippetService)
        {
            _snippetService = snippetService;
        }

        [HttpGet("snippet/{id:long}")]
        public async Task<IActionResult> GetPostById(long id, CancellationToken ct = default)
        {
            var result = await _snippetService.GetByIdAsync(id, ct).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet("snippet-short/{id:long}")]
        public async Task<IActionResult> GetShortPostById(long id, CancellationToken ct = default)
        {
            var result = await _snippetService.GetShortPostById(id, ct).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet("snippet-short/many")]
        public async Task<IActionResult> GetShortPosts([FromQuery] SnippetPostParams? parameters, CancellationToken ct = default)
        {
            parameters ??= new SnippetPostParams();

            var result = await _snippetService.GetAllShortAsync(parameters, ct).ConfigureAwait(false);
            return Ok(result);

        }

        [HttpGet("snippet/many")]
        public async Task<IActionResult> GetPosts([FromQuery] SnippetPostParams? parameters, CancellationToken ct)
        {
            parameters ??= new SnippetPostParams();

            var result = await _snippetService.GetAllAsync(parameters, ct).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPost("snippet/create")]
        public SnippetPost CreateSnippetPost(SnippetPost post, CancellationToken ct = default)
        {
            if (post == null)
                throw new ArgumentNullException(nameof(post));
            post.Title += "[created]";
            post.Date = DateTime.Now;
            return post;
        }

        [HttpPut("snippet/update")]
        public SnippetPost UpdateSnippetPost(SnippetPost post, CancellationToken ct = default)
        {
            if (post == null)
                throw new ArgumentNullException(nameof(post));
            post.Title += "[updated]";
            post.Date = DateTime.Now;

            return post;
        }

        [HttpDelete("snippet/delete/{postId:long}")]
        public bool DeleteSnippetPost(long postId, CancellationToken ct = default)
        {
            return true;
        }

        [HttpGet("snippet/liked-by/{postId:long}")]
        public bool PostLikedBy(long postId, long userId, CancellationToken ct = default)
        {
            return true;
        }
    }
}