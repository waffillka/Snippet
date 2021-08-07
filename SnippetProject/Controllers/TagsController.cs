#nullable enable
using Microsoft.AspNetCore.Mvc;
using Snippet.Common.Parameters;
using Snippet.Services.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Snippet.Services.Interfaces.Service;

namespace SnippetProject.Controllers
{
    [ApiController]
    [Route("tag")]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet("many")]
        public async Task<IActionResult> GetAll([FromQuery] ParamsBase? parameters, CancellationToken ct)
        {
            var result = await _tagService
                .GetAllAsync(parameters, ct)
                .ConfigureAwait(false);
            
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTag(Tag tag, CancellationToken ct)
        {
            var result = await _tagService
                .UpdateAsync(tag, ct)
                .ConfigureAwait(false);

            return result == null 
            ? Ok(result)
            : BadRequest(result);
        }
    }
}