#nullable enable
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Snippet.Common.Parameters;
using Snippet.Services.Models;

namespace SnippetProject.Controllers
{
    [ApiController]
    [Route("lang")]
    public class LanguageController : ControllerBase
    {
        [HttpGet("many")]
        public Language[] GetAll(ParamsBase? parameters, CancellationToken ct)
        {
            parameters ??= new ParamsBase();

            return new Language[parameters.PageSize];
        }

        [HttpGet("most-popular")]
        public Language[] MostPopular(ParamsBase? parameters, CancellationToken ct)
        {
            parameters ??= new ParamsBase();

            var result = new Language[parameters.PageSize].Select((x, index) =>
            {
                x.Id = (ulong) index;
                x.Name = "Haskell";
                return x;
            });

            return result.ToArray();
        }

        [HttpPut("update")]
        public Language UpdateLanguage(Language lang, CancellationToken ct)
        {
            lang.Name += "[updated]";
            return lang;
        }
    }
}