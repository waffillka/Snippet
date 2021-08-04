﻿using System.Collections.Generic;
using Snippet.Data.Entities;
using System.Threading;
using System.Threading.Tasks;
using Snippet.Common.Parameters;

namespace Snippet.Data.Interfaces.Repositories
{
    public interface ITagRepository
    {
        Task<TagEntity?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<TagEntity?> GetByNameAsync(string name, CancellationToken ct = default);
        Task<IEnumerable<TagEntity>> GetAllAsync(ParamsBase? parameters=default, CancellationToken ct = default);
        Task<TagEntity> CreateAsync(TagEntity entity, CancellationToken ct = default);
        TagEntity Update(TagEntity entity);
        Task<bool> DeleteAsync(long id, CancellationToken ct = default);
    }
}
