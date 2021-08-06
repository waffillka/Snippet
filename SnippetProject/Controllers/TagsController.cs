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
        private ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet("many")]
        public async Task<IActionResult> GetAll([FromQuery] ParamsBase? parameters, CancellationToken ct)
        {
            // parameters ??= new ParamsBase();
            //
            // var result = new Tag[parameters.PageSize].Select((x, index) =>
            // {
            //     x = new Tag { Id = index, Name = "popular tag" };
            //     return x;
            // });
            //
            // return result.ToArray();

            var result = await _tagService
                .GetAllAsync(parameters, ct)
                .ConfigureAwait(false);
            
            return Ok(result);
        }

        [HttpPut("update")]
        public Tag UpdateTag(Tag tag, CancellationToken ct)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));
            tag.Name += "[updated]";
            return tag;
        }
    }
}