using AutoMapper;
using Snippet.Common.Exceptions;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.UnitOfWork;
using Snippet.Services.Interfaces.Providers;
using Snippet.Services.Models;
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

        public async Task<User?> GetByNameAsync(string username, CancellationToken ct = default)
        {
            var result = await _unitOfWork.Users.GetByNameAsync(username, ct).ConfigureAwait(false);

            return _mapper.Map<User>(result);
        }

        public async Task<User> GetOrAddAsync(string username, CancellationToken ct = default)
        {
            var result = await _unitOfWork.Users.GetOrAddAsync(username, ct).ConfigureAwait(false);

            return _mapper.Map<User>(result);
        }
        
        public async Task<User?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            var entity = await _unitOfWork.Users.GetByIdAsync(id, ct).ConfigureAwait(false);
            return _mapper.Map<User?>(entity);
        }
    }
}
