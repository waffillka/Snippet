using System;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Snippet.Services.Models;

namespace SnippetProject.Controllers
{
    [ApiController]
    [Route("snippet")]
    public class SnippetPostController : ControllerBase
    {
        [HttpGet("post/{id}")]
        public SnippetPost GetPostById(ulong id, CancellationToken ct)
        {
            var result = new SnippetPost {Id = id, Description = "Default description", Date = DateTime.Now};
            return result;
        }

        // public ShortSnippetPost[] GetShortPosts()
        // {
        //     
        // }
    }
}