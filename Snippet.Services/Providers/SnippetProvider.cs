using AutoMapper;
using Snippet.Common.Enums;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.UnitOfWork;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Models;
using System;
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

        public Task<int> CountLike(ulong id)
        {
            throw new NotImplementedException();
        }

        public async Task<SnippetPost> CreateAsync(SnippetPost model, CancellationToken ct = default)
        {
            var entity = _mapper.Map<SnippetEntity>(model);

            var responseEntity = await _unitOfWork.Snippets.CreateAsync(entity, ct).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            return _mapper.Map<SnippetPost>(responseEntity);

        }

        public async Task<bool> DeleteAsync(ulong id, CancellationToken ct = default)
        {
            var result = await _unitOfWork.Snippets.DeleteAsync(id, ct).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            return result;
        }

        public async Task<IReadOnlyCollection<ShortSnippetPost>> GetAllAsync(int page = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var entities = await _unitOfWork.Snippets.GetAllAsync(page, pageSize, ct).ConfigureAwait(false);

            return _mapper.Map<IReadOnlyCollection<ShortSnippetPost>>(entities);
        }

        public async Task<SnippetPost?> GetByIdAsync(ulong id, CancellationToken ct = default)
        {
            var entity = await _unitOfWork.Snippets.GetByIdAsync(id, ct).ConfigureAwait(false);
            return _mapper.Map<SnippetPost?>(entity);
        }

        public async Task<IReadOnlyCollection<ShortSnippetPost>> GetPageAsync(string orderBy, OrderDirection order, int page = 0, int pageSize = 10, CancellationToken ct = default)
        {
            var entities = await _unitOfWork.Snippets.GetPageAsync(orderBy, order, page, pageSize, ct).ConfigureAwait(false);

            var shortSnippets = _mapper.Map<IReadOnlyCollection<ShortSnippetPost>>(entities);
            foreach(var item in shortSnippets)
            {
                item.Like = await _unitOfWork.Snippets.CountLike(item.Id).ConfigureAwait(false);
            }

            return shortSnippets;
        }

        public async Task<SnippetPost> UpdateAsync(SnippetPost model, CancellationToken ct = default)
        {
            var entity = _mapper.Map<SnippetEntity>(model);

            var responseEntity = await _unitOfWork.Snippets.UpdateAsync(entity, ct).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            return _mapper.Map<SnippetPost>(responseEntity);
        }
    }
}
