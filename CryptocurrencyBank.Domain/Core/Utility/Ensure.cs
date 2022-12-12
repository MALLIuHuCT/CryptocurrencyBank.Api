namespace CryptocurrencyBank.Domain.Core.Utility
{
    internal static class Ensure
    {
        public static void NotLessZero(int value, string message, string valueName)
        {
            if(value < 0)
                throw new ArgumentException(message, valueName);
        }

        public static void NotEmpty(Guid value, string message, string argumentName)
        {
            if (value == Guid.Empty)
                throw new ArgumentException(message, argumentName);
        }
    }
}
