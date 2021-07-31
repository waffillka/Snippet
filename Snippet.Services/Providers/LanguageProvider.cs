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
    public class LanguageProvider : ILanguageProvider
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LanguageProvider(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Language> CreateAsync(Language model, CancellationToken ct = default)
        {
            var entity = _mapper.Map<LanguageEntity>(model);
            var responseTag = await _unitOfWork.Language.CreateAsync(entity, ct).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);
            return _mapper.Map<Language>(responseTag);
        }

        public async Task<bool> DeleteAsync(ulong id, CancellationToken ct = default)
        {
            var result = await _unitOfWork.Language.DeleteAsync(id, ct).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            return result;
        }

        public async Task<Language?> GetByIdAsync(ulong id, CancellationToken ct = default)
        {
            var entity = await _unitOfWork.Language.GetByIdAsync(id, ct).ConfigureAwait(false);
            return _mapper.Map<Language?>(entity);
        }

        public async Task<Language> UpdateAsync(Language model, CancellationToken ct = default)
        {
            var entity = _mapper.Map<LanguageEntity>(model);

            var responseEntity = await _unitOfWork.Language.UpdateAsync(entity, ct).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            return _mapper.Map<Language>(responseEntity);
        }
    }
}
