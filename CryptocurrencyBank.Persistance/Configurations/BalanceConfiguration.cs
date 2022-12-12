using CryptocurrencyBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CryptocurrencyBank.Persistance.Configurations
{
    internal class BalanceConfiguration : IEntityTypeConfiguration<Balance>
    {
        public void Configure(EntityTypeBuilder<Balance> builder)
        {
            builder.HasKey(balance => balance.Id);
            builder.HasIndex(balance => balance.Id).IsUnique();
            builder.Property(balance => balance.Description).HasMaxLength(250);
        }
    }
}
