using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PublicManagment.Domain.Common;

namespace PublicManagment.Domain.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
    }
}