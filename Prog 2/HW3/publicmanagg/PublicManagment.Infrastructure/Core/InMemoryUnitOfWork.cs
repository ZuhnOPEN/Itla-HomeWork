using System.Threading;
using System.Threading.Tasks;

namespace PublicManagment.Infrastructure.Core
{

    public class InMemoryUnitOfWork : IUnitOfWork
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => Task.FromResult(0);
    }
}