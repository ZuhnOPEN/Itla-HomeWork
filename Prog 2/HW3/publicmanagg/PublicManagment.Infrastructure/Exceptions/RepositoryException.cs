using System;

namespace PublicManagment.Infrastructure.Exceptions
{
    public class RepositoryException : InfrastructureException
    {
        public RepositoryException() { }
        public RepositoryException(string message) : base(message) { }
        public RepositoryException(string message, Exception inner) : base(message, inner) { }
    }
}