using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Snippet.Authentication.Configuration
{
    public static class AuthConfiguration
    {
        public static void ConfigureAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://securetoken.google.com/snippets-authentication";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://securetoken.google.com/snippets-authentication",
                        ValidateAudience = true,
                        ValidAudience = "snippets-authentication",
                        ValidateLifetime = true
                    };
                });
        }
    }
}