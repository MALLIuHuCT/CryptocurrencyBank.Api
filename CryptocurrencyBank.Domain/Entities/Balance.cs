using CryptocurrencyBank.Domain.Primitives;

namespace CryptocurrencyBank.Domain.Entities
{
    public sealed class Balance : IEntity
    {
        private Balance() { }
        public static Balance Create(int value, string? descrpiption)
        {
            if(value < 0)
                throw new ArgumentException("Balance must be greater than or equal to zero", "Balance");

            return new Balance() { Value = value, Description = descrpiption };
        }

        public string? Description { get; private set; }
        public Guid Id { get; init; } = Guid.NewGuid();
        public int Value { get; private set; }

        public void ChangeDescription(string? description)
            => Description = description;

        public void Add(int value)
            => Value += value;

        public void Subtract(int value)
            => Value-= value;
    }

}