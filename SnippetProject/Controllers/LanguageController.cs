﻿#nullable enable
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
        public Language[] GetAll([FromQuery] ParamsBase? parameters, CancellationToken ct)
        {
            parameters ??= new ParamsBase();

            var result = new Language[parameters.PageSize].Select((x, index) =>
            {
                x = new Language {Id = (ulong) index, Name = "Haskell"};
                return x;
            });

            return result.ToArray();
        }

        [HttpGet("most-popular")]
        public Language[] MostPopular([FromQuery] ParamsBase? parameters, CancellationToken ct)
        {
            parameters ??= new ParamsBase();

            var result = new Language[parameters.PageSize].Select((x, index) =>
            {
                x = new Language {Id = (ulong) index, Name = "Haskell"};
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