#nullable enable
using Microsoft.AspNetCore.Mvc;
using Snippet.Common.Parameters;
using Snippet.Services.Models;
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
            
            return result.Count != 0
                ? Ok(result)
                : NotFound("Tags with specified parameters could not be found.");
        }
    }
}