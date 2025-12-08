using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FinalHW2.Infrastructure.Core
{
    /// <summary>
    /// Repositorio base en memoria con operaciones CRUD asíncronas.
    /// Requiere que la entidad tenga una propiedad pública llamada "Id" de tipo int.
    /// </summary>
    public class BaseRepository<T> where T : class, new()
    {
        protected readonly List<T> _items = new();
        private readonly object _lock = new();
        private readonly PropertyInfo _idProp;

        public BaseRepository()
        {
            _idProp = typeof(T).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance)
                ?? throw new InvalidOperationException($"El tipo {typeof(T).FullName} debe exponer una propiedad pública llamada 'Id' de tipo int.");
        }

        private int GetEntityId(T entity)
        {
            var val = _idProp.GetValue(entity);
            return val is int i ? i : throw new InvalidOperationException("La propiedad 'Id' debe ser de tipo int.");
        }

        private void SetEntityId(T entity, int id)
        {
            _idProp.SetValue(entity, id);
        }

        public virtual Task<IEnumerable<T>> GetAllAsync()
        {
            lock (_lock)
            {
                // Devolver una copia para evitar modificaciones externas
                var copy = _items.Select(x => x).ToList().AsEnumerable();
                return Task.FromResult(copy);
            }
        }

        public virtual Task<T?> GetByIdAsync(int id)
        {
            lock (_lock)
            {
                var found = _items.FirstOrDefault(item => GetEntityId(item) == id);
                return Task.FromResult(found);
            }
        }

        public virtual Task AddAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            lock (_lock)
            {
                // Generar Id incremental si el Id actual es 0
                var currentId = GetEntityId(entity);
                if (currentId <= 0)
                {
                    var maxId = _items.Count == 0 ? 0 : _items.Max(i => GetEntityId(i));
                    SetEntityId(entity, maxId + 1);
                }
                else
                {
                    // Evitar duplicados
                    if (_items.Any(i => GetEntityId(i) == currentId))
                        throw new InvalidOperationException($"Ya existe una entidad con Id = {currentId}.");
                }

                _items.Add(entity);
            }

            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            lock (_lock)
            {
                var id = GetEntityId(entity);
                var index = _items.FindIndex(i => GetEntityId(i) == id);
                if (index == -1) throw new KeyNotFoundException($"No se encontró la entidad con Id = {id}.");

                _items[index] = entity;
            }

            return Task.CompletedTask;
        }

        public virtual Task DeleteAsync(int id)
        {
            lock (_lock)
            {
                var index = _items.FindIndex(i => GetEntityId(i) == id);
                if (index == -1) throw new KeyNotFoundException($"No se encontró la entidad con Id = {id}.");

                _items.RemoveAt(index);
            }

            return Task.CompletedTask;
        }
    }
}
