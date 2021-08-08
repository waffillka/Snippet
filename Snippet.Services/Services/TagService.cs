using System;
using Snippet.Common.Parameters;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Interfaces.Service;
using Snippet.Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Snippet.Common.Exceptions;

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
            if (id < 0)
                throw new ResourceNotFoundException("You are trying to find tag with deprecated id");
            
            return _provider.GetByIdAsync(id, ct);
        }

        public Task<IReadOnlyCollection<Tag>> GetAllAsync(ParamsBase? parameters, CancellationToken ct = default)
        {
            return _provider.GetAllAsync(parameters, ct);
        }

        public Task<Tag?> GetByNameAsync(string name, CancellationToken ct = default)
        {
            return _provider.GetByNameAsync(name, ct);
        }

        public Task<Tag> CreateAsync(Tag model, CancellationToken ct = default)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            
            return _provider.CreateAsync(model, ct);
        }

        public Task<Tag?> UpdateAsync(Tag model, CancellationToken ct = default)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            
            return _provider.UpdateAsync(model, ct);
        }

        public Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            if (id < 0)
                throw new ResourceNotFoundException("You are trying to find tag with deprecated id");
            
            return _provider.DeleteAsync(id, ct);
        }
    }
}