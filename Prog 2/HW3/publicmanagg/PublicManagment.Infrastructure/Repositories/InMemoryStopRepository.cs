using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PublicManagment.Domain.Entities;
using PublicManagment.Domain.Repositories;

namespace PublicManagment.Infrastructure.Repositories
{
    public class InMemoryStopRepository : IStopRepository
    {
        private readonly ConcurrentDictionary<Guid, Stop> _store = new();

        public Task<Stop> AddAsync(Stop entity)
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

        public Task<IEnumerable<Stop>> GetAllAsync()
        {
            var items = _store.Values.OrderBy(s => s.Sequence).AsEnumerable();
            return Task.FromResult(items);
        }

        public Task<Stop?> GetByIdAsync(Guid id)
        {
            _store.TryGetValue(id, out var item);
            return Task.FromResult(item);
        }

        public Task UpdateAsync(Stop entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (entity.Id == Guid.Empty) throw new ArgumentException("Entity must have an Id", nameof(entity));
            if (!_store.ContainsKey(entity.Id)) throw new KeyNotFoundException("Entity not found");
            _store[entity.Id] = entity;
            return Task.CompletedTask;
        }
    }
}