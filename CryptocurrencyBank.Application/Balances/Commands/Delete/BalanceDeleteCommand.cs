using CryptocurrencyBank.Application.Abstractions.Commands;

namespace CryptocurrencyBank.Application.Balances.Commands.Delete
{
    public class BalanceDeleteCommand : ICommand
    {
        public BalanceDeleteCommand() { }

        public BalanceDeleteCommand(Guid id)
            => Id = id;

        public Guid Id { get; set; }
    }
}
