#nullable enable
using Microsoft.AspNetCore.Mvc;
using Snippet.Common.Parameters;
using Snippet.Services.Interfaces.Service;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;
using Snippet.Authentication;
using Snippet.Services.Models;

namespace SnippetProject.Controllers
{
    [ApiController]
    public class SnippetPostController : ControllerBase
    {
        private readonly ISnippetService _snippetService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        
        
        public SnippetPostController(ISnippetService snippetService, IAuthenticationService authenticationService, 
            IUserService userService)
        {
            _snippetService = snippetService;
            _authenticationService = authenticationService;
            _userService = userService;
        }
        
        [HttpGet("snippet/{id:long}")]
        public async Task<IActionResult> GetPostById(long id, CancellationToken ct = default)
        {
            var result = await _snippetService.GetByIdAsync(id, ct).ConfigureAwait(false);

            return result!=null
                ? Ok(result)
                : NotFound("Snippet post with specified id does not exist.");
        }

        [HttpGet("snippet-short/many")]
        public async Task<IActionResult> GetShortPosts([FromQuery] SnippetPostParams? parameters, CancellationToken ct = default)
        {
            var result = await _snippetService
                .GetAllShortAsync(parameters, ct)
                .ConfigureAwait(false);
            
            return result.Count != 0
                ? Ok(result)
                : NotFound("Snippet posts with specified parameters could not be found.");
        }

        [Authorize]
        [HttpPost("snippet/create")]
        public async Task<IActionResult> CreateSnippetPost(SnippetPost? post, CancellationToken ct = default)
        {
            var token = HttpContext.Request.Headers.GetUserToken();

            var decodedToken = await _authenticationService.DecodeTokenAsync(token, ct).ConfigureAwait(false);

            string username = decodedToken!["nickname"]!.Value<string>();
            
            var result = await _snippetService
                .CreateAsync(post, username!, ct)
                .ConfigureAwait(false);
            
            return Ok(result);
        }
        
        [Authorize]
        [HttpPut("snippet/update")]
        public async Task<IActionResult> UpdateSnippetPost(SnippetPost? post, CancellationToken ct = default)
        {
            var token = HttpContext.Request.Headers.GetUserToken();

            var decodedToken = await _authenticationService.DecodeTokenAsync(token, ct).ConfigureAwait(false);

            string username = decodedToken!["nickname"]!.Value<string>();   
            
            var result = await _snippetService
                .UpdateAsync(post, username!, ct)
                .ConfigureAwait(false);
        
            return Ok(result);
        }
        
        [Authorize]
        [HttpDelete("snippet/delete/{postId:long}")]
        public async Task<IActionResult> DeleteSnippetPost(long postId, CancellationToken ct = default)
        {
            var token = HttpContext.Request.Headers.GetUserToken();

            var decodedToken = await _authenticationService.DecodeTokenAsync(token, ct).ConfigureAwait(false);

            string username = decodedToken!["nickname"]!.Value<string>();
            
            var result = await _snippetService.DeleteAsync(postId, username!, ct).ConfigureAwait(false);
           
            return Ok(result);
        }

        [Authorize]
        [HttpPost("like-snippet/{postId:long}")]
        public async Task<IActionResult> LikeSnippetPost(long postId, CancellationToken ct = default)
        {
            var token = HttpContext.Request.Headers.GetUserToken();

            var decodedToken = await _authenticationService.DecodeTokenAsync(token, ct).ConfigureAwait(false);

            string username = decodedToken!["nickname"]!.Value<string>()!;

            var result = await _snippetService.LikeSnippetPost(postId, username, ct).ConfigureAwait(false);

            return Ok(result);
        }
        
        [Authorize]
        [HttpGet("is-owner/{postId:long}")]
        public async Task<IActionResult> IsOwner(long postId, CancellationToken ct = default)
        {
            var token = HttpContext.Request.Headers.GetUserToken();

            var decodedToken = await _authenticationService.DecodeTokenAsync(token, ct).ConfigureAwait(false);

            string username = decodedToken!["nickname"]!.Value<string>()!;

            var result = await _userService.IsOwner(postId, username, ct).ConfigureAwait(false);
            
            return Ok(result);
        }
    }
}