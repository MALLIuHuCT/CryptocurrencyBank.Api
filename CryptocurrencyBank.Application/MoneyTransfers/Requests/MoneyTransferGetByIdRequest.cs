using CryptocurrencyBank.Application.Abstractions.Request;
using CryptocurrencyBank.Domain.Entities;

namespace CryptocurrencyBank.Application.MoneyTransfers.Requests
{
    public class MoneyTransferGetByIdRequest : IRequest<MoneyTransfer>
    {
        public MoneyTransferGetByIdRequest() { }
        public MoneyTransferGetByIdRequest(Guid id)
            => Id = id;

        public Guid Id { get; set; }
    }
}
