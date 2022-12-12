using CryptocurrencyBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CryptocurrencyBank.Persistance.Configurations
{
    internal class MoneyTransferConfiguration : IEntityTypeConfiguration<MoneyTransfer>
    {
        public void Configure(EntityTypeBuilder<MoneyTransfer> builder)
        {
            builder.HasKey(moneyTransfer => moneyTransfer.Id);
            builder.HasIndex(moneyTransfer => moneyTransfer.Id).IsUnique();

            builder.HasOne<Balance>()
                .WithMany()
                .HasForeignKey(moneyTransfer => moneyTransfer.From);

            builder.HasOne<Balance>()
                .WithMany()
                .HasForeignKey(moneyTransfer => moneyTransfer.To);
        }
    }
}
