using System;

namespace PublicManagment.Infrastructure.Core
{
    public interface IGuidProvider
    {
        Guid NewGuid();
    }
}