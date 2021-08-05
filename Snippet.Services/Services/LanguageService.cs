using Snippet.Services.Providers;

namespace Snippet.Services.Services
{
    public class LanguageService
    {
        private LanguageProvider _provider;

        public LanguageService(LanguageProvider provider)
        {
            _provider = provider;
        }
    }
}