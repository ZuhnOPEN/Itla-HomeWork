using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tierdwebapp.Models;

namespace tierdwebapp.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<TodoItem?> GetAsync(Guid id);
        Task<TodoItem> CreateAsync(TodoItem item);
        Task<bool> UpdateAsync(TodoItem item);
        Task<bool> DeleteAsync(Guid id);
    }
}