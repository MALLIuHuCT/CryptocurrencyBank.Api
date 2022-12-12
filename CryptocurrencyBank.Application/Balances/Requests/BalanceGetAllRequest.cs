using CryptocurrencyBank.Application.Abstractions.Request;
using CryptocurrencyBank.Domain.Entities;

namespace CryptocurrencyBank.Application.Balances.Requests
{
    public sealed class BalanceGetAllRequest : IRequest<IEnumerable<Balance>>
    {
        public BalanceGetAllRequest() { }
    }
}