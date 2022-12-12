using CryptocurrencyBank.Application.Abstractions.Request;
using CryptocurrencyBank.Domain.Entities;

namespace CryptocurrencyBank.Application.MoneyTransfers.Requests
{
    public class MoneyTransferGetAllByDateRequest : IRequest<IEnumerable<MoneyTransfer>>
    {
        public MoneyTransferGetAllByDateRequest() { }
        public MoneyTransferGetAllByDateRequest(DateTime date)
            => Date = date;

        public DateTime Date { get; set; }
    }
}
