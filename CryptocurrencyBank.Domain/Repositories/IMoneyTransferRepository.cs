using CryptocurrencyBank.Domain.Core.Repositories;
using CryptocurrencyBank.Domain.Entities;
using CryptocurrencyBank.Domain.Enumerations;

namespace CryptocurrencyBank.Domain.Repositories
{
    public interface IMoneyTransferRepository : IGenericRepository<MoneyTransfer>
    {
        MoneyTransfer CreateNew(Guid from, Guid to, int transferValue, DateTime date, TransferType transferType, ClientType client, CancellationToken token);
    }
}
