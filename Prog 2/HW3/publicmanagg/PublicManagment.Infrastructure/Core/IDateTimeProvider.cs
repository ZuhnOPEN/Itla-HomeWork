using System;

namespace PublicManagment.Infrastructure.Core
{

    public interface IDateTimeProvider
    {
        DateTimeOffset UtcNow { get; }
        DateTimeOffset Now { get; }
    }
}