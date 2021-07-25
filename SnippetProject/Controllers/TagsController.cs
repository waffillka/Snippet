using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SnippetProject.Dev.Extensions;
using SnippetProject.Models;

namespace SnippetProject.Controllers
{
    [ApiController]
    [Route("tags")]
    public class TagsController : ControllerBase
    {
        [HttpGet("{page}&{substring=\"\"}&{filterSettings?=null}&{sortSettings?=null}")]
        public Tag[] GetTags(int page, string substring = "", FilterSettings? filterSettings = null, SortSettings? sortSettings = null)
        {
            IEnumerable<Tag> result = Global.DefaultTags.Select(x =>
            {
                x.Name += $"page: {page}";
                return x;
            });

            if (!string.IsNullOrEmpty(substring))
            {
                result = result.Select(x =>
                {
                    x.Name += $"has {substring}";
                    return x;
                });
            }
            
            if (filterSettings != null)
            {
                result = result.Select(x =>
                {
                    x.Name += " filtered";
                    return x;
                });
            }

            if (sortSettings != null)
            {
                result = result.Select(x =>
                {
                    x.Name += "sorted ";
                    return x;
                });
            }

            return result.ToArray();
        }
    }
}