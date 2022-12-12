using CryptocurrencyBank.Application.Abstractions.Request;
using CryptocurrencyBank.Domain.Entities;

namespace CryptocurrencyBank.Application.Balances.Requests
{
    public sealed class BalanceGetByIdRequest : IRequest<Balance>
    {
        public BalanceGetByIdRequest() { }
        public BalanceGetByIdRequest(Guid id)
            => Id = id;

        public Guid Id { get; set; }
    }
}