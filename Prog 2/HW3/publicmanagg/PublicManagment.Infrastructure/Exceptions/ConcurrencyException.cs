using System;

namespace PublicManagment.Infrastructure.Exceptions
{
    public class ConcurrencyException : RepositoryException
    {
        public ConcurrencyException() { }
        public ConcurrencyException(string message) : base(message) { }
        public ConcurrencyException(string message, Exception inner) : base(message, inner) { }
    }
}