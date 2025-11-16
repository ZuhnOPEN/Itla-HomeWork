using System;

namespace PublicManagment.Infrastructure.Core
{
    public class GuidProvider : IGuidProvider
    {
        public Guid NewGuid() => Guid.NewGuid();
    }
}