using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PublicManagment.Domain.Entities;
using PublicManagment.Domain.Repositories;

namespace PublicManagment.Infrastructure.Repositories
{
    public class InMemoryLineRepository : ILineRepository
    {
        private readonly ConcurrentDictionary<Guid, Line> _store = new();

        public Task<Line> AddAsync(Line entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var id = entity.Id != Guid.Empty ? entity.Id : Guid.NewGuid();
            _store[id] = entity;
            return Task.FromResult(entity);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return Task.FromResult(_store.TryRemove(id, out _));
        }

        public Task<IEnumerable<Line>> GetAllAsync()
        {
            var items = _store.Values.OrderBy(l => l.Code).AsEnumerable();
            return Task.FromResult(items);
        }

        public Task<Line?> GetByIdAsync(Guid id)
        {
            _store.TryGetValue(id, out var item);
            return Task.FromResult(item);
        }

        public Task UpdateAsync(Line entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (entity.Id == Guid.Empty) throw new ArgumentException("Entity must have an Id", nameof(entity));
            if (!_store.ContainsKey(entity.Id)) throw new KeyNotFoundException("Entity not found");
            _store[entity.Id] = entity;
            return Task.CompletedTask;
        }
    }
}