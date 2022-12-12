using CryptocurrencyBank.Domain.Entities;

namespace CryptocurrencyBank.Domain.Test
{
    public class MoneyTransferEntityTests
    {
        [Fact]
        public void Create_MustThrowingException_WhenGuidsFromAndToIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => MoneyTransfer.Create(Guid.Empty, Guid.Empty, 0, DateTime.Today, 0, 0));
            Assert.Throws<ArgumentException>(() => MoneyTransfer.Create(Guid.NewGuid(), Guid.Empty, 0, DateTime.Today, 0, 0));
            Assert.Throws<ArgumentException>(() => MoneyTransfer.Create(Guid.Empty, Guid.NewGuid(), 0, DateTime.Today, 0, 0));
        }

        [Fact]
        public void Create_MustThrowingException_WhenTransferValueLessThanZero()
        {
            var transferValue = -100;

            Assert.Throws<ArgumentException>(() => MoneyTransfer.Create(Guid.Empty, Guid.Empty, transferValue, DateTime.Today, 0, 0));
        }

        [Fact]
        public void ChangeData_MustThrowException_WhenGuidsFromAndToIsEmpty()
        {
            var moneyTransfer = MoneyTransfer.Create(Guid.NewGuid(), Guid.NewGuid(), 0, DateTime.Today, 0, 0);

            Assert.Throws<ArgumentException>(() => moneyTransfer.ChangeData(Guid.Empty, Guid.Empty, 0, moneyTransfer.Date, 0, 0));
            Assert.Throws<ArgumentException>(() => moneyTransfer.ChangeData(moneyTransfer.From, Guid.Empty, 0, moneyTransfer.Date, 0, 0));
            Assert.Throws<ArgumentException>(() => moneyTransfer.ChangeData(Guid.Empty, moneyTransfer.To, 0, moneyTransfer.Date, 0, 0));
        }

        [Fact]
        public void ChangeData_MustThrowException_WhenTransferValueIsLessThanZero()
        {
            int newTransferValue = -100;
            var moneyTransfer = MoneyTransfer.Create(Guid.NewGuid(), Guid.NewGuid(), 0, DateTime.Today, 0, 0);

            Assert.Throws<ArgumentException>(() => moneyTransfer.ChangeData(
                moneyTransfer.From,
                moneyTransfer.To,
                newTransferValue,
                moneyTransfer.Date,
                moneyTransfer.TransferType,
                moneyTransfer.Client));
        }
    }
}