using AutoMapper;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.UnitOfWork;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Providers
{
    public class TagProvider : ITagProvider
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TagProvider(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Tag> CreateAsync(Tag model, CancellationToken ct = default)
        {
            var entity = _mapper.Map<TagEntity>(model);
            var responseTag = await _unitOfWork.Tags.CreateAsync(entity, ct).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);
            return _mapper.Map<Tag>(responseTag);
        }

        public async Task<bool> DeleteAsync(ulong id, CancellationToken ct = default)
        {
            var result = await _unitOfWork.Tags.DeleteAsync(id, ct).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            return result;
        }

        public async Task<Tag?> GetByIdAsync(ulong id, CancellationToken ct = default)
        {
            var entity = await _unitOfWork.Tags.GetByIdAsync(id, ct).ConfigureAwait(false);
            return _mapper.Map<Tag?>(entity);
        }

        public async Task<Tag> UpdateAsync(Tag model, CancellationToken ct = default)
        {
            var entity = _mapper.Map<TagEntity>(model);

            var responseEntity = await _unitOfWork.Tags.UpdateAsync(entity, ct).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            return _mapper.Map<Tag>(responseEntity);
        }
    }
}
