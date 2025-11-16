using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tierdwebapp.Models;

namespace tierdwebapp.Repositories
{
    public class InMemoryTodoRepository : ITodoRepository
    {
        private readonly ConcurrentDictionary<Guid, TodoItem> _store = new();

        public Task<TodoItem> CreateAsync(TodoItem item)
        {
            if (item.Id == Guid.Empty) item.Id = Guid.NewGuid();
            item.CreatedAt = DateTimeOffset.UtcNow;
            _store[item.Id] = item;
            return Task.FromResult(item);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return Task.FromResult(_store.TryRemove(id, out _));
        }

        public Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            var items = _store.Values.OrderBy(x => x.CreatedAt).AsEnumerable();
            return Task.FromResult(items);
        }

        public Task<TodoItem?> GetAsync(Guid id)
        {
            _store.TryGetValue(id, out var item);
            return Task.FromResult(item);
        }

        public Task<bool> UpdateAsync(TodoItem item)
        {
            if (item.Id == Guid.Empty) return Task.FromResult(false);
            if (!_store.ContainsKey(item.Id)) return Task.FromResult(false);
            _store[item.Id] = item;
            return Task.FromResult(true);
        }
    }
}