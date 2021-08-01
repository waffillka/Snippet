using Snippet.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Interfaces.Providers
{
    public interface IUserProvider
    {
        Task<User?> GetByIdAsync(ulong id, CancellationToken ct = default);
        Task<User> CreateAsync(User model, CancellationToken ct = default);
        Task<User> UpdateAsync(User model, CancellationToken ct = default);
        Task<bool> DeleteAsync(ulong id, CancellationToken ct = default);
    }
}
