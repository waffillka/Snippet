using AutoMapper;
using Snippet.Common.Parameters;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.UnitOfWork;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Snippet.Common.Exceptions;

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

        public async Task<IReadOnlyCollection<Tag>> GetAllAsync(ParamsBase? parameters = default,
            CancellationToken ct = default)
        {
            var result = await _unitOfWork.Tags
                .GetAllAsync(parameters, ct)
                .ConfigureAwait(false);
            return _mapper.Map<IReadOnlyCollection<Tag>>(result);
        }

        public async Task<Tag?> GetByNameAsync(string name, CancellationToken ct = default)
        {
            var tag = await _unitOfWork.Tags.GetByNameAsync(name, ct).ConfigureAwait(false);
            return _mapper.Map<Tag>(tag);
        }
        
        public async Task<Tag?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            var entity = await _unitOfWork.Tags.GetByIdAsync(id, ct).ConfigureAwait(false);
            return _mapper.Map<Tag?>(entity);
        }


        public async Task<Tag> CreateAsync(Tag model, CancellationToken ct = default)
        {
            var entity = _mapper.Map<TagEntity>(model);
            var responseTag = await _unitOfWork.Tags.CreateAsync(entity, ct).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);
            return _mapper.Map<Tag>(responseTag);
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            if (await GetByIdAsync(id, ct).ConfigureAwait(false) == null)
                throw new ResourceNotFoundException("Tag with specified id does not exist");
            var result = await _unitOfWork.Tags.DeleteAsync(id, ct).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            return result;
        }

        public async Task<Tag?> UpdateAsync(Tag model, CancellationToken ct = default)
        {
            if (await GetByIdAsync(model.Id, ct).ConfigureAwait(false) == null)
                throw new ResourceNotFoundException("Tag with specified id does not exist");
            
            var entity = _mapper.Map<TagEntity>(model);
            var responseEntity = _unitOfWork.Tags.Update(entity);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            return _mapper.Map<Tag>(responseEntity);
        }
        
        public async Task<ICollection<Tag>> GetRangeByNameAsync(IEnumerable<string> names, CancellationToken ct = default)
        {
            var result = await _unitOfWork.Tags
                .GetRangeByNameAsync(names, ct)
                .ConfigureAwait(false);

            return _mapper.Map<ICollection<Tag>>(result);
        }

        //public Task AddRangeAsync(IEnumerable<string> names, CancellationToken ct = default)
        //{
        //    return _unitOfWork.Tags.AddRangeAsync(names, ct);
        //}

        //public async Task<ICollection<TagEntity>> GetOrAddRangeAsync(IEnumerable<string> names, CancellationToken ct = default)
        //{
            //var namesList = names.ToList();

            //var existingTags = await _unitOfWork.Tags
            //    .GetRangeByNameAsync(namesList, ct)
            //    .ConfigureAwait(false);

            //var notCreatedTags = namesList.Except(existingTags.Select(tag => tag.Name)).ToList();

            //await AddRangeAsync(notCreatedTags, ct).ConfigureAwait(false);
            //await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            //var newTags = await _unitOfWork.Tags
            //    .GetRangeByNameAsync(notCreatedTags, ct)
            //    .ConfigureAwait(false);

        //    return wait _unitOfWork.Tags.GetOrAddRangeAsync(names, ct).ConfigureAwait(false));//(existingTags.Union(newTags)).ToList();
        //}
        
    }
}
