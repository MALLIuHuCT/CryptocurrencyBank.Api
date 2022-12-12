using CryptocurrencyBank.Application.Abstractions.Request;
using CryptocurrencyBank.Domain.Entities;

namespace CryptocurrencyBank.Application.MoneyTransfers.Requests
{
    public class MoneyTransferGetAllRequest : IRequest<IEnumerable<MoneyTransfer>>
    {
        public MoneyTransferGetAllRequest() { }
    }
}
