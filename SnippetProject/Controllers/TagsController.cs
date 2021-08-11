#nullable enable
using Microsoft.AspNetCore.Mvc;
using Snippet.Common.Exceptions;
using Snippet.Common.Parameters;
using Snippet.Services.Interfaces.Service;
using Snippet.Services.Models;
using System.Threading;
using System.Threading.Tasks;

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

            return result.Count != 0
                ? Ok(result)
                : NotFound("Tags with specified parameters could not be found.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTag(Tag tag, CancellationToken ct)
        {
            if (await _tagService.GetByIdAsync(tag.Id, ct).ConfigureAwait(false) == null)
                throw new ResourceNotFoundException("Language with specified id does not exist.");

            var result = await _tagService
                .UpdateAsync(tag, ct)
                .ConfigureAwait(false);

            return Ok(result);
        }
    }
}