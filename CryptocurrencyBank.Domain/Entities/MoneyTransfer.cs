using CryptocurrencyBank.Domain.Core.Utility;
using CryptocurrencyBank.Domain.Enumerations;
using CryptocurrencyBank.Domain.Primitives;

namespace CryptocurrencyBank.Domain.Entities
{
    public sealed class MoneyTransfer : IEntity
    { 
        private MoneyTransfer() { }
        private MoneyTransfer(Guid from, Guid to, int transferValue, DateTime date, TransferType transferType, ClientType client)
            => (From, To, HowMany, Date, TransferType, Client) = (from, to, transferValue, date, transferType, client);

        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid From { get; private set; }
        public Guid To { get; private set; }
        public int HowMany { get; private set; }
        public DateTime Date { get; private set; }
        public TransferType TransferType { get; private set; }
        public ClientType Client { get; private set; }

        public void ChangeData(Guid from, Guid to, int transferValue, DateTime date, TransferType transferType, ClientType client)
        {
            Ensure.NotEmpty(from, "a write-off account is required", nameof(from));
            Ensure.NotEmpty(to, "the accrual account is required", nameof(to));
            Ensure.NotLessZero(transferValue, "the amount of funds transferred must exceed zero", nameof(transferValue));

            (From, To, HowMany, Date, TransferType, Client) = (from, to, transferValue, date, transferType, client);
        }

        public static MoneyTransfer Create(Guid from, Guid to, int transferValue, DateTime date, TransferType transferType, ClientType client)
        {
            Ensure.NotEmpty(from, "a write-off account is required", nameof(from));
            Ensure.NotEmpty(to, "the accrual account is required", nameof(to));
            Ensure.NotLessZero(transferValue, "the amount of funds transferred must exceed zero", nameof(transferValue));

            return new MoneyTransfer(from, to, transferValue, date, transferType, client);
        }
    }

}