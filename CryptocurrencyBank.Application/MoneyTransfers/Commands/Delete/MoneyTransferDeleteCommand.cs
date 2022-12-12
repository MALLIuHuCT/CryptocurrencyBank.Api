using CryptocurrencyBank.Application.Abstractions.Commands;

namespace CryptocurrencyBank.Application.MoneyTransfers.Delete
{
    public sealed class MoneyTransferDeleteCommand : ICommand
    {
        public MoneyTransferDeleteCommand() { }
        public MoneyTransferDeleteCommand(Guid id)
            => Id = id;

        public Guid Id { get; set; }
    }
}