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
    [Route("lang")]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet("many")]
        public async Task<IActionResult> GetAll([FromQuery] ParamsBase? parameters, CancellationToken ct)
        {
            var result = await _languageService.GetAllAsync(parameters, ct).ConfigureAwait(false);

            return result.Count != 0
                    ? Ok(result)
                    : NotFound("languages with specified parameters could not be found.");
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name, CancellationToken ct)
        {
            var result = await _languageService.GetByNameAsync(name, ct).ConfigureAwait(false);

            return result != null
                ? Ok(result)
                : NotFound("Language with specified name does not exist.");
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Language lang, CancellationToken ct)
        {
            var result = await _languageService.CreateAsync(lang, ct).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateLanguage(Language lang, CancellationToken ct)
        {
            if (await _languageService.GetByIdAsync(lang.Id, ct).ConfigureAwait(false) == null)
                throw new ResourceNotFoundException("Language with specified id does not exist.");

            var result = await _languageService.UpdateAsync(lang, ct).ConfigureAwait(false);
            return Ok(result);
        }
    }
}