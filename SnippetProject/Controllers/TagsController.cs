#nullable enable
using Microsoft.AspNetCore.Mvc;
using Snippet.Common.Parameters;
using Snippet.Services.Models;
using System;
using System.Linq;
using System.Threading;

namespace SnippetProject.Controllers
{
    [ApiController]
    [Route("tag")]
    public class TagsController : ControllerBase
    {
        [HttpGet("many")]
        public Tag[] GetAll([FromQuery] ParamsBase? parameters, CancellationToken ct)
        {
            parameters ??= new ParamsBase();

            var result = new Tag[parameters.PageSize].Select((x, index) =>
            {
                x = new Tag { Id = index, Name = "popular tag" };
                return x;
            });

            return result.ToArray();
        }

        [HttpGet("most-popular")]
        public Tag[] MostPopular([FromQuery] ParamsBase? parameters, CancellationToken ct)
        {
            parameters ??= new ParamsBase();

            var result = new Tag[parameters.PageSize].Select((x, index) =>
            {
                x = new Tag { Id = index, Name = "popular tag" };
                return x;
            });

            return result.ToArray();
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