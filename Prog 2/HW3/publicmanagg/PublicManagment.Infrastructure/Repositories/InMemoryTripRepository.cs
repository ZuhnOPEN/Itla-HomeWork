using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PublicManagment.Domain.Entities;
using PublicManagment.Domain.Repositories;

namespace PublicManagment.Infrastructure.Repositories
{
    public class InMemoryTripRepository : ITripRepository
    {
        private readonly ConcurrentDictionary<Guid, Trip> _store = new();

        public Task<Trip> AddAsync(Trip entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var id = entity.Id != Guid.Empty ? entity.Id : Guid.NewGuid();
            // Si la entidad proviene del dominio con Id ya asignado, respetarlo.
            _store[id] = entity;
            return Task.FromResult(entity);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return Task.FromResult(_store.TryRemove(id, out _));
        }

        public Task<IEnumerable<Trip>> GetAllAsync()
        {
            var items = _store.Values.OrderBy(t => t.Departure).AsEnumerable();
            return Task.FromResult(items);
        }

        public Task<Trip?> GetByIdAsync(Guid id)
        {
            _store.TryGetValue(id, out var item);
            return Task.FromResult(item);
        }

        public Task UpdateAsync(Trip entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (entity.Id == Guid.Empty) throw new ArgumentException("Entity must have an Id", nameof(entity));
            if (!_store.ContainsKey(entity.Id)) throw new KeyNotFoundException("Entity not found");
            _store[entity.Id] = entity;
            return Task.CompletedTask;
        }
    }
}