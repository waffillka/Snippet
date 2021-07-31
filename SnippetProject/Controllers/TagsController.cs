#nullable enable
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Snippet.Common.Parameters;
using Snippet.Services.Models;

namespace SnippetProject.Controllers
{
    [ApiController]
    [Route("tag")]
    public class TagsController : ControllerBase
    {
        [HttpGet("many")]
        public Tag[] GetAll(ParamsBase? parameters, CancellationToken ct)
        {
            parameters ??= new ParamsBase();

            return new Tag[parameters.PageSize];
        }

        [HttpGet("most-popular")]
        public Tag[] MostPopular(ParamsBase? parameters, CancellationToken ct)
        {
            parameters ??= new ParamsBase();

            var result = new Tag[parameters.PageSize].Select((x, index) =>
            {
                x.Id = (ulong) index;
                x.Name = "popular tag";
                return x;
            });

            return result.ToArray();
        }

        [HttpPut("update")]
        public Tag UpdateTag(Tag tag, CancellationToken ct)
        {
            tag.Name += "[updated]";
            return tag;
        }
    }
}