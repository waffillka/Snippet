using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SnippetProject.Dev.Extensions;
using SnippetProject.Models;

namespace SnippetProject.Controllers
{
    [ApiController]
    [Route("posts")]
    public class SnippetPostController : ControllerBase
    {
        private static readonly SnippetPost DefaultPost = new SnippetPost().ConfigureAll();

        [HttpGet("short/{id}")]
        public ShortSnippetPost GetShortSnippetPostById(Guid id)
        {
            return DefaultPost.ConfigureId(id);
        }

        [HttpGet("full/{id}")]
        public SnippetPost GetSnippetPostById(Guid id)
        {
            return GetShortSnippetPostById(id).AsSnippetPost();
        }

        [HttpGet("short/{page}&{filterSettings?}&{sortSettings?}")]
        public ShortSnippetPost[] GetShortSnippetPosts(int page, FilterSettings? filterSettings = null,
            SortSettings? sortSettings = null)
        {
            IEnumerable<ShortSnippetPost> result = DefaultPost.Duplicate(5);

            int i = 0;
            foreach (var item in result)
            {
                item.Title += $" №: {++i} page: {page}";
            }

            if (filterSettings != null)
            {
                result = result.Select(x =>
                {
                    x.Title += " filtered";
                    return x;
                });
            }

            if (sortSettings != null)
            {
                result = result.Select(x =>
                {
                    x.Title += " sorted by " + sortSettings;
                    return x;
                });
            }

            return result.ToArray();
        }

        [HttpGet("full/{page}&{filterSettings?}&{sortSettings?}")]
        public SnippetPost[] GetSnippetPosts(int page, FilterSettings? filterSettings, SortSettings? sortSettings)
        {
            return GetShortSnippetPosts(page, filterSettings, sortSettings)
                .Select(x => x.AsSnippetPost())
                .ToArray();
        }

        #region Previous implementation

// [HttpGet("short/{page}")]
        // public ShortSnippetPost[] GetShortSnippetPosts(int page)
        // {
        //     var result = DefaultPost.Duplicate(5);
        //     for (int i = 0; i < result.Length; i++)
        //     {
        //         result[i].Title += $" №: {i + 1} page: {page}";
        //     }
        //
        //     return result;
        // }
        //
        // [HttpGet("short/filtered/{filterSettings}")]
        // public ShortSnippetPost[] GetShortSnippetPostsFiltered(FilterSettings filterSettings)
        // {
        //     return DefaultPost
        //         .Duplicate(5).Select(x =>
        //         {
        //             x.Title += " filtered";
        //             return x;
        //         })
        //         .ToArray();
        // }
        //
        // [HttpGet("filtered/{filterSettings}")]
        // public SnippetPost[] GetSnippetPostsFiltered(FilterSettings filterSettings)
        // {
        //     return GetShortSnippetPostsFiltered(filterSettings)
        //         .Select(x => x.AsSnippetPost())
        //         .ToArray();
        // }
        //
        // [HttpGet("short/sorted-by/{sortSettings}")]
        // public ShortSnippetPost[] GetShortSnippetPostsSortedBy(SortSettings sortSettings)
        // {
        //     return DefaultPost
        //         .Duplicate(5)
        //         .Select(x =>
        //         {
        //             x.Title += " sorted by " + sortSettings;
        //             return x;
        //         })
        //         .ToArray();
        //         
        // }
        //
        // [HttpGet("sorted-by/{sortSettings}")]
        // public SnippetPost[] GetSnippetPostsSortedBy(SortSettings sortSettings)
        // {
        //     return GetShortSnippetPostsSortedBy(sortSettings)
        //         .Select(x => x.AsSnippetPost())
        //         .ToArray();
        // }
        //
        // [HttpGet("short/filtered-sorted/{filterSettings}&{sortSettings}")]
        // public ShortSnippetPost[] GetShortSnippetPostsFilteredAndSortedBy(FilterSettings filterSettings,
        //     SortSettings sortSettings)
        // {
        //     return GetShortSnippetPostsFiltered(filterSettings)
        //         .Select(x =>
        //         {
        //             x.Title += " sorted by" + sortSettings;
        //             return x;
        //         }).ToArray();
        // }
        //
        // [HttpGet("filtered-sorted/{filterSettings}&{sortSettings}")]
        // public SnippetPost[] GetSnippetPostsFilteredAndSortedBy(FilterSettings filterSettings,
        //     SortSettings sortSettings)
        // {
        //     return GetShortSnippetPostsFilteredAndSortedBy(filterSettings, sortSettings)
        //         .Select(x => x.AsSnippetPost())
        //         .ToArray();
        // }

        #endregion
    }
}