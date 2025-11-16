using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PublicManagment.Domain.Entities;
using PublicManagment.Domain.Repositories;

namespace PublicManagment.Infrastructure.Repositories
{
    public class InMemoryVehicleRepository : IVehicleRepository
    {
        private readonly ConcurrentDictionary<Guid, Vehicle> _store = new();

        public Task<Vehicle> AddAsync(Vehicle entity)
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

        public Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            var items = _store.Values.OrderBy(v => v.Registration).AsEnumerable();
            return Task.FromResult(items);
        }

        public Task<Vehicle?> GetByIdAsync(Guid id)
        {
            _store.TryGetValue(id, out var item);
            return Task.FromResult(item);
        }

        public Task UpdateAsync(Vehicle entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (entity.Id == Guid.Empty) throw new ArgumentException("Entity must have an Id", nameof(entity));
            if (!_store.ContainsKey(entity.Id)) throw new KeyNotFoundException("Entity not found");
            _store[entity.Id] = entity;
            return Task.CompletedTask;
        }
    }
}