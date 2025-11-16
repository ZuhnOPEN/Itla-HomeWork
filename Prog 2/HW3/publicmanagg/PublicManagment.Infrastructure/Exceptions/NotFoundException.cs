using System;

namespace PublicManagment.Infrastructure.Exceptions
{
    public class NotFoundException : RepositoryException
    {
        public string? ResourceName { get; }
        public object? Key { get; }

        public NotFoundException() { }

        public NotFoundException(string message) : base(message) { }

        public NotFoundException(string resourceName, object key)
            : base($"{resourceName} with key '{key}' was not found.")
        {
            ResourceName = resourceName;
            Key = key;
        }

        public NotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}