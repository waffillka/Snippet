﻿using Snippet.Common.Parameters;
using Snippet.Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Services.Interfaces.Service
{
    public interface ILanguageService
    {
        Task<Language?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<Language?> GetByNameAsync(string name, CancellationToken ct = default);
        Task<Language> CreateAsync(Language model, CancellationToken ct = default);
        Task<Language?> UpdateAsync(Language model, CancellationToken ct = default);
        Task<bool> DeleteAsync(long id, CancellationToken ct = default);
        Task<IReadOnlyCollection<Language>> GetAllAsync(ParamsBase? parameters = default, CancellationToken ct = default);
    }
}