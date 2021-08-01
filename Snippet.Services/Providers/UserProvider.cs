using AutoMapper;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.UnitOfWork;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var responseTag = await _unitOfWork.Users.CreateAsync(entity, ct).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);
            return _mapper.Map<User>(responseTag);
        }

        public async Task<bool> DeleteAsync(ulong id, CancellationToken ct = default)
        {
            var result = await _unitOfWork.Users.DeleteAsync(id, ct).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            return result;
        }

        public async Task<User?> GetByIdAsync(ulong id, CancellationToken ct = default)
        {
            var entity = await _unitOfWork.Users.GetByIdAsync(id, ct).ConfigureAwait(false);
            return _mapper.Map<User?>(entity);
        }

        public async Task<User> UpdateAsync(User model, CancellationToken ct = default)
        {
            var entity = _mapper.Map<UserEntity>(model);

            var responseEntity = await _unitOfWork.Users.UpdateAsync(entity, ct).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync(ct).ConfigureAwait(false);

            return _mapper.Map<User>(responseEntity);
        }
    }
}
