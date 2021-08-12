#nullable enable
using Microsoft.AspNetCore.Http;

namespace Snippet.Authentication
{
    public static class AuthenticationHelper
    {
        private static string _tokenClassName = string.Empty;
        
        public static void Configure(string tokenClaimName)
        {
            _tokenClassName = tokenClaimName;
        }

        public static string GetUserToken(this IHeaderDictionary header)
        {
            return header[_tokenClassName];
        }
    }
}