using CryptocurrencyBank.Application.Abstractions.Commands;

namespace CryptocurrencyBank.Application.Balances.Commands
{
    public class BalanceCreateCommand : ICommand
    {
        public BalanceCreateCommand() { }
        public BalanceCreateCommand(int balanceValue, string? description)
            => (BalanceValue, Description) = (balanceValue, description);

        public int BalanceValue { get; set; }
        public string? Description { get; set; }
    }
}