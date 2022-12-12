using CryptocurrencyBank.Application.Abstractions.DBContext;
using CryptocurrencyBank.Domain.Entities;
using CryptocurrencyBank.Domain.Enumerations;
using CryptocurrencyBank.Domain.Repositories;

namespace CryptocurrencyBank.Persistance.Repositories
{
    public class MoneyTransferReposiroty : IMoneyTransferRepository
    {
        private readonly IDBContext _dBContext;

        public MoneyTransferReposiroty(IDBContext dBContext)
            => _dBContext = dBContext;

        public MoneyTransfer CreateNew(Guid from, Guid to, int transferValue, DateTime date, TransferType transferType, ClientType client, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return MoneyTransfer.Create(from, to, transferValue, date, transferType, client);
        }

        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            var item = await _dBContext.MoneyTransfers.FindAsync(id) ?? throw new Exception("transfer not founded");
            _dBContext.MoneyTransfers.Remove(item);
            await _dBContext.SaveAsync();
        }

        public async Task<IEnumerable<MoneyTransfer>> GetAllAsync(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return await Task.Run(() => _dBContext.MoneyTransfers.ToList());
        }

        public async Task<MoneyTransfer> GetByIdAsync(Guid id, CancellationToken token)
        {
            return await _dBContext.MoneyTransfers.FindAsync(id, token) ?? throw new Exception("transfer not founded");
        }

        public async Task Insert(MoneyTransfer item, CancellationToken token)
        {
            if(item is null)
                throw new Exception("transfer is null");

            await _dBContext.MoneyTransfers.AddAsync(item, token);
            await _dBContext.SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _dBContext.SaveAsync();
        }
    }
}
