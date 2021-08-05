using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Snippet.Common.Parameters;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Interfaces.Service;
using Snippet.Services.Models;

namespace Snippet.Services.Services
{
    public class TagService : ITagService
    {
        private readonly ITagProvider _provider;


        public TagService(ITagProvider provider)
        {
            _provider = provider;
        }

        public Task<Tag?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            return _provider.GetByIdAsync(id, ct);
        }

        public Task<IEnumerable<Tag>> GetAllAsync(ParamsBase? parameters, CancellationToken ct = default)
        {
            return _provider.GetAllAsync(parameters, ct);
        }

        public Task<Tag?> GetByNameAsync(string name, CancellationToken ct = default)
        {
            return _provider.GetByNameAsync(name, ct);
        }

        public Task<Tag> CreateAsync(Tag model, CancellationToken ct = default)
        {
            return _provider.CreateAsync(model, ct);
        }

        public Task<Tag> UpdateAsync(Tag model, CancellationToken ct = default)
        {
            return _provider.UpdateAsync(model, ct);
        }

        public Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            return _provider.DeleteAsync(id, ct);
        }
    }
}