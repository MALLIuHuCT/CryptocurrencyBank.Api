using CryptocurrencyBank.Domain.Entities;
using CryptocurrencyBank.Domain.Primitives;

namespace CryptocurrencyBank.Domain.Core.Repositories
{
    public interface IGenericRepository<T>
        where T : IEntity
    {
        Task<T> GetByIdAsync(Guid id, CancellationToken token);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken token);
        Task DeleteAsync(Guid id, CancellationToken token);
        Task Insert(T item, CancellationToken token);
        Task SaveAsync();
    }
}
