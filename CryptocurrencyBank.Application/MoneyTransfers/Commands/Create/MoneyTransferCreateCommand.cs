using CryptocurrencyBank.Application.Abstractions.Commands;
using CryptocurrencyBank.Domain.Enumerations;

namespace CryptocurrencyBank.Application.MoneyTransfers.Create
{
    public sealed class MoneyTransferCreateCommand : ICommand
    {
        public MoneyTransferCreateCommand() { }
        public MoneyTransferCreateCommand(Guid from, 
            Guid to, 
            int amountOfMoney, 
            DateTime transferDate, 
            TransferType transferType, 
            ClientType client)
        {
            (From, To, HowMany, Date, TransferType, Client) = (from, to, amountOfMoney, transferDate, transferType, client);
        }

        public Guid From { get; set; }
        public Guid To { get; set; }
        public int HowMany { get; set; }
        public DateTime Date { get; set; }
        public TransferType TransferType { get; set; }
        public ClientType Client { get; set; }
    }
}