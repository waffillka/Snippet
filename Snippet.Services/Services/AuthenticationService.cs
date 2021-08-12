using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Snippet.Services.Interfaces.Service;

namespace Snippet.Services.Services
{
    public class AuthenticationService : IAuthenticationService, IDisposable
    {
        private readonly HttpClient _client;
        private readonly Uri domain;

        public AuthenticationService(IHttpClientFactory factory, IConfiguration configuration)
        {
            _client = factory.CreateClient();
            
            domain = new Uri($"https://{configuration["Auth0:Domain"]}/userinfo");
            
        }
        
        public async Task<JObject?> DecodeTokenAsync(string token, CancellationToken ct = default)
        {
            _client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(token);

            JObject result = null;
            
            for (int i = 0; i < 10; i++)
            {
                var response = await _client.GetAsync(domain, ct).ConfigureAwait(false);
            
                var decodedToken = await response.Content.ReadAsStringAsync(ct).ConfigureAwait(false);

                result =  JsonConvert.DeserializeObject(decodedToken) as JObject;

                if (result.ContainsKey("error"))
                {
                    result = null;
                    await Task.Delay(1500, ct).ConfigureAwait(false);
                }
                else
                {
                    break;
                }
            }
            
            return result;
        }

        public void Dispose()
        {
            _client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}