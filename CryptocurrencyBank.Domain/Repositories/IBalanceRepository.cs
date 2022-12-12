using CryptocurrencyBank.Domain.Core.Repositories;
using CryptocurrencyBank.Domain.Entities;

namespace CryptocurrencyBank.Domain.Repositories
{
    public interface IBalanceRepository : IGenericRepository<Balance>
    {
        Balance CreateNew(int balanceValue, string? description, CancellationToken token);
    }
}
