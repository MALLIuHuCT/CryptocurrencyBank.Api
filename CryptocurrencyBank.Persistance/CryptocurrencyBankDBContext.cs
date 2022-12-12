using CryptocurrencyBank.Application.Abstractions.DBContext;
using CryptocurrencyBank.Domain.Entities;
using CryptocurrencyBank.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyBank.Persistance
{
    public class CryptocurrencyBankDBContext : DbContext, IDBContext
    {
        public CryptocurrencyBankDBContext(DbContextOptions<CryptocurrencyBankDBContext> options)
            : base(options) { }

        public DbSet<Balance> Balances { get; set; }
        public DbSet<MoneyTransfer> MoneyTransfers { get; set; }

        public async Task SaveAsync()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BalanceConfiguration());
            modelBuilder.ApplyConfiguration(new MoneyTransferConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
