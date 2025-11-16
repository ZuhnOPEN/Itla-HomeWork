using System.Threading;
using System.Threading.Tasks;

namespace PublicManagment.Infrastructure.Core
{

    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}