using AutoMapper;
using Snippet.Common.Exceptions;
using Snippet.Common.Parameters;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.UnitOfWork;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Providers
{
    public class SnippetProvider : ISnippetProvider
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SnippetProvider(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IReadOnlyCollection<SnippetPost>> GetAllAsync(SnippetPostParams? parameters = null, CancellationToken ct = default)
        {
            var entities = await _unitOfWork.Snippets
                .GetAllAsync(parameters, ct)
                .ConfigureAwait(false);

            var result = _mapper.Map<IReadOnlyCollection<SnippetPost>>(entities);

            return result;
        }
        
        public async Task<SnippetPost?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            var entity = await _unitOfWork.Snippets.GetByIdAsync(id, ct).ConfigureAwait(false);
            return _mapper.Map<SnippetPost>(entity);
        }

        public async Task<ShortSnippetPost?> GetShortPostById(long id, CancellationToken ct = default)
        {
            var entity = await _unitOfWork.Snippets.GetByIdAsync(id, ct).ConfigureAwait(false);
            return _mapper.Map<ShortSnippetPost?>(entity);
        }

        public async Task<IReadOnlyCollection<ShortSnippetPost>> GetAllShortAsync
            (SnippetPostParams? parameters = default, CancellationToken ct = default)
        {
            var entities = await _unitOfWork.Snippets
                .GetAllAsync(parameters, ct)
                .ConfigureAwait(false);

            var result = _mapper.Map<IReadOnlyCollection<ShortSnippetPost>>(entities);

            return result;
        }
        public async Task<SnippetPost> CreateAsync(SnippetPost model, CancellationToken ct = default)
        {
            var entity = _mapper.Map<SnippetEntity>(model);
            var result = await _unitOfWork.Snippets
                .CreateAsync(entity, ct)
                .ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            return _mapper.Map<SnippetPost>(result);
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            if (await GetByIdAsync(id, ct).ConfigureAwait(false) == null)
                throw new ResourceNotFoundException("Snippet post with specified id does not exist.");

            var result = await _unitOfWork.Snippets.DeleteAsync(id, ct).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            return result;
        }
        public async Task<SnippetPost> UpdateAsync(SnippetPost model, CancellationToken ct = default)
        {
            if (await GetByIdAsync(model.Id, ct).ConfigureAwait(false) == null)
                throw new ResourceNotFoundException("Snippet post specified id does not exist.");

            var entity = _mapper.Map<SnippetEntity>(model);

            var responseEntity = _unitOfWork.Snippets.Update(entity);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            return _mapper.Map<SnippetPost>(responseEntity);
        }
        
        public async Task<int> CountLike(long id, CancellationToken ct = default)
        {
            if (await GetByIdAsync(id, ct).ConfigureAwait(false) == null)
                throw new ResourceNotFoundException("Snippet post specified id does not exist.");

            return await _unitOfWork.Snippets.CountLike(id, ct).ConfigureAwait(false);
        }
    }
}
