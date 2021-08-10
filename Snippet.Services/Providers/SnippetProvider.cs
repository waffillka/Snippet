using AutoMapper;
using Snippet.Common.Exceptions;
using Snippet.Common.Parameters;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.UnitOfWork;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Models;
using Snippet.Services.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Providers
{
    public class SnippetProvider : ISnippetProvider
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITagParser _parser;
        private readonly ITagProvider _tagProvider;

        public SnippetProvider(IMapper mapper, IUnitOfWork unitOfWork, ITagParser parser, ITagProvider tagProvider)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _parser = parser;
            _tagProvider = tagProvider;
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
            // modern problems require modern solution (kind of)
            // we need to set some userID, because we do not have auth
            model.UserId = 2;

            var entity = _mapper.Map<SnippetEntity>(model);

            var tags = _parser.ParseTags(entity.Description, ct);
            entity.Tags = await _unitOfWork.Tags.GetOrAddRangeAsync(tags, ct).ConfigureAwait(false);

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
            if (await _unitOfWork.Users.GetByIdAsync(model.UserId, ct).ConfigureAwait(false) == null)
                throw new ResourceNotFoundException("Snippet post specified id does not exist.");
            /*if (await _unitOfWork.Language.GetByIdAsync(model.LanguageId, ct).ConfigureAwait(false) == null)
                throw new ResourceNotFoundException("Snippet post specified id does not exist.");*/

            var entityFromDb = await _unitOfWork.Snippets.GetByIdAsync(model.Id, ct, true).ConfigureAwait(false);
            var tags = _parser.ParseTags(model.Description, ct);

            entityFromDb.Tags = await _unitOfWork.Tags.GetOrAddRangeAsync(tags, ct).ConfigureAwait(false);
            entityFromDb.Description = model.Description;
            entityFromDb.Title = model.Title;
            entityFromDb.Snippet = model.Snippet;
            entityFromDb.Date = DateTime.Now;
            entityFromDb.LanguageId = model.LanguageId;
            entityFromDb.UserId = model.UserId;

            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            return _mapper.Map<SnippetPost>(entityFromDb);
        }
        
        public async Task<int> CountLike(long id, CancellationToken ct = default)
        {
            if (await GetByIdAsync(id, ct).ConfigureAwait(false) == null)
                throw new ResourceNotFoundException("Snippet post specified id does not exist.");

            return await _unitOfWork.Snippets.CountLike(id, ct).ConfigureAwait(false);
        }
    }
}
