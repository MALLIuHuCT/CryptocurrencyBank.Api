using CryptocurrencyBank.Application.Abstractions.DBContext;
using CryptocurrencyBank.Domain.Entities;
using CryptocurrencyBank.Domain.Repositories;

namespace CryptocurrencyBank.Persistance.Repositories
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly IDBContext _dBContext;

        public BalanceRepository(IDBContext dBContext)
            => _dBContext = dBContext;

        public Balance CreateNew(int balanceValue, string? description, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return Balance.Create(balanceValue, description);
        }

        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            var balance = await _dBContext.Balances.FindAsync(id, token) ?? throw new Exception("balance not founded");
            _dBContext.Balances.Remove(balance);
            await _dBContext.SaveAsync();
        }

        public async Task<IEnumerable<Balance>> GetAllAsync(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return await Task.Run(() => _dBContext.Balances.ToList());
        }

        public async Task<Balance> GetByIdAsync(Guid id, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return await _dBContext.Balances.FindAsync(id) ?? throw new Exception("balance not founded");
        }

        public async Task Insert(Balance item, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            if (item is null)
                throw new Exception("transfer is null");

            await _dBContext.Balances.AddAsync(item, token);
            await _dBContext.SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _dBContext.SaveAsync();
        }
    }
}
