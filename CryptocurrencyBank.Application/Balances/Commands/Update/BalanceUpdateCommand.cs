using CryptocurrencyBank.Application.Abstractions.Commands;

namespace CryptocurrencyBank.Application.Balances.Commands.Update
{
    public class BalanceUpdateCommand : ICommand
    {
        public BalanceUpdateCommand() { }

        public BalanceUpdateCommand(Guid id, string? newDescription)
            => (Id, Description) = (id, newDescription);

        public Guid Id { get; set; }
        public string? Description { get; set; }
    }
}
