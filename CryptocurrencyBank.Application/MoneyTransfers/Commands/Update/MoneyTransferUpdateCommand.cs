using CryptocurrencyBank.Application.Abstractions.Commands;
using CryptocurrencyBank.Domain.Enumerations;

namespace CryptocurrencyBank.Application.MoneyTransfers.Update
{
    public sealed class MoneyTransferUpdateCommand : ICommand
    {
        public MoneyTransferUpdateCommand() { }
        public MoneyTransferUpdateCommand(Guid transferId,
            Guid from, 
            Guid to, 
            int transferValue, 
            DateTime date, 
            TransferType transferType, 
            ClientType client)
        {
            (Id, From, To, HowMany, Date, TransferType, Client) = (transferId, from, to, transferValue, date, transferType, client);
        }

        public Guid Id { get; set; }
        public Guid From { get; set; }
        public Guid To { get; set; }
        public int HowMany { get; set; }
        public DateTime Date { get; set; }
        public TransferType TransferType { get; set; }
        public ClientType Client { get; set; }
    }
}