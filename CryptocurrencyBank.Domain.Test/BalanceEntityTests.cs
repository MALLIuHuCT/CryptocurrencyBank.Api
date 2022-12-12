using CryptocurrencyBank.Domain.Entities;

namespace CryptocurrencyBank.Domain.Test
{
    public class BalanceEntityTests
    {
        [Fact]
        public void Create_MustThrowException_WhenBalanceValueLessThanZero()
        {
            int balanceValue = -100;

            Assert.Throws<ArgumentException>(() => Balance.Create(balanceValue, null));
        }

        [Fact]
        public void Add_ShouldExecuteCorrectly()
        {
            int addingValue = 100;
            int expected = 100;

            var balance = Balance.Create(0, null);
            balance.Add(addingValue);
            Assert.Equal(expected, balance.Value);
        }

        [Fact]
        public void Substract_ShouldExecuteCorrectly() 
        { 
            int substractingValue = 100;
            int expected = -100;

            var balance = Balance.Create(0, null);
            balance.Subtract(substractingValue);
            Assert.Equal(expected, balance.Value);
        }

        [Fact]
        public void DescriptionChange_MustChangeDescription()
        {
            string newDescription = "new description";

            var balance = Balance.Create(0, null);
            balance.ChangeDescription(newDescription);

            Assert.Equal(newDescription, balance.Description);
        }
    }
}
