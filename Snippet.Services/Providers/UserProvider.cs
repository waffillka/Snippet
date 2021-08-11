using AutoMapper;
using Snippet.Common.Exceptions;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.UnitOfWork;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Models;
using Snippet.Services.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserProvider(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<User> CreateAsync(User model, CancellationToken ct = default)
        {
            var entity = _mapper.Map<UserEntity>(model);

            var responseUser = await _unitOfWork.Users.CreateAsync(entity, ct).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            var responseModel = _mapper.Map<User>(responseUser);
            return responseModel;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            if (await GetByIdAsync(id, ct).ConfigureAwait(false) == null)
                throw new ResourceNotFoundException("Tag with specified id does not exist");

            var result = await _unitOfWork.Users.DeleteAsync(id, ct).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            return result;
        }

        public async Task<UserResponse?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            var entity = await _unitOfWork.Users.GetByIdAsync(id, ct).ConfigureAwait(false);
            return _mapper.Map<UserResponse?>(entity);
        }

        public async Task<UserResponse> UpdateAsync(User model, CancellationToken ct = default)
        {
            if (await GetByIdAsync(model.Id, ct).ConfigureAwait(false) == null)
                throw new ResourceNotFoundException("Tag with specified id does not exist");

            var entity = _mapper.Map<UserEntity>(model);
            var responseEntity = _unitOfWork.Users.Update(entity);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            return _mapper.Map<UserResponse>(responseEntity);
        }
    }
}
