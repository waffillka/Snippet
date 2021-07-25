using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SnippetProject.Dev.Extensions;
using SnippetProject.Models;

namespace SnippetProject.Controllers
{
    [ApiController]
    [Route("languages")]
    public class LanguageController: ControllerBase
    {
        public Language[] GetLanguages(int page, string substring = "", FilterSettings? filterSettings = null,
            SortSettings? sortSettings = null)
        {
            var result = Global.DefaultLanguages.Select(x =>
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