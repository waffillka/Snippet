﻿using AutoMapper;
using Snippet.Common.Parameters;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.UnitOfWork;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Snippet.Common.Exceptions;

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

        public async Task<Language?> GetByNameAsync(string name, CancellationToken ct = default)
        {
            var tag = await _unitOfWork.Language.GetByNameAsync(name, ct).ConfigureAwait(false);
            return _mapper.Map<Language>(tag);
        }
        
        public async Task<Language?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            var entity = await _unitOfWork.Language.GetByIdAsync(id, ct).ConfigureAwait(false);
            return _mapper.Map<Language?>(entity);
        }
        
        public async Task<IReadOnlyCollection<Language>> GetAllAsync(ParamsBase? parameters = null, CancellationToken ct = default)
        {
            var result = await _unitOfWork.Language.GetAllAsync(parameters, ct).ConfigureAwait(false);
            return _mapper.Map<IReadOnlyCollection<Language>>(result);
        }
        
        public async Task<Language> CreateAsync(Language model, CancellationToken ct = default)
        {
            var entity = _mapper.Map<LanguageEntity>(model);
            var responseTag = await _unitOfWork.Language.CreateAsync(entity, ct).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);
            return _mapper.Map<Language>(responseTag);
        }
        
        public async Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            if (await GetByIdAsync(id, ct).ConfigureAwait(false) == null)
                throw new ResourceNotFoundException("Language with specified id does not exist.");
            
            var result = await _unitOfWork.Language.DeleteAsync(id, ct).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            return result;
        }

        public async Task<Language?> UpdateAsync(Language model, CancellationToken ct = default)
        {
            if (await GetByIdAsync(model.Id, ct).ConfigureAwait(false) == null)
                throw new ResourceNotFoundException("Language with specified id does not exist.");
            var entity = _mapper.Map<LanguageEntity>(model);

            var responseEntity = _unitOfWork.Language.Update(entity);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            return _mapper.Map<Language>(responseEntity);
        }
    }
}
